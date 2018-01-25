namespace Cyberarms.IntrusionDetection.Admin {
    partial class CyberarmsSettingsNavigationItem {
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
            this.pictureBoxNavigationIcon = new System.Windows.Forms.PictureBox();
            this.smartLabelAgentName = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNavigationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxNavigationIcon
            // 
            this.pictureBoxNavigationIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxNavigationIcon.Name = "pictureBoxNavigationIcon";
            this.pictureBoxNavigationIcon.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxNavigationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxNavigationIcon.TabIndex = 0;
            this.pictureBoxNavigationIcon.TabStop = false;
            this.pictureBoxNavigationIcon.Click += new System.EventHandler(this.CyberarmsSettingsNavigationItem_Click);
            this.pictureBoxNavigationIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CyberarmsSettingsNavigationItem_MouseDown);
            this.pictureBoxNavigationIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CyberarmsSettingsNavigationItem_MouseUp);
            // 
            // smartLabelAgentName
            // 
            this.smartLabelAgentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartLabelAgentName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabelAgentName.Location = new System.Drawing.Point(29, 3);
            this.smartLabelAgentName.Name = "smartLabelAgentName";
            this.smartLabelAgentName.Selected = false;
            this.smartLabelAgentName.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelAgentName.Size = new System.Drawing.Size(247, 20);
            this.smartLabelAgentName.TabIndex = 1;
            this.smartLabelAgentName.Text = "AgentName";
            this.smartLabelAgentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smartLabelAgentName.Click += new System.EventHandler(this.CyberarmsSettingsNavigationItem_Click);
            this.smartLabelAgentName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CyberarmsSettingsNavigationItem_MouseDown);
            this.smartLabelAgentName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CyberarmsSettingsNavigationItem_MouseUp);
            // 
            // CyberarmsSettingsNavigationItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.smartLabelAgentName);
            this.Controls.Add(this.pictureBoxNavigationIcon);
            this.Name = "CyberarmsSettingsNavigationItem";
            this.Size = new System.Drawing.Size(279, 28);
            this.Click += new System.EventHandler(this.CyberarmsSettingsNavigationItem_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CyberarmsSettingsNavigationItem_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CyberarmsSettingsNavigationItem_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNavigationIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxNavigationIcon;
        private SmartLabel smartLabelAgentName;
    }
}
