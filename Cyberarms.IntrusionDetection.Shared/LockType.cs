using System;
using System.Collections.Generic;
using Cyberarms.IntrusionDetection.Shared;
using System.Text;

namespace Cyberarms.IntrusionDetection {
    public enum LockType {
        None = Lock.LOCK_STATUS_NONE,
        SoftLockRequested = Lock.LOCK_STATUS_SOFTLOCK_REQUESTED,
        SoftLock = Lock.LOCK_STATUS_SOFTLOCK,
        HardLockRequested = Lock.LOCK_STATUS_HARDLOCK_REQUESTED,
        HardLock = Lock.LOCK_STATUS_HARDLOCK
    }
}
