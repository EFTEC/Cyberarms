namespace Cyberarms.IntrusionDetection.Admin {
    partial class PanelSmtpSettings {
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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxSmtpServer = new System.Windows.Forms.TextBox();
            this.textBoxRecipient = new System.Windows.Forms.TextBox();
            this.textBoxSender = new System.Windows.Forms.TextBox();
            this.checkBoxAuthentication = new System.Windows.Forms.CheckBox();
            this.smartLabel4 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabel3 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabel2 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabel1 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.smartLabel6 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.checkBoxUseSSL = new System.Windows.Forms.CheckBox();
            this.smartLabel8 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.textBoxSmtpPort = new System.Windows.Forms.TextBox();
            this.smartPanel1 = new Cyberarms.IntrusionDetection.Admin.SmartPanel();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.smartLabelTestError = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.errSmtpPort = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.buttonTestSmtpSettings = new System.Windows.Forms.Button();
            this.pictureBoxSave = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            this.smartPanel1.SuspendLayout();
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
            this.smartLabel5.Size = new System.Drawing.Size(182, 20);
            this.smartLabel5.TabIndex = 21;
            this.smartLabel5.Text = "SMTP server configuration";
            this.smartLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxUsername.Location = new System.Drawing.Point(112, 186);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(210, 22);
            this.textBoxUsername.TabIndex = 6;
            this.textBoxUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBoxSmtpServer
            // 
            this.textBoxSmtpServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSmtpServer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSmtpServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxSmtpServer.Location = new System.Drawing.Point(112, 64);
            this.textBoxSmtpServer.Name = "textBoxSmtpServer";
            this.textBoxSmtpServer.Size = new System.Drawing.Size(210, 22);
            this.textBoxSmtpServer.TabIndex = 2;
            this.textBoxSmtpServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBoxRecipient
            // 
            this.textBoxRecipient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRecipient.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRecipient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxRecipient.Location = new System.Drawing.Point(112, 36);
            this.textBoxRecipient.Name = "textBoxRecipient";
            this.textBoxRecipient.Size = new System.Drawing.Size(210, 22);
            this.textBoxRecipient.TabIndex = 1;
            this.textBoxRecipient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBoxSender
            // 
            this.textBoxSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSender.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxSender.Location = new System.Drawing.Point(112, 8);
            this.textBoxSender.Name = "textBoxSender";
            this.textBoxSender.Size = new System.Drawing.Size(210, 22);
            this.textBoxSender.TabIndex = 0;
            this.textBoxSender.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBoxAuthentication
            // 
            this.checkBoxAuthentication.AutoSize = true;
            this.checkBoxAuthentication.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAuthentication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxAuthentication.Location = new System.Drawing.Point(6, 161);
            this.checkBoxAuthentication.Name = "checkBoxAuthentication";
            this.checkBoxAuthentication.Size = new System.Drawing.Size(203, 17);
            this.checkBoxAuthentication.TabIndex = 5;
            this.checkBoxAuthentication.Text = "This server requires authentication";
            this.checkBoxAuthentication.UseVisualStyleBackColor = true;
            this.checkBoxAuthentication.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // smartLabel4
            // 
            this.smartLabel4.AutoSize = true;
            this.smartLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel4.Location = new System.Drawing.Point(3, 188);
            this.smartLabel4.Name = "smartLabel4";
            this.smartLabel4.Selected = false;
            this.smartLabel4.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel4.Size = new System.Drawing.Size(58, 13);
            this.smartLabel4.TabIndex = 11;
            this.smartLabel4.Text = "Username";
            // 
            // smartLabel3
            // 
            this.smartLabel3.AutoSize = true;
            this.smartLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel3.Location = new System.Drawing.Point(3, 66);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Selected = false;
            this.smartLabel3.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel3.Size = new System.Drawing.Size(67, 13);
            this.smartLabel3.TabIndex = 14;
            this.smartLabel3.Text = "SMTP server";
            // 
            // smartLabel2
            // 
            this.smartLabel2.AutoSize = true;
            this.smartLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel2.Location = new System.Drawing.Point(3, 38);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Selected = false;
            this.smartLabel2.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel2.Size = new System.Drawing.Size(98, 13);
            this.smartLabel2.TabIndex = 13;
            this.smartLabel2.Text = "Recipient address";
            // 
            // smartLabel1
            // 
            this.smartLabel1.AutoSize = true;
            this.smartLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel1.Location = new System.Drawing.Point(3, 10);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Selected = false;
            this.smartLabel1.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel1.Size = new System.Drawing.Size(86, 13);
            this.smartLabel1.TabIndex = 12;
            this.smartLabel1.Text = "Sender address";
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_edit;
            this.pictureBoxEdit.Location = new System.Drawing.Point(460, 0);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxEdit.TabIndex = 20;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Visible = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            this.pictureBoxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxPassword.Location = new System.Drawing.Point(112, 214);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(210, 22);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // smartLabel6
            // 
            this.smartLabel6.AutoSize = true;
            this.smartLabel6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel6.Location = new System.Drawing.Point(3, 216);
            this.smartLabel6.Name = "smartLabel6";
            this.smartLabel6.Selected = false;
            this.smartLabel6.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel6.Size = new System.Drawing.Size(56, 13);
            this.smartLabel6.TabIndex = 11;
            this.smartLabel6.Text = "Password";
            // 
            // checkBoxUseSSL
            // 
            this.checkBoxUseSSL.AutoSize = true;
            this.checkBoxUseSSL.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUseSSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxUseSSL.Location = new System.Drawing.Point(6, 120);
            this.checkBoxUseSSL.Name = "checkBoxUseSSL";
            this.checkBoxUseSSL.Size = new System.Drawing.Size(165, 17);
            this.checkBoxUseSSL.TabIndex = 4;
            this.checkBoxUseSSL.Text = "Use SSL for communication";
            this.checkBoxUseSSL.UseVisualStyleBackColor = true;
            this.checkBoxUseSSL.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // smartLabel8
            // 
            this.smartLabel8.AutoSize = true;
            this.smartLabel8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel8.Location = new System.Drawing.Point(3, 94);
            this.smartLabel8.Name = "smartLabel8";
            this.smartLabel8.Selected = false;
            this.smartLabel8.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel8.Size = new System.Drawing.Size(79, 13);
            this.smartLabel8.TabIndex = 14;
            this.smartLabel8.Text = "SMTP/SSL Port";
            // 
            // textBoxSmtpPort
            // 
            this.textBoxSmtpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSmtpPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSmtpPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxSmtpPort.Location = new System.Drawing.Point(112, 92);
            this.textBoxSmtpPort.Name = "textBoxSmtpPort";
            this.textBoxSmtpPort.Size = new System.Drawing.Size(210, 22);
            this.textBoxSmtpPort.TabIndex = 3;
            this.textBoxSmtpPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // smartPanel1
            // 
            this.smartPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartPanel1.AutoScroll = true;
            this.smartPanel1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.smartPanel1.Controls.Add(this.buttonDiscard);
            this.smartPanel1.Controls.Add(this.buttonSave);
            this.smartPanel1.Controls.Add(this.smartLabelTestError);
            this.smartPanel1.Controls.Add(this.errSmtpPort);
            this.smartPanel1.Controls.Add(this.buttonTestSmtpSettings);
            this.smartPanel1.Controls.Add(this.textBoxPassword);
            this.smartPanel1.Controls.Add(this.textBoxUsername);
            this.smartPanel1.Controls.Add(this.textBoxSmtpPort);
            this.smartPanel1.Controls.Add(this.textBoxSmtpServer);
            this.smartPanel1.Controls.Add(this.textBoxRecipient);
            this.smartPanel1.Controls.Add(this.textBoxSender);
            this.smartPanel1.Controls.Add(this.checkBoxUseSSL);
            this.smartPanel1.Controls.Add(this.checkBoxAuthentication);
            this.smartPanel1.Controls.Add(this.smartLabel6);
            this.smartPanel1.Controls.Add(this.smartLabel8);
            this.smartPanel1.Controls.Add(this.smartLabel4);
            this.smartPanel1.Controls.Add(this.smartLabel3);
            this.smartPanel1.Controls.Add(this.smartLabel2);
            this.smartPanel1.Controls.Add(this.smartLabel1);
            this.smartPanel1.Location = new System.Drawing.Point(22, 40);
            this.smartPanel1.Name = "smartPanel1";
            this.smartPanel1.PaintBorder = false;
            this.smartPanel1.Size = new System.Drawing.Size(462, 359);
            this.smartPanel1.TabIndex = 0;
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.BackColor = System.Drawing.Color.White;
            this.buttonDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscard.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDiscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonDiscard.Location = new System.Drawing.Point(220, 296);
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
            this.buttonSave.Location = new System.Drawing.Point(112, 296);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 26);
            this.buttonSave.TabIndex = 29;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // smartLabelTestError
            // 
            this.smartLabelTestError.AutoSize = true;
            this.smartLabelTestError.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabelTestError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.smartLabelTestError.Location = new System.Drawing.Point(3, 323);
            this.smartLabelTestError.Name = "smartLabelTestError";
            this.smartLabelTestError.Selected = false;
            this.smartLabelTestError.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabelTestError.Size = new System.Drawing.Size(83, 13);
            this.smartLabelTestError.TabIndex = 15;
            this.smartLabelTestError.Text = "Smtp test error";
            this.smartLabelTestError.Visible = false;
            // 
            // errSmtpPort
            // 
            this.errSmtpPort.AutoSize = true;
            this.errSmtpPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errSmtpPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.errSmtpPort.Location = new System.Drawing.Point(329, 94);
            this.errSmtpPort.Name = "errSmtpPort";
            this.errSmtpPort.Selected = false;
            this.errSmtpPort.SelectedColor = System.Drawing.Color.Empty;
            this.errSmtpPort.Size = new System.Drawing.Size(130, 13);
            this.errSmtpPort.TabIndex = 15;
            this.errSmtpPort.Text = "value must be a number";
            this.errSmtpPort.Visible = false;
            // 
            // buttonTestSmtpSettings
            // 
            this.buttonTestSmtpSettings.BackColor = System.Drawing.Color.White;
            this.buttonTestSmtpSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTestSmtpSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTestSmtpSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonTestSmtpSettings.Location = new System.Drawing.Point(332, 212);
            this.buttonTestSmtpSettings.Name = "buttonTestSmtpSettings";
            this.buttonTestSmtpSettings.Size = new System.Drawing.Size(74, 26);
            this.buttonTestSmtpSettings.TabIndex = 8;
            this.buttonTestSmtpSettings.Text = "Test";
            this.buttonTestSmtpSettings.UseVisualStyleBackColor = false;
            this.buttonTestSmtpSettings.Click += new System.EventHandler(this.buttonTestSmtpSettings_Click);
            // 
            // pictureBoxSave
            // 
            this.pictureBoxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSave.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_save;
            this.pictureBoxSave.Location = new System.Drawing.Point(429, 0);
            this.pictureBoxSave.Name = "pictureBoxSave";
            this.pictureBoxSave.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxSave.TabIndex = 22;
            this.pictureBoxSave.TabStop = false;
            this.pictureBoxSave.Visible = false;
            this.pictureBoxSave.Click += new System.EventHandler(this.pictureBoxSave_Click);
            this.pictureBoxSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // PanelSmtpSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxSave);
            this.Controls.Add(this.smartLabel5);
            this.Controls.Add(this.pictureBoxEdit);
            this.Controls.Add(this.smartPanel1);
            this.Name = "PanelSmtpSettings";
            this.Size = new System.Drawing.Size(486, 402);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            this.smartPanel1.ResumeLayout(false);
            this.smartPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SmartLabel smartLabel5;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxSmtpServer;
        private System.Windows.Forms.TextBox textBoxRecipient;
        private System.Windows.Forms.TextBox textBoxSender;
        private System.Windows.Forms.CheckBox checkBoxAuthentication;
        private SmartLabel smartLabel4;
        private SmartLabel smartLabel3;
        private SmartLabel smartLabel2;
        private SmartLabel smartLabel1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private SmartLabel smartLabel6;
        private System.Windows.Forms.CheckBox checkBoxUseSSL;
        private SmartLabel smartLabel8;
        private System.Windows.Forms.TextBox textBoxSmtpPort;
        private SmartPanel smartPanel1;
        private System.Windows.Forms.Button buttonTestSmtpSettings;
        private System.Windows.Forms.PictureBox pictureBoxSave;
        private SmartLabel errSmtpPort;
        private SmartLabel smartLabelTestError;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Button buttonSave;
    }
}
