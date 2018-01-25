using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cyberarms.IntrusionDetection.Admin {
    public partial class SmartForm : Form {

        Color buttonHighlight = Color.FromArgb(205, 230, 247);
        Color buttonPress = Color.FromArgb(105, 130, 147);
        Color buttonNormal = Color.FromKnownColor(KnownColor.Window);

        public SmartForm() {
            InitializeComponent();
            this.Text = Name;
            this.labelFormText.Text = this.Text;

        }


        private void pictureBoxCloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void panelWindowGrip_MouseDown(object sender, MouseEventArgs e) {
            IsMoving = true;
            MoveStartPoint = new Point(e.X, e.Y);
        }

        public bool IsMoving { get; set; }
        public Point MoveStartPoint { get; set; }
        private void panelWindowGrip_MouseUp(object sender, MouseEventArgs e) {
            IsMoving = false;
        }

        private void panelWindowGrip_MouseMove(object sender, MouseEventArgs e) {
            if (IsMoving) {
                this.Location = new Point(this.Location.X + e.X - MoveStartPoint.X, this.Location.Y + e.Y - MoveStartPoint.Y);

            }
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            pictureBox1.ContextMenuStrip.Show(PointToScreen(pictureBox1.Location));
        }

        public event EventHandler HelpClicked;

        private void pictureBoxHelpButon_Click(object sender, EventArgs e) {
            if (HelpClicked != null) HelpClicked(this, EventArgs.Empty);
        }

        private void pictureBoxMinimizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxMaximizeButton_Click(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Maximized) {
                this.WindowState = FormWindowState.Maximized;
                pictureBoxMaximizeButton.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_scale;
            } else {
                this.WindowState = FormWindowState.Normal;
                pictureBoxMaximizeButton.Image = global::Cyberarms.IntrusionDetection.Admin.Properties.Resources.icon_maximize;
            }
        }


        private void pictureBoxButton_MouseEnter(object sender, EventArgs e) {
            (sender as Control).BackColor = buttonHighlight;
        }

        private void pictureBoxButton_MouseLeave(object sender, EventArgs e) {
            (sender as Control).BackColor = buttonNormal;
        }

        private void pictureBoxButton_MouseDown(object sender, MouseEventArgs e) {
            (sender as Control).BackColor = buttonPress;
        }

        private void pictureBoxButton_MouseUp(object sender, MouseEventArgs e) {
            (sender as Control).BackColor = buttonNormal;
        }

        private void resizeForm(Point mouseLocation) {
            int deltaX = (resizeStartLocation.X - mouseLocation.X);
            int deltaY = (resizeStartLocation.Y - mouseLocation.Y);
            if ((resizeDirection & ResizeDirection.Left) == ResizeDirection.Left) {
                this.Left += -deltaX;
                this.Width += deltaX;
            } else if ((resizeDirection & ResizeDirection.Right) == ResizeDirection.Right) {
                this.Width -= deltaX;
                resizeStartLocation = mouseLocation;
            }

        }

        ResizeDirection resizeDirection = ResizeDirection.None;
        bool isResizing = false;
        Point resizeStartLocation = new Point(0, 0);

        enum ResizeDirection {
            None,
            Top,
            Right,
            Bottom,
            Left
        }

        private void panelContent_MouseDown(object sender, MouseEventArgs e) {
            isResizing = (resizeDirection == ResizeDirection.None) ? false : true;
            if (isResizing) resizeStartLocation = e.Location;
        }

        private void panelContent_MouseUp(object sender, MouseEventArgs e) {
            isResizing = false;
        }

        private void panelContent_MouseLeave(object sender, EventArgs e) {
            if (!isResizing) resizeDirection = ResizeDirection.None;
        }

        private void borderN_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Top;
            resizeStartLocation = e.Location;
            isResizing = true;
        }

        private void borderE_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Right;
            resizeStartLocation = e.Location;
            isResizing = true;
        }

        private void borderS_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Bottom;
            resizeStartLocation = e.Location;
            isResizing = true;
        }

        private void borderW_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Left;
            resizeStartLocation = e.Location;
            isResizing = true;
        }

        private void borderNE_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Right | ResizeDirection.Top;
        }

        private void borderSE_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Right | ResizeDirection.Bottom;
            resizeStartLocation = e.Location;
            isResizing = true;
        }

        private void borderSW_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Left | ResizeDirection.Bottom;
            resizeStartLocation = e.Location;
            isResizing = true;
        }

        private void borderNW_MouseDown(object sender, MouseEventArgs e) {
            resizeDirection = ResizeDirection.Left | ResizeDirection.Top;
            resizeStartLocation = e.Location;
            isResizing = true;
        }

        private void border_MouseMove(object sender, MouseEventArgs e) {
            if (isResizing) {
                resizeForm(e.Location);
            } 
        }

       


    }
}
