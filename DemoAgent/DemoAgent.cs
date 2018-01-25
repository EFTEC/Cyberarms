using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Cyberarms.IntrusionDetection.Api.Plugin;         // use theIntrusion Detectionplugin API

namespace DemoAgent {
    /// <summary>
    /// Simple security agent for demonstration of Cyberarms Intrusion Detection plugin functionality.
    /// To create the plugin, this Class must be inherited from AgentPlugin
    /// </summary>
    public class DemoAgent : AgentPlugin {
        /// <summary>
        /// A FileSystemWatcher to monitor a directory for changes (could be a log directory)
        /// </summary>
        FileSystemWatcher watcher;

        /// <summary>
        /// Important: This plugin uses a custom configuration (see DemoConfiguration.cs). 
        /// This is loaded in the constructor, and the TypeName of this configuration is set.
        ///Intrusion Detectiontakes care of persistance of configuration settings, but it must know the type.
        /// </summary>
        public DemoAgent() {
            this.Configuration.AgentSettings = new DemoConfiguration();
            Configuration.ConfigurationSettingsTypeName = 
                this.Configuration.AgentSettings.GetType().FullName;
        }
        
        /// <summary>
        /// Override the OnStartAgent function to load and initialize objects as needed
        /// This DemoAgent configures a FileSystemWatcher to monitor a directory 
        /// for creation/change of files with the extension .agentTest
        /// The directory is specified in the custom plugin configuration "DemoConfiguration". 
        /// If no value is provided, it falls back to the default directory (c:\temp\)
        /// </summary>
        protected override void OnStartAgent() {
            watcher = new FileSystemWatcher();
            string directory = (Configuration.AgentSettings==null)?"c:\\temp\\"
                :((DemoConfiguration)Configuration.AgentSettings).DirectoryName;
            watcher.Path =  String.IsNullOrEmpty(directory)?"c:\\temp\\":directory;
            watcher.Filter = "*.agentTest";
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
        }

        /// <summary>
        /// Override the OnStopAgent function which is called when stopping theIntrusion DetectionService
        /// </summary>
        protected override void OnStopAgent() {
            watcher.EnableRaisingEvents = false;
            watcher = null;
        }

        /// <summary>
        /// Override the OnPauseAgent function which is called when pausing theIntrusion DetectionService
        /// </summary>
        protected override void OnPauseAgent() {
            watcher.EnableRaisingEvents = false;

        }

        /// <summary>
        /// Override the OnContinueAgent function which is called when resuming theIntrusion DetectionService
        /// </summary>
        protected override void OnContinueAgent() {
            watcher.EnableRaisingEvents = true;
        }



        /// <summary>
        /// Override the IsRunning function. This should return an 
        /// indication whether the agent is in a running state
        /// </summary>
        public override bool IsRunning {
            get {
                if (watcher != null) return watcher.EnableRaisingEvents; else return false;
            }
        }

        /// <summary>
        /// The FileSystemWatcher.Changed event handler does the job for this example. 
        /// Calling the base.OnAttackDetected(object, NotificationEventArgs) function 
        /// notifiesIntrusion Detectionwith information about a potential attack
        /// 
        /// The EventId can be any valuem, 4001 is just for example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void watcher_Changed(object sender, FileSystemEventArgs e) {
            if (e.ChangeType == WatcherChangeTypes.Changed) {
                NotificationEventArgs args = new NotificationEventArgs();
                args.CreateDate = DateTime.Now;
                args.EventId = 4001; // Agent found something
                args.IpAddress = "192.168.1.23";
                base.OnAttackDetected(this, args);
            }

        }
    }
}
