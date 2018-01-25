using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;
using System.IO;

namespace Cyberarms.IntrusionDetection.Shared {
    [Serializable]
    public class SecurityAgent : IAgentFilter {

        public event EventHandler StatisticsUpdated;

        public SecurityAgent() { }

        public SecurityAgent(string name, Guid id)
            : this(name) {
            this.Id = id;
        }

        public SecurityAgent(string name) {
            Name = name;
        }

        public SecurityAgent(string name, int failedLogins, int hardLocks, int softLocks, System.Drawing.Image icon)
            : this(name) {
            FailedLogins = failedLogins;
            HardLocks = hardLocks;
            SoftLocks = softLocks;
            Icon = icon;
        }


        public SecurityAgent(string name, Guid id, int failedLogins, int hardLocks, int softLocks, System.Drawing.Image icon)
            : this(name, failedLogins, hardLocks, softLocks, icon) {
            this.Id = id;
        }

        public bool CheckConfigVersionById() {
            if (Id == null || Id.Equals(Guid.Empty)) return false;
            string sqlCommand = "Select Serial from SecurityAgents where AgentId=@p0";
            object dbVersion = Database.Instance.ExecuteScalar(sqlCommand, Id);
            if (dbVersion != null) {
                if (Db.DbValueConverter.ToInt(dbVersion) > Serial) {
                    Reload();
                }
                return true;
            }
            return false;
        }

        public bool CheckConfigVersionByName() {
            string sqlCommand = "Select Serial from SecurityAgents where Name=@p0";
            object dbVersion = Database.Instance.ExecuteScalar(sqlCommand, Name);
            if (dbVersion != null) {
                if (Db.DbValueConverter.ToInt(dbVersion) > Serial) {
                    Reload();
                }
                return true;
            }
            return false;
        }

        public void Reload() {
            if (!Database.Instance.IsConfigured) {
                throw new ApplicationException("Database is not configured yet. Please configure database and re-try this operation!");
            }
            if (Id == null || Id.Equals(Guid.Empty)) return;
            IDataReader rdr = Database.Instance.ExecuteReader("select * from securityAgents where AgentId=@p0", Id);
            // load all agents
            if (rdr.Read()) {
                Name = Db.DbValueConverter.ToString(rdr["Name"]);
                AssemblyName = Db.DbValueConverter.ToString(rdr["AssemblyName"]);
                Id = Db.DbValueConverter.ToGuid(rdr["AgentId"]);
                HardLockAttempts = Db.DbValueConverter.ToInt(rdr["HardLockAttempts"]);
                HardLockTimeHours = Db.DbValueConverter.ToInt(rdr["HardLockTimeHours"]);
                LockForever = Db.DbValueConverter.ToBool(rdr["LockForever"]);
                SoftLockAttempts = Db.DbValueConverter.ToInt(rdr["SoftLockAttempts"]);
                SoftLockTimeMinutes = Db.DbValueConverter.ToInt(rdr["SoftLockTimeMinutes"]);
                OverrideConfig = Db.DbValueConverter.ToBool(rdr["OverwriteConfiguration"]);
                DisplayName = Db.DbValueConverter.ToString(rdr["DisplayName"]);
                Enabled = Db.DbValueConverter.ToBool(rdr["Enabled"]);
                Serial = Db.DbValueConverter.ToInt(rdr["Serial"]);
            }
            rdr.Close();
            LoadCustomConfig();
        }

        public void LoadCustomConfig() {
            IDataReader rdr = Database.Instance.ExecuteReader("select PropertyName,PropertyValueString from SecurityAgentConfig where AgentId like @p0", Id);
            while (rdr.Read()) {
                string propName = Db.DbValueConverter.ToString(rdr["PropertyName"]);
                if (CustomConfiguration.ContainsKey(propName)) {
                    CustomConfiguration[propName] = Db.DbValueConverter.ToString(rdr["PropertyValueString"]);
                }
            }
            rdr.Close();
        }
        
        public string Name { get; set; }

        public int FailedLogins { get; set; }
        public int HardLocks { get; set; }
        public int SoftLocks { get; set; }
        private byte[] _selectedIcon;
        public System.Drawing.Image SelectedIcon {
            get {
                return FromByte(_selectedIcon);
            }
            set {
                _selectedIcon = FromImage(value);
            }
        }

        private byte[] FromImage(Image value) {
            if (value == null) return null;
            MemoryStream ms = new MemoryStream();
            value.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private Image FromByte(byte[] value) {
            if (value == null) return null;
            MemoryStream ms = new MemoryStream(value);
            return new Bitmap(ms);
        }


        private byte[] _unselectedIcon;
        public Image UnselectedIcon {
            get {
                return FromByte(_unselectedIcon);
            }
            set {
                _unselectedIcon = FromImage(value);
            }
        }

        private byte[] _icon;
        public Image Icon {
            get {
                return FromByte(_icon);
            }
            set {
                _icon = FromImage(value);
            }
        }

        public void Save() {
            if (this.Id == null || this.Id == Guid.Empty) Id = GetId();
            string sqlString;
            IDbTransaction trans = Database.Instance.Connection.BeginTransaction(IsolationLevel.Serializable);
            try {
                if (!DoesExistInDb(this.Id)) {
                   
                    sqlString = @"INSERT INTO SecurityAgents(AgentId, AssemblyName,HardLockAttempts,HardLockTimeHours,
LockForever,SoftLockAttempts,SoftLockTimeMinutes,OverwriteConfiguration,DisplayName, Enabled, Name, Serial) 
values (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,0)";
                } else {
                    sqlString = @"UPDATE SecurityAgents set AssemblyName = @p1,
HardLockAttempts=@p2, HardLockTimeHours=@p3, LockForever=@p4, SoftLockAttempts=@p5, SoftLockTimeMinutes=@p6,
OverwriteConfiguration=@p7, DisplayName=@p8, Enabled=@p9, Name=@p10 where AgentId=@p0";
                }
                Database.Instance.ExecuteNonQuery(sqlString, trans, Id, AssemblyName, HardLockAttempts, HardLockTimeHours,
                    LockForever, SoftLockAttempts, SoftLockTimeMinutes, OverrideConfig, DisplayName, Enabled, Name);
                Database.Instance.ExecuteNonQuery("UPDATE SecurityAgents set Serial = Serial+1 where AgentId=@p0", trans, Id);
                SaveCustomConfig();
                trans.Commit();
                OnStatisticsUpdated();
            } catch (Exception ex) {
                trans.Rollback();
                throw ex;
            }
        }

