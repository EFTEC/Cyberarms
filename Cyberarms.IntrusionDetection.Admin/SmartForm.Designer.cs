namespace Cyberarms.IntrusionDetection.Admin {
    partial class SmartForm {
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
            this.components = new System.ComponentModel.Container();
            this.panelWindowGrip = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStripControlBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelFormText = new Cyberarms.IntrusionDetection.Admin.SmartLabel();
            this.pictureBoxMaximizeButton = new System.Windows.Forms.PictureBox();
            this.pictureBoxHelpButon = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinimizeButton = new System.Windows.Forms.PictureBox();
            this.pictureBoxCloseButton = new System.Windows.Forms.PictureBox();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.borderN = new System.Windows.Forms.Panel();
            this.borderS = new System.Windows.Forms.Panel();
            this.borderE = new System.Windows.Forms.Panel();
            this.borderW = new System.Windows.Forms.Panel();
            this.borderSE = new System.Windows.Forms.Panel();
            this.borderNE = new System.Windows.Forms.Panel();
            this.borderNW = new System.Windows.Forms.Panel();
            this.borderSW = new System.Windows.Forms.Panel();
            this.borderN1 = new System.Windows.Forms.Panel();
            this.borderS1 = new System.Windows.Forms.Panel();
            this.borderE1 = new System.Windows.Forms.Panel();
            this.borderW1 = new System.Windows.Forms.Panel();
            this.panelWindowGrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStripControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaximizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelpButon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseButton)).BeginInit();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWindowGrip
            // 
            this.panelWindowGrip.Controls.Add(this.pictureBox1);
            this.panelWindowGrip.Controls.Add(this.labelFormText);
            this.panelWindowGrip.Controls.Add(this.pictureBoxMaximizeButton);
            this.panelWindowGrip.Controls.Add(this.pictureBoxHelpButon);
            this.panelWindowGrip.Controls.Add(this.pictureBoxMinimizeButton);
            this.panelWindowGrip.Controls.Add(this.pictureBoxCloseButton);
            this.panelWindowGrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWindowGrip.Location = new System.Drawing.Point(0, 0);
            this.panelWindowGrip.Margin = new System.Windows.Forms.Padding(0);
            this.panelWindowGrip.Name = "panelWindowGrip";
            this.panelWindowGrip.Size = new System.Drawing.Size(802, 24);
            this.panelWindowGrip.TabIndex = 0;
            this.panelWindowGrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelWindowGrip_MouseDown);
            this.panelWindowGrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelWindowGrip_MouseMove);
            this.panelWindowGrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelWindowGrip_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStripControlBox;
            this.pictureBox1.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.Paladin_Icon_16;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // contextMenuStripControlBox
            // 
            this.contextMenuStripControlBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStripControlBox.Name = "contextMenuStripControlBox";
            this.contextMenuStripControlBox.Size = new System.Drawing.Size(146, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // labelFormText
            // 
            this.labelFormText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFormText.CausesValidation = false;
            this.labelFormText.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.labelFormText.Location = new System.Drawing.Point(94, 0);
            this.labelFormText.Name = "labelFormText";
            this.labelFormText.Size = new System.Drawing.Size(580, 24);
            this.labelFormText.TabIndex = 1;
            this.labelFormText.Text = "SmartForm";
            this.labelFormText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFormText.DoubleClick += new System.EventHandler(this.pictureBoxMaximizeButton_Click);
            this.labelFormText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelWindowGrip_MouseDown);
            this.labelFormText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelWindowGrip_MouseMove);
            this.labelFormText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelWindowGrip_MouseUp);
            // 
            // pictureBoxMaximizeButton
            // 
            this.pictureBoxMaximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMaximizeButton.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_maximize;
            this.pictureBoxMaximizeButton.InitialImage = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_maximize;
            this.pictureBoxMaximizeButton.Location = new System.Drawing.Point(747, 0);
            this.pictureBoxMaximizeButton.Name = "pictureBoxMaximizeButton";
            this.pictureBoxMaximizeButton.Size = new System.Drawing.Size(27, 20);
            this.pictureBoxMaximizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMaximizeButton.TabIndex = 0;
            this.pictureBoxMaximizeButton.TabStop = false;
            this.pictureBoxMaximizeButton.Click += new System.EventHandler(this.pictureBoxMaximizeButton_Click);
            this.pictureBoxMaximizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseDown);
            this.pictureBoxMaximizeButton.MouseEnter += new System.EventHandler(this.pictureBoxButton_MouseEnter);
            this.pictureBoxMaximizeButton.MouseLeave += new System.EventHandler(this.pictureBoxButton_MouseLeave);
            this.pictureBoxMaximizeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseUp);
            // 
            // pictureBoxHelpButon
            // 
            this.pictureBoxHelpButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHelpButon.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_help;
            this.pictureBoxHelpButon.Location = new System.Drawing.Point(693, 0);
            this.pictureBoxHelpButon.Name = "pictureBoxHelpButon";
            this.pictureBoxHelpButon.Size = new System.Drawing.Size(27, 20);
            this.pictureBoxHelpButon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxHelpButon.TabIndex = 0;
            this.pictureBoxHelpButon.TabStop = false;
            this.pictureBoxHelpButon.Click += new System.EventHandler(this.pictureBoxHelpButon_Click);
            this.pictureBoxHelpButon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseDown);
            this.pictureBoxHelpButon.MouseEnter += new System.EventHandler(this.pictureBoxButton_MouseEnter);
            this.pictureBoxHelpButon.MouseLeave += new System.EventHandler(this.pictureBoxButton_MouseLeave);
            this.pictureBoxHelpButon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseUp);
            // 
            // pictureBoxMinimizeButton
            // 
            this.pictureBoxMinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMinimizeButton.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_minimize;
            this.pictureBoxMinimizeButton.Location = new System.Drawing.Point(720, 0);
            this.pictureBoxMinimizeButton.Name = "pictureBoxMinimizeButton";
            this.pictureBoxMinimizeButton.Size = new System.Drawing.Size(27, 20);
            this.pictureBoxMinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMinimizeButton.TabIndex = 0;
            this.pictureBoxMinimizeButton.TabStop = false;
            this.pictureBoxMinimizeButton.Click += new System.EventHandler(this.pictureBoxMinimizeButton_Click);
            this.pictureBoxMinimizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseDown);
            this.pictureBoxMinimizeButton.MouseEnter += new System.EventHandler(this.pictureBoxButton_MouseEnter);
            this.pictureBoxMinimizeButton.MouseLeave += new System.EventHandler(this.pictureBoxButton_MouseLeave);
            this.pictureBoxMinimizeButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseUp);
            // 
            // pictureBoxCloseButton
            // 
            this.pictureBoxCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCloseButton.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_close;
            this.pictureBoxCloseButton.Location = new System.Drawing.Point(774, 0);
            this.pictureBoxCloseButton.Name = "pictureBoxCloseButton";
            this.pictureBoxCloseButton.Size = new System.Drawing.Size(27, 20);
            this.pictureBoxCloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxCloseButton.TabIndex = 0;
            this.pictureBoxCloseButton.TabStop = false;
            this.pictureBoxCloseButton.Click += new System.EventHandler(this.pictureBoxCloseButton_Click);
            this.pictureBoxCloseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseDown);
            this.pictureBoxCloseButton.MouseEnter += new System.EventHandler(this.pictureBoxButton_MouseEnter);
            this.pictureBoxCloseButton.MouseLeave += new System.EventHandler(this.pictureBoxButton_MouseLeave);
            this.pictureBoxCloseButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxButton_MouseUp);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.SystemColors.Window;
            this.panelForm.Controls.Add(this.panelContent);
            this.panelForm.Controls.Add(this.panelWindowGrip);
            this.panelForm.Location = new System.Drawing.Point(4, 4);
            this.panelForm.Margin = new System.Windows.Forms.Padding(0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(802, 520);
            this.panelForm.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 24);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(10, 1, 10, 0);
            this.panelContent.Size = new System.Drawing.Size(802, 496);
            this.panelContent.TabIndex = 3;
            // 
            // borderN
            // 
            this.borderN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderN.BackColor = System.Drawing.Color.Gray;
            this.borderN.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.borderN.Location = new System.Drawing.Point(1, 0);
            this.borderN.Name = "borderN";
            this.borderN.Size = new System.Drawing.Size(808, 1);
            this.borderN.TabIndex = 2;
            this.borderN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderN_MouseDown);
            this.borderN.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderS
            // 
            this.borderS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderS.BackColor = System.Drawing.Color.Gray;
            this.borderS.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.borderS.Location = new System.Drawing.Point(0, 529);
            this.borderS.Margin = new System.Windows.Forms.Padding(0);
            this.borderS.Name = "borderS";
            this.borderS.Size = new System.Drawing.Size(808, 1);
            this.borderS.TabIndex = 2;
            this.borderS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderS_MouseDown);
            this.borderS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderE
            // 
            this.borderE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderE.BackColor = System.Drawing.Color.Gray;
            this.borderE.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.borderE.Location = new System.Drawing.Point(809, 1);
            this.borderE.Margin = new System.Windows.Forms.Padding(0);
            this.borderE.Name = "borderE";
            this.borderE.Size = new System.Drawing.Size(1, 528);
            this.borderE.TabIndex = 2;
            this.borderE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderE_MouseDown);
            this.borderE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderW
            // 
            this.borderW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.borderW.BackColor = System.Drawing.Color.Gray;
            this.borderW.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.borderW.Location = new System.Drawing.Point(0, 0);
            this.borderW.Margin = new System.Windows.Forms.Padding(0);
            this.borderW.Name = "borderW";
            this.borderW.Size = new System.Drawing.Size(1, 530);
            this.borderW.TabIndex = 2;
            this.borderW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderW_MouseDown);
            this.borderW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderSE
            // 
            this.borderSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.borderSE.BackColor = System.Drawing.Color.Gray;
            this.borderSE.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.borderSE.Location = new System.Drawing.Point(800, 520);
            this.borderSE.Margin = new System.Windows.Forms.Padding(0);
            this.borderSE.Name = "borderSE";
            this.borderSE.Size = new System.Drawing.Size(10, 10);
            this.borderSE.TabIndex = 2;
            this.borderSE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderSE_MouseDown);
            this.borderSE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderNE
            // 
            this.borderNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.borderNE.BackColor = System.Drawing.Color.Gray;
            this.borderNE.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.borderNE.Location = new System.Drawing.Point(800, 0);
            this.borderNE.Margin = new System.Windows.Forms.Padding(0);
            this.borderNE.Name = "borderNE";
            this.borderNE.Size = new System.Drawing.Size(10, 8);
            this.borderNE.TabIndex = 2;
            this.borderNE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderNE_MouseDown);
            this.borderNE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderNW
            // 
            this.borderNW.BackColor = System.Drawing.Color.Gray;
            this.borderNW.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.borderNW.Location = new System.Drawing.Point(0, 0);
            this.borderNW.Name = "borderNW";
            this.borderNW.Size = new System.Drawing.Size(8, 8);
            this.borderNW.TabIndex = 2;
            this.borderNW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderNW_MouseDown);
            this.borderNW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderSW
            // 
            this.borderSW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.borderSW.BackColor = System.Drawing.Color.Gray;
            this.borderSW.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.borderSW.Location = new System.Drawing.Point(0, 522);
            this.borderSW.Margin = new System.Windows.Forms.Padding(0);
            this.borderSW.Name = "borderSW";
            this.borderSW.Size = new System.Drawing.Size(8, 8);
            this.borderSW.TabIndex = 2;
            this.borderSW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderSW_MouseDown);
            this.borderSW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderN1
            // 
            this.borderN1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderN1.BackColor = System.Drawing.Color.White;
            this.borderN1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.borderN1.Location = new System.Drawing.Point(4, 1);
            this.borderN1.Name = "borderN1";
            this.borderN1.Size = new System.Drawing.Size(800, 4);
            this.borderN1.TabIndex = 2;
            this.borderN1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderN_MouseDown);
            this.borderN1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderS1
            // 
            this.borderS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderS1.BackColor = System.Drawing.Color.White;
            this.borderS1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.borderS1.Location = new System.Drawing.Point(1, 525);
            this.borderS1.Margin = new System.Windows.Forms.Padding(0);
            this.borderS1.Name = "borderS1";
            this.borderS1.Size = new System.Drawing.Size(800, 4);
            this.borderS1.TabIndex = 2;
            this.borderS1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderS_MouseDown);
            this.borderS1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderE1
            // 
            this.borderE1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderE1.BackColor = System.Drawing.Color.White;
            this.borderE1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.borderE1.Location = new System.Drawing.Point(805, 4);
            this.borderE1.Margin = new System.Windows.Forms.Padding(0);
            this.borderE1.Name = "borderE1";
            this.borderE1.Size = new System.Drawing.Size(1, 528);
            this.borderE1.TabIndex = 2;
            this.borderE1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderE_MouseDown);
            this.borderE1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // borderW1
            // 
            this.borderW1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.borderW1.BackColor = System.Drawing.Color.White;
            this.borderW1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.borderW1.Location = new System.Drawing.Point(1, 4);
            this.borderW1.Margin = new System.Windows.Forms.Padding(0);
            this.borderW1.Name = "borderW1";
            this.borderW1.Size = new System.Drawing.Size(4, 528);
            this.borderW1.TabIndex = 2;
            this.borderW1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderW_MouseDown);
            this.borderW1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.border_MouseMove);
            // 
            // SmartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(810, 530);
            this.ControlBox = false;
            this.Controls.Add(this.borderN);
            this.Controls.Add(this.borderS);
            this.Controls.Add(this.borderE);
            this.Controls.Add(this.borderW);
            this.Controls.Add(this.borderN1);
            this.Controls.Add(this.borderS1);
            this.Controls.Add(this.borderE1);
            this.Controls.Add(this.borderW1);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.borderSE);
            this.Controls.Add(this.borderNE);
            this.Controls.Add(this.borderNW);
            this.Controls.Add(this.borderSW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "SmartForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Cyberarms Intrusion Detection";
            this.panelWindowGrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStripControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaximizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelpButon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCloseButton)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWindowGrip;
        private System.Windows.Forms.PictureBox pictureBoxCloseButton;
        private System.Windows.Forms.Panel panelForm;
        private SmartLabel labelFormText;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripControlBox;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxMaximizeButton;
        private System.Windows.Forms.PictureBox pictureBoxHelpButon;
        private System.Windows.Forms.PictureBox pictureBoxMinimizeButton;
        private System.Windows.Forms.Panel borderN;
        private System.Windows.Forms.Panel borderS;
        private System.Windows.Forms.Panel borderSW;
        private System.Windows.Forms.Panel borderNW;
        private System.Windows.Forms.Panel borderNE;
        private System.Windows.Forms.Panel borderSE;
        private System.Windows.Forms.Panel borderW;
        private System.Windows.Forms.Panel borderE;
        private System.Windows.Forms.Panel borderN1;
        private System.Windows.Forms.Panel borderS1;
        private System.Windows.Forms.Panel borderW1;
        private System.Windows.Forms.Panel borderE1;
    }
}