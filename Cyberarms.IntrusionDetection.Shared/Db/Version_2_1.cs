using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cyberarms.IntrusionDetection.Shared.Db {


    public class Version_2_1 : DbUpgradeScript {
        public override int INTERNAL_VERSION {
            get {
                return 1;
            }
        }

        public const string TABLE_DB_CONFIG = @"CREATE TABLE DbConfig(Version bigint NOT NULL, UpgradeDate DateTime NOT NULL, UpgradeLog nvarchar(1000), UpgradeSuccessful bit NOT NULL)";

        public const string TABLE_CONFIGURATION = @"
CREATE TABLE Configuration (
    ConfigVersionNumber INTEGER PRIMARY KEY AUTOINCREMENT not null,
    ConfigVersionDate DateTime NULL,
	HardLockAttempts int NOT NULL,
	HardLockTimeHours int NOT NULL,
	LockForever bit NOT NULL,
	SoftLockAttempts int NOT NULL,
	SoftLockTimeMinutes int NOT NULL,
	UseSafeNetworkList bit NOT NULL,
	PluginDirectory nvarchar(255) NULL,
	LicenseKey nvarchar(255) NULL,
	ActivationId nvarchar(255) NULL,
    HardwareId nvarchar(255) NULL,
	SendInfoMail bit NOT NULL,
	SmtpPort int NOT NULL,
	SenderEmailAddress nvarchar(255) NULL,
	SmtpRequiresAuthentication bit NOT NULL,
	NotificationEmailAddress nvarchar(255) NULL,
	SmtpServer nvarchar(255) NULL,
	SmtpUsername nvarchar(255) NULL,
	SmtpPassword nvarchar(255) NULL,
    SmtpSslRequired bit NOT NULL,
	CyberSheriffContributor bit NOT NULL,
	WebBasedMonitoring bit NOT NULL
)";

        public const string CREATE_DEFAULT_CONFIGURATION = @"
INSERT INTO Configuration(ConfigVersionDate, HardLockAttempts, HardLockTimeHours, LockForever,
                SoftLockAttempts, SoftLockTimeMinutes, UseSafeNetworkList, SendInfoMail, SmtpPort, 
                SmtpRequiresAuthentication, SmtpSslRequired, CyberSheriffContributor, WebBasedMonitoring)
        values('4/4/2013',10,24,0,3,20,0,0,25,0,0,0,0)";

        public const string CREATE_DEFAULT_DB_CONFIGURATION = @"
INSERT INTO DbConfig(Version, UpgradeDate, UpgradeLog, UpgradeSuccessful)
        values(1,'now','Initial setup',1)
";

        public const string TABLE_INTRUSION_LOG = @" 
CREATE TABLE IntrusionLog (
    Id INTEGER PRIMARY KEY AUTOINCREMENT not null,
    IncidentTime DateTime null,
    AgentId uniqueidentifier null,
    ClientIP nvarchar(80) null,
    Action int null,
    ActionTriggeredByUser bit null
)";
        public const string TABLE_LOCKS = @"
CREATE TABLE Locks (
    LockId INTEGER PRIMARY KEY AUTOINCREMENT not null,
    LockDate DateTime not null,
    IpAddress nvarchar(60),
    Port int null,
    UnlockDate DateTime null,
    TriggerIncident bigint not null,
    Status int not null, 
    LastUpdate DateTime null
)";
        public const string TABLE_SECURITY_AGENTS = @"
CREATE TABLE SecurityAgents(
    AgentId uniqueidentifier PRIMARY KEY NOT NULL,
    Name nvarchar(250) NOT NULL,
    AssemblyName nvarchar(250) NOT NULL,    
    HardLockAttempts int NULL,
	HardLockTimeHours int NULL,
	LockForever bit NULL,
	SoftLockAttempts int NULL,
	SoftLockTimeMinutes int NULL,
    OverwriteConfiguration bit NOT NULL,
    DisplayName nvarchar(100) NOT NULL,
    Enabled bit NOT NULL DEFAULT 0,
    Serial int NOT NULL DEFAULT 0
)";

        public const string TABLE_SECURITY_AGENT_CONFIG = @"
CREATE TABLE SecurityAgentConfig(
    AgentId uniqueidentifier not null,
    PropertyName nvarchar(255) not null,
    PropertyValueString nvarchar(255) null, 
    PRIMARY KEY(AgentId, PropertyName)
)";

        public const string TABLE_SECURITY_AGENT_CONFIG_CLUSTERED_KEY = @"
ALTER TABLE SecurityAgentConfig ADD CONSTRAINT
	PK_SecurityAgentConfig PRIMARY KEY  
	(
	AgentId,
	PropertyName
	) 
";

        public const string TABLE_WHITE_LIST = @"
CREATE TABLE Whitelist(
    IPAddress nvarchar(80) not null,
    NetworkMask nvarchar(80) not null
)";
        public const string TABLE_BLACKLIST_NETWORKS = @"
CREATE TABLE Blacklist(
    IPAddress nvarchar(80) not null,
    NetworkMask nvarchar(80) not null
)";

        public const string TABLE_APP_CONFIG = @"
CREATE TABLE AppConfig(
    ConfigKey nvarchar(250) PRIMARY KEY not null,
    ConfigValue nvarchar(250) null)";


        public const string TABLE_AGENT_STATISTICS = @"
CREATE TABLE AgentStatistics(
    AgentId uniqueidentifier PRIMARY KEY NOT NULL,
    FailedLogins int not null default 0, 
    HardLocks int not null default 0, 
    SoftLocks int not null default 0)";

        public override void UpgradeDatabase(System.Data.IDbConnection connection) {
            try {
                RunCommand(connection, TABLE_DB_CONFIG);
                RunCommand(connection, TABLE_CONFIGURATION);
                RunCommand(connection, CREATE_DEFAULT_DB_CONFIGURATION);
                RunCommand(connection, CREATE_DEFAULT_CONFIGURATION);                
                RunCommand(connection, TABLE_INTRUSION_LOG);
                RunCommand(connection, TABLE_LOCKS);
                RunCommand(connection, TABLE_SECURITY_AGENT_CONFIG);
                // RunCommand(connection, TABLE_SECURITY_AGENT_CONFIG_CLUSTERED_KEY);
                RunCommand(connection, TABLE_SECURITY_AGENTS);
                RunCommand(connection, TABLE_APP_CONFIG);
                RunCommand(connection, TABLE_WHITE_LIST);
                RunCommand(connection, TABLE_AGENT_STATISTICS);
            } catch (Exception ex) {
                throw (ex);
            }
        }

        

    }
}
