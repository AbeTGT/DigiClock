using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiClock
{
    public partial class Form1 : Form
    {
        public string curVersion = "v0.01.0";
        private bool mousedown;
        private Point lastlocation;
        private bool isContextMenuStripVisible = false;
        public Form1()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
            this.TopMost = true;
            var pos1 = this.PointToScreen(label1.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label1.Parent = pictureBox1;
            label1.Location = pos1;
            label1.BackColor = Color.Transparent;
            var pos2 = this.PointToScreen(label2.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label2.Parent = pictureBox1;
            label2.Location = pos2;
            label2.BackColor = Color.Transparent;
            label3.Parent = panel1;
            var pos3 = this.PointToScreen(SettingLabel.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            SettingLabel.Parent = pictureBox1;
            SettingLabel.Location = pos3;
            SettingLabel.BackColor = Color.Transparent;
            var pos4 = this.PointToScreen(WelcomeMsg.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            WelcomeMsg.Parent = pictureBox1;
            WelcomeMsg.Location = pos4;
            WelcomeMsg.BackColor = Color.Transparent;
            WelcomeMsg.Text = "Welcome, " + Environment.UserName + ".";
            toolStripMenuItem1.Checked = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            lastlocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                this.Location = new Point((this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(button1, "Closes DigiClock.");
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.LimeGreen;
            label3.Text = "DigiClock | 2022 AbeTGT";
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
            label3.Text = "DigiClock " + curVersion;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            lastlocation = e.Location;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                this.Location = new Point((this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (toolStripMenuItem1.Checked == false)
            {
                this.TopMost = true;
                toolStripMenuItem1.Checked = true;
                MessageBox.Show("TopMost has successfully been set to true.\nDigiClock will now be on top of other applications.", "DigiClock | Settings");
            } else
            {
                this.TopMost = false;
                toolStripMenuItem1.Checked = false;
                MessageBox.Show("TopMost has successfully been set to false.\nDigiClock will no longer be on top of other applications.", "DigiClock | Settings");
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (isContextMenuStripVisible == false)
                {
                    isContextMenuStripVisible = true;
                } else if (isContextMenuStripVisible == true)
                {
                    isContextMenuStripVisible = false;
                }
                contextMenuStrip1.Visible = isContextMenuStripVisible;
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (isContextMenuStripVisible == false)
                {
                    isContextMenuStripVisible = true;
                }
                else if (isContextMenuStripVisible == true)
                {
                    isContextMenuStripVisible = false;
                }
                contextMenuStrip1.Visible = isContextMenuStripVisible;
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void setTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                label1.ForeColor = dlg.Color;
                label2.ForeColor = dlg.Color;
                SettingLabel.ForeColor = dlg.Color;
                WelcomeMsg.ForeColor = dlg.Color;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string toolString = toolStripComboBox1.SelectedItem.ToString();
            if (toolString.Equals("Blue City (Default)"))
            {
                SetAllLabelsToColor(Color.White);
                pictureBox1.Image = Properties.Resources.b4045820491130ade657939f75a30783;
                MessageBox.Show("The default theme has been successfully applied.", "DigiClock | Themes");
            } else if (toolString.Equals("Cyberpunk 2077"))
            {
                SetAllLabelsToColor(Color.FromArgb(255, 191, 244));
                pictureBox1.Image = Properties.Resources.Cyberpunk2077;
                MessageBox.Show("The Cyberpunk 2077 theme has been successfully applied.", "DigiClock | Themes");
            }
        }

        void SetAllLabelsToColor(Color chosenColor)
        {
            label1.ForeColor = chosenColor;
            label2.ForeColor = chosenColor;
            SettingLabel.ForeColor = chosenColor;
            WelcomeMsg.ForeColor = chosenColor;
        }
    }
}