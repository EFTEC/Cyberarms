namespace Cyberarms.IntrusionDetection.Admin {
    partial class PanelLockoutConfiguration {
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
            this.checkBoxLockForever = new System.Windows.Forms.CheckBox();
            this.textBoxSoftLocks = new System.Windows.Forms.TextBox();
            this.textBoxSoftLockDuration = new System.Windows.Forms.TextBox();
            this.textBoxHardLocks = new System.Windows.Forms.TextBox();
            this.textBoxHardLockDuration = new System.Windows.Forms.TextBox();
            this.errSoftLocks = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.errSoftLockDuration = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.errHardLocks = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.errHardLockDuration = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.pictureBoxSave = new System.Windows.Forms.PictureBox();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.smartLabel5 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabel4 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabel3 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabel2 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.smartLabel1 = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxLockForever
            // 
            this.checkBoxLockForever.AutoSize = true;
            this.checkBoxLockForever.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLockForever.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.checkBoxLockForever.Location = new System.Drawing.Point(27, 159);
            this.checkBoxLockForever.Name = "checkBoxLockForever";
            this.checkBoxLockForever.Size = new System.Drawing.Size(114, 17);
            this.checkBoxLockForever.TabIndex = 4;
            this.checkBoxLockForever.Text = "Hard lock forever";
            this.checkBoxLockForever.UseVisualStyleBackColor = true;
            this.checkBoxLockForever.CheckedChanged += new System.EventHandler(this.checkBoxLockForever_CheckedChanged);
            // 
            // textBoxSoftLocks
            // 
            this.textBoxSoftLocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSoftLocks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoftLocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxSoftLocks.Location = new System.Drawing.Point(257, 46);
            this.textBoxSoftLocks.Name = "textBoxSoftLocks";
            this.textBoxSoftLocks.Size = new System.Drawing.Size(65, 22);
            this.textBoxSoftLocks.TabIndex = 0;
            this.textBoxSoftLocks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSoftLocks_KeyPress);
            // 
            // textBoxSoftLockDuration
            // 
            this.textBoxSoftLockDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSoftLockDuration.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoftLockDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxSoftLockDuration.Location = new System.Drawing.Point(257, 74);
            this.textBoxSoftLockDuration.Name = "textBoxSoftLockDuration";
            this.textBoxSoftLockDuration.Size = new System.Drawing.Size(65, 22);
            this.textBoxSoftLockDuration.TabIndex = 1;
            this.textBoxSoftLockDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSoftLocks_KeyPress);
            // 
            // textBoxHardLocks
            // 
            this.textBoxHardLocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHardLocks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHardLocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxHardLocks.Location = new System.Drawing.Point(257, 102);
            this.textBoxHardLocks.Name = "textBoxHardLocks";
            this.textBoxHardLocks.Size = new System.Drawing.Size(65, 22);
            this.textBoxHardLocks.TabIndex = 2;
            this.textBoxHardLocks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSoftLocks_KeyPress);
            // 
            // textBoxHardLockDuration
            // 
            this.textBoxHardLockDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHardLockDuration.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHardLockDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.textBoxHardLockDuration.Location = new System.Drawing.Point(257, 130);
            this.textBoxHardLockDuration.Name = "textBoxHardLockDuration";
            this.textBoxHardLockDuration.Size = new System.Drawing.Size(65, 22);
            this.textBoxHardLockDuration.TabIndex = 3;
            this.textBoxHardLockDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSoftLocks_KeyPress);
            // 
            // errSoftLocks
            // 
            this.errSoftLocks.AutoSize = true;
            this.errSoftLocks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errSoftLocks.ForeColor = System.Drawing.Color.Red;
            this.errSoftLocks.Location = new System.Drawing.Point(328, 48);
            this.errSoftLocks.Name = "errSoftLocks";
            this.errSoftLocks.Selected = false;
            this.errSoftLocks.SelectedColor = System.Drawing.Color.Empty;
            this.errSoftLocks.Size = new System.Drawing.Size(130, 13);
            this.errSoftLocks.TabIndex = 11;
            this.errSoftLocks.Text = "value must be a number";
            this.errSoftLocks.Visible = false;
            // 
            // errSoftLockDuration
            // 
            this.errSoftLockDuration.AutoSize = true;
            this.errSoftLockDuration.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errSoftLockDuration.ForeColor = System.Drawing.Color.Red;
            this.errSoftLockDuration.Location = new System.Drawing.Point(328, 74);
            this.errSoftLockDuration.Name = "errSoftLockDuration";
            this.errSoftLockDuration.Selected = false;
            this.errSoftLockDuration.SelectedColor = System.Drawing.Color.Empty;
            this.errSoftLockDuration.Size = new System.Drawing.Size(130, 13);
            this.errSoftLockDuration.TabIndex = 11;
            this.errSoftLockDuration.Text = "value must be a number";
            this.errSoftLockDuration.Visible = false;
            // 
            // errHardLocks
            // 
            this.errHardLocks.AutoSize = true;
            this.errHardLocks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errHardLocks.ForeColor = System.Drawing.Color.Red;
            this.errHardLocks.Location = new System.Drawing.Point(328, 104);
            this.errHardLocks.Name = "errHardLocks";
            this.errHardLocks.Selected = false;
            this.errHardLocks.SelectedColor = System.Drawing.Color.Empty;
            this.errHardLocks.Size = new System.Drawing.Size(130, 13);
            this.errHardLocks.TabIndex = 11;
            this.errHardLocks.Text = "value must be a number";
            this.errHardLocks.Visible = false;
            // 
            // errHardLockDuration
            // 
            this.errHardLockDuration.AutoSize = true;
            this.errHardLockDuration.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errHardLockDuration.ForeColor = System.Drawing.Color.Red;
            this.errHardLockDuration.Location = new System.Drawing.Point(328, 132);
            this.errHardLockDuration.Name = "errHardLockDuration";
            this.errHardLockDuration.Selected = false;
            this.errHardLockDuration.SelectedColor = System.Drawing.Color.Empty;
            this.errHardLockDuration.Size = new System.Drawing.Size(130, 13);
            this.errHardLockDuration.TabIndex = 11;
            this.errHardLockDuration.Text = "value must be a number";
            this.errHardLockDuration.Visible = false;
            // 
            // pictureBoxSave
            // 
            this.pictureBoxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSave.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_save;
            this.pictureBoxSave.Location = new System.Drawing.Point(405, 0);
            this.pictureBoxSave.Name = "pictureBoxSave";
            this.pictureBoxSave.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxSave.TabIndex = 5;
            this.pictureBoxSave.TabStop = false;
            this.pictureBoxSave.Visible = false;
            this.pictureBoxSave.Click += new System.EventHandler(this.pictureBoxSave_Click);
            this.pictureBoxSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseDown);
            this.pictureBoxSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseUp);
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_edit;
            this.pictureBoxEdit.Location = new System.Drawing.Point(436, 0);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxEdit.TabIndex = 5;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Visible = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            this.pictureBoxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseDown);
            this.pictureBoxEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseUp);
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
            this.smartLabel5.Size = new System.Drawing.Size(158, 20);
            this.smartLabel5.TabIndex = 10;
            this.smartLabel5.Text = "Lock out configuration";
            this.smartLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // smartLabel4
            // 
            this.smartLabel4.AutoSize = true;
            this.smartLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel4.Location = new System.Drawing.Point(24, 132);
            this.smartLabel4.Name = "smartLabel4";
            this.smartLabel4.Selected = false;
            this.smartLabel4.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel4.Size = new System.Drawing.Size(143, 13);
            this.smartLabel4.TabIndex = 0;
            this.smartLabel4.Text = "Hard lock duration (hours)";
            // 
            // smartLabel3
            // 
            this.smartLabel3.AutoSize = true;
            this.smartLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel3.Location = new System.Drawing.Point(24, 104);
            this.smartLabel3.Name = "smartLabel3";
            this.smartLabel3.Selected = false;
            this.smartLabel3.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel3.Size = new System.Drawing.Size(219, 13);
            this.smartLabel3.TabIndex = 0;
            this.smartLabel3.Text = "Hard lock threshold (unsuccessful logins)";
            // 
            // smartLabel2
            // 
            this.smartLabel2.AutoSize = true;
            this.smartLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel2.Location = new System.Drawing.Point(24, 76);
            this.smartLabel2.Name = "smartLabel2";
            this.smartLabel2.Selected = false;
            this.smartLabel2.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel2.Size = new System.Drawing.Size(150, 13);
            this.smartLabel2.TabIndex = 0;
            this.smartLabel2.Text = "Soft lock duration (minutes)";
            // 
            // smartLabel1
            // 
            this.smartLabel1.AutoSize = true;
            this.smartLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.smartLabel1.Location = new System.Drawing.Point(24, 48);
            this.smartLabel1.Name = "smartLabel1";
            this.smartLabel1.Selected = false;
            this.smartLabel1.SelectedColor = System.Drawing.Color.Empty;
            this.smartLabel1.Size = new System.Drawing.Size(215, 13);
            this.smartLabel1.TabIndex = 0;
            this.smartLabel1.Text = "Soft lock threshold (unsuccessful logins)";
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.BackColor = System.Drawing.Color.White;
            this.buttonDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscard.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDiscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonDiscard.Location = new System.Drawing.Point(220, 248);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(102, 26);
            this.buttonDiscard.TabIndex = 30;
            this.buttonDiscard.Text = "&Discard";
            this.buttonDiscard.UseVisualStyleBackColor = false;
            this.buttonDiscard.Visible = false;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.White;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.buttonSave.Location = new System.Drawing.Point(112, 248);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 26);
            this.buttonSave.TabIndex = 29;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.pictureBoxSave_Click);
            // 
            // PanelLockoutConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.errHardLockDuration);
            this.Controls.Add(this.errHardLocks);
            this.Controls.Add(this.errSoftLockDuration);
            this.Controls.Add(this.errSoftLocks);
            this.Controls.Add(this.smartLabel5);
            this.Controls.Add(this.pictureBoxSave);
            this.Controls.Add(this.pictureBoxEdit);
            this.Controls.Add(this.textBoxHardLockDuration);
            this.Controls.Add(this.textBoxHardLocks);
            this.Controls.Add(this.textBoxSoftLockDuration);
            this.Controls.Add(this.textBoxSoftLocks);
            this.Controls.Add(this.checkBoxLockForever);
            this.Controls.Add(this.smartLabel4);
            this.Controls.Add(this.smartLabel3);
            this.Controls.Add(this.smartLabel2);
            this.Controls.Add(this.smartLabel1);
            this.Name = "PanelLockoutConfiguration";
            this.Size = new System.Drawing.Size(462, 292);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SmartLabel smartLabel1;
        private SmartLabel smartLabel2;
        private SmartLabel smartLabel3;
        private SmartLabel smartLabel4;
        private System.Windows.Forms.CheckBox checkBoxLockForever;
        private System.Windows.Forms.TextBox textBoxSoftLocks;
        private System.Windows.Forms.TextBox textBoxSoftLockDuration;
        private System.Windows.Forms.TextBox textBoxHardLocks;
        private System.Windows.Forms.TextBox textBoxHardLockDuration;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private SmartLabel smartLabel5;
        private System.Windows.Forms.PictureBox pictureBoxSave;
        private SmartLabel errSoftLocks;
        private SmartLabel errSoftLockDuration;
        private SmartLabel errHardLocks;
        private SmartLabel errHardLockDuration;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Button buttonSave;
    }
}
