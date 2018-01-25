using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

using System.Data.SQLite;

namespace Cyberarms.IntrusionDetection.Shared {
    public class Database {
        public const string DB_CONNECTION_STRING =
            "Persist Security Info = False; Data Source = {0};" +
            "Password = 'hasdvfdfaxNm.DFd3djkn2li9fu24$'; File Mode = 'read write'; " +
            "Max Buffer Size = 1024";

        private bool _isConfigured = false;
        public bool IsConfigured { get { return _isConfigured; } }

        private SQLiteConnectionStringBuilder connBuilder = new SQLiteConnectionStringBuilder();



        public void Configure(string directory) {
            connBuilder.FailIfMissing = false;
            connBuilder.Flags = SQLiteConnectionFlags.Default;
            connBuilder.ForeignKeys = true;
            connBuilder.JournalMode = SQLiteJournalModeEnum.Truncate;
            connBuilder.Password = "hasdvfdfaxNm.DFd3djkn2li9fu24$";
            connBuilder.Pooling = true;
            connBuilder.ReadOnly = false;
            connBuilder.SyncMode = SynchronizationModes.Normal;
            connBuilder.DataSource = directory + "\\cyberarms.idds.dbf";
            _connection = new SQLiteConnection(connBuilder.ConnectionString);
            if (!System.IO.File.Exists(connBuilder.DataSource)) {
                SQLiteConnection.CreateFile(connBuilder.DataSource);

                /*engine = new SqlCeEngine(String.Format(DB_CONNECTION_STRING, directory + "\\cyberarms.idds.sdf"));
                engine.CreateDatabase();
                engine.Verify(VerifyOption.Default); */
            }
            _connection.Open();
            OpenOrCreate();
            // _connection.FlushFailure += new SqlCeFlushFailureEventHandler(_connection_FlushFailure);
            _connection.StateChange += new StateChangeEventHandler(_connection_StateChange);
            _isConfigured = true;
        }

        void _connection_StateChange(object sender, StateChangeEventArgs e) {
            System.Diagnostics.Debug.Print("Db state {0} --> {1}", e.OriginalState, e.CurrentState);
        }


        private System.Data.SQLite.SQLiteConnection _connection;

        public SQLiteConnection Connection {
            get {
                if (_connection == null) throw new ApplicationException("Sorry, cannot return requested connection object. Please run Configure first to set database path.");
                if (_connection.State == System.Data.ConnectionState.Broken) {
                    _connection.Open();
                }
                // open new connection;
                return _connection;
            }
        }

        private static Database _instance;
        public static Database Instance {
            get {
                if (_instance == null) {
                    _instance = new Database();

                }
                return _instance;
            }
        }

        private Database() {

        }


        public IDataReader ExecuteReader(string sqlString, params object[] parameters) {
            return ExecuteReader(sqlString, null, parameters);
        }

        public IDataReader ExecuteReader(string sqlString, IDbTransaction transaction, params object[] parameters) {
            IDbCommand cmd = PrepareCommand(sqlString, parameters);
            IDataReader rdr = null;
            if (transaction != null) cmd.Transaction = transaction;
            try {
                rdr = cmd.ExecuteReader();
            } catch (Exception ex) {
                for (int i = 0; i < 5; i++) {
                    System.Threading.Thread.Sleep(500);
                    try {
                        rdr = cmd.ExecuteReader();
                        return rdr;
                    } catch { }
                }
                throw ex;
            }
            return rdr;
        }

        public void ExecuteNonQuery(string sqlString, params object[] parameters) {
            ExecuteNonQuery(sqlString, null, parameters);
        }

        public void ExecuteNonQuery(string sqlString, IDbTransaction transaction, params object[] parameters) {
            IDbCommand cmd = PrepareCommand(sqlString, parameters);
            try {
                if (transaction != null) cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                // try to recover
                try {
                    IDbConnection conn = (IDbConnection)Connection.Clone();
                    if (conn.State != ConnectionState.Open) conn.Open();
                    cmd.Connection = conn;
                    try {
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex2) {
                        for (int i = 0; i < 5; i++) {
                            System.Threading.Thread.Sleep(500);
                            try {
                                cmd.ExecuteNonQuery();
                                return;
                            } catch { }
                        }
                        throw ex2;
                    }
                    conn.Close();
                } catch (Exception ex1) {
                    throw ex1;
                }
            }
        }

        private IDbCommand PrepareCommand(string sqlString, params object[] parameters) {
            IDbCommand cmd = Connection.CreateCommand();
            cmd.Connection = Connection;
            cmd.CommandText = sqlString;
            cmd.CommandType = System.Data.CommandType.Text;
            for (int i = 0; i < parameters.Length; i++) {
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = "@p" + i;
                p.Value = parameters[i];
                if (parameters[i] == null) p.Value = DBNull.Value;
                cmd.Parameters.Add(p);
            }
            cmd.Prepare();
            return cmd;
        }

        public object ExecuteScalar(string sqlString, params object[] parameters) {
            return ExecuteScalar(sqlString, null, parameters);
        }

        public object ExecuteScalar(string sqlString, IDbTransaction transaction, params object[] parameters) {
            object result = null;
            IDbCommand cmd = PrepareCommand(sqlString, parameters);
            if (transaction != null) cmd.Transaction = transaction;
            
            try {
                result = cmd.ExecuteScalar();
            } catch (Exception ex) {
                for (int i = 0; i < 5; i++) {
                    // can we recover the problem within a timeout period?
                    System.Threading.Thread.Sleep(500);
                    try {
                        result = cmd.ExecuteScalar();
                        return result;
                    } catch { }
                }
                throw ex;
            }
            return result;
        }

        public int DatabaseVersion { get; set; }

        private void OpenOrCreate() {
            System.Data.IDbCommand cmd = Connection.CreateCommand();
            string version = null;
            try {
                cmd.CommandText = "Select Version from DbConfig";
                version = cmd.ExecuteScalar().ToString();
            } catch (Exception sqEx) {
                //
                System.Diagnostics.Debug.Print(sqEx.Message.ToString());
            }
            if (String.IsNullOrEmpty(version)) {
                // no database exists, or database was deleted. create tables and populate
                Db.DbUpgrader upgrader = new Db.DbUpgrader();
                upgrader.RunUpgradeScripts(Connection);
                int versionNumber;
                if (int.TryParse(cmd.ExecuteScalar().ToString(), out versionNumber)) {
                    DatabaseVersion = versionNumber;
                } else {
                    throw new ApplicationException("Error while accessing or creating the database");
                }
            } else {
                int versionNumber = -1;
                int.TryParse(version, out versionNumber);
                DatabaseVersion = versionNumber;
            }
        }



    }
}
