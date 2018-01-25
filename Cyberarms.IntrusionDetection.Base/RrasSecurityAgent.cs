using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Cyberarms.IntrusionDetection.Base.Plugins {
    [PluginAttribute("Intrusion Detection RRAS Security Agent", "This agent scans and monitors the system eventlog for possible RRAS attacks.")]

    public class RrasSecurityAgent : AgentPlugin, IExtendedInformation {

        private EventLogQuery query;
        private EventLogWatcher watcher;

        internal const string EVENT_LOG_QUERY_FILEMAKER_LOGIN_DENIED = @"<QueryList>
                  <Query Id=""20271"" Path=""System"">
                    <Select Path=""System"">
                        *[System[(EventID=20271) and
                        TimeCreated[timediff(@SystemTime) &lt;= 86400000]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public RrasSecurityAgent() {

        }


        /// <summary>
        /// Agent Startup, initialization of our EventLog watcher
        /// </summary>
        protected override void OnStartAgent() {
            query = new EventLogQuery("System", PathType.LogName,
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
                }

            } catch (Exception ex) {
                EventLog.WriteEntry("Cyberarms.IntrusionDetection.Base.Plugins.RrasSecurityAgent", ex.Message);
            }
        }


        public string DisplayName {
            get {
                return "RRAS Security Agent - Routing and Remote Access";
            }
            set {
                throw new NotSupportedException("DisplayName cannot be changed!");
            }
        }

        private Image _icon = global::Cyberarms.IntrusionDetection.Base.Plugins.Resources.agent15px_rras_dark;
        public Image Icon {
            get {
                return _icon;
            }
            set {
                _icon = value;
            }
        }

        private Image _selectedIcon = global::Cyberarms.IntrusionDetection.Base.Plugins.Resources.agent15px_rras_white;
        public Image SelectedIcon {
            get {
                return _selectedIcon;
            }
            set {
                _selectedIcon = value;
            }
        }

        private Image _unselectedIcon = global::Cyberarms.IntrusionDetection.Base.Plugins.Resources.agent15px_rras_dark;
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
                return new Guid("{FDA41145-2E75-400E-882C-E06EC4790EBE}");
            }
        }

    }
}
