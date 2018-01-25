using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class PanelSmtpSettings : UserControl {
        
        public event EventHandler SmtpSettingsChanged;

        public PanelSmtpSettings() {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Load += new EventHandler(PanelSmtpSettings_Load);
        }

        void PanelSmtpSettings_Load(object sender, EventArgs e) {
            LoadData();

        }

        public bool IsInEditMode { get; set; }


        private void pictureBoxEdit_Click(object sender, EventArgs e) {
            if (IsInEditMode) LoadData();
            ToggleEditMode();
            ClearErrors();
        }

        private void ToggleEditMode() {
            if (!IsInEditMode) {
                pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_delete;
                IsInEditMode = true;
            } else {
                pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_edit;
                IsInEditMode = false;
            }
            pictureBoxSave.Visible = IsInEditMode;
            textBoxSender.Enabled = IsInEditMode;
            textBoxRecipient.Enabled = IsInEditMode;
            textBoxSmtpServer.Enabled = IsInEditMode;
            textBoxSmtpPort.Enabled = IsInEditMode;
            checkBoxUseSSL.Enabled = IsInEditMode;
            checkBoxAuthentication.Enabled = IsInEditMode;
            textBoxUsername.Enabled = IsInEditMode;
            textBoxPassword.Enabled = IsInEditMode;
        }

        private void LoadData() {
            textBoxSender.Text = IddsConfig.Instance.SenderEmailAddress;
            textBoxRecipient.Text = IddsConfig.Instance.NotificationEmailAddress;
            textBoxSmtpServer.Text = IddsConfig.Instance.SmtpServer;
            textBoxSmtpPort.Text = IddsConfig.Instance.SmtpPort.ToString();
            checkBoxUseSSL.Checked = IddsConfig.Instance.SmtpSslRequired;
            checkBoxAuthentication.Checked = IddsConfig.Instance.SmtpRequiresAuthentication;
            textBoxUsername.Text = IddsConfig.Instance.SmtpUsername;
            textBoxPassword.Text = IddsConfig.Instance.GetSmtpPassword();
            SetEditMode(false);
        }

        private void pictureBoxSave_Click(object sender, EventArgs e) {
            
        }

        private void OnSmtpSettingsChanged() {
            if (SmtpSettingsChanged != null) SmtpSettingsChanged(this, EventArgs.Empty);
        }

        private bool CheckFormData() {
            int smtpPort;
            bool hasError = false;
            ClearErrors();
            if (!int.TryParse(textBoxSmtpPort.Text, out smtpPort)) {
                errSmtpPort.Visible = true;
                hasError = true;
            }
            return !hasError;
        }



        private void ClearErrors() {
            errSmtpPort.Visible = false;
        }

        private void buttonTestSmtpSettings_Click(object sender, EventArgs e) {
            smartLabelTestError.Visible = false;

            if (CheckFormData()) {
                try {
                    SmtpClient server = new SmtpClient(textBoxSmtpServer.Text);
                    if (checkBoxAuthentication.Checked) {
                        server.Credentials = new System.Net.NetworkCredential(textBoxUsername.Text, textBoxPassword.Text);
                    }
                    server.EnableSsl = checkBoxUseSSL.Checked;
                    server.Port = int.Parse(textBoxSmtpPort.Text);
                    server.Send(textBoxSender.Text, textBoxRecipient.Text, "Intrusion Detection Testmail", "This is a test message from your Cyberarms Intrusion Detection administration tool.");
                    MessageBox.Show("Mail was sent successfully.");
                } catch (Exception ex) {
                    smartLabelTestError.Text = String.Format("{0}\n{1}", ex.Message, ex.InnerException == null ? "" : ex.InnerException.Message);
                    smartLabelTestError.Visible = true;
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            Point loc = new Point((sender as Control).Location.X, (sender as Control).Location.Y);
            (sender as Control).Location = new Point(loc.X + 1, loc.Y + 1);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            Point loc = new Point((sender as Control).Location.X, (sender as Control).Location.Y);
            (sender as Control).Location = new Point(loc.X - 1, loc.Y - 1);
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            bool isOk = CheckFormData();
            if (isOk) {
                IddsConfig.Instance.SenderEmailAddress = textBoxSender.Text;
                IddsConfig.Instance.NotificationEmailAddress = textBoxRecipient.Text;
                IddsConfig.Instance.SmtpServer = textBoxSmtpServer.Text;
                IddsConfig.Instance.SmtpPort = int.Parse(textBoxSmtpPort.Text);
                IddsConfig.Instance.SmtpSslRequired = checkBoxUseSSL.Checked;
                IddsConfig.Instance.SmtpRequiresAuthentication = checkBoxAuthentication.Checked;
                IddsConfig.Instance.SmtpUsername = textBoxUsername.Text;
                IddsConfig.Instance.SetSmtpPassword(textBoxPassword.Text);
                IddsConfig.Instance.Save();
                
                OnSmtpSettingsChanged();
            }
            SetEditMode(false);
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e) {
            SetEditMode(true);
        }

        private void SetEditMode(bool hasChanges) {
            buttonSave.Visible = hasChanges;
            buttonDiscard.Visible = hasChanges;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e) {
            SetEditMode(true);
        }

    }
}
