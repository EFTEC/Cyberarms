namespace Cyberarms.IntrusionDetection {
    partial class ProjectInstaller {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.intrusionDetectionServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.intrusionDetectionServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // intrusionDetectionServiceProcessInstaller
            // 
            this.intrusionDetectionServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.intrusionDetectionServiceProcessInstaller.Password = null;
            this.intrusionDetectionServiceProcessInstaller.Username = null;
            this.intrusionDetectionServiceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.intrusionDetectionServiceProcessInstaller_AfterInstall);
            // 
            // intrusionDetectionServiceInstaller
            // 
            this.intrusionDetectionServiceInstaller.Description = "Intrusion Detection and Defense System for Windows Servers.";
            this.intrusionDetectionServiceInstaller.DisplayName = "Cyberarms Intrusion Detection Service";
            this.intrusionDetectionServiceInstaller.ServiceName = "Cyberarms Intrusion Detection";
            this.intrusionDetectionServiceInstaller.ServicesDependedOn = new string[] {
        "RpcSs"};
            this.intrusionDetectionServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.intrusionDetectionServiceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.intrusionDetectionServiceInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.intrusionDetectionServiceProcessInstaller,
            this.intrusionDetectionServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller intrusionDetectionServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller intrusionDetectionServiceInstaller;
    }
}