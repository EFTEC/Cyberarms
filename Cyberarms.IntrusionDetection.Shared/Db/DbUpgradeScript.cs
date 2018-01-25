using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cyberarms.IntrusionDetection.Shared.Db {
    public class DbUpgradeScript {
        public virtual int INTERNAL_VERSION { get { return 0; } }

        public virtual void UpgradeDatabase(System.Data.IDbConnection connection) {

        }

        internal void RunCommand(System.Data.IDbConnection connection, string command) {
            System.Data.IDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = command;
            try {
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            }

        }
    }
}
