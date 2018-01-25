using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Xml.Serialization;

namespace IdsServiceForWindowsTest {
    /// <summary>
    /// Summary description for ApiTest
    /// </summary>
    [TestClass]
    public class ApiTest {
        public ApiTest() {
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
        public void TestSerialization() {
            TestPluginConfig config = new TestPluginConfig();
            config.Prop1 = "Test1";
            config.Prop2 = "Test2";
            XmlSerializer xs = new XmlSerializer(typeof(TestPluginConfig));
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\temp\\pluginsettings.xml");
            xs.Serialize(sw, config);
            sw.Close();
        }


    }

    
    public class TestPluginConfig : PluginConfiguration {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
    }
}
