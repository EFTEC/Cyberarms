using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace Cyberarms.Agents.SqlServer {
    //  [PluginAttribute("Intrusion Detection Base Windows Security Agent", "This agent scans and monitors the system eventlog for possible attacks.")]
    public class SqlFailedLoginWatcher : AgentPlugin, IExtendedInformation{


        private EventLogQuery query;
        private EventLogWatcher watcher;

        internal const string EVENT_LOG_QUERY_SQL_SERVER_LOGIN_DENIED = @"<QueryList>
                  <Query Id=""18456"" Path=""Application"">
                    <Select Path=""Application"">
                        *[System[(EventID=18456) and
                        TimeCreated[timediff(@SystemTime) &lt;= 864000]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public SqlFailedLoginWatcher() {

        }


        /// <summary>
        /// Agent Startup, initialization of our EventLog watcher
        /// </summary>
        protected override void OnStartAgent() {
            query = new EventLogQuery("Application", PathType.LogName,
                String.Format(EVENT_LOG_QUERY_SQL_SERVER_LOGIN_DENIED));
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
                    if(Regex.IsMatch(prop.Value.ToString(),"(?:[0-9]{1,3}.){3}[0-9]{1,3}")) {
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
                EventLog.WriteEntry("Cyberarms.Agents.SqlServer.SqlFailedLoginWatcher", ex.Message);
            }
        }

        public string DisplayName {
            get {
                return "SQL Server Security Agent";
            }
            set {

            }
        }

        public Image Icon {
            get {
                return global::Cyberarms.Agents.SqlServer.Resource.agent15px_sql_dark;
            }
            set {

            }
        }

        public Image SelectedIcon {
            get {
                return global::Cyberarms.Agents.SqlServer.Resource.agent15px_sql_white;
            }
            set {

            }
        }

        public Image UnselectedIcon {
            get {
                return global::Cyberarms.Agents.SqlServer.Resource.agent15px_sql_dark; 
            }
            set {

            }
        }


        
        public Guid Id {
            get {
                return new Guid("{0F470A49-594D-4895-ADE1-46B48B9B8A58}");
            }
        }


    }
}
