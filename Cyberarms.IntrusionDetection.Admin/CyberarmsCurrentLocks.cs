using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cyberarms.IntrusionDetection.Shared;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class CyberarmsCurrentLocks : UserControl {
        public CyberarmsCurrentLocks() {
            InitializeComponent();
        }


        private void actionMenu_MouseDown(object sender, MouseEventArgs e) {
            Control c = (Control)sender;
            c.Location = new Point(c.Location.X + 1, c.Location.Y + 1);
        }

        private void actionMenu_MouseUp(object sender, MouseEventArgs e) {
            Control c = (Control)sender;
            c.Location = new Point(c.Location.X - 1, c.Location.Y - 1);
        }

        public DataGridViewRow FindRow(int id) {
            foreach(DataGridViewRow row in dataGridViewLocks.Rows) {
                if(row.Cells[7].Value.ToString().Equals(id.ToString())){
                    return row;
                }
            }
            return null;
        }

        public void Clear() {
            dataGridViewLocks.Rows.Clear();
        }

        public void Add(int id, Image icon, string statusName, string clientIp, string displayName, DateTime lockDate, DateTime unlockDate, int status) {
            DataGridViewRow row = FindRow(id);
            if (row != null) {
                if (row.Cells[2].Value.ToString().Equals(status)) {
                    return;
                }
            } else {
                dataGridViewLocks.Rows.Insert(0, new DataGridViewRow());
                row = dataGridViewLocks.Rows[0];
            }
            (row.Cells[1] as DataGridViewImageCell).Value = icon;
            row.Cells[2].Value = statusName;
            row.Cells[3].Value = clientIp;
            row.Cells[4].Value = displayName;
            row.Cells[5].Value = lockDate;
            row.Cells[6].Value = unlockDate;
            row.Cells[7].Value = id.ToString();
            row.Cells[8].Value = status;
        }

        public void SetHardLocks(int number) {
            labelCurrentLocksHardLocks.Text = String.Format("{0} hard locks", number);

        }

        private void checkBoxSelectAllLocks_CheckedChanged(object sender, EventArgs e) {
            foreach (DataGridViewRow r in dataGridViewLocks.Rows) {
                DataGridViewCheckBoxCell c = (DataGridViewCheckBoxCell)r.Cells["dataGridViewSelectItem"];
                c.Value = (sender as CheckBox).Checked;
            }
        }


        public void SetSoftLocks(int number) {
            labelCurrentLocksSoftLocks.Text = String.Format("{0} soft locks", number);
        }

        private void actionMenuUnlock_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in this.dataGridViewLocks.Rows) {
                DataGridViewCheckBoxCell c = (DataGridViewCheckBoxCell)row.Cells["dataGridViewSelectItem"];
                //if (c.Value == null) {
                //    if (c.Selected) { c.Value = c.TrueValue; } else { c.Value = c.FalseValue; }
                //}
                if ((bool)c.EditedFormattedValue == true && (row.Cells[8].Value.ToString() == Cyberarms.IntrusionDetection.Shared.Lock.LOCK_STATUS_SOFTLOCK.ToString() ||
                              row.Cells[8].Value.ToString() == Cyberarms.IntrusionDetection.Shared.Lock.LOCK_STATUS_HARDLOCK.ToString().ToString()))  {
                    long lockId;
                    if (long.TryParse(row.Cells[7].Value.ToString(), out lockId)) {
                        Lock l = Locks.GetLockById(lockId);
                        if (l != null) {
                            l.Status = Lock.LOCK_STATUS_UNLOCK_REQUESTED;
                            l.Save();
                        }
                        row.Cells[2].Value = LockStatusAdapter.GetLockStatusName((int)Lock.LOCK_STATUS_MANUAL);
                    }
                }
            }
        }

       

       

       
    }
}
