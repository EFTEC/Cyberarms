using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;


namespace Cyberarms.Agents.MailServer {
    public class Sniffer {
        private Socket ipSocket;
        byte[] byteData;

        public event EventHandler IpPacketReceived;
        public event EventHandler IpPacketSent;

        private bool aborted = false;

        public void Abort() {
            aborted = true;
        }

        public void Continue() {
            aborted = false;
        }

        public int? TcpPort { get; set; }

        public IPAddress IPAddress { get; set; }

        public void WatchAddress(object ipAddressToMonitor) {
            byteData = new byte[128];
            IPAddress = (IPAddress)ipAddressToMonitor;
            ipSocket = new Socket(IPAddress.AddressFamily,
                SocketType.Raw, ProtocolType.IP);
            ipSocket.ExclusiveAddressUse = false;
            ipSocket.Bind(new IPEndPoint(IPAddress, TcpPort.HasValue ? TcpPort.Value : 25));
            ipSocket.SetSocketOption(SocketOptionLevel.IP,
                SocketOptionName.HeaderIncluded,
                true);
            byte[] byTrue = new byte[4] { 3, 0, 0, 0 };
            byte[] byOut = new byte[4] { 1, 0, 0, 0 };  // capture outgoing packets
            ipSocket.IOControl(IOControlCode.ReceiveAll,
                byTrue, byOut);
            ipSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(OnReceive), null);

        }

        private void OnReceive(IAsyncResult ar) {
            if (!aborted) {
                try {
                    int length = ipSocket.EndReceive(ar);
                    //ParseData(byteData, nReceived);
                    IPHeader ipHeader = new IPHeader(byteData, length);
                    if (ipHeader.SourceAddress.Equals(IPAddress)) OnPacketSent(ipHeader);
                    if (ipHeader.DestinationAddress.Equals(IPAddress)) OnPacketReceived(ipHeader);
                    // OnPacketReceived(new NetworkPacket(byteData,length));

                    
                } catch (Exception ex) {
                    // Sniffer.LogTrace(ex);
                } finally {
                    byteData = new byte[128];          // set to 16276 bytes
                    // continue receiving
                    ipSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
            }
        }

        private void OnPacketSent(IPHeader ipHeader) {
            if (IpPacketSent != null) {
                IpPacketSent(ipHeader, EventArgs.Empty);
            }
        }

        private void OnPacketReceived(IPHeader ipHeader) {
            if (IpPacketReceived != null) {
                IpPacketReceived(ipHeader, EventArgs.Empty);
            }
        }


        public void CloseSocket() {
            ipSocket.Close();
        }

        public static void LogTrace(Exception ex) {
            System.IO.StreamWriter sw = null;
            try {
                sw = System.IO.File.AppendText(System.IO.Path.GetTempPath() + "\\Cyberarms.Agents.Smtp.ErrorLog.txt");
                sw.WriteLine(String.Format("{0}\n{1}", ex.Message, ex.StackTrace));
                sw.Flush();
            } catch { } finally {
                if(sw!=null) sw.Close();
            }
        }

    }
}


