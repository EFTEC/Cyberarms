namespace Cyberarms.IntrusionDetection.Admin {
    partial class SplashScreen {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.smartLabel1 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabelVersion = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabelStatus = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartPanel1 = new Cyberarms.IntrusionDetection.Admin.SmartPanel();
            this.smartLabelEdition = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.smartPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.Paladin_Icon_128;
            this.pictureBox1.Location = new System.Drawing.Point(16, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // smartLabel1
            // 
            this.smartLabel1.AutoSize = true;
            this.smartLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.smartLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel1.Location = new System.Drawing.Point(169, 21);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Selected = false;
            this.smartLabel1.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel1.Size = new System.Drawing.Size(257, 25);
            this.smartLabel1.TabIndex = 1;
            this.smartLabel1.Text = "Cyberarms IDDS is starting...";
            // 
            // smartLabelVersion
            // 
            this.smartLabelVersion.AutoSize = true;
            this.smartLabelVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.smartLabelVersion.Location = new System.Drawing.Point(170, 55);
            this.smartLabelVersion.Name = "smartLabelVersion";
            this.smartLabelVersion.Selected = false;
            this.smartLabelVersion.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelVersion.Size = new System.Drawing.Size(55, 19);
            this.smartLabelVersion.TabIndex = 2;
            this.smartLabelVersion.Text = "Version";
            // 
            // smartLabelStatus
            // 
            this.smartLabelStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabelStatus.Location = new System.Drawing.Point(170, 112);
            this.smartLabelStatus.Name = "smartLabelStatus";
            this.smartLabelStatus.Selected = false;
            this.smartLabelStatus.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelStatus.Size = new System.Drawing.Size(236, 37);
            this.smartLabelStatus.TabIndex = 3;
            this.smartLabelStatus.Text = "status";
            // 
            // smartPanel1
            // 
            this.smartPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.smartPanel1.Controls.Add(this.smartLabelStatus);
            this.smartPanel1.Controls.Add(this.smartLabelEdition);
            this.smartPanel1.Controls.Add(this.smartLabelVersion);
            this.smartPanel1.Controls.Add(this.smartLabel1);
            this.smartPanel1.Controls.Add(this.pictureBox1);
            this.smartPanel1.Location = new System.Drawing.Point(0, 0);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.PaintBorder = true;
            this.smartPanel1.Size = new System.Drawing.Size(442, 170);
            this.smartPanel1.TabIndex = 4;
            // 
            // smartLabelEdition
            // 
            this.smartLabelEdition.AutoSize = true;
            this.smartLabelEdition.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabelEdition.Location = new System.Drawing.Point(171, 78);
            this.smartLabelEdition.Name = "smartLabelEdition";
            this.smartLabelEdition.Selected = false;
            this.smartLabelEdition.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelEdition.Size = new System.Drawing.Size(41, 15);
            this.smartLabelEdition.TabIndex = 2;
            this.smartLabelEdition.Text = "Edition";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(443, 170);
            this.ControlBox = false;
            this.Controls.Add(this.smartPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cyberarms IDDS is starting up...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.smartPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private SmartLabel smartLabel1;
        private SmartLabel smartLabelVersion;
        private SmartLabel smartLabelStatus;
        private SmartPanel smartPanel1;
        private SmartLabel smartLabelEdition;
    }
}