using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cyberarms.IntrusionDetection.Api.Plugin;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace Cyberarms.Agents.Bind9 {
    public class Bind9DDoSKiller : AgentPlugin {
        
        private EventLogQuery query;
        private EventLogWatcher watcher;

        internal const string EVENT_LOG_QUERY_BIND_RECURSION_DENIED = @"<QueryList>
                  <Query Id=""3"" Path=""Application"">
                    <Select Path=""Application"">
                        *[System[(EventID=3) and
                        *[System/Provider/@Name=""named""]]]
                    </Select>
                  </Query>
                </QueryList>";

        /// <summary>
        /// Initialize the Agent
        /// </summary>
        public Bind9DDoSKiller() {
            this.Configuration = new Bind9DDoSConfig();
        }
        
        

        /// <summary>
        /// Agent Startup, initialization of our EventLog watcher
        /// </summary>
        protected override void OnStartAgent() {
            query = new EventLogQuery("Application", PathType.LogName,
                String.Format(EVENT_LOG_QUERY_BIND_RECURSION_DENIED));
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
                    if (prop.Value.ToString().Contains("CLIENT:")) {
                        string client = prop.Value.ToString();
                        int start = client.IndexOf("CLIENT:") + 7;
                        string ipAddress = client.Substring(start, client.LastIndexOf(']') - start);
                        NotificationEventArgs args = new NotificationEventArgs();
                        args.CreateDate = e.EventRecord.TimeCreated.Value;
                        args.EventId = e.EventRecord.Id;
                        args.IpAddress = ipAddress;
                        OnAttackDetected(this, args);
                    }
                }

            } catch (Exception ex) {
                EventLog.WriteEntry("Cyberarms.Agents.Bind9.Bind9DDoSKiller", ex.Message);
            }
        }

    }
}
