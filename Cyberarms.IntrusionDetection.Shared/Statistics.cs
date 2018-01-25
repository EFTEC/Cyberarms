using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyberarms.IntrusionDetection.Shared {
    public class Statistics {

        private List<Guid> agentIds;

        private Statistics() {
            agentIds = new List<Guid>();
        }

        private static Statistics _instance;
        public static Statistics Instance {
            get {
                if (_instance == null) {
                    _instance = new Statistics();
                }
                return _instance;
            }
        }

        public void IncreaseFailedLoginStatistics(SecurityAgent agent) {
            if (!agentIds.Contains(agent.Id)) ConfigureStatistics(agent);
            agent.FailedLogins++;
            IncreaseStatistics(agent, "FailedLogins");
        }

        public void IncreaseHardLockStatistics(SecurityAgent agent) {
            agent.HardLocks++;
            IncreaseStatistics(agent, "HardLocks");
        }

        public void ConfigureStatistics(SecurityAgent agent) {
            string sqlString = "select count(*) from AgentStatistics where AgentId=@p0";
            object result = Database.Instance.ExecuteScalar(sqlString, agent.Id);
            if (Db.DbValueConverter.ToInt(result) < 1) {
                sqlString = "insert into AgentStatistics(AgentId, FailedLogins, SoftLocks, HardLocks) values (@p0,0,0,0)";
                Database.Instance.ExecuteNonQuery(sqlString, agent.Id);
            }
            agentIds.Add(agent.Id);
        }

        public void IncreaseSoftLockStatistics(SecurityAgent agent) {
            agent.SoftLocks++;
            IncreaseStatistics(agent, "SoftLocks");
        }

        public void IncreaseStatistics(SecurityAgent agent, string statisticsColumn) {
            try {
                string sqlString = String.Format("Update AgentStatistics set {0}={0}+1 where AgentId=@p0", statisticsColumn);
                Database.Instance.ExecuteNonQuery(sqlString, agent.Id);
            } catch(Exception ex) {
                throw ex;
            }
        }

    }
}
