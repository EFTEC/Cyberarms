using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class CyberarmsApplicationSettings : UserControl {

        public const string MENU_LOCK_OUT_CONFIGURATION = "Lock out configuration";
        public const string MENU_SAFE_NETWORKS = "Safe networks";
        public const string MENU_LICENSING = "Licensing";
        public const string MENU_NOTIFICATION_SETTINGS = "Notification settings";
        public const string MENU_SMTP_SETTINGS = "SMTP configuration";
        public event EventHandler ConfigurationChanged;
        

        public CyberarmsApplicationSettings() {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Load += new EventHandler(CyberamsApplicationSettings_Load);
        }

        void CyberamsApplicationSettings_Load(object sender, EventArgs e) {
            cyberarmsSettingsNavigation.NavigationChanged += new EventHandler(cyberarmsSettingsNavigation_NavigationChanged);
            cyberarmsSettingsNavigation.AddNavigationItem(MENU_LOCK_OUT_CONFIGURATION, null, null);
            cyberarmsSettingsNavigation.AddNavigationItem(MENU_SAFE_NETWORKS, null, null);
            cyberarmsSettingsNavigation.AddNavigationItem(MENU_LICENSING, null, null);
            cyberarmsSettingsNavigation.AddNavigationItem(MENU_NOTIFICATION_SETTINGS, null, null);
            cyberarmsSettingsNavigation.AddNavigationItem(MENU_SMTP_SETTINGS, null, null);
        }

        private PanelLockoutConfiguration _lockoutConfiguration;

        public PanelLockoutConfiguration LockoutConfiguration {
            get {
                if (_lockoutConfiguration == null) {
                    _lockoutConfiguration = new PanelLockoutConfiguration();
                    _lockoutConfiguration.Dock = DockStyle.Fill;
                    configurationPanel.Controls.Add(_lockoutConfiguration);
                    _lockoutConfiguration.LockoutConfigurationChanged += new EventHandler(_lockoutConfiguration_LockoutConfigurationChanged);
                }
                return _lockoutConfiguration;
            }
        }

        void _lockoutConfiguration_LockoutConfigurationChanged(object sender, EventArgs e) {
            OnConfigurationChanged();
        }

        

       

        

        private PanelSafeNetworks _panelSafeNetworks;
        public PanelSafeNetworks PanelSafeNetworks {
            get {
                if (_panelSafeNetworks == null) {
                    _panelSafeNetworks = new PanelSafeNetworks();
                    _panelSafeNetworks.Dock = DockStyle.Fill;
                    configurationPanel.Controls.Add(_panelSafeNetworks);
                    _panelSafeNetworks.SafeNetworksChanged += new EventHandler(_panelSafeNetworks_SafeNetworksChanged);
                }
                return _panelSafeNetworks;
            }
        }

        void _panelSafeNetworks_SafeNetworksChanged(object sender, EventArgs e) {
            OnConfigurationChanged();
        }

        private PanelSmtpSettings _panelSmtpSettings;
        public PanelSmtpSettings PanelSmtpSettings {
            get {
                if (_panelSmtpSettings == null) {
                    _panelSmtpSettings = new PanelSmtpSettings();
                    _panelSmtpSettings.Dock = DockStyle.Fill;
                    configurationPanel.Controls.Add(_panelSmtpSettings);
                    _panelSmtpSettings.SmtpSettingsChanged += new EventHandler(_panelSmtpSettings_SmtpSettingsChanged);
                }
                return _panelSmtpSettings;
            }

        }

        void _panelSmtpSettings_SmtpSettingsChanged(object sender, EventArgs e) {
            OnConfigurationChanged();
        }

        private PanelNotificationSettings _panelNotificationSettings;
        public PanelNotificationSettings PanelNotificationSettings {
            get {
                if (_panelNotificationSettings == null) {
                    _panelNotificationSettings = new PanelNotificationSettings();
                    _panelNotificationSettings.Dock = DockStyle.Fill;
                    _panelNotificationSettings.NotificationSettingsChanged += new EventHandler(_panelNotificationSettings_NotificationSettingsChanged);
                    configurationPanel.Controls.Add(_panelNotificationSettings);
                }
                return _panelNotificationSettings;
            }
        }

        void _panelNotificationSettings_NotificationSettingsChanged(object sender, EventArgs e) {
            OnConfigurationChanged();
        }

        void cyberarmsSettingsNavigation_NavigationChanged(object sender, EventArgs e) {
            switch ((sender as CyberarmsSettingsNavigationItem).DisplayName) {
     
                case MENU_LOCK_OUT_CONFIGURATION:
                    LockoutConfiguration.BringToFront();
                    break;
                case MENU_NOTIFICATION_SETTINGS:
                    PanelNotificationSettings.BringToFront();
                    PanelNotificationSettings.LoadData();
                    break;
                case MENU_SAFE_NETWORKS:
                    PanelSafeNetworks.BringToFront();
                    break;
                case MENU_SMTP_SETTINGS:
                    PanelSmtpSettings.BringToFront();
                    break;
            }
        }

        private void OnConfigurationChanged() {
            if (ConfigurationChanged != null) ConfigurationChanged(this, EventArgs.Empty);
        }
      

    }
}
