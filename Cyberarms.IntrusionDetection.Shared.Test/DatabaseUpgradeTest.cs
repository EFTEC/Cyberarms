using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cyberarms.IntrusionDetection.Shared.Test {
    [TestClass]
    public class DatabaseUpgradeTest {
        [TestMethod]
        public void TestDatabaseCreation() {
            Database.Instance.Configure("c:\\temp");
            Assert.AreEqual(1,Database.Instance.DatabaseVersion);
            
        }
    }
}
