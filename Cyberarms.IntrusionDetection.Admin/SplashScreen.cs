using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class SplashScreen : Form {

        Timer t = new Timer();

        public SplashScreen() {
            InitializeComponent();
            smartLabelVersion.Text = "Version " + Application.ProductVersion;
            smartLabelStatus.Text = "Loading components...";
            BackColor = Color.White;
            this.Load += new EventHandler(SplashScreen_Load);
        }

        void SplashScreen_Load(object sender, EventArgs e) {
            t.Interval = 100;
            t.Start();
            t.Tick += new EventHandler(t_Tick);
            
        }

        public void StartupComponents() {
            smartLabelEdition.Text = "Unlimited edition";
            
            smartLabelStatus.Text = "Configuring database...";
            Database.Instance.Configure(Application.StartupPath);
            smartLabelStatus.Text = "Checking database...";
            
            smartLabelStatus.Text = "Setting environment variables...";
            IddsConfig.Instance.ApplicationPath = Application.StartupPath;
            IddsConfig.Instance.PluginsDirectory = System.Windows.Forms.Application.StartupPath + "\\Plugins\\";
            smartLabelStatus.Text = "Loading configuration data...";
            IddsConfig.Instance.Load();
            smartLabelStatus.Text = "Loading agents...";
            SecurityAgents.Instance.RegisterSecurityAgents();
            
            smartLabelStatus.Text = "Loading application...";
            
            IddsAdmin.Instance.PanelSecurityLog.Visible = true; // used to preload element
            IddsAdmin.Instance.InitAdmin();
            IddsAdmin.Instance.Visible = false;            
        }

        public bool IsUpdating { get; set; }


        void t_Tick(object sender, EventArgs e) {
            if (!IsUpdating) {
                IsUpdating = true;
                StartupComponents();
            }
            if(IddsAdmin.Instance.IsInitialized) Close();
        }

    }
}
