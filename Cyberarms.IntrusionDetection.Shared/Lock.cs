using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public class Lock {
        public const int LOCK_STATUS_NONE = 100;
        public const int LOCK_STATUS_SOFTLOCK_REQUESTED = 200;
        public const int LOCK_STATUS_SOFTLOCK = 210;
        public const int LOCK_STATUS_SOFTLOCK_EXPIRED = 220;
        public const int LOCK_STATUS_HARDLOCK_REQUESTED = 300;
        public const int LOCK_STATUS_HARDLOCK = 310;
        public const int LOCK_STATUS_HARDLOCK_EXPIRED = 320;
        public const int LOCK_STATUS_MANUAL = 400;
        public const int LOCK_STATUS_ACTIVE = 510;
        public const int LOCK_STATUS_UNLOCK_REQUESTED = 500;
        public const int LOCK_STATUS_UNLOCKED = 510;
        public const int LOCK_STATUS_HISTORY = 800;
        public const int LOCK_STATUS_LOCK_ERROR = 900;
        public const int LOCK_STATUS_UNLOCK_ERROR = 901;
        public const int LOCK_STATUS_LICENSE_REQUIRED = 999;
        


        public long Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime LockDate { get; set; }
        public DateTime UnlockDate { get; set; }
        public int Port { get; set; }
        public int Status { get; set; }
        public int NumberOfSoftLocks { get; set; }
        public long TriggerIncident { get; set; }

        public void Save() {
            if (Database.Instance.IsConfigured) {
                string sqlString = "update Locks set IpAddress=@p0, LockDate=@p1, Port=@p2, Status=@p3, TriggerIncident=@p4, UnlockDate=@p5, LastUpdate=@p6 where LockId=" + this.Id.ToString();
                Database.Instance.ExecuteNonQuery(sqlString, this.IpAddress, this.LockDate, this.Port, this.Status, this.TriggerIncident, this.UnlockDate, DateTime.Now);
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }
    }
}
