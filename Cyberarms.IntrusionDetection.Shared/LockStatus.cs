using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cyberarms.IntrusionDetection.Shared {
    public enum LockStatus {
        None = Lock.LOCK_STATUS_NONE,
        SoftLockRequested = Lock.LOCK_STATUS_SOFTLOCK_REQUESTED,
        SoftLocked = Lock.LOCK_STATUS_SOFTLOCK,
        SoftLockExpired = Lock.LOCK_STATUS_SOFTLOCK_EXPIRED,
        HardLockRequested = Lock.LOCK_STATUS_HARDLOCK_REQUESTED,
        HardLocked = Lock.LOCK_STATUS_HARDLOCK,
        HardLockExpired = Lock.LOCK_STATUS_HARDLOCK_EXPIRED,        
        Unlocked = Lock.LOCK_STATUS_UNLOCKED,
        ManuallyUnlocked = Lock.LOCK_STATUS_MANUAL,
        LockError = Lock.LOCK_STATUS_LOCK_ERROR,
        UnlockError = Lock.LOCK_STATUS_UNLOCK_ERROR,
        LicenseRequired = Lock.LOCK_STATUS_LICENSE_REQUIRED
    }

    public class LockStatusAdapter {
        private static Dictionary<int, string> _lockStatusNames;
        public static Dictionary<int, string> LockStatusNames {
            get {
                if (_lockStatusNames == null) {
                    _lockStatusNames = new Dictionary<int, string>();
                    _lockStatusNames.Add((int)LockStatus.None, "New");
                    _lockStatusNames.Add((int)LockStatus.SoftLockRequested, "Soft lock requested");
                    _lockStatusNames.Add((int)LockStatus.SoftLocked, "Soft lock");
                    _lockStatusNames.Add((int)LockStatus.SoftLockExpired, "Soft lock expired");
                    _lockStatusNames.Add((int)LockStatus.HardLockRequested, "Hard lock requested");
                    _lockStatusNames.Add((int)LockStatus.HardLocked, "Hard lock");
                    _lockStatusNames.Add((int)LockStatus.HardLockExpired, "Hard lock expired");
                    _lockStatusNames.Add((int)LockStatus.Unlocked, "Unlocked");
                    _lockStatusNames.Add((int)LockStatus.ManuallyUnlocked, "Manually unlocked");
                    _lockStatusNames.Add((int)LockStatus.LockError, "Error adding lock");
                    _lockStatusNames.Add((int)LockStatus.UnlockError, "Unlock error");
                    _lockStatusNames.Add((int)LockStatus.LicenseRequired, "License limitation");
                }
                return _lockStatusNames;
            }
        }

        public static string GetLockStatusName(int status) {
            if(LockStatusNames.ContainsKey(status)) {
                return LockStatusNames[status];
            } else {
                return String.Format("Status {0} not found in LockStatusNames!", status);
            }
        }
    }
}
