using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using System.Data;

namespace Cyberarms.IntrusionDetection.Shared {
    public class IddsConfig {

        public const int ENABLED_FEATURES_FREE = 1;
        public const int ENABLED_FEATURES_PRO = 2;
        public const int CONFIG_DB_VERSION_NUMBER = 1;
        public const string LICENSE_FILE = "idds.vl";

        public const string CONFIG_VALUE_IS_DEBUG = "Configuration.IsDebug";
        

        //private const string LICENSE_SERVER = "http://localhost:54996/activation.cyberarms.net2/";
        private const int IDDS_PRODUCT_ID = 0x66;
        // production server
        private const string LICENSE_SERVER = "https://cyberarms.net/activationV2/";

        private static IddsConfig _instance;
        public static IddsConfig Instance {
            get {
                if (_instance == null) {
                    _instance = new IddsConfig();
                    _instance.Load();
                }
                return _instance;
            }
            set {
                _instance = value;
            }
        }

        public string PluginsDirectory { get; set; }

        
        


        public void Save() {
            //throw new NotImplementedException("Save functionality not implemented yet");
            if (!Database.Instance.IsConfigured) configureDatabase();
            try {
                Database.Instance.ExecuteNonQuery(@"insert into Configuration(ConfigVersionDate,
                    HardLockAttempts, HardLockTimeHours, LockForever, SoftLockAttempts, SoftLockTimeMinutes,
                    UseSafeNetworkList, PluginDirectory, LicenseKey, ActivationId, SendInfoMail, 
                SmtpPort, SenderEmailAddress, SmtpRequiresAuthentication, NotificationEmailAddress, SmtpServer,
                SmtpUsername, SmtpPassword, CyberSheriffContributor, WebBasedMonitoring, HardwareId, SmtpSslRequired) 
                values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21)",
                    DateTime.Now, HardLockAttempts, HardLockTimeHours,
                    LockForever, SoftLockAttempts, SoftLockTimeMinutes, UseSafeNetworkList, PluginDirectory,
                    DBNull.Value, DBNull.Value, SendInfoMail, SmtpPort, SenderEmailAddress, SmtpRequiresAuthentication,
                    NotificationEmailAddress, SmtpServer, SmtpUsername, SmtpPassword, CyberSheriffContributor, WebBasedMonitoring, DBNull.Value, SmtpSslRequired);


            } catch (Exception ex) {
                throw ex;
            }
        }

        public void Load() {
            if (!Database.Instance.IsConfigured) configureDatabase();
            System.Data.IDataReader reader = null;
            try {
                reader = Database.Instance.ExecuteReader("select * from Configuration order by ConfigVersionNumber desc LIMIT 1");
                if (reader.Read()) {
                    HardLockAttempts = Db.DbValueConverter.ToInt(reader["HardLockAttempts"]);
                    HardLockTimeHours = Db.DbValueConverter.ToInt(reader["HardLockTimeHours"]);
                    LockForever = Db.DbValueConverter.ToBool(reader["LockForever"]);
                    SoftLockAttempts = Db.DbValueConverter.ToInt(reader["SoftLockAttempts"]);
                    SoftLockTimeMinutes = Db.DbValueConverter.ToInt(reader["SoftLockTimeMinutes"]);
                    UseSafeNetworkList = Db.DbValueConverter.ToBool(reader["UseSafeNetworkList"]);
                    PluginDirectory = Db.DbValueConverter.ToString(reader["PluginDirectory"]);
                    SendInfoMail = Db.DbValueConverter.ToBool(reader["SendInfoMail"]);
                    SmtpPort = Db.DbValueConverter.ToInt(reader["SmtpPort"]);
                    SenderEmailAddress = Db.DbValueConverter.ToString(reader["SenderEmailAddress"]);
                    SmtpRequiresAuthentication = Db.DbValueConverter.ToBool(reader["SmtpRequiresAuthentication"]);
                    NotificationEmailAddress = Db.DbValueConverter.ToString(reader["NotificationEmailAddress"]);
                    SmtpServer = Db.DbValueConverter.ToString(reader["SmtpServer"]);
                    SmtpUsername = Db.DbValueConverter.ToString(reader["SmtpUsername"]);
                    SmtpPassword = Db.DbValueConverter.ToString(reader["SmtpPassword"]);
                    CyberSheriffContributor = Db.DbValueConverter.ToBool(reader["CyberSheriffContributor"]);
                    WebBasedMonitoring = Db.DbValueConverter.ToBool(reader["WebBasedMonitoring"]);
                    SmtpSslRequired = Db.DbValueConverter.ToBool(reader["SmtpSslRequired"]);
                    LoadSafeNetworks();
                } else {
                    Database.Instance.ExecuteNonQuery(Db.Version_2_1.CREATE_DEFAULT_CONFIGURATION);
                   
                }

            } catch (Exception ex) {
                throw ex;
            } finally {
                if (reader != null && !reader.IsClosed) reader.Close();
            }
        }

        private Dictionary<string, string> _appConfig;
        public Dictionary<string, string> AppConfig {
            get {
                if (_appConfig == null) {
                    LoadAppConfig();
                }
                return _appConfig;
            }
        }

        public void LoadAppConfig() {
            _appConfig = LoadConfig("AppConfig");
        }

        public string GetConfigValue(string key) {
            if (!AppConfig.ContainsKey(key)) AppConfig.Add(key, String.Empty);
            return AppConfig[key];
        }

        public void SetConfigValue(string key, string value) {
            if (AppConfig.ContainsKey(key)) {
                AppConfig[key] = value;
            } else {
                AppConfig.Add(key, value);
            }
        }

        public void SaveAppConfig() {
            if (!Database.Instance.IsConfigured) configureDatabase();
            System.Data.IDbTransaction trans = Database.Instance.Connection.BeginTransaction();
            try {
                Database.Instance.ExecuteNonQuery("delete from AppConfig", trans);
                foreach (string key in AppConfig.Keys) {
                    object exists = Database.Instance.ExecuteScalar("select count(*) from AppConfig where ConfigKey=@p0", trans, key);
                    int count;
                    if (exists != null && int.TryParse(exists.ToString(), out count) && count > 0) {
                        Database.Instance.ExecuteNonQuery("update AppConfig set @p0 = @p1", trans, key, AppConfig[key]);
                    } else {
                        Database.Instance.ExecuteNonQuery("insert into AppConfig(ConfigKey, ConfigValue) Values(@p0, @p1)", trans, key, AppConfig[key]);
                    }
                }
                trans.Commit();
            } catch (Exception ex) {
                trans.Rollback();
                throw ex;
            } finally {
                trans.Dispose();
            }
        }

        private Dictionary<string, string> LoadConfig(string configTable) {
            if (!Database.Instance.IsConfigured) configureDatabase();
            Dictionary<string, string> config = new Dictionary<string, string>();
            System.Data.IDataReader rdr = Database.Instance.ExecuteReader(String.Format("select ConfigKey, ConfigValue from {0}", configTable));
            while (rdr.Read()) {
                config.Add(Db.DbValueConverter.ToString(rdr["ConfigKey"]), Db.DbValueConverter.ToString(rdr["ConfigValue"]));
            }
            rdr.Close();
            return config;
        }

        public void LoadSafeNetworks() {
            SafeNetworks = LoadNetworkList("WhiteList");
        }

        public void SaveSafeNetworks() {
            if (!Database.Instance.IsConfigured) configureDatabase();
            IDbTransaction trans = Database.Instance.Connection.BeginTransaction();
            try {
                Database.Instance.ExecuteNonQuery("delete from WhiteList");
                foreach (CSafeNetwork net in SafeNetworks) {
                    Database.Instance.ExecuteNonQuery("insert into WhiteList(IpAddress, NetworkMask) values (@p0, @p1)", net.IpAddress, net.SubnetMask);
                }
                trans.Commit();
            } catch (Exception ex) {
                trans.Rollback();
                throw ex;
            }
        }

        public CSafeNetworks LoadNetworkList(string list) {
            if (!Database.Instance.IsConfigured) configureDatabase();
            CSafeNetworks net = new CSafeNetworks();
            IDataReader rdr = Database.Instance.ExecuteReader(String.Format("Select IpAddress, NetworkMask from {0}", list));
            while (rdr.Read()) {
                net.Add(new CSafeNetwork(Db.DbValueConverter.ToString(rdr["IpAddress"]), Db.DbValueConverter.ToString(rdr["NetworkMask"])));
            }
            rdr.Close();
            return net;
        }


        internal void configureDatabase() {
            if (!String.IsNullOrEmpty(ApplicationPath)) {
                Database.Instance.Configure(ApplicationPath);
            } else {
                throw new FieldAccessException("ApplicationPath not provided. Please configure application path!");
            }
        }


       

        public string ApplicationPath { get; set; }

        public int ConfigVersionNumber { get; set; }
        public DateTime? Expires { get; set; }
        public string Edition { get; set; }

        
        private IddsConfig() {
        }

    
        /*
         * 
         * Configuration values for IDDS plus Security Agents
         * 
         * 
         */

        public int HardLockAttempts { get; set; }
        public int HardLockTimeHours { get; set; }
        public bool LockForever { get; set; }
        public int SoftLockAttempts { get; set; }
        public int SoftLockTimeMinutes { get; set; }
        public bool UseSafeNetworkList { get; set; }
        public static string PluginDirectory { get; set; }

        /* private string _hardwareId;
        private string GetHardwareId() {
            if (String.IsNullOrEmpty(_hardwareId)) {

                _hardwareId = KeyHelper.GetCurrentHardwareId();
            }
            return _hardwareId;
        } */

        // public string LicenseKey { get; set; }

        public bool CyberSheriffContributor { get; set; }

        private CSafeNetworks _safeNetworks;
        public CSafeNetworks SafeNetworks {
            get {
                if (_safeNetworks == null) {
                    _safeNetworks = SafeNetworks = LoadNetworkList("WhiteList");
                }
                return _safeNetworks;
            }
            set {
                _safeNetworks = value;
            }
        }

        public static IddsConfig GetDefaultConfiguration() {
            IddsConfig config = new IddsConfig();
            config.HardLockAttempts = 10;
            config.SoftLockAttempts = 3;
            config.HardLockTimeHours = 24; // 24 hours
            config.SoftLockTimeMinutes = 30;
            config.LockForever = false;
            config.UseSafeNetworkList = false;
            config.SafeNetworks = new CSafeNetworks();
            config.SenderEmailAddress = "Cyberarms.IDDS@" + System.Net.Dns.GetHostEntry("localhost").HostName;
            //config.AgentConfigurations.GetAgentConfig(PluginDirectory + "Cyberarms.IntrusionDetection.Base.Plugins.dll", "WindowsSecurityBase");
            //config.AgentConfigurations[0].Enabled = true;
            return config;
        }

        public class CSafeNetworks : List<CSafeNetwork> { }
        public class CSafeNetwork {
            public string IpAddress { get; set; }
            public string SubnetMask { get; set; }
            public string DisplayName {
                get {
                    return String.Format("{0}/{1}", IpAddress, SubnetMask);
                }
            }
            public CSafeNetwork() {
            }
            public CSafeNetwork(string ipAddress, string subnetmask) {
                this.IpAddress = ipAddress;
                this.SubnetMask = subnetmask;
            }
        }

        public bool SendInfoMail { get; set; }

        public string NotificationEmailAddress { get; set; }

        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public bool SmtpSslRequired { get; set; }

        private string _smtpPassword;

        public string SmtpPassword {
            get {
                return _smtpPassword;
            }
            set {
                _smtpPassword = value;
            }
        }

        public string SenderEmailAddress { get; set; }

        public bool SmtpRequiresAuthentication { get; set; }

        public bool WebBasedMonitoring { get; set; }

        private bool? _isDebug;
        public bool IsDebug {
            get {
                if (!_isDebug.HasValue) {
                    bool isDebug;
                    if (bool.TryParse(GetConfigValue(CONFIG_VALUE_IS_DEBUG), out isDebug)) {
                        _isDebug = isDebug;
                    } else {
                        _isDebug = false;
                    }
                }
                return _isDebug.Value;
            }
            set {
                _isDebug = value;
                SetConfigValue(CONFIG_VALUE_IS_DEBUG, value.ToString());
            }
        }


        public string GetSmtpPassword() {
            string smtpPassword = String.Empty;
            if (!String.IsNullOrEmpty(SmtpPassword)) {
                smtpPassword = CryptoHelper.Decrypt(SmtpPassword, true);
            }
            return smtpPassword;
        }

        public bool IsInSafeNetwork(string ipAddress) {
            bool result = false;
            try {
                System.Net.IPAddress address = System.Net.IPAddress.Parse(ipAddress);
                foreach (CSafeNetwork net in SafeNetworks) {
                    try {
                        if (IPAddress.Parse(net.IpAddress).AddressFamily.Equals(address.AddressFamily)) {
                            switch (address.AddressFamily) {
                                case System.Net.Sockets.AddressFamily.InterNetwork:
                                    result = IsIp4InNetwork(address, IPAddress.Parse(net.IpAddress), net.SubnetMask);
                                    break;
                                case System.Net.Sockets.AddressFamily.InterNetworkV6:
                                    result = IsIp6InNetwork(address, IPAddress.Parse(net.IpAddress), int.Parse(net.SubnetMask));
                                    break;
                            }
                        }
                        if (result) return true;
                    } catch {
                        // ignore error, function returns false if none found
                    }
                }

            } catch { }
            return false;

        }


        public bool IsIp4InNetwork(IPAddress address, IPAddress networkAddress, string subnetMask) {
            return IsIpInNetwork(address, networkAddress, GetSubnetMaskBits(subnetMask), 4);
        }

        public bool IsIpInNetwork(IPAddress address, IPAddress networkAddress, int maskBits, int addressLength) {
            int count = 0;
            byte[] addressBytes = address.GetAddressBytes();
            byte[] networkBytes = networkAddress.GetAddressBytes();
            for (int i = 0; i < addressLength; i++) {
                string addressBits = Convert.ToString(addressBytes[i], 2).PadLeft(8);
                string networkBits = Convert.ToString(networkBytes[i], 2).PadLeft(8);
                for (int n = 0; n < 8; n++) {
                    if (addressBits.Substring(n, 1).Equals(networkBits.Substring(n, 1))) {
                        count++;
                        if (count == maskBits) return true;
                    } else {
                        return false;
                    }
                }
            }
            return false;
        }

        private List<System.Net.IPAddress> _localAddresses;


        public bool IsIpAddressLocal(System.Net.IPAddress address) {
            if (_localAddresses == null) {
                _localAddresses = new List<System.Net.IPAddress>();
                foreach (System.Net.NetworkInformation.NetworkInterface iface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()) {
                    System.Net.NetworkInformation.IPInterfaceProperties iprop = iface.GetIPProperties();
                    foreach (System.Net.NetworkInformation.UnicastIPAddressInformation info in iprop.UnicastAddresses) {
                        _localAddresses.Add(info.Address);
                    }
                }
            }
            return _localAddresses.Contains(address);
        }


        public int GetSubnetMaskBits(string subnetMask) {
            if (!subnetMask.Contains(".") && int.Parse(subnetMask) > 2 && int.Parse(subnetMask) < 33) return int.Parse(subnetMask);
            string[] s = subnetMask.Split('.');
            if (s.Length < 4) throw new ArgumentException("No valid subnetmask entered");
            int result = 0;
            for (int i = 0; i < 4; i++) {
                byte b = (byte)int.Parse(s[i]);
                string bin = Convert.ToString(b, 2);
                for (int n = 0; n < 8; n++) {
                    if (bin.Substring(n, 1) == "1") {
                        result++;
                    } else {
                        return result;
                    }
                }

            }
            if (result == 32) return result;
            throw new ArgumentException("Error while parsing subnet mask");
        }

        public bool IsIp6InNetwork(IPAddress address, IPAddress networkAddress, int subnetMask) {
            return IsIpInNetwork(address, networkAddress, subnetMask, 16);
        }


        public static bool IsValidIpAddress(string ipAddress) {
            System.Net.IPAddress validIpAddress = null;
            return System.Net.IPAddress.TryParse(ipAddress, out validIpAddress);
        }

        public static bool IsValidSubnetMask(string subnetMask) {
            return IsValidIpAddress(subnetMask);
        }

        public static string ConvertStringToIpAddressNetwork(string ipAddressNetwork) {
            string ip, net;
            int subnetMaskBits = 0;
            ipAddressNetwork = ipAddressNetwork.Trim();
            if (!ipAddressNetwork.Contains("/")) {
                if (!IsValidIpAddress(ipAddressNetwork)) {
                    throw new ArgumentException("No valid IP address provided!");
                }
                return ipAddressNetwork + "/255.255.255.255";
            } else {
                ip = ipAddressNetwork.Split('/')[0];
                net = ipAddressNetwork.Split('/')[1];
                if (!IsValidIpAddress(ip)) {
                    throw new ArgumentException("No valid IP address was provided. Please enter a valid IP address in the form xxx.xxx.xxx.xxx!");
                }
                if (int.TryParse(net, out subnetMaskBits)) {
                    if (System.Net.IPAddress.Parse(ip).AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && 7 < subnetMaskBits && subnetMaskBits < 33) {
                        long netmask = 0;
                        for (int b = 31; b > 31 - subnetMaskBits; b--) {
                            netmask += (long)Math.Pow(2, (double)b);
                        }
                        net = netmask.ToString();
                    } else if (System.Net.IPAddress.Parse(ip).AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) {
                        if (subnetMaskBits < 12 || subnetMaskBits > 128) {
                            throw new ArgumentException("Invalid subnet mask for IPv6 address. Please enter the subnet mask as number from 12 to 128!");
                        }
                    }
                } else {

                    if (!IsValidSubnetMask(net)) {
                        throw new ArgumentException("Invalid subnet mask. Please enter the subnet mask either as number from 8 to 32 or in the form xxx.xxx.xxx.xxx!");
                    }
                }
                ip = System.Net.IPAddress.Parse(ip).ToString();
                if (System.Net.IPAddress.Parse(ip).AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) net = System.Net.IPAddress.Parse(net).ToString();
                ipAddressNetwork = ip + "/" + net;
            }
            return ipAddressNetwork;
        }




        public void SetSmtpPassword(string password) {
            SmtpPassword = CryptoHelper.Encrypt(password, true);
        }


