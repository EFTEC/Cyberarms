using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace Cyberarms.IntrusionDetection.Shared {
    public class IntrusionLog {
        public const int STATUS_INTRUSION_ATTEMPT = 100;
        public const int STATUS_INTRUSION_ATTEMPT_FROM_LOCAL = 110;
        public const int STATUS_INTRUSION_ATTEMPT_FROM_SAFE = 120;
        public const int STATUS_SOFT_LOCK_REQUESTED = 200;
        public const int STATUS_SOFT_LOCKED = 210;
        public const int STATUS_SOFT_LOCK_ERROR = 290;
        public const int STATUS_HARD_LOCK_REQUESTED = 300;
        public const int STATUS_HARD_LOCKED = 310;
        public const int STATUS_HARD_LOCK_ERROR = 390;
        public const int STATUS_UNLOCK_REQUESTED = 500;
        public const int STATUS_UNLOCKED = 510;
        public const int STATUS_UNLOCK_ERROR = 590;
        public const int STATUS_LICENSE_REQUIRED = 999;
        public const string SYSTEM_ID = "{DF7D1183-5033-4C94-AACB-CEFE9009B60F}";

        public static Guid GetSystemId() {
            return new Guid(SYSTEM_ID);
        }

        private static Dictionary<int, string> _statusNames;

        public static Dictionary<int, string> StatusNames {
            get {
                if (_statusNames == null) {
                    _statusNames = new Dictionary<int, string>();
                    _statusNames.Add(STATUS_INTRUSION_ATTEMPT, "Possible intrusion attempt.");
                    _statusNames.Add(STATUS_INTRUSION_ATTEMPT_FROM_LOCAL, "Invalid logon from localhost. Local addresses will not be blocked");
                    _statusNames.Add(STATUS_INTRUSION_ATTEMPT_FROM_SAFE, "Invalid logon from safe network!");
                    _statusNames.Add(STATUS_SOFT_LOCK_REQUESTED, "Soft lock threshold exceeded. Soft lock requested.");
                    _statusNames.Add(STATUS_SOFT_LOCKED, "This client was soft locked.");
                    _statusNames.Add(STATUS_SOFT_LOCK_ERROR, "There was a soft lock error. Please see event viewer for details.");
                    _statusNames.Add(STATUS_HARD_LOCK_REQUESTED, "Hard lock threshold exceeded. Hard lock requested.");
                    _statusNames.Add(STATUS_HARD_LOCKED, "The client was hard locked.");
                    _statusNames.Add(STATUS_HARD_LOCK_ERROR, "There was a hard lock error. Please see event viewer for details.");
                    _statusNames.Add(STATUS_UNLOCK_REQUESTED, "Lock has expired. Unlock requested.");
                    _statusNames.Add(STATUS_UNLOCKED, "This client was unlocked.");
                    _statusNames.Add(STATUS_UNLOCK_ERROR, "There was an unlock error. Please see event viewer for details.");
                    _statusNames.Add(STATUS_LICENSE_REQUIRED, "FREE license limit exceeded. Please order your license.");
                }
                return _statusNames;
            }
        }

        private static Dictionary<int, string> _statusClasses;

        public static Dictionary<int, string> StatusClasses {
            get {
                if (_statusClasses == null) {
                    _statusClasses = new Dictionary<int, string>();
                    _statusClasses.Add(STATUS_INTRUSION_ATTEMPT, "Intrusion");
                    _statusClasses.Add(STATUS_INTRUSION_ATTEMPT_FROM_LOCAL, "Intrusion");
                    _statusClasses.Add(STATUS_INTRUSION_ATTEMPT_FROM_SAFE, "Intrusion");
                    _statusClasses.Add(STATUS_SOFT_LOCK_REQUESTED, "Soft lock");
                    _statusClasses.Add(STATUS_SOFT_LOCKED, "Soft lock");
                    _statusClasses.Add(STATUS_SOFT_LOCK_ERROR, "Error");
                    _statusClasses.Add(STATUS_HARD_LOCK_REQUESTED, "Hard lock");
                    _statusClasses.Add(STATUS_HARD_LOCKED, "Hard lock");
                    _statusClasses.Add(STATUS_HARD_LOCK_ERROR, "Error");
                    _statusClasses.Add(STATUS_UNLOCK_REQUESTED, "Unlock");
                    _statusClasses.Add(STATUS_UNLOCKED, "Unlock");
                    _statusClasses.Add(STATUS_UNLOCK_ERROR, "Error");
                    _statusClasses.Add(STATUS_LICENSE_REQUIRED, "Licensing");
                }
                return _statusClasses;
            }
        }

        private static Dictionary<int, Image> _statusIcons;
        public static Dictionary<int, Image> StatusIcons {
            get {
                if (_statusIcons == null) {
                    _statusIcons = new Dictionary<int, Image>();
                    _statusIcons.Add(STATUS_INTRUSION_ATTEMPT, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_loginAttempt);
                    _statusIcons.Add(STATUS_INTRUSION_ATTEMPT_FROM_LOCAL, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_loginAttempt);
                    _statusIcons.Add(STATUS_INTRUSION_ATTEMPT_FROM_SAFE, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_loginAttempt);
                    _statusIcons.Add(STATUS_SOFT_LOCK_REQUESTED, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_softLock);
                    _statusIcons.Add(STATUS_SOFT_LOCKED, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_softLock);
                    _statusIcons.Add(STATUS_SOFT_LOCK_ERROR, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_warning);
                    _statusIcons.Add(STATUS_HARD_LOCK_REQUESTED, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_hardLock);
                    _statusIcons.Add(STATUS_HARD_LOCKED, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_hardLock);
                    _statusIcons.Add(STATUS_HARD_LOCK_ERROR, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_warning);
                    _statusIcons.Add(STATUS_UNLOCK_REQUESTED, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_unlock);
                    _statusIcons.Add(STATUS_UNLOCKED, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_unlock);
                    _statusIcons.Add(STATUS_UNLOCK_ERROR, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_warning);
                    _statusIcons.Add(STATUS_LICENSE_REQUIRED, global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_warning);
                }
                return _statusIcons;
            }
        }

        public static Image GetStatusIcon(int status) {
            if (StatusIcons.ContainsKey(status)) {
                return StatusIcons[status];
            } else {
                return global::Cyberarms.IntrusionDetection.Shared.Resources.logIcon_systemMessage;
            }
        }

        public static string GetStatusClass(int status) {
            if (StatusClasses.ContainsKey(status)) {
                return StatusClasses[status];
            } else {
                return String.Format("System", status);
            }
        }

        public static string GetStatusName(int status) {
            if (StatusNames.ContainsKey(status)) {
                return StatusNames[status];
            } else {
                return String.Format("Display name for status {0} was not found.", status);
            }
        }

        public static IDataReader ReadInterval(TimeSpan timeSpan) {
            if (Database.Instance.IsConfigured) {
                return Database.Instance.ExecuteReader("select * from IntrusionLog where IncidentTime>@p0 order by Id desc", DateTime.Now.Subtract(timeSpan));
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }


        public static int GetLastLogId() {
            int maxLogId = 0;
            object result = Database.Instance.ExecuteScalar("select Max(Id) from IntrusionLog");
            if (int.TryParse(result.ToString(), out maxLogId)) return maxLogId;
            return -1;
        }

                //table IntrusionLog
                //Id INTEGER PRIMARY KEY AUTOINCREMENT not null,
                //IncidentTime DateTime null,
                //AgentId uniqueidentifier null,
                //ClientIP nvarchar(80) null,
                //Action int null,
                //ActionTriggeredByUser bit null

        public static IDataReader ReadIntervalGrouped(TimeSpan timeSpan) {
            if (Database.Instance.IsConfigured) {
                return Database.Instance.ExecuteReader("select MAX(Id) as MaxId, MAX(IncidentTime) as LatestEvent, Count(*) as NumberOfEvents, AgentId, ClientIP, Action from IntrusionLog where IncidentTime>@p0 group by AgentId, ClientIP, Action order by 1 desc", DateTime.Now.Subtract(timeSpan));
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static bool HasUpdates(int lastSequenceNumber) {
            int lastId;
            if (Database.Instance.IsConfigured) {
                object result = Database.Instance.ExecuteScalar("select max(Id) from IntrusionLog");
                if (result != null && int.TryParse(result.ToString(), out lastId)) {
                    return lastSequenceNumber != lastId;
                } else {
                    return false;
                }
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static IDataReader ReadDifferential(int lastSequenceNumber) {
            if (Database.Instance.IsConfigured) {
                return Database.Instance.ExecuteReader("select * from IntrusionLog where Id>@p0", lastSequenceNumber);
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        
        public static int ReadUnsuccessfulAttempts(DateTime startDate) {
            if (Database.Instance.IsConfigured) {
                int result = 0;
                int.TryParse(Database.Instance.ExecuteScalar("select count(*) from IntrusionLog where IncidentTime>@p0", startDate).ToString(), out result);
                return result;
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static long AddEntry(DateTime incidentTime, Guid agentId, string clientIp, int action, bool actionTriggeredByUser) {
            if (Database.Instance.IsConfigured) {
                string sqlString = @"insert into IntrusionLog(IncidentTime, AgentId, ClientIP, Action, ActionTriggeredByUser)
values (@p0,@p1,@p2,@p3,@p4)";
                Database.Instance.ExecuteNonQuery(sqlString, incidentTime, agentId, clientIp, action, actionTriggeredByUser);
                object result = Database.Instance.ExecuteScalar("select max(Id) from IntrusionLog");
                return Db.DbValueConverter.ToInt64(result);
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }

        public static int GetIncidentsByAgentId(Guid agentId, string IpAddress) {
            if (Database.Instance.IsConfigured) {
                string sqlString = @"select count(*) from IntrusionLog where AgentId=@p0 and IncidentTime>@p1 and ClientIP=@p2";
                object queryResult = Database.Instance.ExecuteScalar(sqlString, agentId, DateTime.Now.AddDays(-1),IpAddress);
                return Db.DbValueConverter.ToInt(queryResult); 
            } else {
                throw new ApplicationException("Database not initialized");
            }
        }
    }
}
