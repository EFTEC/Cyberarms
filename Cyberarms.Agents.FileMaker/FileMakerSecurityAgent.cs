using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Cyberarms.Agents.FileMaker {
    [PluginAttribute("Intrusion Detection Base Windows Security Agent", "This agent scans and monitors the system eventlog for possible attacks.")]

    public class FileMakerSecurityAgent : AgentPlugin, IExtendedInformation {



        private EventLogQuery query;
        private EventLogWatcher watcher;

        internal const string EVENT_LOG_QUERY_FILEMAKER_LOGIN_DENIED = @"<QueryList>
                  <Query Id=""661"" Path=""Application"">
                    <Select Path=""Application"">
                        *[System[(EventID=661) and
                        TimeCreated[timediff(@SystemTime) &lt;= 86400000]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public FileMakerSecurityAgent() {

        }


        /// <summary>
        /// Agent Startup, initialization of our EventLog watcher
        /// </summary>
        protected override void OnStartAgent() {
            query = new EventLogQuery("Application", PathType.LogName,
                String.Format(EVENT_LOG_QUERY_FILEMAKER_LOGIN_DENIED));
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
                    if (Regex.IsMatch(prop.Value.ToString(), "(?:[0-9]{1,3}.){3}[0-9]{1,3}")) {
                        Match ipAddress = Regex.Match(prop.Value.ToString(), "(?:[0-9]{1,3}.){3}[0-9]{1,3}");
                        NotificationEventArgs args = new NotificationEventArgs();
                        args.CreateDate = e.EventRecord.TimeCreated.Value;
                        args.EventId = e.EventRecord.Id;
                        args.IpAddress = ipAddress.Value;
                        System.Net.IPAddress ip;
                        System.Net.IPAddress.TryParse(args.IpAddress, out ip);
                        if (ip != null && ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                            OnAttackDetected(this, args);
                        }
                    }
                    //if (prop.Value.ToString().Contains("CLIENT:")) {
                    //    string client = prop.Value.ToString();
                    //    int start = client.IndexOf("CLIENT:") + 7;
                    //    string ipAddress = client.Substring(start, client.LastIndexOf(']') - start).Trim();
                    //    NotificationEventArgs args = new NotificationEventArgs();
                    //    args.CreateDate = e.EventRecord.TimeCreated.Value;
                    //    args.EventId = e.EventRecord.Id;
                    //    args.IpAddress = ipAddress;
                    //    OnAttackDetected(this, args);
                    //}
                }

            } catch (Exception ex) {
                EventLog.WriteEntry("Cyberarms.Agents.FileMaker.FileMakerSecurityAgent", ex.Message);
            }
        }


        public string DisplayName {
            get {
                return "FileMaker Security Agent";
            }
            set {
                throw new NotSupportedException("DisplayName cannot be changed!");
            }
        }

        private Image _icon = global::Cyberarms.Agents.FileMaker.FileMakerResource.agent15px_filemaker_dark;
        public Image Icon {
            get {
                return _icon;
            }
            set {
                _icon = value;
            }
        }

        private Image _selectedIcon = global::Cyberarms.Agents.FileMaker.FileMakerResource.agent15px_filemaker_white;
        public Image SelectedIcon {
            get {
                return _selectedIcon;
            }
            set {
                _selectedIcon = value;
            }
        }

        private Image _unselectedIcon = global::Cyberarms.Agents.FileMaker.FileMakerResource.agent15px_filemaker_dark;
        public Image UnselectedIcon {
            get {
                return _unselectedIcon;
            }
            set {
                _unselectedIcon = value;
            }
        }

        public Guid Id {
            get {
                return new Guid("{F0F28CC4-8103-4781-927E-CFD4C5991092}");
            }
        }

    }
}
