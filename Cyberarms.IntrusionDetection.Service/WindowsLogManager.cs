using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using Cyberarms.IntrusionDetection.Api.Plugin;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection {
    internal class WindowsLogManager {
        private DateTime lastSearchDate;
        
        // public override event AttackDetectedHandler AttackDetected;

        private EventLog eventLogCyberarms = null;


        private static WindowsLogManager _instance;
        internal static WindowsLogManager Instance {
            get {
                if (_instance == null) {
                    _instance = new WindowsLogManager();
                    _instance.lastSearchDate = DateTime.Now;
                }
                return _instance;
            }
        }

        
        internal void WriteEntry(string text, EventLogEntryType type, int eventId, short category) {
            if (eventLogCyberarms == null) {
                //if (!EventLog.Exists(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME) || !EventLog.SourceExists(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE)) {
                //    // did somebody delete the eventlog with event viewer?
                //    if (!EventLog.Exists(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME) && EventLog.SourceExists(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE)) {
                //        // delete the source first
                //        EventLog.DeleteEventSource(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE);
                //    }
                //    EventLog.CreateEventSource(new EventSourceCreationData(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE, Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME));
                //}
                eventLogCyberarms = new EventLog(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME, ".", Globals.CYBERARMS_WINDOWS_EVENT_SOURCE);
            }

            eventLogCyberarms.WriteEntry(text, type, eventId, category);
        }

        
        
        /// <summary>
        /// Keep it private to avoid multiple instances
        /// </summary>
        private WindowsLogManager() {
            
        }



    }
}
