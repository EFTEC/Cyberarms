using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cyberarms.IntrusionDetection.Shared;
using System.Diagnostics;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class IddsAdmin : Form {
        Color buttonHighlight = Color.FromArgb(205, 230, 247);
        Color buttonPress = Color.FromArgb(105, 130, 147);
        Color buttonNormal = Color.FromKnownColor(KnownColor.Window);
        Timer logReader;
        Timer timerRefreshServiceStatus;
        CyberarmsSecurityLog _panelSecurityLog;
        CyberarmsCurrentLocks _panelCurrentLocks;
        CyberarmsDashboard _dashboard;
        CyberarmsAgentConfiguration _panelAgentConfiguration;
        CyberarmsApplicationSettings _panelApplicationSettings;

        System.ServiceProcess.ServiceController serviceController;
        private System.Diagnostics.EventLog eventLogCyberarms;
        public IddsAdmin() {
            InitializeComponent();
            this.Text = "Cyberarms Intrusion Detection - Version " + Application.ProductVersion;
            this.labelFormText.Text = this.Text;

            //            panelContent.Invalidated += new InvalidateEventHandler(panelContent_Invalidated);
            panelContent.Paint += new PaintEventHandler(panelContent_Paint);
            
            this.Load += new EventHandler(IddsAdmin_Load);
        }

        private static IddsAdmin _instance;
        public static IddsAdmin Instance {
            get {
                if (_instance == null) {
                    _instance = new IddsAdmin();
                    _instance.Visible = false;
                }
                return _instance;
            }
        }


        public CyberarmsApplicationSettings PanelApplicationSettings {
            get {
                if (_panelApplicationSettings == null) {
                    _panelApplicationSettings = new CyberarmsApplicationSettings();
                    _panelApplicationSettings.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_panelApplicationSettings);
                    
                    _panelApplicationSettings.ConfigurationChanged += new EventHandler(_panelApplicationSettings_ConfigurationChanged);
                }
                return _panelApplicationSettings;
            }
        }

        void _panelApplicationSettings_ConfigurationChanged(object sender, EventArgs e) {
            RestartService();
        }

        public CyberarmsAgentConfiguration PanelAgentConfiguration {
            get {
                if (_panelAgentConfiguration == null) {
                    _panelAgentConfiguration = new CyberarmsAgentConfiguration();
                    _panelAgentConfiguration.Dock = DockStyle.Fill;
                    _panelAgentConfiguration.PluginsChanged += new EventHandler(_panelAgentConfiguration_PluginsChanged);
                    _panelAgentConfiguration.AgentSettingsChanged += new EventHandler(_panelAgentConfiguration_AgentSettingsChanged);
                    panelContent.Controls.Add(_panelAgentConfiguration);
                }
                return _panelAgentConfiguration;
            }
        }

        void _panelAgentConfiguration_AgentSettingsChanged(object sender, EventArgs e) {
            RestartService();
        }

        void _panelAgentConfiguration_PluginsChanged(object sender, EventArgs e) {
            InitAgentSettings();
            //RestartService();
        }

        public void RestartService() {
            if (serviceController != null && serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Running) {
                try {
                    serviceController.Stop();
                    while (serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Running ||
                        serviceController.Status == System.ServiceProcess.ServiceControllerStatus.StopPending) {
                        Application.DoEvents();
                    }
                    serviceController.Start();
                } catch { }
            }
        }

        public CyberarmsSecurityLog PanelSecurityLog {
            get {
                if (_panelSecurityLog == null) {
                    _panelSecurityLog = new CyberarmsSecurityLog();
                    _panelSecurityLog.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_panelSecurityLog);
                    IsUpdating = true;
                    
                    IDataReader rdr = IntrusionLog.ReadIntervalGrouped(new TimeSpan(24, 0, 0));
                    int maxLogId = LastLogId;
                    while (rdr.Read()) {
                        int action = int.Parse(rdr["Action"].ToString());
                        string agentId = Shared.Db.DbValueConverter.ToString(rdr["AgentId"]);
                        PanelSecurityLog.FillLogEntry(int.Parse(rdr["MaxId"].ToString()), 
                                int.Parse(rdr["Action"].ToString()), 
                                agentId, 
                                IntrusionLog.GetStatusIcon(action), 
                                IntrusionLog.GetStatusClass(action), DateTime.Parse(rdr["LatestEvent"].ToString()), 
                                rdr["ClientIP"].ToString(), 
                                GetLogMessage(agentId,action),
                                int.Parse(rdr["NumberOfEvents"].ToString()));
                        if (Convert.ToInt32(rdr["MaxId"]) > maxLogId) maxLogId = Convert.ToInt32(rdr["MaxId"]);
                    } 
                    if(maxLogId==0) {
                        LastLogId = IntrusionLog.GetLastLogId();
                    }
                    foreach (SecurityAgent agent in SecurityAgents.Instance) {
                        _panelSecurityLog.AddAgent(agent);
                    }
                    rdr.Close();
                    if (maxLogId > LastLogId) LastLogId = maxLogId;
                    IsUpdating = false;
                }
                return _panelSecurityLog;
            }
        }

        private void FillLog(IDataReader rdr) {
        }

        public CyberarmsCurrentLocks PanelCurrentLocks {
            get {
                if (_panelCurrentLocks == null) {
                    _panelCurrentLocks = new CyberarmsCurrentLocks();
                    _panelCurrentLocks.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_panelCurrentLocks);
                }
                return _panelCurrentLocks;
            }
        }

        public CyberarmsDashboard Dashboard {
            get {
                if (_dashboard == null) {
                    _dashboard = new CyberarmsDashboard();
                    _dashboard.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_dashboard);
                    _dashboard.SecurityAgentConfigurationRequest += new EventHandler(_dashboard_SecurityAgentConfigurationRequest);
                }
                return _dashboard;
            }
        }

        void _dashboard_SecurityAgentConfigurationRequest(object sender, EventArgs e) {
            if (sender != null && sender is SecurityAgent) {
                ShowMenu(labelMenuAgents);
                PanelAgentConfiguration.ShowAgentConfig((sender as SecurityAgent));
                PanelAgentConfiguration.BringToFront();
                panelOnlineServices.Hide();
            }
        }

        public bool IsServiceRunning { get; set; }

        void serviceReader_Tick(object sender, EventArgs e) {
            RefreshServiceStatus();
        }


        public bool ServiceError { get; set; }

        public void RefreshServiceStatus() {
            serviceController.Refresh();
            if (ServiceError) {
                smartLabelServiceStatus.Text = "Service not found!";
                smartLabelServiceStatus.ForeColor = Color.FromArgb(225, 50, 50);
                return;
            }
            try {
                if (serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Running && !IsServiceRunning) {
                    IsServiceRunning = true;
                    pictureBoxStartService.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.service_controller_start_deactivated;
                    pictureBoxStartService.Enabled = false;
                    pictureBoxStopService.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.service_controller_stop;
                    pictureBoxStopService.Enabled = true;
                    smartLabelServiceStatus.Text = "Service is running";
                    smartLabelServiceStatus.ForeColor = Color.FromArgb(0, 159, 227);
                } else if (serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Stopped && IsServiceRunning) {
                    IsServiceRunning = false;
                    pictureBoxStartService.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.service_controller_start;
                    pictureBoxStartService.Enabled = true;
                    pictureBoxStopService.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.service_controller_stop_deactivated;
                    pictureBoxStopService.Enabled = false;
                    smartLabelServiceStatus.Text = "Service is stopped";
                    smartLabelServiceStatus.ForeColor = Color.FromArgb(225, 50, 50);
                }
            } catch {
                ServiceError = true;
            }

        }

        public bool IsUpdating { get; set; }

        public string GetLogMessage(string agentId, int action) {
            string agentName = SecurityAgents.Instance.GetDisplayName(agentId);
            string message = String.Empty;
            if (action <= IntrusionLog.STATUS_SOFT_LOCK_REQUESTED || action == IntrusionLog.STATUS_HARD_LOCK_REQUESTED) {
                message = String.Format("{0}: ", agentName);
            }
            return String.Format("{0}{1}", message, Cyberarms.IntrusionDetection.Shared.IntrusionLog.GetStatusName(action));
        }

        void logReader_Tick(object sender, EventArgs e) {
            DateTime metering = DateTime.Now;
            if (!IsUpdating && Database.Instance.IsConfigured) {
                IsUpdating = true;
                if (CurrentMenu == labelMenuSecurityLog && IntrusionLog.HasUpdates(LastLogId)) {
                    IDataReader rdr = IntrusionLog.ReadDifferential(LastLogId);
                    int maxLogId = LastLogId;
                    while (rdr.Read()) {
                        int action = int.Parse(rdr["Action"].ToString());
                        string agentId = Shared.Db.DbValueConverter.ToString(rdr["AgentId"]);
                        PanelSecurityLog.AddLogEntry(int.Parse(rdr["id"].ToString()), action, 
                            agentId, 
                            IntrusionLog.GetStatusIcon(action), 
                            IntrusionLog.GetStatusClass(action), DateTime.Parse(rdr["IncidentTime"].ToString()), rdr["ClientIP"].ToString(), 
                            GetLogMessage(agentId,action));
                        if (Convert.ToInt32(rdr["Id"]) > maxLogId) maxLogId = Convert.ToInt32(rdr["Id"]);
                    }
                    rdr.Close();
                    rdr.Dispose();
                    if (maxLogId > LastLogId) LastLogId = maxLogId;
                }
                
                if (CurrentMenu == labelMenuCurrentLocks && Locks.HasUpdates(LastLockUpdate)) {
                    LastLockUpdate = DateTime.Now;
                    PanelCurrentLocks.Clear();
                    IDataReader locksReader = Locks.ReadLocks(); 
                    while (locksReader.Read()) {
                        DateTime lockDate;
                        DateTime unlockDate;
                        DateTime.TryParse(locksReader["LockDate"].ToString(), out lockDate);
                        DateTime.TryParse(locksReader["UnlockDate"].ToString(), out unlockDate);
                        PanelCurrentLocks.Add(int.Parse(locksReader["LockId"].ToString()), global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.logIcon_softLock,
                            LockStatusAdapter.GetLockStatusName(int.Parse(locksReader["Status"].ToString())), locksReader["ClientIp"].ToString(), 
                            locksReader["DisplayName"].ToString(),
                            lockDate, unlockDate, IntrusionDetection.Shared.Db.DbValueConverter.ToInt(locksReader["Status"]));
                    }
                    locksReader.Close();
                    locksReader.Dispose();
                    
                }
                if (CurrentMenu == labelMenuHome) {
                    Dashboard.SetUnsuccessfulLogins(Locks.ReadUnsuccessfulLoginAttempts(DateTime.Now.AddDays(-30)));
                    foreach(SecurityAgent agent in SecurityAgents.Instance) {
                        agent.UpdateStatistics();
                    }
                }
                if (CurrentMenu == labelMenuHome || CurrentMenu == labelMenuCurrentLocks) {
                    int softLocks = Locks.ReadCurrentSoftLocks();
                    int hardLocks = Locks.ReadCurrentHardLocks();
                    PanelCurrentLocks.SetSoftLocks(softLocks);
                    PanelCurrentLocks.SetHardLocks(hardLocks);
                    Dashboard.SetHardLocks(hardLocks);
                    Dashboard.SetSoftLocks(softLocks);
                    
                }
                if (!IsInitialized || (CurrentMenu == labelMenuHome || CurrentMenu == labelMenuSecurityLog)) {
                // ?? 
                }
            }
            IsInitialized = true;
            IsUpdating = false;
            System.Diagnostics.Debug.Print(DateTime.Now.Subtract(metering).TotalMilliseconds.ToString());
        }

        public int LastLogId { get; set; }
        
        public DateTime LastLockUpdate { get; set; }

        void panelContent_Invalidated(object sender, InvalidateEventArgs e) {
            paintPanelTopBorder();
        }


        void paintPanelTopBorder() {
            if (CurrentMenu != null) {
                Graphics g = Graphics.FromHwnd(panelContent.Handle);
                Pen borderPen = new Pen(Color.FromArgb(190, 190, 190), 1);
                Pen backgroundPen = new Pen(panelContent.BackColor, 1);
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                g.DrawLine(borderPen, new Point(0, 0), new Point(CurrentMenu.Location.X + 1, 0));
                g.DrawLine(backgroundPen, new Point(CurrentMenu.Location.X + 1, 0), new Point(CurrentMenu.Location.X + CurrentMenu.Width - 1, 0));
                g.DrawLine(borderPen, new Point(CurrentMenu.Location.X + CurrentMenu.Width - 1, 0), new Point(Width, 0));
            }
        }

        #region Form basics
        private void pictureBoxCloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void panelWindowGrip_MouseDown(object sender, MouseEventArgs e) {
            IsMoving = true;
            MoveStartPoint = new Point(e.X, e.Y);
        }

        public bool IsMoving { get; set; }
        public Point MoveStartPoint { get; set; }
        private void panelWindowGrip_MouseUp(object sender, MouseEventArgs e) {
            IsMoving = false;
        }

        private void panelWindowGrip_MouseMove(object sender, MouseEventArgs e) {
            if (IsMoving) {
                this.Location = new Point(this.Location.X + e.X - MoveStartPoint.X, this.Location.Y + e.Y - MoveStartPoint.Y);

            }
        }

        private void labelMenuHome_Click(object sender, EventArgs e) {
            ShowMenu(labelMenuHome);
            Dashboard.BringToFront();
            panelOnlineServices.Hide();
        }


        private void ShowMenu(SmartLabel newMenu) {
            //if (newMenu == CurrentMenu) return;
            if (CurrentMenu != null && newMenu != CurrentMenu) {
                CurrentMenu.Selected = false;
            }
            newMenu.Selected = true;
            CurrentMenu = newMenu;
            //paintPanelTopBorder(CurrentMenu);
            paintPanelTopBorder();

        }

        public SmartLabel CurrentMenu { get; set; }

        private void labelMenuSecurityLog_Click(object sender, EventArgs e) {
            ShowMenu(labelMenuSecurityLog);
            //panelSecurityLog.BringToFront();
            PanelSecurityLog.BringToFront();
            panelOnlineServices.Hide();

        }

        private void labelMenuAgents_Click(object sender, EventArgs e) {
            ShowMenu(labelMenuAgents);
            PanelAgentConfiguration.BringToFront();
            panelOnlineServices.Hide();
        }

        private void labelMenuSettings_Click(object sender, EventArgs e) {
            ShowMenu(labelMenuSettings);
            PanelApplicationSettings.BringToFront();
            panelOnlineServices.Hide();
        }



        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            pictureBox1.ContextMenuStrip.Show(PointToScreen(new Point(pictureBox1.Location.X, pictureBox1.Location.Y + pictureBox1.Height)));
        }

        private void pictureBoxHelpButon_Click(object sender, EventArgs e) {
            System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo("http://cyberarms.net/iddshelp/");
            System.Diagnostics.Process.Start(sInfo);
        }

        private void pictureBoxMinimizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxMaximizeButton_Click(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Maximized) {
                this.WindowState = FormWindowState.Maximized;
                pictureBoxMaximizeButton.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_scale;
            } else {
                this.WindowState = FormWindowState.Normal;
                pictureBoxMaximizeButton.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_maximize;
            }
        }


        private void pictureBoxButton_MouseEnter(object sender, EventArgs e) {
            (sender as Control).BackColor = buttonHighlight;
        }

        private void pictureBoxButton_MouseLeave(object sender, EventArgs e) {
            (sender as Control).BackColor = buttonNormal;
        }

        private void pictureBoxButton_MouseDown(object sender, MouseEventArgs e) {
            (sender as Control).BackColor = buttonPress;
        }

        private void pictureBoxButton_MouseUp(object sender, MouseEventArgs e) {
            (sender as Control).BackColor = buttonNormal;
        }

        private void panelUnsuccessfulLogins_Click(object sender, EventArgs e) {

        }

        private void IddsAdmin_Load(object sender, EventArgs e) {

            //@DEMO: List demo agent
            InitAdmin();
        }

        public void InitAgentSettings() {
            Dashboard.ClearAgents();
            PanelAgentConfiguration.ClearSecurityAgents();
            foreach (SecurityAgent agent in SecurityAgents.Instance) {
                Dashboard.AddAgent(agent);
                PanelAgentConfiguration.LoadSecurityAgent(agent);
            }
        }

        public void InitAdmin() {
            if (IsInitialized) return;
            InitAgentSettings();
            //SecurityAgent agentX = new SecurityAgent("FTP Security Agent", 1563, 18, 230, global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.Paladin_Icon_32);

            //Dashboard.AddAgent(agentX);

            labelMenuHome_Click(labelMenuHome, EventArgs.Empty);

            //CurrentMenu = labelMenuHome;
            paintPanelTopBorder();

            // Invalidate(false);
            try {
                serviceController = new System.ServiceProcess.ServiceController("Cyberarms Intrusion Detection Service");
                IsServiceRunning = serviceController.Status != System.ServiceProcess.ServiceControllerStatus.Running;
            } catch (Exception ex) {
                GenericErrorDialog errdlg = new GenericErrorDialog("Error starting application", "The service is not installed or installed correctly. Please uninstall Cyberarms IDDS and reinstall to fix the problem!", false);
                errdlg.ShowDialog();
                EventLog.WriteEntry("Cyberarms.IntrusionDetection.Admin", ex.Message);
            }
            logReader = new Timer();
            logReader.Interval = 1000;
            logReader.Tick += new EventHandler(logReader_Tick);
            logReader.Enabled = true;
            logReader.Start();

            timerRefreshServiceStatus = new Timer();
            timerRefreshServiceStatus.Interval = 1000;
            timerRefreshServiceStatus.Tick += new EventHandler(serviceReader_Tick);
            timerRefreshServiceStatus.Enabled = true;
            timerRefreshServiceStatus.Start();

            eventLogCyberarms = new EventLog("Cyberarms");
            eventLogCyberarms.Source = "Cyberarms Intrusion Detection";

            ShowMenu(labelMenuHome);
            Dashboard.BringToFront();

        }

        public bool IsInitialized { get; set; }


        internal void WriteEntry(string text, EventLogEntryType type, int eventId, short category) {
            eventLogCyberarms.WriteEntry(text, type, eventId, category);
        }

        private void resizeForm(Point mouseLocation) {
            int deltaX = (resizeStartLocation.X - mouseLocation.X);
            int deltaY = (resizeStartLocation.Y - mouseLocation.Y);
            if ((resizeDirection & ResizeDirection.Left) == ResizeDirection.Left) {
                this.Left += -deltaX;
                this.Width += deltaX;
            }
            if ((resizeDirection & ResizeDirection.Right) == ResizeDirection.Right) {
                this.Width -= deltaX;
            }
            if ((resizeDirection & ResizeDirection.Top) == ResizeDirection.Top) {
                this.Height += deltaY;
                this.Top += -deltaY;
            }
            if ((resizeDirection & ResizeDirection.Bottom) == ResizeDirection.Bottom) {
                this.Height -= deltaY;
            }

        }

        ResizeDirection resizeDirection = ResizeDirection.None;
        bool isResizing = false;
        Point resizeStartLocation = new Point(0, 0);

        enum ResizeDirection {
            None = 0,
            Top = 1,
            Right = 2,
            Bottom = 4,
            Left = 8
        }



        private void borderN_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Top;
            enterResizeMode(e.Location);
        }

        private void borderE_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Right;
            enterResizeMode(e.Location);
        }

        private void borderS_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Bottom;
            enterResizeMode(e.Location);
        }

        private void borderW_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Left;
            enterResizeMode(e.Location);
        }

        private void borderNE_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Right | ResizeDirection.Top;
            enterResizeMode(e.Location);
        }

        private void borderSE_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Right | ResizeDirection.Bottom;
            enterResizeMode(e.Location);
        }

        private void borderSW_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Left | ResizeDirection.Bottom;
            enterResizeMode(e.Location);
        }

        private void borderNW_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Left | ResizeDirection.Top;
            enterResizeMode(e.Location);
        }

        private void enterResizeMode(Point currentLocation) {
            resizeStartLocation = currentLocation;
            isResizing = true;
            //this.SuspendLayout();
        }

        private void border_MouseMove(object sender, MouseEventArgs e) {
            if (isResizing) {
                resizeForm(e.Location);
            }
        }
        private void IddsAdmin_Resize(object sender, EventArgs e) {

        }

        private void border_MouseUp(object sender, MouseEventArgs e) {
            isResizing = false;
            //this.ResumeLayout();
        }

        #endregion

        private void labelMenuOnline_Click(object sender, EventArgs e) {
            if (panelOnlineServices.Visible) {
                panelOnlineServices.Hide();
            } else {
                panelOnlineServices.Dock = DockStyle.Left;
                panelOnlineServices.Show();
            }
        }

        private void labelMenuCurrentLocks_Click(object sender, EventArgs e) {
            ShowMenu(labelMenuCurrentLocks);
            //panelCurrentLocks.BringToFront();
            PanelCurrentLocks.BringToFront();
            panelOnlineServices.Hide();
        }


        private void actionMenu_MouseDown(object sender, MouseEventArgs e) {
            Control c = (Control)sender;
            c.Location = new Point(c.Location.X + 1, c.Location.Y + 1);
        }

        private void actionMenu_MouseUp(object sender, MouseEventArgs e) {
            Control c = (Control)sender;
            c.Location = new Point(c.Location.X - 1, c.Location.Y - 1);
        }


        private void panelContent_Paint(object sender, PaintEventArgs e) {
            paintPanelTopBorder();
        }

        private void pictureBoxStartService_Click(object sender, EventArgs e) {
            StartService();
        }

        private void pictureBoxStopService_Click(object sender, EventArgs e) {
            StopService();
        }

        private void StartService() {
            smartLabelServiceStatus.Text = "Starting service...";
            smartLabelServiceStatus.ForeColor = Color.FromArgb(0x666666);
            if (serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Paused ||
                serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Stopped) {
                serviceController.Start();
            }
            RefreshServiceStatus();
        }

        private void StopService() {
            smartLabelServiceStatus.Text = "Stopping service...";
            smartLabelServiceStatus.ForeColor = Color.FromArgb(0x666666);
            if (serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Running) {
                serviceController.Stop();
            }
            RefreshServiceStatus();
        }

       




    }
}
