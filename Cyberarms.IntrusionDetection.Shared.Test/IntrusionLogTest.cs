using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cyberarms.IntrusionDetection.Shared;
using System.Data;

namespace Cyberarms.IntrusionDetection.Shared.Test {
    [TestClass]
    public class IntrusionLogTest {
        public IntrusionLogTest() {
            Database.Instance.Configure(System.Windows.Forms.Application.StartupPath);
        }

        [TestMethod]
        public void ReadIntervalTest() {
            prepareIntrusionLog();
            IDataReader rdr = IntrusionLog.ReadInterval(new TimeSpan(0, 24, 0, 0, 0));
            if (rdr.FieldCount != 6) Assert.Fail("Field count changed!");
            
            while (rdr.Read()) {
                System.Diagnostics.Debug.Print("Log Id {0} ({1}): {2}", rdr["Id"],rdr["IncidentTime"], rdr["ClientIP"]);
            }

        }

        [TestMethod]
        public void HasUpdatesTest() { 
        }

        [TestMethod]
        public void ReadDifferentialTest() {
        }

        private void prepareIntrusionLog() {
            Database.Instance.ExecuteNonQuery(INSERT_COMMAND, DateTime.Now.AddHours(-1), null, "10.10.1.1", 0, false);
            Database.Instance.ExecuteNonQuery(INSERT_COMMAND, DateTime.Now.AddHours(-1).AddMinutes(-1), null, "10.10.1.1", 0, false);
            Database.Instance.ExecuteNonQuery(INSERT_COMMAND, DateTime.Now.AddHours(-1).AddMinutes(-2), null, "10.10.1.1", 0, false);
            Database.Instance.ExecuteNonQuery(INSERT_COMMAND, DateTime.Now.AddHours(-1).AddMinutes(-3), null, "10.10.1.1", 0, false);
            Database.Instance.ExecuteNonQuery(INSERT_COMMAND, DateTime.Now.AddHours(-1).AddMinutes(-4), null, "10.10.1.1", 0, false);

        }

        const string INSERT_COMMAND = "insert into IntrusionLog(IncidentTime,AgentId, ClientIP, Action, ActionTriggeredByUser) values(@p0,@p1,@p2,@p3,@p4)";


    }

}
