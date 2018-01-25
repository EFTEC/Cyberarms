using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Cyberarms.IntrusionDetection.Shared {
    public class Locks  {
        

        
        public static bool HasUpdates(DateTime lastUpdate) {
            if (Database.Instance.IsConfigured) {
                object result = Database.Instance.ExecuteScalar("select count(*) from Locks where LastUpdate>@p0", lastUpdate);
                int count;
                if (result != null && int.TryParse(result.ToString(), out count)) {
                    return count>0;
                } else {
                    return false;
                }
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }


        
        public static IDataReader ReadLocks() {
            if (Database.Instance.IsConfigured) {
                return Database.Instance.ExecuteReader(@"select l.LockId, i.ClientIp, l.LockDate, l.UnlockDate,i.IncidentTime, a.DisplayName, l.status
                                                        from Locks l inner join IntrusionLog i on l.TriggerIncident = i.Id
                                                            inner join SecurityAgents a on i.AgentId = a.AgentId
                                                        where l.status in (@p0,@p1) order by l.LockDate desc", Lock.LOCK_STATUS_HARDLOCK, Lock.LOCK_STATUS_SOFTLOCK);
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static int Today() {
            int result;
            if (Database.Instance.IsConfigured) {
                object queryResult = Database.Instance.ExecuteScalar(@"select count(*) from IntrusionLog where (action=@p0 or action=@p1) and IncidentTime>@p2", 
                    IntrusionLog.STATUS_SOFT_LOCKED, IntrusionLog.STATUS_HARD_LOCKED, DateTime.Now.AddDays(-1));
                if (int.TryParse(queryResult.ToString(), out result)) {
                    return result;
                } else {
                    throw new ApplicationException("Invalid data");
                }
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static int ReadCurrentSoftLocks() {
            object result = Database.Instance.ExecuteScalar("select count(*) from Locks where status in (@p0) ", (int)LockStatus.SoftLocked);
            int softLocks = 0;
            int.TryParse(result.ToString(), out softLocks);
            return softLocks;
        }

        public static int ReadCurrentHardLocks() {
            object result = Database.Instance.ExecuteScalar("select count(*) from Locks where status in (@p0)", (int)LockStatus.HardLocked);
            int hardLocks = 0;
            int.TryParse(result.ToString(), out hardLocks);
            return hardLocks;
        }

        public static int ReadUnsuccessfulLoginAttempts(DateTime startDate) {
            object result = Database.Instance.ExecuteScalar("select count(*) from IntrusionLog where IncidentTime>@p0 and Action in (@p1,@p2,@p3)", startDate, IntrusionLog.STATUS_INTRUSION_ATTEMPT, IntrusionLog.STATUS_INTRUSION_ATTEMPT_FROM_LOCAL, IntrusionLog.STATUS_INTRUSION_ATTEMPT_FROM_SAFE);
            int intrusionAttempts = 0;
            int.TryParse(result.ToString(), out intrusionAttempts);
            return intrusionAttempts;
        }

        public static List<Lock> GetCurrentLocks() {
            if (Database.Instance.IsConfigured) {
                List<Lock> result = new List<Lock>();
                string sqlString = @"select LockId, LockDate, UnlockDate, TriggerIncident, Status, Port, IpAddress from Locks where status in (@p0,@p1)";
                IDataReader rdr = Database.Instance.ExecuteReader(sqlString, Lock.LOCK_STATUS_HARDLOCK, Lock.LOCK_STATUS_SOFTLOCK);
                while (rdr.Read()) {
                    Lock l = new Lock();
                    l.Id = Db.DbValueConverter.ToInt64(rdr["LockId"]);
                    l.LockDate = Db.DbValueConverter.ToDateTime(rdr["LockDate"]);
                    l.UnlockDate = Db.DbValueConverter.ToDateTime(rdr["UnlockDate"]);
                    l.Status = Db.DbValueConverter.ToInt(rdr["Status"]);
                    l.Port = Db.DbValueConverter.ToInt(rdr["Port"]);
                    l.IpAddress = Db.DbValueConverter.ToString(rdr["IpAddress"]);
                    result.Add(l);
                }
                rdr.Close();
                return result;
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static Lock GetLockById(long id) {
            if (Database.Instance.IsConfigured) {
                Lock result = new Lock();
                string sqlString = @"select LockId, LockDate, UnlockDate, TriggerIncident, Status, Port, IpAddress from Locks where LockId = @p0";
                IDataReader rdr = Database.Instance.ExecuteReader(sqlString, id);
                if (rdr.Read()) {
                    result.Id = Db.DbValueConverter.ToInt64(rdr["LockId"]);
                    result.LockDate = Db.DbValueConverter.ToDateTime(rdr["LockDate"]);
                    result.UnlockDate = Db.DbValueConverter.ToDateTime(rdr["UnlockDate"]);
                    result.Status = Db.DbValueConverter.ToInt(rdr["Status"]);
                    result.Port = Db.DbValueConverter.ToInt(rdr["Port"]);
                    result.IpAddress = Db.DbValueConverter.ToString(rdr["IpAddress"]);
                    result.TriggerIncident = Db.DbValueConverter.ToInt64(rdr["TriggerIncident"]);
                }
                rdr.Close();
                return result;
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static bool LockExists(string ipAddress) {
            if (Database.Instance.IsConfigured) {

                string sqlString = @"Select count(*) from Locks where IpAddress=@p0 and status in (@p1,@p2,@p3,@p4)";

                object count = Database.Instance.ExecuteScalar(sqlString, ipAddress, Lock.LOCK_STATUS_HARDLOCK, Lock.LOCK_STATUS_SOFTLOCK, Lock.LOCK_STATUS_SOFTLOCK_REQUESTED, Lock.LOCK_STATUS_HARDLOCK_REQUESTED);
                if (Db.DbValueConverter.ToInt(count) > 0) {
                    return true;
                } else {
                    return false;
                }
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static Lock CreateLock(DateTime lockDate, DateTime unlockDate, long triggerIncident, int status, int port, string ipAddress) {
            Lock l = new Lock();
            l.IpAddress = ipAddress;
            l.LockDate = lockDate;
            l.Port = port;
            l.Status = status;
            l.TriggerIncident = triggerIncident;
            l.UnlockDate = unlockDate;
            l.Id = CreateLock(l);
            return l;
        }

        public static long CreateLock(Lock l) {
            if (Database.Instance.IsConfigured) {
                Lock result = new Lock();
                string sqlString = @"insert into Locks(LockDate, UnlockDate, TriggerIncident, Status, Port, IpAddress, LastUpdate) values (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";
                Database.Instance.ExecuteNonQuery(sqlString, l.LockDate, l.UnlockDate, l.TriggerIncident, l.Status, l.Port, l.IpAddress, DateTime.Now);
                object id = Database.Instance.ExecuteScalar("SELECT last_insert_rowid()");
                l.Id = Db.DbValueConverter.ToInt64(id);
                return l.Id;
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static void UpdateLock(Lock l) {
            if (Database.Instance.IsConfigured) {
                string sqlString = @"update Locks set LockDate=@p0, UnlockDate=@p1, TriggerIncident=@p2, Status=@p3, Port=@p4, IpAddress=@p5, LastUpdate=@p6 where LockId=@p7";
                Database.Instance.ExecuteNonQuery(sqlString, l.LockDate, l.UnlockDate, l.TriggerIncident, l.Status, l.Port, l.IpAddress, DateTime.Now, l.Id);
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static List<Lock> GetUnlockList() {
            List<Lock> result = new List<Lock>();
            if (Database.Instance.IsConfigured) {
                string sqlString = @"select * from Locks where (UnlockDate<@p0 and (status=@p1 or status=@p2)) or status=@p3";
                IDataReader rdr = Database.Instance.ExecuteReader(sqlString, DateTime.Now, Lock.LOCK_STATUS_HARDLOCK, Lock.LOCK_STATUS_SOFTLOCK, Lock.LOCK_STATUS_UNLOCK_REQUESTED);
                while (rdr.Read()) {
                    Lock l = new Lock();
                    l.Id = Db.DbValueConverter.ToInt64(rdr["LockId"]);
                    l.IpAddress = Db.DbValueConverter.ToString(rdr["IpAddress"]);
                    l.LockDate = Db.DbValueConverter.ToDateTime(rdr["LockDate"]);
                    l.Port = Db.DbValueConverter.ToInt(rdr["Port"]);
                    l.Status = Db.DbValueConverter.ToInt(rdr["Status"]);
                    l.TriggerIncident = Db.DbValueConverter.ToInt64(rdr["TriggerIncident"]);
                    l.UnlockDate = Db.DbValueConverter.ToDateTime(rdr["UnlockDate"]);
                    result.Add(l);
                }
                rdr.Close();
                return result;
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        
        
    }
}
