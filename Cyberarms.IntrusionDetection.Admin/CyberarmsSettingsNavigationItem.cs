using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class CyberarmsSettingsNavigationItem : UserControl {

        public event EventHandler NavigationClicked;

        public CyberarmsSettingsNavigationItem() {
            InitializeComponent();
        }

        public bool IsSelected { get; set; }

        public Image SelectedIcon { get; set; }

        public Image UnselectedIcon { get; set; }

        public string DisplayName {
            get {
                return smartLabelAgentName.Text;
            }
            set {
                smartLabelAgentName.Text = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (IsSelected) {
                this.BackColor = Color.FromArgb(4, 46, 100);
                smartLabelAgentName.ForeColor = Color.White;
                pictureBoxNavigationIcon.Image = SelectedIcon;
            } else {
                this.BackColor = Color.White;
                smartLabelAgentName.ForeColor = Color.FromArgb(0x666666);
                pictureBoxNavigationIcon.Image = UnselectedIcon;
            }
            base.OnPaint(e);
        }

        
        
        private void CyberarmsSettingsNavigationItem_MouseDown(object sender, MouseEventArgs e) {
            pictureBoxNavigationIcon.Location = new Point(pictureBoxNavigationIcon.Location.X + 1, pictureBoxNavigationIcon.Location.Y + 1);
            smartLabelAgentName.Location = new Point(smartLabelAgentName.Location.X + 1, smartLabelAgentName.Location.Y + 1);
        }

        private void CyberarmsSettingsNavigationItem_MouseUp(object sender, MouseEventArgs e) {
            pictureBoxNavigationIcon.Location = new Point(pictureBoxNavigationIcon.Location.X - 1, pictureBoxNavigationIcon.Location.Y - 1);
            smartLabelAgentName.Location = new Point(smartLabelAgentName.Location.X - 1, smartLabelAgentName.Location.Y - 1);
        }

        

        private void CyberarmsSettingsNavigationItem_Click(object sender, EventArgs e) {
            OnNavigationClicked();
            
        }

        private void OnNavigationClicked() {
            if (NavigationClicked != null) NavigationClicked(this, EventArgs.Empty);
        }

        
        
    }
}
