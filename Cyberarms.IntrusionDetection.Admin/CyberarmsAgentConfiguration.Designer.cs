namespace Cyberarms.IntrusionDetection.Admin {
    partial class CyberarmsAgentConfiguration {
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
            this.configurationPanel = new Cyberarms.IntrusionDetection.Admin.SmartPanel();
            this.cyberarmsSettingsNavigation = new Cyberarms.IntrusionDetection.Admin.CyberarmsSettingsNavigation();
            this.SuspendLayout();
            // 
            // configurationPanel
            // 
            this.configurationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configurationPanel.AutoScroll = true;
            this.configurationPanel.BorderColor = System.Drawing.SystemColors.ControlText;
            this.configurationPanel.Location = new System.Drawing.Point(322, 28);
            this.configurationPanel.Name = "configurationPanel";
            this.configurationPanel.PaintBorder = false;
            this.configurationPanel.Size = new System.Drawing.Size(463, 491);
            this.configurationPanel.TabIndex = 2;
            // 
            // cyberarmsSettingsNavigation
            // 
            this.cyberarmsSettingsNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cyberarmsSettingsNavigation.BackColor = System.Drawing.Color.White;
            this.cyberarmsSettingsNavigation.Location = new System.Drawing.Point(24, 28);
            this.cyberarmsSettingsNavigation.Name = "cyberarmsSettingsNavigation";
            this.cyberarmsSettingsNavigation.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.cyberarmsSettingsNavigation.ShowSeparator = true;
            this.cyberarmsSettingsNavigation.ShowTopMenu = false;
            this.cyberarmsSettingsNavigation.Size = new System.Drawing.Size(292, 491);
            this.cyberarmsSettingsNavigation.TabIndex = 0;
            this.cyberarmsSettingsNavigation.NavigationChanged += new System.EventHandler(this.cyberarmsSettingsNavigation_NavigationChanged);
            // 
            // CyberarmsAgentConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configurationPanel);
            this.Controls.Add(this.cyberarmsSettingsNavigation);
            this.Name = "CyberarmsAgentConfiguration";
            this.Size = new System.Drawing.Size(799, 536);
            this.ResumeLayout(false);

        }

        #endregion

        private CyberarmsSettingsNavigation cyberarmsSettingsNavigation;
        private SmartPanel configurationPanel;
    }
}
