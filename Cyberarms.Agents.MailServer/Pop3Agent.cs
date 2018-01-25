using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection;
using Cyberarms.IntrusionDetection.Api;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cyberarms.Agents.MailServer {
    public class Pop3Agent : Cyberarms.IntrusionDetection.Api.Plugin.AgentPlugin {
        public const int CLEANUP_INTERVAL_MINS = 2;
        public event EventHandler Trace;
        public bool Tracing { get; set; }
        public System.Timers.Timer cleanupTimer;
        ThreadStart ts;
        Thread td;

        List<Sniffer> sniffers = new List<Sniffer>();

        public Pop3Agent() {

            this.Configuration.AgentSettings = new Pop3Config();
            Configuration.ConfigurationSettingsTypeName =
                this.Configuration.AgentSettings.GetType().FullName;
            cleanupTimer = new System.Timers.Timer();
            cleanupTimer.Interval = 5000;
            cleanupTimer.Elapsed += new System.Timers.ElapsedEventHandler(cleanupTimer_Elapsed);
        }

        void cleanupTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            //for (int i = CurrentClients.Keys.Max(); i > 0; i--) {
            //    if (CurrentClients.ContainsKey(i) && CurrentClients[i].LastInteraction.AddMinutes(CLEANUP_INTERVAL_MINS) < DateTime.Now) CurrentClients.Remove(i);
            //}
            foreach (int key in CurrentClients.Keys) {
                if (CurrentClients[key].LastInteraction.AddMinutes(CLEANUP_INTERVAL_MINS) < DateTime.Now) CurrentClients.Remove(key);
            }
        }

        protected override void OnStartAgent() {
            ts = new ThreadStart(RunWatcher);
            td = new Thread(ts);
            td.Start();
            base.OnStartAgent();
        }

        void RunWatcher() {
            IPHostEntry hostEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (hostEntry.AddressList.Length > 0) {
                foreach (IPAddress ip in hostEntry.AddressList) {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                        ParameterizedThreadStart pts = new ParameterizedThreadStart(WatchAddress);
                        pts.Invoke(ip);
                    }
                }
            }
        }



        void WatchAddress(object ipAddress) {
            Sniffer s = new Sniffer();
            s.IpPacketReceived += new EventHandler(s_IpPacketReceived);
            s.IpPacketSent += new EventHandler(s_IpPacketSent);
            s.TcpPort = ((Pop3Config)Configuration.AgentSettings).Pop3Port;
            System.Diagnostics.EventLog.WriteEntry("Cyberarms.Agents.MailServer", String.Format("POP3 Server Security Agent is listening on port {0}", s.TcpPort));
            s.WatchAddress((IPAddress)ipAddress);
            sniffers.Add(s);
        }

        public void TestReceive(byte[] data) {
            IPHeader hdr = new IPHeader(data, data.Length);
            s_IpPacketReceived(hdr, EventArgs.Empty);
        }

        public void TestSend(byte[] data) {
            IPHeader hdr = new IPHeader(data, data.Length);
            s_IpPacketSent(hdr, EventArgs.Empty);
        }

        void s_IpPacketReceived(object sender, EventArgs e) {
            IPHeader ipHeader = (IPHeader)sender;
            if (ipHeader.ProtocolType == Protocol.Tcp) {
                try {
                    TCPHeader tcp = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);
                    int sourcePort;
                    int destinationPort;
                    if (int.TryParse(tcp.SourcePort, out sourcePort) && int.TryParse(tcp.DestinationPort, out destinationPort)) {
                        if (destinationPort == ((Pop3Config)Configuration.AgentSettings).Pop3Port) {
                            if (tcp.Data.Length > 0) {
                                AppLayerPop3 pop3 = new AppLayerPop3(tcp.Data, tcp.Data.Length);
                                if (!CurrentClients.ContainsKey(sourcePort)) CurrentClients.Add(sourcePort, new Pop3Client());
                                CurrentClients[sourcePort].LastInteraction = DateTime.Now;
                                switch (pop3.Pop3Code.ToUpper()) {
                                    case AppLayerPop3.POP3_INTERACTION_CODE_LIST:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.LIST;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_DELE:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.DELE;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_NOOP:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.NOOP;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_PASS:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.PASS;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_QUIT:
                                        if (CurrentClients.ContainsKey(sourcePort)) CurrentClients.Remove(sourcePort);
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_RETR:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.RETR;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_RSET:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.RSET;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_STAT:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.STAT;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_TOP:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.TOP;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_UIDL:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.UIDL;
                                        break;
                                    case AppLayerPop3.POP3_INTERACTION_CODE_USER:
                                        CurrentClients[sourcePort].LastMessage = Pop3Message.USER;
                                        break;
                                }
                            }
                            // Console.WriteLine("Flags: {0}\tAck: {1}\tSeq:{2}", tcp.Flags, tcp.AcknowledgementNumber, tcp.SequenceNumber);
                            // Console.WriteLine("Source: {0}:{1}\tDestination: {2}:{3}", ipHeader.SourceAddress, tcp.SourcePort, ipHeader.DestinationAddress, tcp.DestinationPort);
                        }
                    }
                } catch (Exception ex) {
                    Sniffer.LogTrace(ex);
                }

            }
        }

        void s_IpPacketSent(object sender, EventArgs e) {
            IPHeader ipHeader = (IPHeader)sender;
            if (ipHeader.ProtocolType == Protocol.Tcp) {
                try {
                    TCPHeader tcp = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);
                    int sourcePort;
                    int destinationPort;
                    if (int.TryParse(tcp.SourcePort, out sourcePort) && int.TryParse(tcp.DestinationPort, out destinationPort)) {
                        if (sourcePort == ((Pop3Config)Configuration.AgentSettings).Pop3Port) {
                            if (tcp.Data.Length > 0) {
                                AppLayerPop3 ftp = new AppLayerPop3(tcp.Data, tcp.Data.Length);
                                if (ftp.Pop3Code.ToUpper().Equals(AppLayerPop3.POP3_REPLY_CODE_ERROR.ToUpper())) {
                                    System.Threading.Thread.Sleep(100);
                                    if (CurrentClients.ContainsKey(destinationPort) && CurrentClients[destinationPort].LastMessage == Pop3Message.PASS) {
                                        if (Tracing) {
                                            OnTrace((IPHeader)sender);
                                        }
                                        UnsuccessfulLogin(ipHeader.DestinationAddress.ToString());
                                    }
                                }
                            }
                            // Console.WriteLine("Flags: {0}\tAck: {1}\tSeq:{2}", tcp.Flags, tcp.AcknowledgementNumber, tcp.SequenceNumber);
                            // Console.WriteLine("Source: {0}:{1}\tDestination: {2}:{3}", ipHeader.SourceAddress, tcp.SourcePort, ipHeader.DestinationAddress, tcp.DestinationPort);
                        }
                    }
                } catch (Exception ex) {
                    Sniffer.LogTrace(ex);
                }

            }
        }


        private Dictionary<int, Pop3Client> _currentClients;
        public Dictionary<int, Pop3Client> CurrentClients {
            get {
                if (_currentClients == null) {
                    _currentClients = new Dictionary<int, Pop3Client>();
                }
                return _currentClients;
            }
            set {
                _currentClients = value;
            }
        }

        private void OnTrace(IPHeader tlsPackage) {
            if (Trace != null) Trace(tlsPackage, EventArgs.Empty);
        }

        protected override void OnContinueAgent() {
            Start();
            base.OnContinueAgent();
        }

        protected override void OnPauseAgent() {
            Stop();
            base.OnPauseAgent();
        }

        protected override void OnStopAgent() {
            foreach (Sniffer s in sniffers) {
                s.Abort();
                s.CloseSocket();
            }
            sniffers.Clear();
            base.OnStopAgent();
        }

        public override bool IsRunning {
            get {
                return base.IsRunning;
            }
        }

        void UnsuccessfulLogin(string ipAddress) {
            NotificationEventArgs args = new NotificationEventArgs();
            args.CreateDate = DateTime.Now;
            args.EventId = 9112;
            args.EventMessage = "POP3 authentication failure";
            args.IpAddress = ipAddress;
            OnAttackDetected(this, args);
        }

        
        public Guid Id {
            get {
                return new Guid("{1F917251-2661-473A-970B-B2BB62EA6E1A}");
            }
        }

    }
}
