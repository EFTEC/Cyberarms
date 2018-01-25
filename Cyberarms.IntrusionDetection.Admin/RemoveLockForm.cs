using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class RemoveLockForm : Form {
        public RemoveLockForm() {
            InitializeComponent();
        }

        private void RemoveLockForm_Load(object sender, EventArgs e) {

        }

        private void buttonOK_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
