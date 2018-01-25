using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class SmartLabelTextbox : UserControl {

        public event KeyPressEventHandler TextBoxKeyPress;

        public SmartLabelTextbox() {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
        }

        void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (TextBoxKeyPress != null) TextBoxKeyPress(sender, e);
        }

        public string LabelText {
            get {
                return smartLabel1.Text;
            }
            set {
                smartLabel1.Text = value;
            }
        }

        public string TextBoxText {
            get {
                return textBox1.Text;
            }
            set {
                textBox1.Text = value;
            }
        }

        
    }
}
