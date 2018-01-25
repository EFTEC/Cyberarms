using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;

namespace Cyberarms.IntrusionDetection.Shared {
    public class InstallState : Dictionary<string,string> { }
    [RunInstaller(true)]
    public partial class InstallationHelper : System.Configuration.Install.Installer {
        //private EventLogInstaller eventLogInstaller;

        public override void Install(IDictionary stateSaver) {
            base.Install(stateSaver);
        }
        public InstallationHelper() {
            InitializeComponent();
            //eventLogInstaller = new EventLogInstaller();
            //eventLogInstaller.Log = Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME;
            //eventLogInstaller.Source = Globals.CYBERARMS_WINDOWS_EVENT_SOURCE;
            
            this.AfterInstall += new InstallEventHandler(InstallationHelper_AfterInstall);
            this.BeforeUninstall += new InstallEventHandler(InstallationHelper_BeforeUninstall);
            this.AfterUninstall += new InstallEventHandler(InstallationHelper_AfterUninstall);
            this.BeforeInstall += new InstallEventHandler(InstallationHelper_BeforeInstall);
        }

        void InstallationHelper_BeforeInstall(object sender, InstallEventArgs e) {
            
/*            if (!EventLog.Exists(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME) || !EventLog.SourceExists(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE)) {
                // did somebody delete the eventlog with event viewer?
                if (!EventLog.Exists(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME) && EventLog.SourceExists(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE)) {
                    // delete the source first
                    EventLog.DeleteEventSource(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE);
                }
                EventLog.CreateEventSource(new EventSourceCreationData(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE, Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME));
            } */
            //eventLogInstaller.BeforeInstall += new InstallEventHandler(eventLogInstaller_BeforeInstall);
            //eventLogInstaller.Install(e.SavedState);
            
            if (EventLog.SourceExists(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE)) {
                EventLog.DeleteEventSource(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE);
            }
        }

        //void eventLogInstaller_BeforeInstall(object sender, InstallEventArgs e) {
        //    if (EventLog.SourceExists(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE)) EventLog.DeleteEventSource(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE);
        //    if (EventLog.Exists(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME)) EventLog.Delete(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME);
        //}

        void InstallationHelper_AfterUninstall(object sender, InstallEventArgs e) {
            try {
                if(System.Diagnostics.EventLog.SourceExists(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE)) System.Diagnostics.EventLog.DeleteEventSource(Globals.CYBERARMS_WINDOWS_EVENT_SOURCE);
                if(System.Diagnostics.EventLog.Exists(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME)) System.Diagnostics.EventLog.Delete(Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME);
            } catch {
            }
            try {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo("https://cyberarms.net/intrusion-detection/sorry-to-see-you-leave.aspx");
                System.Diagnostics.Process.Start(sInfo);
            } catch { }
            
        }

        void InstallationHelper_BeforeUninstall(object sender, InstallEventArgs e) {
            
        }

        void InstallationHelper_AfterInstall(object sender, InstallEventArgs e) {
            try {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo("https://cyberarms.net/intrusion-detection/whats-next.aspx");
                System.Diagnostics.Process.Start(sInfo);
            } catch { }
        }
    }
}
