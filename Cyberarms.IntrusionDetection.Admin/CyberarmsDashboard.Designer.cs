namespace Cyberarms.IntrusionDetection.Admin {
    partial class CyberarmsDashboard {
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
            this.label2 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.label1 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.panelSoftLocks = new System.Windows.Forms.Panel();
            this.labelSoftLocksName = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.labelSoftLocks = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.panelUnsuccessfulLogins = new System.Windows.Forms.Panel();
            this.labelUnsuccessfulLoginsName = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.labelUnsuccessfulLogins = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.panelHardLocks = new System.Windows.Forms.Panel();
            this.labelHardLocks = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.labelHardLocksName = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.flowLayoutPanelPlugins = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSoftLocks.SuspendLayout();
            this.panelUnsuccessfulLogins.SuspendLayout();
            this.panelHardLocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.label2.Location = new System.Drawing.Point(387, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Selected = false;
            this.label2.SelectedColor = System.Drawing.Color.Empty;
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Installed agents";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Selected = false;
            this.label1.SelectedColor = System.Drawing.Color.Empty;
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Locks && login attempts";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSoftLocks
            // 
            this.panelSoftLocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.panelSoftLocks.Controls.Add(this.labelSoftLocksName);
            this.panelSoftLocks.Controls.Add(this.labelSoftLocks);
            this.panelSoftLocks.Location = new System.Drawing.Point(156, 66);
            this.panelSoftLocks.Name = "panelSoftLocks";
            this.panelSoftLocks.Size = new System.Drawing.Size(120, 120);
            this.panelSoftLocks.TabIndex = 6;
            // 
            // labelSoftLocksName
            // 
            this.labelSoftLocksName.AutoSize = true;
            this.labelSoftLocksName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoftLocksName.ForeColor = System.Drawing.Color.White;
            this.labelSoftLocksName.Location = new System.Drawing.Point(5, 6);
            this.labelSoftLocksName.Margin = new System.Windows.Forms.Padding(0);
            this.labelSoftLocksName.Name = "labelSoftLocksName";
            this.labelSoftLocksName.Selected = false;
            this.labelSoftLocksName.SelectedColor = System.Drawing.Color.Empty;
            this.labelSoftLocksName.Size = new System.Drawing.Size(98, 15);
            this.labelSoftLocksName.TabIndex = 0;
            this.labelSoftLocksName.Text = "current soft locks";
            this.labelSoftLocksName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSoftLocks
            // 
            this.labelSoftLocks.Font = new System.Drawing.Font("Segoe UI", 30F);
            this.labelSoftLocks.ForeColor = System.Drawing.Color.White;
            this.labelSoftLocks.Location = new System.Drawing.Point(0, 62);
            this.labelSoftLocks.Margin = new System.Windows.Forms.Padding(0);
            this.labelSoftLocks.Name = "labelSoftLocks";
            this.labelSoftLocks.Selected = false;
            this.labelSoftLocks.SelectedColor = System.Drawing.Color.Empty;
            this.labelSoftLocks.Size = new System.Drawing.Size(120, 58);
            this.labelSoftLocks.TabIndex = 0;
            this.labelSoftLocks.Text = "0";
            this.labelSoftLocks.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panelUnsuccessfulLogins
            // 
            this.panelUnsuccessfulLogins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(46)))), ((int)(((byte)(100)))));
            this.panelUnsuccessfulLogins.Controls.Add(this.labelUnsuccessfulLoginsName);
            this.panelUnsuccessfulLogins.Controls.Add(this.labelUnsuccessfulLogins);
            this.panelUnsuccessfulLogins.Location = new System.Drawing.Point(29, 192);
            this.panelUnsuccessfulLogins.Name = "panelUnsuccessfulLogins";
            this.panelUnsuccessfulLogins.Size = new System.Drawing.Size(247, 130);
            this.panelUnsuccessfulLogins.TabIndex = 8;
            // 
            // labelUnsuccessfulLoginsName
            // 
            this.labelUnsuccessfulLoginsName.AutoSize = true;
            this.labelUnsuccessfulLoginsName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnsuccessfulLoginsName.ForeColor = System.Drawing.Color.White;
            this.labelUnsuccessfulLoginsName.Location = new System.Drawing.Point(5, 10);
            this.labelUnsuccessfulLoginsName.Margin = new System.Windows.Forms.Padding(0);
            this.labelUnsuccessfulLoginsName.Name = "labelUnsuccessfulLoginsName";
            this.labelUnsuccessfulLoginsName.Selected = false;
            this.labelUnsuccessfulLoginsName.SelectedColor = System.Drawing.Color.Empty;
            this.labelUnsuccessfulLoginsName.Size = new System.Drawing.Size(155, 30);
            this.labelUnsuccessfulLoginsName.TabIndex = 0;
            this.labelUnsuccessfulLoginsName.Text = "unsuccessful login attempts\r\n(last 30 days)";
            this.labelUnsuccessfulLoginsName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUnsuccessfulLogins
            // 
            this.labelUnsuccessfulLogins.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnsuccessfulLogins.ForeColor = System.Drawing.Color.White;
            this.labelUnsuccessfulLogins.Location = new System.Drawing.Point(0, 44);
            this.labelUnsuccessfulLogins.Margin = new System.Windows.Forms.Padding(0);
            this.labelUnsuccessfulLogins.Name = "labelUnsuccessfulLogins";
            this.labelUnsuccessfulLogins.Selected = false;
            this.labelUnsuccessfulLogins.SelectedColor = System.Drawing.Color.Empty;
            this.labelUnsuccessfulLogins.Size = new System.Drawing.Size(247, 83);
            this.labelUnsuccessfulLogins.TabIndex = 0;
            this.labelUnsuccessfulLogins.Text = "0";
            this.labelUnsuccessfulLogins.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panelHardLocks
            // 
            this.panelHardLocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(227)))));
            this.panelHardLocks.Controls.Add(this.labelHardLocks);
            this.panelHardLocks.Controls.Add(this.labelHardLocksName);
            this.panelHardLocks.Location = new System.Drawing.Point(29, 66);
            this.panelHardLocks.Name = "panelHardLocks";
            this.panelHardLocks.Size = new System.Drawing.Size(120, 120);
            this.panelHardLocks.TabIndex = 7;
            // 
            // labelHardLocks
            // 
            this.labelHardLocks.Font = new System.Drawing.Font("Segoe UI", 30F);
            this.labelHardLocks.ForeColor = System.Drawing.Color.White;
            this.labelHardLocks.Location = new System.Drawing.Point(0, 62);
            this.labelHardLocks.Margin = new System.Windows.Forms.Padding(0);
            this.labelHardLocks.Name = "labelHardLocks";
            this.labelHardLocks.Selected = false;
            this.labelHardLocks.SelectedColor = System.Drawing.Color.Empty;
            this.labelHardLocks.Size = new System.Drawing.Size(121, 58);
            this.labelHardLocks.TabIndex = 0;
            this.labelHardLocks.Text = "0";
            this.labelHardLocks.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // labelHardLocksName
            // 
            this.labelHardLocksName.AutoSize = true;
            this.labelHardLocksName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHardLocksName.ForeColor = System.Drawing.Color.White;
            this.labelHardLocksName.Location = new System.Drawing.Point(5, 6);
            this.labelHardLocksName.Margin = new System.Windows.Forms.Padding(0);
            this.labelHardLocksName.Name = "labelHardLocksName";
            this.labelHardLocksName.Selected = false;
            this.labelHardLocksName.SelectedColor = System.Drawing.Color.Empty;
            this.labelHardLocksName.Size = new System.Drawing.Size(102, 15);
            this.labelHardLocksName.TabIndex = 0;
            this.labelHardLocksName.Text = "current hard locks";
            this.labelHardLocksName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelPlugins
            // 
            this.flowLayoutPanelPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPlugins.AutoScroll = true;
            this.flowLayoutPanelPlugins.Location = new System.Drawing.Point(392, 66);
            this.flowLayoutPanelPlugins.Name = "flowLayoutPanelPlugins";
            this.flowLayoutPanelPlugins.Size = new System.Drawing.Size(307, 256);
            this.flowLayoutPanelPlugins.TabIndex = 5;
            // 
            // CyberarmsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelSoftLocks);
            this.Controls.Add(this.panelUnsuccessfulLogins);
            this.Controls.Add(this.panelHardLocks);
            this.Controls.Add(this.flowLayoutPanelPlugins);
            this.Name = "CyberarmsDashboard";
            this.Size = new System.Drawing.Size(741, 372);
            this.panelSoftLocks.ResumeLayout(false);
            this.panelSoftLocks.PerformLayout();
            this.panelUnsuccessfulLogins.ResumeLayout(false);
            this.panelUnsuccessfulLogins.PerformLayout();
            this.panelHardLocks.ResumeLayout(false);
            this.panelHardLocks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SmartLabel label2;
        private SmartLabel label1;
        private System.Windows.Forms.Panel panelSoftLocks;
        private SmartLabel labelSoftLocksName;
        private SmartLabel labelSoftLocks;
        private System.Windows.Forms.Panel panelUnsuccessfulLogins;
        private SmartLabel labelUnsuccessfulLoginsName;
        private SmartLabel labelUnsuccessfulLogins;
        private System.Windows.Forms.Panel panelHardLocks;
        private SmartLabel labelHardLocks;
        private SmartLabel labelHardLocksName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPlugins;
    }
}
