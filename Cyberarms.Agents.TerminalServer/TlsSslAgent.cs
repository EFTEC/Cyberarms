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
using System.Drawing;

namespace Cyberarms.Agents.TerminalServer {
    public class TlsSslAgent:Cyberarms.IntrusionDetection.Api.Plugin.AgentPlugin, IExtendedInformation {
        public event EventHandler Trace;
        public bool Tracing { get; set; }
        ThreadStart ts;
        Thread td;
        
        List<Sniffer> sniffers = new List<Sniffer>();

        public TlsSslAgent() {
            this.Configuration.AgentSettings = new TslSslConfig();
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
            s.TcpPort = ((TslSslConfig)Configuration.AgentSettings).RdpPort;
            System.Diagnostics.EventLog.WriteEntry("Cyberarms.Agents.TlsSslAgent", String.Format("Remote Desktop Security Agent is listening on port {0}", s.TcpPort));
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
                        if (sourcePort == ((TslSslConfig)Configuration.AgentSettings).RdpPort) {
                            if (Tracing) {
                                OnTrace((IPHeader)sender);
                            }
                            if (tcp.Data.Length > 0) {
                                AppLayerTlsSsl tls = new AppLayerTlsSsl(tcp.Data, tcp.Data.Length);
                                if (tls.TlsHeader.MinorVersion >= 1 && tls.TlsHeader.MinorVersion < 10 && tls.TlsHeader.MajorVersion >= 1 && tls.TlsHeader.MajorVersion < 10) {       // check if packet is tls/ssl
                                    if (tls.TlsHeader.ContentType == AppLayerTlsSsl.CONTENT_TYPE_ENCRYPTED_ALERT) {
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
            args.EventMessage = "Remote desktop connection TLS/SSL authentication failure";
            args.IpAddress = ipAddress;
            OnAttackDetected(this, args);
        }


        public string DisplayName {
            get {
                return "TLS/SSL Security Agent";
            }
            set {

            }
        }

        public Image Icon {
            get {
                return global::Cyberarms.Agents.TerminalServer.Resource.agent15px_rdp_dark;
            }
            set {

            }
        }

        public Image SelectedIcon {
            get {
                return global::Cyberarms.Agents.TerminalServer.Resource.agent15px_rdp_white;
            }
            set {

            }
        }

        public Image UnselectedIcon {
            get {
                return global::Cyberarms.Agents.TerminalServer.Resource.agent15px_rdp_dark;
            }
            set {

            }
        }


        public Guid Id {
            get {
                return new Guid("{A682433B-852F-4150-ADF4-FB7F75090015}");
            }
        }
    }
}