//        public void WriteAgentConfiguration(Cyberarms.IntrusionDetection.Api.Plugin.IAgentConfiguration agentConfiguration) {
//            // find the agent first
//            if (!Database.Instance.IsConfigured) configureDatabase();
//            Guid agentId = GetAgentId(agentConfiguration.AgentName);

//            string writeConfigCmd;
//            if (agentId != Guid.Empty) {
//                writeConfigCmd = @"update SecurityAgents set HardLockAttempts = @p2, HardLockTimeHours = @p3,
//LockForever = @p4, SoftLockAttempts = @p5, SoftLockTimeMinutes=@p6, OverwriteConfiguration=@p7 where AssemblyName = @p0";
//            } else {
//                // agent not configured in database
//                agentId = Guid.NewGuid();
//                writeConfigCmd = @"insert into SecurityAgents(AssemblyName, AgentId, HardLockAttempts, HardLockTimeHours,
//LockForever, SoftLockAttempts, SoftLockTimeMinutes, OverwriteConfiguration) values (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
//            }
//            Database.Instance.ExecuteNonQuery(writeConfigCmd, agentConfiguration.AssemblyName, agentId.ToString(),
//                agentConfiguration.HardLockAttempts, agentConfiguration.HardLockDurationHrs,
//                agentConfiguration.NeverUnlock, agentConfiguration.SoftLockAttempts, agentConfiguration.SoftLockDurationMins, agentConfiguration.OverwriteConfiguration);

