using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using Cyberarms.IntrusionDetection.Shared;
using System.Net.Mail;

namespace Cyberarms.IntrusionDetection
{
    public partial class Service : ServiceBase
    {

        internal event EventHandler ClientIpAddressSoftLocked;
        internal event EventHandler ClientIpAddressUnlocked;
        internal event EventHandler ClientIpAddressHardLocked;

        delegate void StartServiceDelegate();


        // private LogAlerts logAlerts;
        private System.Timers.Timer cleanupTimer = new System.Timers.Timer();


        // private bool restartPending = false;
        // private System.Timers.Timer restartTimer = new System.Timers.Timer(2000);
        private bool isInitialized;

        public Service()
        {
            InitializeComponent();
            isInitialized = false;
            ConfigureSystem();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = false;
            this.CanShutdown = true;
            this.EventLog.Source = Globals.APPLICATION_NAME;
            this.ClientIpAddressSoftLocked += new EventHandler(Service_ClientIpAddressSoftLocked);
            this.ClientIpAddressUnlocked += new EventHandler(Service_ClientIpAddressUnlocked);
            this.ClientIpAddressHardLocked += new EventHandler(Service_ClientIpAddressHardLocked);
            // IntrusionDetectionConfiguration.PluginDirectory = System.Windows.Forms.Application.StartupPath + "\\Plugins\\";
            ReportScheduler.Instance.RunDailyReport += new EventHandler(Instance_RunDailyReport);
            ReportScheduler.Instance.RunWeeklyReport += new EventHandler(Instance_RunWeeklyReport);
            ReportScheduler.Instance.RunMonthlyReport += new EventHandler(Instance_RunMonthlyReport);
            ReportScheduler.Instance.StartReporting();
            // Configuration.Instance.ConfigurationChanged += new EventHandler(Instance_ConfigurationChanged);

        }

