using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Cyberarms.IntrusionDetection;
using Cyberarms.IntrusionDetection.Shared;

namespace IdsServiceForWindowsTest {
    [TestClass]
    public class EventLogTest {
        [TestMethod]
        public void TestCreateWhenSourceExists() {
            WindowsLogManager.Instance.WriteEntry("Test Message", EventLogEntryType.Information, 0, 0);
        }
    }
}
