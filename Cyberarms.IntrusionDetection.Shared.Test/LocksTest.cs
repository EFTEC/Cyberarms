using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection.Shared.Test {
    [TestClass]
    public class LocksTest {

        public LocksTest() {
            Database.Instance.Configure(System.Windows.Forms.Application.StartupPath);
        }

        [TestMethod]
        public void CreateLockTest() {
            long currentMaxId = GetMaxLocksId();
            Lock l = new Lock();
            l.IpAddress = "10.20.1.1";
            l.LockDate = DateTime.Now;
            l.UnlockDate = DateTime.Now.AddDays(1);
            l.Port = 0;
            l.Status = Lock.LOCK_STATUS_HARDLOCK;
            l.NumberOfSoftLocks = 2;
            l.TriggerIncident = 100;
            l.Id = Locks.CreateLock(l);
            Assert.AreEqual(currentMaxId + 1, l.Id);
        }

        private long GetMaxLocksId() {
            object result = Database.Instance.ExecuteScalar("Select max(LockId) from Locks");
            return Db.DbValueConverter.ToInt64(result);
            
        }

        [TestMethod]
        public void TestLockExists() {
            Assert.IsFalse(Locks.LockExists("192.158.178.120"));
        }

        [TestMethod]
        public void TestLockExists2() {
            Assert.IsTrue(Locks.LockExists("10.20.1.1"));
        }
    }
}
