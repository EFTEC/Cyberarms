using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Shared;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Cyberarms.IntrusionDetection {
    public class NetworkMonitor {
        ThreadStart ts;
        Thread td;

        private NetworkMonitor() {
        }

        private static NetworkMonitor _instance;
        public static NetworkMonitor Instance {
            get {
                if (_instance == null) {
                    _instance = new NetworkMonitor();
                }
                return _instance;
            }
            set {
                _instance = new NetworkMonitor();
            }
        }


        protected void StartNetworkSniffer() {
            ts = new ThreadStart(RunWatcher);
            td = new Thread(ts);
            td.Start();
        }

        void RunWatcher() {
            IPHostEntry hostEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (hostEntry.AddressList.Length > 0) {
                foreach (IPAddress ip in hostEntry.AddressList) {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                        Sniffer s = new Sniffer();
                        foreach (TcpSnifferPort port in this.TcpSnifferPorts) {
                            if (port.IPAddress==null || (port.IPAddress !=null && port.IPAddress.Equals(ip))) {
                                if (port.HandlesReceived) {
                                    s.IpPacketReceived += port.Received;
                                }
                                if (port.HandlesSent) {
                                    s.IpPacketSent += port.Sent;
                                } 
                            }
                        }
                        ParameterizedThreadStart pts = new ParameterizedThreadStart(s.WatchAddress);
                        pts.Invoke(ip);
                    }
                }
            }
        }

        void s_IpPacketReceived(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        public void AddSnifferAddressPort(IPAddress address, int port, bool handlesReceived, bool handlesSent, EventHandler received, EventHandler sent) {
            this.TcpSnifferPorts.Add(new TcpSnifferPort(address, port, handlesReceived, handlesSent, received, sent));
        }

        private List<TcpSnifferPort> _tcpSnifferPorts;
        private List<TcpSnifferPort> TcpSnifferPorts {
            get {
                if (_tcpSnifferPorts == null) {
                    _tcpSnifferPorts = new List<TcpSnifferPort>();
                }
                return _tcpSnifferPorts;
            }
            set {
                _tcpSnifferPorts = value;
            }
        }

        private class TcpSnifferPort {
            public TcpSnifferPort(IPAddress ipaddress, int port, bool handlesReceived, bool handlesSent, EventHandler received, EventHandler sent) {
                this.IPAddress = ipaddress;
                this.Port = port;
                this.HandlesReceived = handlesReceived;
                this.HandlesSent = handlesSent;
                Received = received;
                Sent = sent;
            }
            public IPAddress IPAddress;
            public int Port;
            public bool HandlesReceived;
            public bool HandlesSent;
            public EventHandler Received;
            public EventHandler Sent;
        }

    }
}
