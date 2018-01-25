using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection {
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer {




        public ProjectInstaller() {
            InitializeComponent();
            this.Committed += new InstallEventHandler(ProjectInstaller_Committed);
            this.BeforeUninstall += new InstallEventHandler(ProjectInstaller_BeforeUninstall);
            this.AfterInstall += new InstallEventHandler(ProjectInstaller_AfterInstall);
            this.BeforeInstall += new InstallEventHandler(ProjectInstaller_BeforeInstall);
            EventLogInstaller DefaultInstaller = null;
            foreach (Installer installer in this.intrusionDetectionServiceInstaller.Installers) {
                if (installer is EventLogInstaller) {
                    DefaultInstaller = (EventLogInstaller)installer;
                    break;
                }

            }
            if (DefaultInstaller != null) {
                try {
                    DefaultInstaller.Log = Globals.CYBERARMS_WINDOWS_EVENT_LOG_NAME;
                    DefaultInstaller.Source = Globals.CYBERARMS_WINDOWS_EVENT_SOURCE;
                    System.Diagnostics.EventLog.WriteEntry("Cyberarms Intrusion Detection Installer", "Configured Event Log");
                } catch {
                }
            }

        }

        void ProjectInstaller_BeforeInstall(object sender, InstallEventArgs e) {
            try {
                System.ServiceProcess.ServiceController controller = new System.ServiceProcess.ServiceController(intrusionDetectionServiceInstaller.DisplayName);
                if (controller != null && controller.Status == System.ServiceProcess.ServiceControllerStatus.Running) {
                    controller.Stop();
                }
            } catch {
            }
        }

        

 
        void ProjectInstaller_AfterInstall(object sender, InstallEventArgs e) {
            try {
                System.ServiceProcess.ServiceController controller = new System.ServiceProcess.ServiceController(intrusionDetectionServiceInstaller.DisplayName);
                if (controller != null && controller.Status != System.ServiceProcess.ServiceControllerStatus.Running) {
                    controller.Start();
                }
            } catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Cyberarms Intrusion Detection Installer", "Error: " + ex.Message);
            }
        }

        void ProjectInstaller_BeforeUninstall(object sender, InstallEventArgs e) {
            try {
                System.ServiceProcess.ServiceController controller = new System.ServiceProcess.ServiceController(intrusionDetectionServiceInstaller.DisplayName);
                if (controller != null && controller.Status == System.ServiceProcess.ServiceControllerStatus.Running) {
                    controller.Stop();
                }
            } catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Cyberarms Intrusion Detection Installer", "Error: " + ex.Message);
            }
        }

        void ProjectInstaller_Committed(object sender, InstallEventArgs e) {
            try {

                System.ServiceProcess.ServiceController controller = new System.ServiceProcess.ServiceController(intrusionDetectionServiceInstaller.DisplayName);
                if (controller != null && controller.Status != System.ServiceProcess.ServiceControllerStatus.Running) {
                    controller.Start();
                }
            } catch (Exception ex) {
                System.Diagnostics.EventLog.WriteEntry("Cyberarms Intrusion Detection Installer", "Error: " + ex.Message);
            }
        }

        private void intrusionDetectionServiceInstaller_AfterInstall(object sender, InstallEventArgs e) {

        }

        private void intrusionDetectionServiceProcessInstaller_AfterInstall(object sender, InstallEventArgs e) {

        }
    }
}
