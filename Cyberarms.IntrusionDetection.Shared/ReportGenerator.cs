using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public class ReportGenerator {

        const string SELECT_BY_AGENT = @"SELECT a.DisplayName as AgentName, i.Action as Action, COUNT(*) as Incidents FROM IntrusionLog i INNER JOIN SecurityAgents a ON a.AgentId=i.AgentId WHERE IncidentTime>@p0 AND IncidentTime<@p1 GROUP BY a.DisplayName, i.Action ORDER BY 1";
        const string SELECT_BY_IP = @"SELECT ClientIP, COUNT(*) AS Incidents FROM IntrusionLog WHERE IncidentTime>@p0 AND IncidentTime<@p1 AND Action=@p2 GROUP BY ClientIp ORDER BY COUNT(*)";

        private ReportGenerator() {
        }

        private static ReportGenerator _instance;
        public static ReportGenerator Instance {
            get {
                if (_instance == null) {
                    _instance = new ReportGenerator();
                }
                return _instance;
            }
        }

        public string DailyReport() {
            return string.Empty;
        }

        public long TotalIntrusionAttempts { get; set; }
        public long TotalSoftLocks { get; set; }
        public long TotalHardLocks { get; set; }

        public string GetEventsPerAgent(DateTime start, DateTime end) {
            IDataReader rdr = Database.Instance.ExecuteReader(SELECT_BY_AGENT, start, end);
            string currentAgent = String.Empty;
            string currentLine = String.Empty;
            bool hasValues = false;
            StringBuilder sb = new StringBuilder();
            long intrusionAttempts = 0;
            long softLocks = 0;
            long hardLocks = 0;
            TotalIntrusionAttempts = 0;
            TotalSoftLocks = 0;
            TotalHardLocks = 0;
            string agent = String.Empty;
            while (rdr.Read()) {
                int action = Db.DbValueConverter.ToInt(rdr["Action"]);
                agent = Db.DbValueConverter.ToString(rdr["AgentName"]);
                long incidents = Db.DbValueConverter.ToInt64(rdr["Incidents"]);
                if(!agent.Equals(currentAgent) && hasValues) {
                    sb.AppendLine(SetEventsPerAgent(currentAgent, intrusionAttempts, softLocks, hardLocks));
                    currentAgent = agent;
                    intrusionAttempts = 0;
                    softLocks = 0;
                    hardLocks = 0;
                } else if (!hasValues) {
                    currentAgent = agent;
                }
                switch (action) {
                    case IntrusionLog.STATUS_INTRUSION_ATTEMPT:
                        intrusionAttempts = incidents;
                        break;
                    case IntrusionLog.STATUS_SOFT_LOCKED:
                        softLocks = incidents;
                        break;
                    case IntrusionLog.STATUS_HARD_LOCKED:
                        hardLocks = incidents;
                        break;
                }
                hasValues = true;
            }
            if (hasValues) {
                sb.AppendLine(SetEventsPerAgent(agent, intrusionAttempts, softLocks, hardLocks));
            }
            rdr.Close();
            return sb.ToString();
        }

        public string GetIncidentsByIP(int action, DateTime start, DateTime end) {
            IDataReader rdr = Database.Instance.ExecuteReader(SELECT_BY_IP, start, end, action);
            StringBuilder sb = new StringBuilder();
            while (rdr.Read()) {
                string result = GetIncidentByIPTemplate();
                string ipAddress = Db.DbValueConverter.ToString(rdr["ClientIP"]);
                long incidents = Db.DbValueConverter.ToInt64(rdr["Incidents"]);
                result = result.Replace("[%IP_ADDRESS%]", ipAddress);
                result = result.Replace("[%INTRUSION_ATTEMPTS%]", incidents.ToString());
                sb.AppendLine(result);
            }
            return sb.ToString();
        }

        public string GetIncidentByIPTemplate() {
            return global::Cyberarms.IntrusionDetection.Shared.Resources.IntrusionAttemptsByIp;
        }

        public string GetEventsPerAgentTemplate() {
            return global::Cyberarms.IntrusionDetection.Shared.Resources.EventsPerAgent;
        }

        public string SetEventsPerAgent(string agentName, long intrusionAttempts, long softLocks, long hardLocks) {
            string result = GetEventsPerAgentTemplate().Replace("[%AGENT_NAME%]", agentName);
            result = result.Replace("[%INTRUSION_ATTEMPTS%]", intrusionAttempts.ToString());
            result = result.Replace("[%SOFT_LOCKS%]", softLocks.ToString());
            result = result.Replace("[%HARD_LOCKS%]", hardLocks.ToString());
            TotalIntrusionAttempts += intrusionAttempts;
            TotalSoftLocks += softLocks;
            TotalHardLocks += hardLocks;
            return result;
        }

        public string GetReport(string title, string subtitle, string installationInformation, DateTime start, DateTime end) {
            string result = global::Cyberarms.IntrusionDetection.Shared.Resources.ReportTemplate;
            result = result.Replace("[%TITLE%]", title);
            result = result.Replace("[%SUBTITLE%]", subtitle);
            result = result.Replace("[%INSTALLATION_INFORMATION%]", installationInformation);

            result = result.Replace("[%EVENTS_PER_AGENT%]", GetEventsPerAgent(start, end));
            result = result.Replace("[%INTRUSION_ATTEMPTS_BY_IP%]", GetIncidentsByIP(IntrusionLog.STATUS_INTRUSION_ATTEMPT, start, end));
            result = result.Replace("[%SOFT_LOCKS_BY_IP%]", GetIncidentsByIP(IntrusionLog.STATUS_SOFT_LOCKED, start, end));
            result = result.Replace("[%HARD_LOCKS_BY_IP%]", GetIncidentsByIP(IntrusionLog.STATUS_HARD_LOCKED, start, end));
            result = result.Replace("[%TOTAL_INTRUSION_ATTEMPTS%]", TotalIntrusionAttempts.ToString());
            result = result.Replace("[%TOTAL_SOFT_LOCKS%]", TotalSoftLocks.ToString());
            result = result.Replace("[%TOTAL_HARD_LOCKS%]", TotalHardLocks.ToString());
            
            return result;
        }
     
    }
}