        public bool DoesExistInDb(Guid id) {
            Guid agentId;
            string sqlString = "select AgentId from SecurityAgents where AgentId = @p0";
            object result = Database.Instance.ExecuteScalar(sqlString, id);
            if (result != null && Guid.TryParse(result.ToString(), out agentId) && id.Equals(agentId)) return true;
            return false;
        }

        public void SaveCustomConfig() {
            foreach (string key in CustomConfiguration.Keys) {
                //select PropertyName,PropertyValueString from SecurityAgentConfig where AgentId like @p0", Id);
                object dbResult = Database.Instance.ExecuteScalar("select count(*) from SecurityAgentConfig where AgentId like @p0 and PropertyName like @p1", Id, key);
                int found = Db.DbValueConverter.ToInt(dbResult);
                string sql;
                if (found > 0) {
                    sql = "update SecurityAgentConfig set PropertyValueString = @p0 where AgentId like @p1 and PropertyName like @p2";
                } else {
                    sql = "insert into SecurityAgentConfig (PropertyValueString, AgentId, PropertyName) values(@p0,@p1,@p2)";
                }
                Database.Instance.ExecuteNonQuery(sql, CustomConfiguration[key], Id, key);
            }
        }

        public void UpdateStatistics() {
            string sqlString = "select FailedLogins, HardLocks, SoftLocks from AgentStatistics where AgentId=@p0";
            int hardLocks, failedLogins, softLocks;
            try {
                IDataReader rdr = Database.Instance.ExecuteReader(sqlString, Id);
                if (rdr.Read()) {
                    hardLocks = Db.DbValueConverter.ToInt(rdr["HardLocks"]);
                    failedLogins = Db.DbValueConverter.ToInt(rdr["FailedLogins"]);
                    softLocks = Db.DbValueConverter.ToInt(rdr["SoftLocks"]);
                    if (hardLocks != HardLocks || softLocks != SoftLocks || failedLogins != FailedLogins) {
                        HardLocks = hardLocks;
                        SoftLocks = softLocks;
                        FailedLogins = failedLogins;
                        OnStatisticsUpdated();
                    }
                } else {
                    HardLocks = 0;
                    FailedLogins = 0;
                    SoftLocks = 0;
                }
                rdr.Close();

            } catch { }
        }

        private void OnStatisticsUpdated() {
            if (StatisticsUpdated != null) StatisticsUpdated(this, EventArgs.Empty);
        }

        public Guid GetId() {
            if (Id != null && !Id.Equals(Guid.Empty)) return Id;
            // if agent does not provide ID, set the ID from this agent. Otherwise read from database
            if (!Database.Instance.IsConfigured) Database.Instance.Configure(IddsConfig.PluginDirectory);
            object result = Database.Instance.ExecuteScalar("Select AgentId from SecurityAgents where AssemblyName = @p0", AssemblyName);
            if (result != null) {
                Guid id = Db.DbValueConverter.ToGuid(result);
                if (id != null && id != Guid.Empty) {
                    return id;
                }
            }
            // last thing, return new guid --> should never happen when agents are configured properly
            return Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int HardLockAttempts { get; set; }
        public int SoftLockAttempts { get; set; }
        public int SoftLockTimeMinutes { get; set; }
        public int HardLockTimeHours { get; set; }
        public bool OverrideConfig { get; set; }
        public string DisplayName { get; set; }
        public bool LockForever { get; set; }
        public bool Enabled { get; set; }
        public int Serial { get; set; }
        public string AssemblyName { get; set; }
        public string AssemblyFilename { get; set; }
        public bool BinaryMissing { get; set; }
        public AppDomain AppDomain { get; set; }

        public LockType GetCurrentLockType(string IpAddress) {
            int unsuccessfulLogins = IntrusionLog.GetIncidentsByAgentId(Id, IpAddress);
            if (OverrideConfig) {
                if (unsuccessfulLogins >= HardLockAttempts) return LockType.HardLockRequested;
                if (unsuccessfulLogins >= SoftLockAttempts) return LockType.SoftLockRequested;
                return LockType.None;
            } else {
                if (unsuccessfulLogins >= IddsConfig.Instance.HardLockAttempts) return LockType.HardLockRequested;
                if (unsuccessfulLogins >= IddsConfig.Instance.SoftLockAttempts) return LockType.SoftLockRequested;
                return LockType.None;
            }
        }

        private Dictionary<string, string> _customConfiguration;
        public Dictionary<string,string> CustomConfiguration {
            get {
                if (_customConfiguration == null) _customConfiguration = new Dictionary<string,string>();
                return _customConfiguration;
            }
            set {
                _customConfiguration = value;
            }
        }

    }
}

