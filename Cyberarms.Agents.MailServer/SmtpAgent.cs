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
    public class SmtpAgent : Cyberarms.IntrusionDetection.Api.Plugin.AgentPlugin {
        public event EventHandler Trace;
        public bool Tracing { get; set; }
        ThreadStart ts;
        Thread td;

        List<Sniffer> sniffers = new List<Sniffer>();

        public SmtpAgent() {
            this.Configuration.AgentSettings = new SmtpConfig();
            Configuration.ConfigurationSettingsTypeName =
                this.Configuration.AgentSettings.GetType().FullName;
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
            // s.IpPacketReceived += new EventHandler(s_IpPacketReceived);
            s.IpPacketSent += new EventHandler(s_IpPacketSent);
            s.TcpPort = ((SmtpConfig)Configuration.AgentSettings).SmtpPort;
            System.Diagnostics.EventLog.WriteEntry("Cyberarms.Agents.SmtpServer", String.Format("Smtp Server Security Agent is listening on port {0}", s.TcpPort));
            s.WatchAddress((IPAddress)ipAddress);
            sniffers.Add(s);
        }

        void s_IpPacketSent(object sender, EventArgs e) {
            IPHeader ipHeader = (IPHeader)sender;
            if (ipHeader.ProtocolType == Protocol.Tcp) {
                try {
                    TCPHeader tcp = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);
                    int sourcePort;
                    if (int.TryParse(tcp.SourcePort, out sourcePort)) {
                        if (sourcePort == ((SmtpConfig)Configuration.AgentSettings).SmtpPort) {
                            if (Tracing) {
                                OnTrace((IPHeader)sender);
                            }
                            if (tcp.Data.Length > 0) {
                                AppLayerSmtp ftp = new AppLayerSmtp(tcp.Data, tcp.Data.Length);
                                if (ftp.SmtpReplyCode == AppLayerSmtp.SMTP_REPLY_CODE_LOGIN_DENIED) {
                                    UnsuccessfulLogin(ipHeader.DestinationAddress.ToString());
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
            args.EventMessage = "SMTP authentication failure";
            args.IpAddress = ipAddress;
            OnAttackDetected(this, args);
        }

        public Guid Id {
            get {
                return new Guid("{EB69BF23-939C-4F89-97D0-50274306D018}");
            }
        }

    }
}
