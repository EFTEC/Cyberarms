using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Cyberarms.IntrusionDetection.Shared;
using System.Text;
using System.Windows.Forms;


namespace Cyberarms.IntrusionDetection.Admin
{
    public partial class PanelNotificationSettings : UserControl
    {
        public event EventHandler NotificationSettingsChanged;
        public PanelNotificationSettings()
        {
            InitializeComponent();
            this.Load += new EventHandler(PanelNotificationSettings_Load);
        }

        void PanelNotificationSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public bool IsInEditMode { get; set; }

        public void LoadData()
        {
            checkBoxSoftLock.Checked = NotificationSettings.Instance.OnSoftLock;
            checkBoxHardLocks.Checked = NotificationSettings.Instance.OnHardLock;
            checkBoxOnUnlock.Checked = NotificationSettings.Instance.OnUnlock;
            checkBoxDailySummary.Checked = NotificationSettings.Instance.SummaryReportDaily;
            checkBoxWeeklyReport.Checked = NotificationSettings.Instance.SummaryReportWeekly;
            checkBoxMonthlyReport.Checked = NotificationSettings.Instance.SummaryReportMonthly;
            checkBoxDailySummary.Enabled = true;
            checkBoxWeeklyReport.Enabled = true;
            checkBoxMonthlyReport.Enabled = true;
            SetEditMode(false);
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            if (IsInEditMode) LoadData();
            ToggleEditMode();
        }

        private void ToggleEditMode()
        {
            if (!IsInEditMode)
            {
                pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_delete;
                IsInEditMode = true;
            }
            else
            {
                pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_edit;
                IsInEditMode = false;
            }
            pictureBoxSave.Visible = IsInEditMode;
            checkBoxSoftLock.Enabled = IsInEditMode;
            checkBoxHardLocks.Enabled = IsInEditMode;
            checkBoxOnUnlock.Enabled = IsInEditMode;
                checkBoxDailySummary.Enabled = IsInEditMode;
                checkBoxWeeklyReport.Enabled = IsInEditMode;
                checkBoxMonthlyReport.Enabled = IsInEditMode;
            
        }

        private void pictureBoxSave_Click(object sender, EventArgs e)
        {

            ToggleEditMode();
        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point loc = new Point((sender as Control).Location.X, (sender as Control).Location.Y);
            (sender as Control).Location = new Point(loc.X + 1, loc.Y + 1);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point loc = new Point((sender as Control).Location.X, (sender as Control).Location.Y);
            (sender as Control).Location = new Point(loc.X - 1, loc.Y - 1);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            NotificationSettings.Instance.OnSoftLock = checkBoxSoftLock.Checked;
            NotificationSettings.Instance.OnHardLock = checkBoxHardLocks.Checked;
            NotificationSettings.Instance.OnUnlock = checkBoxOnUnlock.Checked;
            NotificationSettings.Instance.SummaryReportDaily = checkBoxDailySummary.Checked;
            NotificationSettings.Instance.SummaryReportWeekly = checkBoxWeeklyReport.Checked;
            NotificationSettings.Instance.SummaryReportMonthly = checkBoxMonthlyReport.Checked;
            IddsConfig.Instance.SaveAppConfig();
            OnNotificationSettingsChanged();
            SetEditMode(false);
        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void OnNotificationSettingsChanged()
        {
            if (NotificationSettingsChanged != null) NotificationSettingsChanged(this, EventArgs.Empty);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetEditMode(true);
        }

        private void SetEditMode(bool hasChanges)
        {
            buttonSave.Visible = hasChanges;
            buttonDiscard.Visible = hasChanges;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            SetEditMode(true);
        }
    }
}
