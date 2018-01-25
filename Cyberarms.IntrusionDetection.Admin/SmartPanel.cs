using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Cyberarms.IntrusionDetection.Admin {
    public class SmartPanel : Panel {

        public SmartPanel() {
            BorderColor = ForeColor;
        }

        public Color BorderColor { get; set; }
        public bool PaintBorder { get; set; }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (PaintBorder) {
                e.Graphics.DrawRectangle(new Pen(BorderColor), new Rectangle(0,0,Width-1,Height-1));
            }
        }
    }
}
