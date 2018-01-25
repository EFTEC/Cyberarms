using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace Cyberarms.Agents.WebSecurity {
    //  [PluginAttribute("Intrusion Detection Base Windows Security Agent", "This agent scans and monitors the system eventlog for possible attacks.")]
    
    public class WebSecurityAgent : AgentPlugin, IExtendedInformation {


        private EventLogQuery query;
        private EventLogWatcher watcher;
        private const string SEARCH_PATTERN_BEGIN = "[IP = '";
        private const string SEARCH_PATTERN_END = "']";

        internal const string EVENT_LOG_QUERY_CYBERARMS_IIS_SECURITY_MONITOR_ACCESS_DENIED = @"<QueryList>
                  <Query Id=""4625"" Path=""Application"">
                    <Select Path=""Application"">
                        *[System[(EventID=4625) and
                        TimeCreated[timediff(@SystemTime) &lt;= 864000]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public WebSecurityAgent() {

        }


        /// <summary>
        /// Agent Startup, initialization of our EventLog watcher
        /// </summary>
        protected override void OnStartAgent() {
            query = new EventLogQuery("Application", PathType.LogName,
                String.Format(EVENT_LOG_QUERY_CYBERARMS_IIS_SECURITY_MONITOR_ACCESS_DENIED));
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
                    // extract ip address from event log entry
                    // format: <clientname> [IP = 'x.x.x.x']
                    if (prop.Value.ToString().Contains(SEARCH_PATTERN_BEGIN)) {
                        string orig = prop.Value.ToString();
                        int start = orig.IndexOf(SEARCH_PATTERN_BEGIN) + SEARCH_PATTERN_BEGIN.Length;
                        int length = orig.IndexOf(SEARCH_PATTERN_END) - start;
                        string ipAddress = orig.Substring(start, length);
                        NotificationEventArgs args = new NotificationEventArgs();
                        args.CreateDate = e.EventRecord.TimeCreated.Value;
                        args.EventId = e.EventRecord.Id;
                        args.IpAddress = ipAddress;
                        System.Net.IPAddress probe;
                        if (System.Net.IPAddress.TryParse(ipAddress, out probe)) {
                            if (probe.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || probe.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) {
                                OnAttackDetected(this, args);
                            }
                        }
                    }

                }

            } catch (Exception ex) {
                EventLog.WriteEntry("Cyberarms.Agents.WebSecurity.WebSecurityAgent", ex.Message);
            }
        }

        public string DisplayName {
            get {
                return "Web Security Agent";
            }
            set {

            }
        }

        public Image Icon {
            get {
                return global::Cyberarms.Agents.WebSecurity.Resource.agent15px_sharePoint_dark;
            }
            set {

            }
        }

        public Image SelectedIcon {
            get {
                return global::Cyberarms.Agents.WebSecurity.Resource.agent15px_sharePoint_white;
            }
            set {

            }
        }

        public Image UnselectedIcon {
            get {
                return global::Cyberarms.Agents.WebSecurity.Resource.agent15px_sharePoint_dark;
            }
            set {

            }
        }



        public Guid Id {
            get {
                return new Guid("{63F5567C-7A75-4870-A842-E981855DA3E9}");
            }
        }


    }
}