        void Instance_RunMonthlyReport(object sender, EventArgs e)
        {
            try
            {
                DateTime end = DateTime.Now.AddDays(-1);
                DateTime start = new DateTime(end.Year, end.Month, 1, 0, 0, 0);
                string report = ReportGenerator.Instance.GetReport("Monthly Report", String.Format("Report for {0}/{1}", start.Month, start.Year), String.Format("Server: {0}", System.Net.Dns.GetHostName()),
                    start, new DateTime(end.Year, end.Month, end.Day, 23, 59, 59));
                SendMail(String.Format("Monthly report for {0}", System.Net.Dns.GetHostName()), report);
            }
            catch (Exception ex)
            {
                WindowsLogManager.Instance.WriteEntry(ex.Message, EventLogEntryType.Error, Globals.CYBERARMS_EVENT_ID_CONFIGURATION_ERROR, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
            }
        }

        void Instance_RunWeeklyReport(object sender, EventArgs e)
        {
            try
            {
                DateTime end = DateTime.Now.AddDays(-1);
                DateTime start = end.AddDays(-6);
                string report = ReportGenerator.Instance.GetReport("Weekly Report", String.Format("Week of {0}-{1}-{2}", start.Year, start.Month, start.Day), String.Format("Server: {0}", System.Net.Dns.GetHostName()),
                    new DateTime(start.Year, start.Month, start.Day, 0, 0, 0), new DateTime(end.Year, end.Month, end.Day, 23, 59, 59));
                SendMail(String.Format("Weekly report for {0}", System.Net.Dns.GetHostName()), report);
            }
            catch (Exception ex)
            {
                WindowsLogManager.Instance.WriteEntry(ex.Message, EventLogEntryType.Error, Globals.CYBERARMS_EVENT_ID_CONFIGURATION_ERROR, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
            }
        }

        void Instance_RunDailyReport(object sender, EventArgs e)
        {
            try
            {
                DateTime d = DateTime.Now.AddDays(-1);
                string report = ReportGenerator.Instance.GetReport("Daily Report", String.Format("{0}-{1}-{2}", d.Year, d.Month, d.Day), String.Format("Server: {0}", System.Net.Dns.GetHostName()),
                    new DateTime(d.Year, d.Month, d.Day, 0, 0, 0), new DateTime(d.Year, d.Month, d.Day, 23, 59, 59));
                SendMail(String.Format("Daily report for {0}", System.Net.Dns.GetHostName()), report);
            }
            catch (Exception ex)
            {
                WindowsLogManager.Instance.WriteEntry(ex.Message, EventLogEntryType.Error, Globals.CYBERARMS_EVENT_ID_CONFIGURATION_ERROR, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
            }
        }


        void ConfigureSystem()
        {
            Database.Instance.Configure(System.Windows.Forms.Application.StartupPath);

            IddsConfig.Instance.ApplicationPath = System.Windows.Forms.Application.StartupPath;
            IddsConfig.Instance.PluginsDirectory = System.Windows.Forms.Application.StartupPath + "\\Plugins\\";
            IddsConfig.Instance.Load();
            SecurityAgents.Instance.RegisterSecurityAgents();
        }

        //void Instance_ConfigurationChanged(object sender, EventArgs e) {
        //    restartPending = true;
        //    restartTimer.Enabled = true;
        //}

        void Service_ClientIpAddressHardLocked(object sender, EventArgs e)
        {
            ClientOperationInformation op = (ClientOperationInformation)sender;
            IntrusionLog.AddEntry(DateTime.Now, op.AgentId, op.IpAddress, IntrusionLog.STATUS_HARD_LOCKED, false);
            SendInfoMail(sender, LockType.HardLock);
        }

        void Service_ClientIpAddressUnlocked(object sender, EventArgs e)
        {
            ClientOperationInformation op = (ClientOperationInformation)sender;
            if (op.HasError)
            {
                IntrusionLog.AddEntry(DateTime.Now, IntrusionLog.GetSystemId(), op.IpAddress, IntrusionLog.STATUS_UNLOCK_ERROR, false);
            }
            else
            {
                IntrusionLog.AddEntry(DateTime.Now, IntrusionLog.GetSystemId(), op.IpAddress, IntrusionLog.STATUS_UNLOCKED, false);
            }
            SendInfoMail(sender, LockType.None);
        }

        void Service_ClientIpAddressSoftLocked(object sender, EventArgs e)
        {
            ClientOperationInformation op = (ClientOperationInformation)sender;
            IntrusionLog.AddEntry(DateTime.Now, op.AgentId, op.IpAddress, IntrusionLog.STATUS_SOFT_LOCKED, false);
            SendInfoMail(sender, LockType.SoftLock);
        }

        void OnClientIpAddressHardLocked(Lock lockItem, Exception ex, Guid agentId)
        {
            if (this.ClientIpAddressHardLocked != null)
            {
                ClientOperationInformation co = GetClientOperationInformation(lockItem.IpAddress, ex, "hard");
                co.AgentId = agentId;
                ClientIpAddressHardLocked(co, EventArgs.Empty);
            }
        }

        private ClientOperationInformation GetClientOperationInformation(string ipAddress, Exception ex, string info)
        {
            ClientOperationInformation op = new ClientOperationInformation();
            op.IpAddress = ipAddress;
            op.Exception = ex;
            if (ex != null)
            {
                op.HasError = true;
                op.Message = "Error while trying to " + info + " lock client with IP address " + ipAddress + ":\r\n" + ex.Message;
            }
            else
            {
                op.Message = "Client with IP address " + ipAddress + " was " + info + " locked";
            }
            return op;
        }

        void OnClientIpAddressSoftLocked(Lock lockItem, Exception ex, Guid agentId)
        {
            if (this.ClientIpAddressSoftLocked != null)
            {
                ClientOperationInformation co = GetClientOperationInformation(lockItem.IpAddress, ex, "soft");
                co.AgentId = agentId;
                ClientIpAddressSoftLocked(co, EventArgs.Empty);
            }
        }

        void OnClientIpAddressUnlocked(Lock lockItem, Exception ex)
        {
            if (ClientIpAddressUnlocked != null)
            {
                ClientOperationInformation op = new ClientOperationInformation();
                op.IpAddress = lockItem.IpAddress;
                op.Exception = ex;
                op.AgentId = IntrusionLog.GetSystemId();
                if (ex != null)
                {
                    op.HasError = true;
                    op.Message = "Error while unlocking " + lockItem.IpAddress + ":\r\n" + ex.Message;
                }
                else
                {
                    op.Message = "Client with IP address " + lockItem.IpAddress + " was unlocked";
                }
                ClientIpAddressUnlocked(op, EventArgs.Empty);
            }
        }


        void SendInfoMail(object o, LockType lockOperation)
        {
            //if (!Configuration.Instance.IntrusionDetectionConfiguration.SendInfoMail) return;
            //if (!IddsConfig.Instance.SendInfoMail) return;

            if (o == null || !(o is ClientOperationInformation)) return;
            ClientOperationInformation op = (ClientOperationInformation)o;
            try
            {
                string subject = string.Empty;
                switch (lockOperation)
                {
                    case LockType.None:
                        if (!NotificationSettings.Instance.OnUnlock) return;
                        subject = "Cyberarms IDDS: Unlock notification (" + op.IpAddress + ")";
                        break;
                    case LockType.SoftLock:
                        if (!NotificationSettings.Instance.OnSoftLock) return;
                        subject = "Cyberarms IDDS: Soft lock notification (" + op.IpAddress + ")";
                        break;
                    case LockType.HardLock:
                        if (!NotificationSettings.Instance.OnHardLock) return;
                        subject = "Cyberarms IDDS: Hard lock notification (" + op.IpAddress + ")";
                        break;
                }
                SendMail(subject, op.Message);
            }
            catch (Exception ex)
            {
                WindowsLogManager.Instance.WriteEntry("Error while sending notification email.\r\n" + ex.Message,
                            EventLogEntryType.Error, Globals.CYBERARMS_EVENT_ID_INVALID_FUNCTION_CALL, Globals.CYBERARMS_LOG_CATEGORY_PLUGIN);
            }
        }

        void SendMail(string subject, string message)
        {
            try
            {
                if (!String.IsNullOrEmpty(IddsConfig.Instance.SmtpServer) && !String.IsNullOrEmpty(IddsConfig.Instance.SenderEmailAddress)
                    && !String.IsNullOrEmpty(IddsConfig.Instance.NotificationEmailAddress))
                {
                    SmtpClient server = new SmtpClient(IddsConfig.Instance.SmtpServer);
                    server.Port = IddsConfig.Instance.SmtpPort == 0 ? 25 : IddsConfig.Instance.SmtpPort;
                    if (IddsConfig.Instance.SmtpRequiresAuthentication)
                    {
                        server.Credentials = new System.Net.NetworkCredential(
                            IddsConfig.Instance.SmtpUsername,
                            IddsConfig.Instance.GetSmtpPassword());
                    }
                    server.EnableSsl = IddsConfig.Instance.SmtpSslRequired;
                    MailMessage msg = new MailMessage(IddsConfig.Instance.SenderEmailAddress,
                        IddsConfig.Instance.NotificationEmailAddress, subject, message);
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.SubjectEncoding = Encoding.UTF8;
                    server.Send(msg);
                }
            }
            catch { }
        }



        private void Init()
        {

            cleanupTimer.Interval = 1000;
            cleanupTimer.Elapsed += new System.Timers.ElapsedEventHandler(cleanupTimer_Elapsed);
            // restartTimer.Elapsed += new System.Timers.ElapsedEventHandler(restartTimer_Elapsed);
                WindowsLogManager.Instance.WriteEntry("Intrusion Detection Service was initialized successfully.", EventLogEntryType.Information,
                   Globals.CYBERARMS_EVENT_ID_INFORMATION, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
            isInitialized = true;
        }



        void cleanupTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<Lock> timedOutLocks = Locks.GetUnlockList();
            foreach (Lock l in timedOutLocks)
            {
                l.Status = Lock.LOCK_STATUS_UNLOCKED;
                l.Save();
            }
            foreach (Lock l in timedOutLocks)
            {
                try
                {
                    FirewallPolicyManager.Instance.RemoveIpAddressFromBlockList(l.IpAddress);
                    // IntrusionLog.AddEntry(DateTime.Now, Guid.Empty, l.IpAddress, IntrusionLog.STATUS_UNLOCK_REQUESTED, false);
                    OnClientIpAddressUnlocked(l, null);
                    //l.Save();
                }
                catch (Exception ex)
                {
                    // IntrusionLog.AddEntry(DateTime.Now, Guid.Empty, l.IpAddress, IntrusionLog.STATUS_UNLOCK_ERROR, false);
                    WindowsLogManager.Instance.WriteEntry(String.Format("IP address {0} cannot be unlocked. Error details: {1}",
                        l.IpAddress, ex.Message),
                        EventLogEntryType.Error, Globals.CYBERARMS_EVENT_ID_INVALID_FUNCTION_CALL, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
                    if (FirewallPolicyManager.Instance.IsLocked(l.IpAddress))
                    {
                        l.Status = Lock.LOCK_STATUS_UNLOCK_ERROR;
                    }
                    else
                    {
                        l.Status = Lock.LOCK_STATUS_UNLOCKED;
                    }
                    l.Save();
                    OnClientIpAddressUnlocked(l, ex);
                }
                //if (l.UnlockDate < DateTime.Now.AddDays(-1) || (l.Status == Lock.LOCK_STATUS_LOCK_ERROR || l.Status == Lock.LOCK_STATUS_UNLOCK_ERROR)) {
                //    l.Status = Lock.LOCK_STATUS_HISTORY;
                //}
            }
        }


        public bool LimitMailSent { get; set; }

        void LockDownIp(Lock lockItem, LockType lockType, SecurityAgent reportingAgent)
        {
            int locksForToday = Locks.Today();
            LimitMailSent = false;
            try
            {
                // TO DO: Hard Lock overrides Soft Lock!
                if (FirewallPolicyManager.Instance.IsLocked(lockItem.IpAddress))
                {
                    WindowsLogManager.Instance.WriteEntry("Received another request to lock IP address " + lockItem.IpAddress +
                                ". This IP address is already locked.", EventLogEntryType.Information, Globals.CYBERARMS_EVENT_ID_INFORMATION,
                                Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
                    return;
                }
            }
            catch (Exception ex)
            {
                WindowsLogManager.Instance.WriteEntry("Intrusion Detection Service had an error:" + ex.Message, EventLogEntryType.Error,
                      Globals.CYBERARMS_EVENT_ID_CONFIGURATION_ERROR, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
            }
            WindowsLogManager.Instance.WriteEntry(String.Format("{0} lock: Unsuccessful login attempts from ip address {1} exceeded threshold. Firewall rule is being created to block the address specified.",
                lockType == LockType.HardLock ? "Hard" : "Soft", lockItem.IpAddress), EventLogEntryType.FailureAudit, Globals.CYBERARMS_EVENT_ID_FIREWALL_RULE_CREATED,
                        Globals.CYBERARMS_LOG_CATEGORY_SECURITY);
            // lockItem.Id = Locks.CreateLock(lockItem);
            try
            {
                FirewallPolicyManager.Instance.Block(lockItem.IpAddress);
                switch (lockType)
                {
                    case LockType.SoftLock:
                        lockItem.Status = Lock.LOCK_STATUS_SOFTLOCK;
                        Statistics.Instance.IncreaseSoftLockStatistics(reportingAgent);
                        break;
                    case LockType.HardLock:
                        lockItem.Status = Lock.LOCK_STATUS_HARDLOCK;
                        Statistics.Instance.IncreaseHardLockStatistics(reportingAgent);
                        break;
                }
            }
            catch
            {
                lockItem.Status = Lock.LOCK_STATUS_LOCK_ERROR;
            }
            switch (lockType)
            {
                case LockType.SoftLock:
                    OnClientIpAddressSoftLocked(lockItem, null, reportingAgent.Id);
                    break;
                case LockType.HardLock:
                    OnClientIpAddressHardLocked(lockItem, null, reportingAgent.Id);
                    break;
            }
            lockItem.Save();


        }



        protected override void OnStart(string[] args)
        {
            StartServiceDelegate serviceStarter = new StartServiceDelegate(StartService);
            IAsyncResult result = serviceStarter.BeginInvoke(new AsyncCallback(StartServiceHandler), null);
        }

        void StartServiceHandler(IAsyncResult result)
        {
            // service started
        }

        void StartService()
        {
            try
            {
                if (!isInitialized) Init();
                // FirewallPolicyManager.Instance.CleanUpRules();
                InitAgentConfiguration();
                LoadAgents();
                SecurityAgents.Instance.StartAgents();
                cleanupTimer.Enabled = true;
                WindowsLogManager.Instance.WriteEntry("Intrusion Detection Service was started successfully.", EventLogEntryType.Information,
    Globals.CYBERARMS_EVENT_ID_INFORMATION, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);

            }
            catch (Exception ex)
            {
                WindowsLogManager.Instance.WriteEntry("Intrusion Detection Service had a startup error. Details:" + ex.Message, EventLogEntryType.Error,
    Globals.CYBERARMS_EVENT_ID_CONFIGURATION_ERROR, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
            }
        }


        protected override void OnStop()
        {
            SecurityAgents.Instance.StopAgents();
            cleanupTimer.Enabled = false;
            WindowsLogManager.Instance.WriteEntry("Intrusion Detection Service was stopped.", EventLogEntryType.Information,
    Globals.CYBERARMS_EVENT_ID_INFORMATION, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
            UnloadAgents();
        }

        protected override void OnPause()
        {
            SecurityAgents.Instance.PauseAgents();
            //SecurityAgents.Instance.UnloadAgents();
            cleanupTimer.Enabled = false;
            WindowsLogManager.Instance.WriteEntry("Intrusion Detection Service was paused.", EventLogEntryType.Information,
    Globals.CYBERARMS_EVENT_ID_INFORMATION, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);

        }

        protected override void OnContinue()
        {
            //SecurityAgents.Instance.LoadAgents();
            SecurityAgents.Instance.ContinueAgents();
            cleanupTimer.Enabled = true;
            WindowsLogManager.Instance.WriteEntry("Intrusion Detection Service has continued securing your system.", EventLogEntryType.Information,
    Globals.CYBERARMS_EVENT_ID_INFORMATION, Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
        }

        private void InitAgentConfiguration()
        {
            SecurityAgents.Instance.RegisterSecurityAgents();
        }



        void Service_AttackDetected(object sender, INotificationEventArgs notificationEventArgs)
        {
            try
            {
                if (notificationEventArgs == null)
                {
                    if (IddsConfig.Instance.IsDebug)
                    {
                        // the following error should just be thrown when running in debug mode.
                        throw new ApplicationException("Operation not supported. EventArgs must be passed as NotificationEventArgs");
                    }
                    else
                    {
                        // otherwise write to the log file
                        WindowsLogManager.Instance.WriteEntry("Plugin error: the lock delegate was called, but notificationEventArgs must not be null!",
                            EventLogEntryType.Error, Globals.CYBERARMS_EVENT_ID_INVALID_FUNCTION_CALL, Globals.CYBERARMS_LOG_CATEGORY_PLUGIN);
                        return;
                    }
                }
                SecurityAgent reportingAgent = SecurityAgents.Instance.FindByName((sender as IAgentPlugin).Configuration.AgentName);
                long incidentId;
                if (IddsConfig.IsValidIpAddress(notificationEventArgs.IpAddress))
                {
                    Statistics.Instance.IncreaseFailedLoginStatistics(reportingAgent);
                    System.Net.IPAddress ipAddress;
                    if (System.Net.IPAddress.TryParse(notificationEventArgs.IpAddress, out ipAddress) && IddsConfig.Instance.IsIpAddressLocal(ipAddress))
                    {
                        incidentId = IntrusionLog.AddEntry(notificationEventArgs.CreateDate, reportingAgent.Id, notificationEventArgs.IpAddress,
                            IntrusionLog.STATUS_INTRUSION_ATTEMPT_FROM_LOCAL, false);
                    }
                    else if (IddsConfig.Instance.UseSafeNetworkList && IddsConfig.Instance.IsInSafeNetwork(notificationEventArgs.IpAddress))
                    {
                        incidentId = IntrusionLog.AddEntry(notificationEventArgs.CreateDate, reportingAgent.Id, notificationEventArgs.IpAddress,
                            IntrusionLog.STATUS_INTRUSION_ATTEMPT_FROM_SAFE, false);
                    }
                    else
                    {
                        incidentId = IntrusionLog.AddEntry(notificationEventArgs.CreateDate, reportingAgent.Id, notificationEventArgs.IpAddress,
                            IntrusionLog.STATUS_INTRUSION_ATTEMPT, false);

                        try
                        {
                            if (!Locks.LockExists(notificationEventArgs.IpAddress))
                            {
                                LockType lockType = reportingAgent.GetCurrentLockType(notificationEventArgs.IpAddress);
                                switch (lockType)
                                {
                                    case LockType.SoftLockRequested:
                                        //IntrusionLog.AddEntry(notificationEventArgs.CreateDate, reportingAgent.Id,
                                        //    notificationEventArgs.IpAddress, IntrusionLog.STATUS_SOFT_LOCK_REQUESTED, false);
                                        LockDownIp(Locks.CreateLock(DateTime.Now, DateTime.Now.AddMinutes(IddsConfig.Instance.GetSoftLockMinutes(reportingAgent)), incidentId, Lock.LOCK_STATUS_SOFTLOCK, 0, notificationEventArgs.IpAddress), LockType.SoftLock, reportingAgent);
                                        break;
                                    case LockType.SoftLock:
                                        // already locked, ignore
                                        break;
                                    case LockType.HardLockRequested:
                                        //IntrusionLog.AddEntry(notificationEventArgs.CreateDate, reportingAgent.Id,
                                        //    notificationEventArgs.IpAddress, IntrusionLog.STATUS_HARD_LOCK_REQUESTED, false);
                                        LockDownIp(Locks.CreateLock(DateTime.Now, DateTime.Now.AddHours(IddsConfig.Instance.GetHardLockHours(reportingAgent)), incidentId, Lock.LOCK_STATUS_HARDLOCK, 0, notificationEventArgs.IpAddress), LockType.HardLock, reportingAgent);
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WindowsLogManager.Instance.WriteEntry(String.Format("Unrecoverable error: {0}",
                                    ex.Message), EventLogEntryType.FailureAudit, Globals.CYBERARMS_EVENT_ID_PLUGIN_ERROR,
                                    Globals.CYBERARMS_LOG_CATEGORY_RUNTIME);
                            // OnClientIpAddressSoftLocked(new Lock( new Client(notificationEventArgs.IpAddress), ex);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                WindowsLogManager.Instance.WriteEntry(String.Format("AttackDetected delegate invocation of {0} caused a problem. \r\nDetails:\r\n{1}", (sender != null ? sender.GetType().Name : "unknown"), ex.Message),
                    EventLogEntryType.Error, Globals.CYBERARMS_EVENT_ID_PLUGIN_ERROR, Globals.CYBERARMS_LOG_CATEGORY_PLUGIN);
            }
        }



        private void LoadAgents()
        {
            SecurityAgents.Instance.LoadAgents();
            foreach (SecurityAgent agent in SecurityAgents.Instance.LoadedAgents.Keys)
            {
                AgentProxy agentPlugin = (AgentProxy)SecurityAgents.Instance.LoadedAgents[agent];
                if (agent.Enabled)
                {
                    agentPlugin.AttackDetected += new AttackDetectedHandler(Service_AttackDetected);
                }
            }
        }


        private void UnloadAgents()
        {
            SecurityAgents.Instance.UnloadAgents();
        }

    }
}
