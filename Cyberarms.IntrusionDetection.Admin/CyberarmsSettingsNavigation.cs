using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class CyberarmsSettingsNavigation : UserControl {

        public event EventHandler PluginsChanged;

        public CyberarmsSettingsNavigation() {
            InitializeComponent();
        }

        public event EventHandler NavigationChanged;

        public Color SeparatorColor { get; set; }

        public bool ShowSeparator { get; set; }

        public bool ShowTopMenu { get; set; }
        
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (!ShowTopMenu) {
                flowLayoutPanelNavigationItems.Top = 0;
                flowLayoutPanelNavigationItems.Height = Height - 1;
                smartPanelActionBar.Hide();
            } else {
                flowLayoutPanelNavigationItems.Top = 33;
                flowLayoutPanelNavigationItems.Height = Height - 34;
                smartPanelActionBar.Show();
            }            
            if (ShowSeparator) {
                e.Graphics.DrawLine(new Pen(SeparatorColor,1), Width - 5, 0, Width - 5, Height);
            }
        }

        private void cyberarmsSettingsNavigationItem_Click(object sender, EventArgs e) {
            if (!(sender as CyberarmsSettingsNavigationItem).IsSelected) {
                UnselectAll();
                (sender as CyberarmsSettingsNavigationItem).IsSelected = true;
                OnNavigationChanged(sender);
            }
        }

        private List<CyberarmsSettingsNavigationItem> _navigationItems;
        private List<CyberarmsSettingsNavigationItem> NavigationItems {
            get {
                if (_navigationItems == null) {
                    _navigationItems = new List<CyberarmsSettingsNavigationItem>();
                }
                return _navigationItems;
            }
        }

        public void AddNavigationItem(CyberarmsSettingsNavigationItem item) {
            NavigationItems.Add(item);
        }

        public void AddNavigationItem(string name, Image selectedIcon, Image unselectedIcon) {
            CyberarmsSettingsNavigationItem item = new CyberarmsSettingsNavigationItem();
            item.SelectedIcon = selectedIcon;
            item.DisplayName = name;
            item.UnselectedIcon = unselectedIcon;
            flowLayoutPanelNavigationItems.Controls.Add(item);
            item.NavigationClicked += new EventHandler(cyberarmsSettingsNavigationItem_Click);
            if (flowLayoutPanelNavigationItems.Controls.Count == 1) {
                item.IsSelected = true;
                OnNavigationChanged(item);
            }
        }

        public void Clear() {
            NavigationItems.Clear();
        }

        
        public CyberarmsSettingsNavigationItem SelectedItem {
            get {
                foreach (Control c in flowLayoutPanelNavigationItems.Controls) {
                    if (c is CyberarmsSettingsNavigationItem && (c as CyberarmsSettingsNavigationItem).IsSelected) return (c as CyberarmsSettingsNavigationItem);
                }
                return null;
            }
        }

        public void SetSelectedItem(string name) {
            foreach (Control c in flowLayoutPanelNavigationItems.Controls) {
                if(c is CyberarmsSettingsNavigationItem && (c as CyberarmsSettingsNavigationItem).DisplayName.Equals(name)) {
                    UnselectAll();
                    (c as CyberarmsSettingsNavigationItem).IsSelected = true;
                    OnNavigationChanged(this);
                }
            }
        }

        private void OnNavigationChanged(object sender) {
            if (NavigationChanged != null) NavigationChanged(sender, EventArgs.Empty);
        }

        public string SelectedName {
            get {
                foreach (Control c in flowLayoutPanelNavigationItems.Controls) {
                    if (c is CyberarmsSettingsNavigationItem && (c as CyberarmsSettingsNavigationItem).IsSelected) return (c as CyberarmsSettingsNavigationItem).DisplayName;
                }
                return String.Empty;
            }
        }

        public void UnselectAll() {
            foreach(Control c in flowLayoutPanelNavigationItems.Controls){
                if (c is CyberarmsSettingsNavigationItem) {
                    if ((c as CyberarmsSettingsNavigationItem).IsSelected) {
                        (c as CyberarmsSettingsNavigationItem).IsSelected = false;
                        c.Invalidate();
                    }
                }
            }
        }


        private void pictureBoxAdd_MouseDown(object sender, MouseEventArgs e) {
            pictureBoxAdd.Location = new Point(pictureBoxAdd.Location.X + 1, pictureBoxAdd.Location.Y + 1); 
        }

        private void pictureBoxAdd_MouseUp(object sender, MouseEventArgs e) {
            pictureBoxAdd.Location = new Point(pictureBoxAdd.Location.X - 1, pictureBoxAdd.Location.Y - 1);
        }

        private void pictureBoxRemove_MouseUp(object sender, MouseEventArgs e) {
            pictureBoxRemove.Location = new Point(pictureBoxRemove.Location.X - 1, pictureBoxRemove.Location.Y - 1); 
        }

        private void pictureBoxRemove_MouseDown(object sender, MouseEventArgs e) {
            pictureBoxRemove.Location = new Point(pictureBoxRemove.Location.X + 1, pictureBoxRemove.Location.Y + 1);
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckPathExists = true;
            openFile.CheckFileExists = true;
            openFile.Filter = "Assemblies (*.dll)|*.dll";
            openFile.Title = "Please select plugin assembly";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string pluginDirectory = Cyberarms.IntrusionDetection.Shared.IddsConfig.Instance.PluginsDirectory;
                string chosenDirectory = openFile.FileNames[0].Substring(0, openFile.FileNames[0].LastIndexOf('\\'));
                if (openFile.FileNames.Length <= 0) {
                    GenericErrorDialog error = new GenericErrorDialog("No file was selected!", "Please choose at least one assembly to load.", false);
                    error.ShowDialog();
                    return;
                }
                if (chosenDirectory == pluginDirectory) {
                    GenericErrorDialog error = new GenericErrorDialog("Invalid directory", "Please choose a directory other than the plugin directory. These assemblies are already loaded.", false);
                    error.ShowDialog();
                    return;
                }
                if (!Directory.Exists(pluginDirectory)) {
                    try {
                        Directory.CreateDirectory(pluginDirectory);
                    } catch (Exception ex) {
                        GenericErrorDialog error = new GenericErrorDialog("Plugin directory not found!", ex.Message, false);
                        error.ShowDialog();
                        return;
                    }
                }
                foreach (string fileName in openFile.FileNames) {
                    string assemblyName = fileName.Remove(0, fileName.LastIndexOf('\\') + 1);
                    if (!File.Exists(pluginDirectory + assemblyName) ||
                        MessageBox.Show("This assembly already exists. Do you want to overwrite the existing?", "Overwrite existing?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes) {
                        try {
                            File.Copy(fileName, pluginDirectory + assemblyName, true);
                        } catch (Exception ex) {
                            GenericErrorDialog error = new GenericErrorDialog("Assembly cannot be copied.", ex.Message, false);
                            error.ShowDialog();
                        }
                    }
                }
                Cyberarms.IntrusionDetection.Shared.SecurityAgents.Instance.InitializeAgents();
                OnPluginsChanged();
            }
        }

        private void OnPluginsChanged() {
            if (PluginsChanged != null) {
                this.PluginsChanged(this, EventArgs.Empty);
            }
        }
        

    }
}