//        }

        //public Guid GetAgentId(string displayName) {
        //    string cmd = "Select AgentId from  SecurityAgents where DisplayName like @p0";
        //    try {
        //        object result = Database.Instance.ExecuteScalar(cmd, displayName);
        //        Guid agentId;
        //        if (result != null && Guid.TryParse(result.ToString(), out agentId)) return agentId;
        //    } catch (Exception ex) {
        //        throw ex;
        //    }
        //    return Guid.Empty;
        //}

        public int GetSoftLockMinutes(SecurityAgent agent) {
            if (agent.OverrideConfig) {
                return agent.SoftLockTimeMinutes;
            }
            return SoftLockTimeMinutes;
        }

        
        public int GetHardLockHours(SecurityAgent agent) {
            int hardLockHours;
            if (agent.OverrideConfig) {
                hardLockHours = agent.HardLockTimeHours;
                if (agent.LockForever) hardLockHours = (int)DateTime.MaxValue.Subtract(DateTime.Now).TotalHours;
            } else {
                hardLockHours = HardLockTimeHours;
                if (LockForever) hardLockHours = (int)DateTime.MaxValue.Subtract(DateTime.Now).TotalHours;
            }
            return hardLockHours;
        }

        //         public const string TABLE_SECURITY_AGENTS = @"
        //CREATE TABLE SecurityAgents(
        //    AgentId uniqueidentifier PRIMARY KEY not null,
        //    HardLockAttempts int NOT NULL,
        //	HardLockTimeHours int NOT NULL,
        //	LockForever bit NOT NULL,
        //	SoftLockAttempts int NOT NULL,
        //	SoftLockTimeMinutes int NOT NULL,
        //    CurrentConfigSet int null
        //)";

        //        public const string TABLE_SECURITY_AGENT_CONFIG = @"
        //CREATE TABLE SecurityAgentConfig(
        //    ConfigSet int not null,
        //    AgentId uniqueidentifier not null,
        //    PropertyName uniqueidentifier not null,
        //    PropertyValueString nvarchar(255) null
        //)";


    }
}
