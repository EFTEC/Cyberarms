using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cyberarms.IntrusionDetection.Shared.Db {
    public class DbUpgrader {
        
        

        public void RunUpgradeScripts(System.Data.IDbConnection connection) {
            System.Data.IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT VersionNumber from DbConfig order by VersionNumber desc LIMIT 1";
            int latestVersion = 0;
            object result = null;
            try {
                result = cmd.ExecuteScalar();
            } catch (System.Data.Common.DbException) {
                result = null;
                latestVersion = 0;
            } catch(Exception ex) {
                throw (ex);
            }
            if (result != null && !String.IsNullOrEmpty(result.ToString())) {
                if(!int.TryParse(result.ToString(), out latestVersion)) {
                    latestVersion = 0;
                }
            }
            InitScripts();
            UpgradeAll(connection, latestVersion);
        }

        public void UpgradeAll(System.Data.IDbConnection connection, int latestVersionNumber) {
            foreach (int key in upgradeScripts.Keys) {
                if (key > latestVersionNumber) {
                    upgradeScripts[key].UpgradeDatabase(connection);
                }
            }
        }

        
        SortedList<int, DbUpgradeScript> upgradeScripts;

        private void InitScripts() {
            upgradeScripts = new SortedList<int, DbUpgradeScript>();
            upgradeScripts.Add(1, new Version_2_1());
        }

        public DbUpgrader() {
            
        }
    }
}
