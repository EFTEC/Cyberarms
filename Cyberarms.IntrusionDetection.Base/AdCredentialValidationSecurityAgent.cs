using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Net;

namespace Cyberarms.IntrusionDetection.Base.Plugins {
    [PluginAttribute("Active Directory Credential validation Security Agent", "This agent scans and monitors the system eventlog for possible attacks.")]
    public class AdCredentialValidationSecurityAgent : AgentPlugin, IExtendedInformation {


        private EventLogQuery query;
        private EventLogWatcher watcher;

        internal const string EVENT_LOG_QUERY_WINDOWS_LOGIN_DENIED = @"<QueryList>
                  <Query Id=""0"" Path=""Security"">
                    <Select Path=""Security"">
                        *[System[(EventID=4776) and
                        TimeCreated[timediff(@SystemTime) &lt;= 86400000]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public AdCredentialValidationSecurityAgent() {

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
                string[] xPathProperties = new string[1] { @"Event/EventData/Data[@Name=""Workstation""]" };
                EventLogPropertySelector props = new EventLogPropertySelector(xPathProperties);
                string hostName = ((EventLogRecord)e.EventRecord).GetPropertyValues(props)[0].ToString();
                string[] ipAddresses = ResolveIp(hostName);
                foreach (string ipAddress in ipAddresses) {
                    NotificationEventArgs args = new NotificationEventArgs();
                    args.CreateDate = e.EventRecord.TimeCreated.Value;
                    args.EventId = e.EventRecord.Id;
                    args.IpAddress = ipAddress;
                    OnAttackDetected(this, args);
                }
            } catch (Exception ex) {
                EventLog.WriteEntry("Cyberarms.IntrusionDetection.Base.Plugins.WindowsSecurityBase.AdCredentialValidation", ex.Message);
            }
        }

        private string[] ResolveIp(string hostname) {
            List<string> result = new List<string>();
            IPAddress[] addr = System.Net.Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in addr) {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) {
                    result.Add(ip.ToString());
                }
            }
            return result.ToArray();
        }

        public string DisplayName {
            get {
                return "AD Credential Validation Security Agent";
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
                return new Guid("{D67852B4-DBEF-4831-877C-E37DAB764952}");
            }
        }

    }
}
