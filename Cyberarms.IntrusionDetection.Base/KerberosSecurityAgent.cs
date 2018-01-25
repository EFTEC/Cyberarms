using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace Cyberarms.IntrusionDetection.Base.Plugins {
    [PluginAttribute("Intrusion Detection Base Windows (Kerberos) Security Agent", "This agent scans and monitors the system eventlog for possible attacks.")]
    public class KerberosSecurityAgent : AgentPlugin, IExtendedInformation {


        private EventLogQuery query;
        private EventLogWatcher watcher;

        internal const string EVENT_LOG_QUERY_WINDOWS_LOGIN_DENIED = @"<QueryList>
                  <Query Id=""0"" Path=""Security"">
                    <Select Path=""Security"">
                        *[System[(EventID=4771) and
                        TimeCreated[timediff(@SystemTime) &lt;= 86400000]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public KerberosSecurityAgent() {

        }


        /// <summary>
        /// Agent Startup, initialization of our EventLog watcher
        /// </summary>
        protected override void OnStartAgent() {
            query = new EventLogQuery("Security", PathType.LogName,
                String.Format(EVENT_LOG_QUERY_WINDOWS_LOGIN_DENIED));
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
                string[] xPathProperties = new string[1] { @"Event/EventData/Data[@Name=""Client Address""]" };
                EventLogPropertySelector props = new EventLogPropertySelector(xPathProperties);
                string ipAddress = ((EventLogRecord)e.EventRecord).GetPropertyValues(props)[0].ToString();
                NotificationEventArgs args = new NotificationEventArgs();
                args.CreateDate = e.EventRecord.TimeCreated.Value;
                args.EventId = e.EventRecord.Id;
                args.IpAddress = ipAddress;
                OnAttackDetected(this, args);
            } catch (Exception ex) {
                EventLog.WriteEntry("Cyberarms.IntrusionDetection.Base.Plugins.WindowsSecurityBase.Kerberos", ex.Message);
            }
        }


        public string DisplayName {
            get {
                return "Kerberos pre-authentication Security Agent";
            }
            set {
                throw new NotSupportedException("DisplayName cannot be changed!");
            }
        }

        private Image _icon = global::Cyberarms.IntrusionDetection.Base.Plugins.Resources.WindowsSecurityAgent_dark;
        public Image Icon {
            get {
                return _icon;
            }
            set {
                _icon = value;
            }
        }

        private Image _selectedIcon = global::Cyberarms.IntrusionDetection.Base.Plugins.Resources.WindowsSecurityAgent_white;
        public Image SelectedIcon {
            get {
                return _selectedIcon;
            }
            set {
                _selectedIcon = value;
            }
        }

        private Image _unselectedIcon = global::Cyberarms.IntrusionDetection.Base.Plugins.Resources.WindowsSecurityAgent_dark;
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
                return new Guid("{880435D7-AB31-4498-B872-1512E7D723F0}");
            }
        }

    }
}
