namespace Cyberarms.IntrusionDetection.Admin {
    partial class CyberarmsSecurityLog {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.labelEventsCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFilter = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSecurityLogGridPanel = new Cyberarms.IntrusionDetection.Admin.SmartPanel();
            this.smartLabelLatestEntry = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabelMessage = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabelNumberOfEvents = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabelpAddress = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabelType = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.dataGridViewIntrusionLog = new System.Windows.Forms.DataGridView();
            this.panelSecurityLogActionBar = new Cyberarms.IntrusionDetection.Admin.SmartPanel();
            this.comboBoxAgentSelection = new System.Windows.Forms.ComboBox();
            this.checkBoxSystemMessages = new System.Windows.Forms.CheckBox();
            this.checkBoxHardLocks = new System.Windows.Forms.CheckBox();
            this.checkBoxSoftLocks = new System.Windows.Forms.CheckBox();
            this.checkBoxFailedLogins = new System.Windows.Forms.CheckBox();
            this.smartLabel1 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.LogIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.LogType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatestEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfEvents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSecurityLogGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIntrusionLog)).BeginInit();
            this.panelSecurityLogActionBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label5.Location = new System.Drawing.Point(159, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "|";
            // 
            // labelEventsCount
            // 
            this.labelEventsCount.AutoSize = true;
            this.labelEventsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.labelEventsCount.Location = new System.Drawing.Point(241, 49);
            this.labelEventsCount.Name = "labelEventsCount";
            this.labelEventsCount.Size = new System.Drawing.Size(13, 13);
            this.labelEventsCount.TabIndex = 13;
            this.labelEventsCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label4.Location = new System.Drawing.Point(176, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "total events:";
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.labelFilter.Location = new System.Drawing.Point(72, 49);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(67, 13);
            this.labelFilter.TabIndex = 11;
            this.labelFilter.Text = "last 24 hours";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.Paladin_Icon_32;
            this.pictureBox2.Location = new System.Drawing.Point(24, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // panelSecurityLogGridPanel
            // 
            this.panelSecurityLogGridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSecurityLogGridPanel.AutoScroll = true;
            this.panelSecurityLogGridPanel.BackColor = System.Drawing.SystemColors.Window;
            this.panelSecurityLogGridPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.panelSecurityLogGridPanel.Controls.Add(this.smartLabelLatestEntry);
            this.panelSecurityLogGridPanel.Controls.Add(this.smartLabelMessage);
            this.panelSecurityLogGridPanel.Controls.Add(this.smartLabelNumberOfEvents);
            this.panelSecurityLogGridPanel.Controls.Add(this.smartLabelpAddress);
            this.panelSecurityLogGridPanel.Controls.Add(this.smartLabelType);
            this.panelSecurityLogGridPanel.Controls.Add(this.dataGridViewIntrusionLog);
            this.panelSecurityLogGridPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panelSecurityLogGridPanel.Location = new System.Drawing.Point(24, 116);
            this.panelSecurityLogGridPanel.Name = "panelSecurityLogGridPanel";
            this.panelSecurityLogGridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.panelSecurityLogGridPanel.PaintBorder = true;
            this.panelSecurityLogGridPanel.Size = new System.Drawing.Size(810, 328);
            this.panelSecurityLogGridPanel.TabIndex = 15;
            // 
            // smartLabelLatestEntry
            // 
            this.smartLabelLatestEntry.AutoSize = true;
            this.smartLabelLatestEntry.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.smartLabelLatestEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.smartLabelLatestEntry.Location = new System.Drawing.Point(116, 7);
            this.smartLabelLatestEntry.Name = "smartLabelLatestEntry";
            this.smartLabelLatestEntry.Selected = false;
            this.smartLabelLatestEntry.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelLatestEntry.Size = new System.Drawing.Size(66, 13);
            this.smartLabelLatestEntry.TabIndex = 1;
            this.smartLabelLatestEntry.Text = "Latest entry";
            // 
            // smartLabelMessage
            // 
            this.smartLabelMessage.AutoSize = true;
            this.smartLabelMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.smartLabelMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.smartLabelMessage.Location = new System.Drawing.Point(441, 8);
            this.smartLabelMessage.Name = "smartLabelMessage";
            this.smartLabelMessage.Selected = false;
            this.smartLabelMessage.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelMessage.Size = new System.Drawing.Size(52, 13);
            this.smartLabelMessage.TabIndex = 1;
            this.smartLabelMessage.Text = "Message";
            // 
            // smartLabelNumberOfEvents
            // 
            this.smartLabelNumberOfEvents.AutoSize = true;
            this.smartLabelNumberOfEvents.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.smartLabelNumberOfEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.smartLabelNumberOfEvents.Location = new System.Drawing.Point(235, 8);
            this.smartLabelNumberOfEvents.Name = "smartLabelNumberOfEvents";
            this.smartLabelNumberOfEvents.Selected = false;
            this.smartLabelNumberOfEvents.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelNumberOfEvents.Size = new System.Drawing.Size(76, 13);
            this.smartLabelNumberOfEvents.TabIndex = 1;
            this.smartLabelNumberOfEvents.Text = "# of incidents";
            // 
            // smartLabelpAddress
            // 
            this.smartLabelpAddress.AutoSize = true;
            this.smartLabelpAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.smartLabelpAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.smartLabelpAddress.Location = new System.Drawing.Point(341, 7);
            this.smartLabelpAddress.Name = "smartLabelpAddress";
            this.smartLabelpAddress.Selected = false;
            this.smartLabelpAddress.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelpAddress.Size = new System.Drawing.Size(59, 13);
            this.smartLabelpAddress.TabIndex = 1;
            this.smartLabelpAddress.Text = "IP address";
            // 
            // smartLabelType
            // 
            this.smartLabelType.AutoSize = true;
            this.smartLabelType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.smartLabelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.smartLabelType.Location = new System.Drawing.Point(9, 7);
            this.smartLabelType.Name = "smartLabelType";
            this.smartLabelType.Selected = false;
            this.smartLabelType.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelType.Size = new System.Drawing.Size(32, 13);
            this.smartLabelType.TabIndex = 1;
            this.smartLabelType.Text = "Type";
            // 
            // dataGridViewIntrusionLog
            // 
            this.dataGridViewIntrusionLog.AllowUserToAddRows = false;
            this.dataGridViewIntrusionLog.AllowUserToDeleteRows = false;
            this.dataGridViewIntrusionLog.AllowUserToResizeColumns = false;
            this.dataGridViewIntrusionLog.AllowUserToResizeRows = false;
            this.dataGridViewIntrusionLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewIntrusionLog.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewIntrusionLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewIntrusionLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewIntrusionLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIntrusionLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewIntrusionLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIntrusionLog.ColumnHeadersVisible = false;
            this.dataGridViewIntrusionLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogIcon,
            this.LogType,
            this.LatestEntry,
            this.NumberOfEvents,
            this.IpAddress,
            this.Agent,
            this.AgentId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewIntrusionLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewIntrusionLog.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridViewIntrusionLog.Location = new System.Drawing.Point(1, 27);
            this.dataGridViewIntrusionLog.Name = "dataGridViewIntrusionLog";
            this.dataGridViewIntrusionLog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewIntrusionLog.RowHeadersVisible = false;
            this.dataGridViewIntrusionLog.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewIntrusionLog.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataGridViewIntrusionLog.RowTemplate.ReadOnly = true;
            this.dataGridViewIntrusionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewIntrusionLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIntrusionLog.Size = new System.Drawing.Size(808, 300);
            this.dataGridViewIntrusionLog.TabIndex = 0;
            this.dataGridViewIntrusionLog.Resize += new System.EventHandler(this.dataGridViewIntrusionLog_Resize);
            // 
            // panelSecurityLogActionBar
            // 
            this.panelSecurityLogActionBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSecurityLogActionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelSecurityLogActionBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.panelSecurityLogActionBar.Controls.Add(this.comboBoxAgentSelection);
            this.panelSecurityLogActionBar.Controls.Add(this.checkBoxSystemMessages);
            this.panelSecurityLogActionBar.Controls.Add(this.checkBoxHardLocks);
            this.panelSecurityLogActionBar.Controls.Add(this.checkBoxSoftLocks);
            this.panelSecurityLogActionBar.Controls.Add(this.checkBoxFailedLogins);
            this.panelSecurityLogActionBar.Location = new System.Drawing.Point(24, 78);
            this.panelSecurityLogActionBar.Name = "panelSecurityLogActionBar";
            this.panelSecurityLogActionBar.PaintBorder = true;
            this.panelSecurityLogActionBar.Size = new System.Drawing.Size(810, 39);
            this.panelSecurityLogActionBar.TabIndex = 14;
            // 
            // comboBoxAgentSelection
            // 
            this.comboBoxAgentSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAgentSelection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAgentSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.comboBoxAgentSelection.FormattingEnabled = true;
            this.comboBoxAgentSelection.Location = new System.Drawing.Point(10, 7);
            this.comboBoxAgentSelection.Name = "comboBoxAgentSelection";
            this.comboBoxAgentSelection.Size = new System.Drawing.Size(219, 21);
            this.comboBoxAgentSelection.TabIndex = 4;
            this.comboBoxAgentSelection.Text = "All Agents";
            this.comboBoxAgentSelection.SelectedIndexChanged += new System.EventHandler(this.CyberarmsSecurityLog_FilterSelectionChanged);
            // 
            // checkBoxSystemMessages
            // 
            this.checkBoxSystemMessages.AutoSize = true;
            this.checkBoxSystemMessages.Checked = true;
            this.checkBoxSystemMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSystemMessages.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSystemMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxSystemMessages.Location = new System.Drawing.Point(523, 9);
            this.checkBoxSystemMessages.Name = "checkBoxSystemMessages";
            this.checkBoxSystemMessages.Size = new System.Drawing.Size(113, 17);
            this.checkBoxSystemMessages.TabIndex = 3;
            this.checkBoxSystemMessages.Text = "System messages";
            this.checkBoxSystemMessages.UseVisualStyleBackColor = true;
            this.checkBoxSystemMessages.CheckedChanged += new System.EventHandler(this.CyberarmsSecurityLog_FilterSelectionChanged);
            // 
            // checkBoxHardLocks
            // 
            this.checkBoxHardLocks.AutoSize = true;
            this.checkBoxHardLocks.Checked = true;
            this.checkBoxHardLocks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHardLocks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHardLocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxHardLocks.Location = new System.Drawing.Point(437, 9);
            this.checkBoxHardLocks.Name = "checkBoxHardLocks";
            this.checkBoxHardLocks.Size = new System.Drawing.Size(80, 17);
            this.checkBoxHardLocks.TabIndex = 3;
            this.checkBoxHardLocks.Text = "Hard locks";
            this.checkBoxHardLocks.UseVisualStyleBackColor = true;
            this.checkBoxHardLocks.CheckedChanged += new System.EventHandler(this.CyberarmsSecurityLog_FilterSelectionChanged);
            // 
            // checkBoxSoftLocks
            // 
            this.checkBoxSoftLocks.AutoSize = true;
            this.checkBoxSoftLocks.Checked = true;
            this.checkBoxSoftLocks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSoftLocks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSoftLocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxSoftLocks.Location = new System.Drawing.Point(355, 9);
            this.checkBoxSoftLocks.Name = "checkBoxSoftLocks";
            this.checkBoxSoftLocks.Size = new System.Drawing.Size(76, 17);
            this.checkBoxSoftLocks.TabIndex = 3;
            this.checkBoxSoftLocks.Text = "Soft locks";
            this.checkBoxSoftLocks.UseVisualStyleBackColor = true;
            this.checkBoxSoftLocks.CheckedChanged += new System.EventHandler(this.CyberarmsSecurityLog_FilterSelectionChanged);
            // 
            // checkBoxFailedLogins
            // 
            this.checkBoxFailedLogins.AutoSize = true;
            this.checkBoxFailedLogins.Checked = true;
            this.checkBoxFailedLogins.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFailedLogins.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFailedLogins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxFailedLogins.Location = new System.Drawing.Point(257, 9);
            this.checkBoxFailedLogins.Name = "checkBoxFailedLogins";
            this.checkBoxFailedLogins.Size = new System.Drawing.Size(92, 17);
            this.checkBoxFailedLogins.TabIndex = 3;
            this.checkBoxFailedLogins.Text = "Failed logins";
            this.checkBoxFailedLogins.UseVisualStyleBackColor = true;
            this.checkBoxFailedLogins.CheckedChanged += new System.EventHandler(this.CyberarmsSecurityLog_FilterSelectionChanged);
            // 
            // smartLabel1
            // 
            this.smartLabel1.AutoSize = true;
            this.smartLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.smartLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel1.Location = new System.Drawing.Point(68, 28);
            this.smartLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Selected = false;
            this.smartLabel1.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel1.Size = new System.Drawing.Size(196, 20);
            this.smartLabel1.TabIndex = 9;
            this.smartLabel1.Text = "CYBERARMS SECURITY LOG";
            this.smartLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogIcon
            // 
            this.LogIcon.HeaderText = "";
            this.LogIcon.Name = "LogIcon";
            this.LogIcon.ReadOnly = true;
            this.LogIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LogIcon.Width = 20;
            // 
            // LogType
            // 
            this.LogType.HeaderText = "Type";
            this.LogType.Name = "LogType";
            this.LogType.ReadOnly = true;
            this.LogType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LogType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LogType.Width = 90;
            // 
            // LatestEntry
            // 
            this.LatestEntry.HeaderText = "LatestEntry";
            this.LatestEntry.Name = "LatestEntry";
            this.LatestEntry.ReadOnly = true;
            this.LatestEntry.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LatestEntry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LatestEntry.Width = 125;
            // 
            // NumberOfEvents
            // 
            this.NumberOfEvents.HeaderText = "Number of Events";
            this.NumberOfEvents.Name = "NumberOfEvents";
            // 
            // IpAddress
            // 
            this.IpAddress.HeaderText = "IP-Address";
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.ReadOnly = true;
            this.IpAddress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IpAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Agent
            // 
            this.Agent.HeaderText = "Agent / Attacked System";
            this.Agent.Name = "Agent";
            this.Agent.ReadOnly = true;
            this.Agent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Agent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Agent.Width = 600;
            // 
            // AgentId
            // 
            this.AgentId.HeaderText = "AgentId";
            this.AgentId.Name = "AgentId";
            this.AgentId.ReadOnly = true;
            this.AgentId.Visible = false;
            // 
            // CyberarmsSecurityLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelSecurityLogGridPanel);
            this.Controls.Add(this.panelSecurityLogActionBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelEventsCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.smartLabel1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "CyberarmsSecurityLog";
            this.Size = new System.Drawing.Size(868, 471);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSecurityLogGridPanel.ResumeLayout(false);
            this.panelSecurityLogGridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIntrusionLog)).EndInit();
            this.panelSecurityLogActionBar.ResumeLayout(false);
            this.panelSecurityLogActionBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SmartPanel panelSecurityLogGridPanel;
        private SmartLabel smartLabelLatestEntry;
        private SmartLabel smartLabelMessage;
        private SmartLabel smartLabelpAddress;
        private SmartLabel smartLabelType;
        private System.Windows.Forms.DataGridView dataGridViewIntrusionLog;
        private SmartPanel panelSecurityLogActionBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelEventsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelFilter;
        private SmartLabel smartLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBoxAgentSelection;
        private System.Windows.Forms.CheckBox checkBoxSystemMessages;
        private System.Windows.Forms.CheckBox checkBoxHardLocks;
        private System.Windows.Forms.CheckBox checkBoxSoftLocks;
        private System.Windows.Forms.CheckBox checkBoxFailedLogins;
        private SmartLabel smartLabelNumberOfEvents;
        private System.Windows.Forms.DataGridViewImageColumn LogIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogType;
        private System.Windows.Forms.DataGridViewTextBoxColumn LatestEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agent;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentId;


    }
}
