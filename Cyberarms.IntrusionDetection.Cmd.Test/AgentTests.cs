using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace CyberarmsPaladinCmd.Test {
    [TestClass]
    public class AgentTests {
        [TestMethod]
        public void TestResolveIP() {
            string[] result = ResolveIp("isicos01");
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("192.168.1.102", result[0]);
        }


        private string[] ResolveIp(string hostname) {
            List<string> result = new List<string>();
            IPAddress[] addr = System.Net.Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in addr) {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) {
                    result.Add(ip.ToString());
                }
            }
            return result.ToArray();
        }

    }
}
