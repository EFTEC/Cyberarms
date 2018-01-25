namespace Cyberarms.IntrusionDetection.Admin {
    partial class PanelNotificationSettings {
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
            this.smartLabel5 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartPanel1 = new Cyberarms.IntrusionDetection.Admin.SmartPanel();
            this.smartLabelSummary = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.checkBoxOnUnlock = new System.Windows.Forms.CheckBox();
            this.checkBoxHardLocks = new System.Windows.Forms.CheckBox();
            this.checkBoxMonthlyReport = new System.Windows.Forms.CheckBox();
            this.checkBoxWeeklyReport = new System.Windows.Forms.CheckBox();
            this.checkBoxDailySummary = new System.Windows.Forms.CheckBox();
            this.checkBoxSoftLock = new System.Windows.Forms.CheckBox();
            this.smartLabel1 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.pictureBoxSave = new System.Windows.Forms.PictureBox();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.smartPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).BeginInit();
            this.SuspendLayout();
            // 
            // smartLabel5
            // 
            this.smartLabel5.AutoSize = true;
            this.smartLabel5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.smartLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.smartLabel5.Location = new System.Drawing.Point(23, 0);
            this.smartLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.smartLabel5.Name = "smartLabel5";
            this.smartLabel5.Selected = false;
            this.smartLabel5.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel5.Size = new System.Drawing.Size(187, 20);
            this.smartLabel5.TabIndex = 24;
            this.smartLabel5.Text = "E-mail notification settings";
            this.smartLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // smartPanel1
            // 
            this.smartPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartPanel1.AutoScroll = true;
            this.smartPanel1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.smartPanel1.Controls.Add(this.smartLabelSummary);
            this.smartPanel1.Controls.Add(this.checkBoxOnUnlock);
            this.smartPanel1.Controls.Add(this.checkBoxHardLocks);
            this.smartPanel1.Controls.Add(this.checkBoxMonthlyReport);
            this.smartPanel1.Controls.Add(this.checkBoxWeeklyReport);
            this.smartPanel1.Controls.Add(this.checkBoxDailySummary);
            this.smartPanel1.Controls.Add(this.checkBoxSoftLock);
            this.smartPanel1.Controls.Add(this.smartLabel1);
            this.smartPanel1.Location = new System.Drawing.Point(22, 40);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.PaintBorder = false;
            this.smartPanel1.Size = new System.Drawing.Size(331, 277);
            this.smartPanel1.TabIndex = 25;
            // 
            // smartLabelSummary
            // 
            this.smartLabelSummary.AutoSize = true;
            this.smartLabelSummary.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabelSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabelSummary.Location = new System.Drawing.Point(2, 128);
            this.smartLabelSummary.Name = "smartLabelSummary";
            this.smartLabelSummary.Selected = false;
            this.smartLabelSummary.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelSummary.Size = new System.Drawing.Size(138, 13);
            this.smartLabelSummary.TabIndex = 20;
            this.smartLabelSummary.Text = "Reports (Pro edition only)";
            // 
            // checkBoxOnUnlock
            // 
            this.checkBoxOnUnlock.AutoSize = true;
            this.checkBoxOnUnlock.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOnUnlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxOnUnlock.Location = new System.Drawing.Point(6, 91);
            this.checkBoxOnUnlock.Name = "checkBoxOnUnlock";
            this.checkBoxOnUnlock.Size = new System.Drawing.Size(116, 17);
            this.checkBoxOnUnlock.TabIndex = 19;
            this.checkBoxOnUnlock.Text = "On unlock events";
            this.checkBoxOnUnlock.UseVisualStyleBackColor = true;
            this.checkBoxOnUnlock.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxHardLocks
            // 
            this.checkBoxHardLocks.AutoSize = true;
            this.checkBoxHardLocks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHardLocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxHardLocks.Location = new System.Drawing.Point(6, 68);
            this.checkBoxHardLocks.Name = "checkBoxHardLocks";
            this.checkBoxHardLocks.Size = new System.Drawing.Size(129, 17);
            this.checkBoxHardLocks.TabIndex = 19;
            this.checkBoxHardLocks.Text = "On hard lock events";
            this.checkBoxHardLocks.UseVisualStyleBackColor = true;
            this.checkBoxHardLocks.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxMonthlyReport
            // 
            this.checkBoxMonthlyReport.AutoSize = true;
            this.checkBoxMonthlyReport.Enabled = false;
            this.checkBoxMonthlyReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMonthlyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxMonthlyReport.Location = new System.Drawing.Point(24, 210);
            this.checkBoxMonthlyReport.Name = "checkBoxMonthlyReport";
            this.checkBoxMonthlyReport.Size = new System.Drawing.Size(104, 17);
            this.checkBoxMonthlyReport.TabIndex = 19;
            this.checkBoxMonthlyReport.Text = "Monthly report";
            this.checkBoxMonthlyReport.UseVisualStyleBackColor = true;
            this.checkBoxMonthlyReport.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxWeeklyReport
            // 
            this.checkBoxWeeklyReport.AutoSize = true;
            this.checkBoxWeeklyReport.Enabled = false;
            this.checkBoxWeeklyReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxWeeklyReport.Location = new System.Drawing.Point(24, 182);
            this.checkBoxWeeklyReport.Name = "checkBoxWeeklyReport";
            this.checkBoxWeeklyReport.Size = new System.Drawing.Size(98, 17);
            this.checkBoxWeeklyReport.TabIndex = 19;
            this.checkBoxWeeklyReport.Text = "Weekly report";
            this.checkBoxWeeklyReport.UseVisualStyleBackColor = true;
            this.checkBoxWeeklyReport.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxDailySummary
            // 
            this.checkBoxDailySummary.AutoSize = true;
            this.checkBoxDailySummary.Enabled = false;
            this.checkBoxDailySummary.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDailySummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxDailySummary.Location = new System.Drawing.Point(24, 154);
            this.checkBoxDailySummary.Name = "checkBoxDailySummary";
            this.checkBoxDailySummary.Size = new System.Drawing.Size(86, 17);
            this.checkBoxDailySummary.TabIndex = 19;
            this.checkBoxDailySummary.Text = "Daily report";
            this.checkBoxDailySummary.UseVisualStyleBackColor = true;
            this.checkBoxDailySummary.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxSoftLock
            // 
            this.checkBoxSoftLock.AutoSize = true;
            this.checkBoxSoftLock.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSoftLock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxSoftLock.Location = new System.Drawing.Point(6, 45);
            this.checkBoxSoftLock.Name = "checkBoxSoftLock";
            this.checkBoxSoftLock.Size = new System.Drawing.Size(125, 17);
            this.checkBoxSoftLock.TabIndex = 19;
            this.checkBoxSoftLock.Text = "On soft lock events";
            this.checkBoxSoftLock.UseVisualStyleBackColor = true;
            this.checkBoxSoftLock.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // smartLabel1
            // 
            this.smartLabel1.AutoSize = true;
            this.smartLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel1.Location = new System.Drawing.Point(3, 19);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Selected = false;
            this.smartLabel1.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel1.Size = new System.Drawing.Size(96, 13);
            this.smartLabel1.TabIndex = 11;
            this.smartLabel1.Text = "Basic notification";
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_edit;
            this.pictureBoxEdit.Location = new System.Drawing.Point(331, 0);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxEdit.TabIndex = 23;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Visible = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            this.pictureBoxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // pictureBoxSave
            // 
            this.pictureBoxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSave.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_save;
            this.pictureBoxSave.Location = new System.Drawing.Point(300, 0);
            this.pictureBoxSave.Name = "pictureBoxSave";
            this.pictureBoxSave.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxSave.TabIndex = 26;
            this.pictureBoxSave.TabStop = false;
            this.pictureBoxSave.Visible = false;
            this.pictureBoxSave.Click += new System.EventHandler(this.pictureBoxSave_Click);
            this.pictureBoxSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.BackColor = System.Drawing.Color.White;
            this.buttonDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscard.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDiscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonDiscard.Location = new System.Drawing.Point(220, 339);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(102, 26);
            this.buttonDiscard.TabIndex = 30;
            this.buttonDiscard.Text = "&Discard";
            this.buttonDiscard.UseVisualStyleBackColor = false;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.White;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonSave.Location = new System.Drawing.Point(112, 339);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 26);
            this.buttonSave.TabIndex = 29;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // PanelNotificationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pictureBoxSave);
            this.Controls.Add(this.smartLabel5);
            this.Controls.Add(this.smartPanel1);
            this.Controls.Add(this.pictureBoxEdit);
            this.Name = "PanelNotificationSettings";
            this.Size = new System.Drawing.Size(356, 378);
            this.smartPanel1.ResumeLayout(false);
            this.smartPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SmartLabel smartLabel5;
        private SmartPanel smartPanel1;
        private System.Windows.Forms.CheckBox checkBoxSoftLock;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.CheckBox checkBoxHardLocks;
        private System.Windows.Forms.CheckBox checkBoxMonthlyReport;
        private System.Windows.Forms.CheckBox checkBoxWeeklyReport;
        private System.Windows.Forms.CheckBox checkBoxDailySummary;
        private SmartLabel smartLabel1;
        private System.Windows.Forms.PictureBox pictureBoxSave;
        private SmartLabel smartLabelSummary;
        private System.Windows.Forms.CheckBox checkBoxOnUnlock;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Button buttonSave;
    }
}
