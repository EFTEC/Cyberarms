using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection {
    public class Sniffer {

        private Socket ipSocket;
        byte[] byteData;

        public event EventHandler IpPacketReceived;
        public event EventHandler IpPacketSent;
        public event EventHandler TcpPacketReceived;
        public event EventHandler TcpPacketSent;


        private bool isPaused = false;

        public void Pause() {
            isPaused = true;
        }

        public void Continue() {
            isPaused = false;
        }

        
        public IPAddress IPAddress { get; set; }

        public void WatchAddress(object ipAddressToMonitor) {
            try {
                byteData = new byte[128];
                IPAddress = (IPAddress)ipAddressToMonitor;
                ipSocket = new Socket(IPAddress.AddressFamily,
                    SocketType.Raw, ProtocolType.IP);
                ipSocket.ExclusiveAddressUse = false;
                ipSocket.Bind(new IPEndPoint(IPAddress, 0));
                ipSocket.SetSocketOption(SocketOptionLevel.IP,
                    SocketOptionName.HeaderIncluded,
                    true);
                byte[] byTrue = new byte[4] { 3, 0, 0, 0 };
                byte[] byOut = new byte[4] { 3, 0, 0, 0 };  // capture outgoing packets
                ipSocket.IOControl(IOControlCode.ReceiveAll,
                    byTrue, byOut); 
                
                ipSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                    new AsyncCallback(OnReceive), null);
            } catch (Exception ex) {
                LogTrace(ex);
            }

        }

        private void OnReceive(IAsyncResult ar) {
            if (!isPaused) {
                try {
                    int length = ipSocket.EndReceive(ar);
                    byte[] packet = new byte[length];
                    Array.Copy(byteData, 0, packet, 0, length);
                    IPHeader ipHeader = new IPHeader(packet, length);
                    if (ipHeader.SourceAddress.Equals(IPAddress)) OnPacketSent(ipHeader);
                    if (ipHeader.DestinationAddress.Equals(IPAddress)) OnPacketReceived(ipHeader);
                } catch (Exception ex) {
                    Sniffer.LogTrace(ex);
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
            TCPHeader tcpHeader = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);
            if (TcpPacketSent != null) {
                TcpPacketSent(tcpHeader, EventArgs.Empty);
            }
        }

        private void OnPacketReceived(IPHeader ipHeader) {
            if (IpPacketReceived != null) {
                IpPacketReceived(ipHeader, EventArgs.Empty);
            }
            TCPHeader tcpHeader = new TCPHeader(ipHeader.Data, ipHeader.MessageLength);
            if (TcpPacketReceived != null) {
                TcpPacketReceived(tcpHeader, EventArgs.Empty);
            }
        }


        public void CloseSocket() {
            ipSocket.Close();
        }

        public static void LogTrace(Exception ex) {
            System.IO.StreamWriter sw = null;
            try {
                sw = System.IO.File.AppendText(System.IO.Path.GetTempPath() + "\\Cyberarms.IntrusionDetection.Sniffer.ErrorLog.txt");
                sw.WriteLine(String.Format("{0}\n{1}", ex.Message, ex.StackTrace));
                sw.Flush();
            } catch { } finally {
                if(sw!=null) sw.Close();
            }
        }

    }
}


