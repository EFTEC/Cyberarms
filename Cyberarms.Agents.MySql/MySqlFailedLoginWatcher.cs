using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace Cyberarms.Agents.MySql
{
    //  [PluginAttribute("Intrusion Detection Base Windows Security Agent", "This agent scans and monitors the system eventlog for possible attacks.")]
        public class MySqlFailedLoginWatcher : AgentPlugin, IExtendedInformation{


        private EventLogQuery query;
        private EventLogWatcher watcher;

        internal const string EVENT_LOG_QUERY_MYSQL_SERVER_LOGIN_DENIED = @"<QueryList>
                  <Query Id=""100"" Path=""Application"">
                    <Select Path=""Application"">
                        *[System[(EventID=100) and
                        TimeCreated[timediff(@SystemTime) &lt;= 864000]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public MySqlFailedLoginWatcher()
        {

        }


        /// <summary>
        /// Agent Startup, initialization of our EventLog watcher
        /// </summary>
        protected override void OnStartAgent() {
            query = new EventLogQuery("Application", PathType.LogName,
                String.Format(EVENT_LOG_QUERY_MYSQL_SERVER_LOGIN_DENIED));
            watcher = new EventLogWatcher(query);
            watcher.EventRecordWritten += new EventHandler<EventRecordWrittenEventArgs>(watcher_EventRecordWritten);
            watcher.Enabled = true;
        }

        /// <summary>
        /// Resume from Pause
        /// </summary>
        protected override void OnContinueAgent() {
            watcher.Enabled = true;
        }

        /// <summary>
        /// Pause the agent
        /// </summary>
        protected override void OnPauseAgent() {
            watcher.Enabled = false;
        }

        /// <summary>
        /// Stop the agent
        /// </summary>
        protected override void OnStopAgent() {
            watcher.Enabled = false;
            watcher = null;
            query = null;
        }

        private void watcher_EventRecordWritten(object sender, EventRecordWrittenEventArgs e) {
            try {
                // (new System.Collections.Generic.Mscorlib_CollectionDebugView<System.Diagnostics.Eventing.Reader.EventProperty>(e.EventRecord.Properties)).Items[0]
                foreach (System.Diagnostics.Eventing.Reader.EventProperty prop in e.EventRecord.Properties) {
                    if (Regex.IsMatch(prop.Value.ToString(), "^.*?\bAccess denied\b.*(?:[0-9]{1,3}.){3}[0-9]{1,3}"))
                    {
                        Match ipAddress = Regex.Match(prop.Value.ToString(), "(?:[0-9]{1,3}.){3}[0-9]{1,3}");
                        NotificationEventArgs args = new NotificationEventArgs();
                        args.CreateDate = e.EventRecord.TimeCreated.Value;
                        args.EventId = e.EventRecord.Id;
                        args.IpAddress = ipAddress.Value;
                        System.Net.IPAddress probe;
                        if (System.Net.IPAddress.TryParse(ipAddress.Value, out probe)) {
                            if (probe.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || probe.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) {
                                OnAttackDetected(this, args);
                            }
                        }
                    }
                   
                }

            } catch (Exception ex) {
                EventLog.WriteEntry("Cyberarms.Agents.MySqlServer.MySqlFailedLoginWatcher", ex.Message);
            }
        }

        public string DisplayName {
            get {
                return "MySql Server Security Agent";
            }
            set {

            }
        }

        public Image Icon {
            get {
                return global::Cyberarms.Agents.MySql.Resource.agent15px_sql_dark;
            }
            set {

            }
        }

        public Image SelectedIcon {
            get {
                return global::Cyberarms.Agents.MySql.Resource.agent15px_sql_white;
            }
            set {

            }
        }

        public Image UnselectedIcon {
            get {
                return global::Cyberarms.Agents.MySql.Resource.agent15px_sql_dark; 
            }
            set {

            }
        }


        
        public Guid Id {
            get {
                return new Guid("{EE4906AD-7242-4940-A3B0-81B4E3F16B71}");
            }
        }


    }
}
