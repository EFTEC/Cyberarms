using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Cyberarms.IntrusionDetection.Shared;
using System.Text;
using System.Windows.Forms;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class PanelSafeNetworks : UserControl {

        public event EventHandler SafeNetworksChanged;

        public PanelSafeNetworks() {
            InitializeComponent();
            this.BackColor = Color.White;
            listBoxSafeNetworks.Sorted = true;
            listBoxSafeNetworks.DisplayMember = "DisplayName";
            this.Load += new EventHandler(PanelSafeNetworks_Load);
        }

        void PanelSafeNetworks_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void textBoxAddNetwork_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                AddNetwork();
                e.Handled = true;
            }
            if (e.KeyChar == 27) {
                HideNetworkPanel();
                e.Handled = true;
            }
        }

        private void AddNetwork() {
            smartLabelInvalidNetwork.Visible = false;
            try {
                string ipnet = IddsConfig.ConvertStringToIpAddressNetwork(textBoxAddNetwork.Text);
                if (EditExisting) {
                    listBoxSafeNetworks.Items.Remove(listBoxSafeNetworks.SelectedItem);
                }
                
                listBoxSafeNetworks.Items.Add(new IddsConfig.CSafeNetwork(ipnet.Split('/')[0], ipnet.Split('/')[1]));
                HideNetworkPanel();
                listBoxSafeNetworks.Focus();
            } catch (Exception ex) {
                smartLabelInvalidNetwork.Text = ex.Message;
                smartLabelInvalidNetwork.Visible = true;
            }
        }

        private void ShowAddNetworkPanel() {
            smartPanelAdd.Visible = true;
            textBoxAddNetwork.Focus();
        }

        private void HideNetworkPanel() {
            textBoxAddNetwork.Text = "";
            EditExisting = false;
            smartPanelAdd.Visible = false;
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e) {
            ShowAddNetworkPanel();
            SetEditMode(true);
        }

        private void listBoxSafeNetworks_DoubleClick(object sender, EventArgs e) {
            if(listBoxSafeNetworks.SelectedItems.Count==1) {
                textBoxAddNetwork.Text = listBoxSafeNetworks.SelectedItem.ToString();
                EditExisting = true;
                ShowAddNetworkPanel();
            }
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e) {
            List<IddsConfig.CSafeNetwork> selected = new List<IddsConfig.CSafeNetwork>();
            foreach(object o in listBoxSafeNetworks.SelectedItems) {
                selected.Add((o as IddsConfig.CSafeNetwork));
            }
            foreach(IddsConfig.CSafeNetwork net in selected) {
                listBoxSafeNetworks.Items.Remove(net);
            }
            SetEditMode(true);
        }

        private void button1_Click(object sender, EventArgs e) {
            HideNetworkPanel();
        }

        private void buttonAddNetwork_Click(object sender, EventArgs e) {
            AddNetwork();
        }

        private void listBoxSafeNetworks_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13 && listBoxSafeNetworks.SelectedItem!=null) {
                textBoxAddNetwork.Text = listBoxSafeNetworks.SelectedItem.ToString();
                EditExisting = true;
                ShowAddNetworkPanel();
            }
            if (e.KeyChar == '+') {
                ShowAddNetworkPanel();
            }
        }

        private void OnSafeNetworksChanged() {
            if (SafeNetworksChanged != null) SafeNetworksChanged(this, EventArgs.Empty);
        }

        public bool EditExisting { get; set; }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            Point loc = new Point((sender as Control).Location.X, (sender as Control).Location.Y);
            (sender as Control).Location = new Point(loc.X + 1, loc.Y + 1);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            Point loc = new Point((sender as Control).Location.X, (sender as Control).Location.Y);
            (sender as Control).Location = new Point(loc.X - 1, loc.Y - 1);
        }

        private void pictureBoxSave_Click(object sender, EventArgs e) {
            
        }

        private void LoadData() {
            listBoxSafeNetworks.Items.Clear();
            checkBoxConfigureSafeNetworks.Checked = IddsConfig.Instance.UseSafeNetworkList;
            foreach (IddsConfig.CSafeNetwork net in IddsConfig.Instance.SafeNetworks) {
                listBoxSafeNetworks.Items.Add(net);
            }
            SetEditMode(false);
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e) {
            if (IsInEditMode) LoadData();
            ToggleEditMode();
        }

        public bool IsInEditMode { get; set; }
        
        private void ToggleEditMode() {
            if (!IsInEditMode) {
                pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_delete;
                IsInEditMode = true;
            } else {
                pictureBoxEdit.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.button25px_edit;
                IsInEditMode = false;
            }
            pictureBoxSave.Visible = IsInEditMode;
            pictureBoxAdd.Enabled = IsInEditMode;
            pictureBoxDelete.Enabled = IsInEditMode;
            listBoxSafeNetworks.Enabled = IsInEditMode;
            checkBoxConfigureSafeNetworks.Enabled = IsInEditMode;
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            Cyberarms.IntrusionDetection.Shared.IddsConfig.CSafeNetworks nets = new IddsConfig.CSafeNetworks();
            foreach (object o in listBoxSafeNetworks.Items) {
                if (o is IddsConfig.CSafeNetwork) {
                    nets.Add((IddsConfig.CSafeNetwork)o);
                }
            }
            IddsConfig.Instance.SafeNetworks = nets;
            IddsConfig.Instance.SaveSafeNetworks();
            IddsConfig.Instance.UseSafeNetworkList = checkBoxConfigureSafeNetworks.Checked;
            IddsConfig.Instance.Save();
            
            OnSafeNetworksChanged();
            SetEditMode(false);
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
