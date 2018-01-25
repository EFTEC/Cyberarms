namespace Cyberarms.IntrusionDetection.Admin {
    partial class CyberarmsSettingsNavigation {
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
            this.flowLayoutPanelNavigationItems = new System.Windows.Forms.FlowLayoutPanel();
            this.smartPanelActionBar = new Cyberarms.IntrusionDetection.Admin.SmartPanel();
            this.pictureBoxRemove = new System.Windows.Forms.PictureBox();
            this.pictureBoxAdd = new System.Windows.Forms.PictureBox();
            this.smartPanelActionBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNavigationItems
            // 
            this.flowLayoutPanelNavigationItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelNavigationItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelNavigationItems.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanelNavigationItems.Name = "flowLayoutPanelNavigationItems";
            this.flowLayoutPanelNavigationItems.Size = new System.Drawing.Size(268, 463);
            this.flowLayoutPanelNavigationItems.TabIndex = 0;
            // 
            // smartPanelActionBar
            // 
            this.smartPanelActionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.smartPanelActionBar.BorderColor = System.Drawing.SystemColors.ControlText;
            this.smartPanelActionBar.Controls.Add(this.pictureBoxRemove);
            this.smartPanelActionBar.Controls.Add(this.pictureBoxAdd);
            this.smartPanelActionBar.Location = new System.Drawing.Point(6, 1);
            this.smartPanelActionBar.Name = "smartPanelActionBar";
            this.smartPanelActionBar.PaintBorder = false;
            this.smartPanelActionBar.Size = new System.Drawing.Size(265, 34);
            this.smartPanelActionBar.TabIndex = 1;
            // 
            // pictureBoxRemove
            // 
            this.pictureBoxRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxRemove.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_delete;
            this.pictureBoxRemove.Location = new System.Drawing.Point(229, 4);
            this.pictureBoxRemove.Name = "pictureBoxRemove";
            this.pictureBoxRemove.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxRemove.TabIndex = 0;
            this.pictureBoxRemove.TabStop = false;
            this.pictureBoxRemove.Visible = false;
            this.pictureBoxRemove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRemove_MouseDown);
            this.pictureBoxRemove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRemove_MouseUp);
            // 
            // pictureBoxAdd
            // 
            this.pictureBoxAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAdd.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_add;
            this.pictureBoxAdd.Location = new System.Drawing.Point(191, 4);
            this.pictureBoxAdd.Name = "pictureBoxAdd";
            this.pictureBoxAdd.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxAdd.TabIndex = 0;
            this.pictureBoxAdd.TabStop = false;
            this.pictureBoxAdd.Visible = false;
            this.pictureBoxAdd.Click += new System.EventHandler(this.pictureBoxAdd_Click);
            this.pictureBoxAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxAdd_MouseDown);
            this.pictureBoxAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxAdd_MouseUp);
            // 
            // CyberarmsSettingsNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.smartPanelActionBar);
            this.Controls.Add(this.flowLayoutPanelNavigationItems);
            this.Name = "CyberarmsSettingsNavigation";
            this.Size = new System.Drawing.Size(286, 500);
            this.smartPanelActionBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavigationItems;
        private SmartPanel smartPanelActionBar;
        private System.Windows.Forms.PictureBox pictureBoxAdd;
        private System.Windows.Forms.PictureBox pictureBoxRemove;

    }
}
