using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Cyberarms.IntrusionDetection.Shared;

namespace IdsServiceForWindowsTest {
    /// <summary>
    /// Summary description for LockTest
    /// </summary>
    [TestClass]
    public class LockTest {
        public LockTest() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        

        [TestMethod]
        public void TestIpAddressLocal() {
            
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Assert.IsTrue(IddsConfig.Instance.IsIpAddressLocal(ip));
            foreach (IPAddress address in getLocalIps()) {
                Assert.IsTrue(IddsConfig.Instance.IsIpAddressLocal(address));
                System.Diagnostics.Debug.Print(address.ToString());
            }
            Assert.IsFalse(IddsConfig.Instance.IsIpAddressLocal(IPAddress.Parse("10.1.1.1")));
            Assert.IsFalse(IddsConfig.Instance.IsIpAddressLocal(IPAddress.Parse("192.168.13.1")));
            Assert.IsFalse(IddsConfig.Instance.IsIpAddressLocal(IPAddress.Parse("73.24.12.42")));
        }

        [TestMethod]
        public void TestIsIpAddressLocalPerformanceTest() {
            DateTime start = DateTime.Now;
            for (int i = 0; i < 2000; i++) {
                TestIpAddressLocal();
            }
            if ((DateTime.Now - start).TotalSeconds > 1) {
                Assert.Fail("Time taken for 28.000 ip address comparisons: " + (DateTime.Now - start).TotalSeconds + " seconds!");
            }
        }


        private List<IPAddress> _localAddresses;
        private List<IPAddress> getLocalIps() {
            if (_localAddresses == null) {
                _localAddresses = new List<IPAddress>();
                foreach (System.Net.NetworkInformation.NetworkInterface iface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()) {
                    System.Net.NetworkInformation.IPInterfaceProperties iprop = iface.GetIPProperties();
                    foreach (System.Net.NetworkInformation.UnicastIPAddressInformation info in iprop.UnicastAddresses) {
                        _localAddresses.Add(IPAddress.Parse(info.Address.ToString()));
                    }
                }
            }
            return _localAddresses;
        }

    }


}
