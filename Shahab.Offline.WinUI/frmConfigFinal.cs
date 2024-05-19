using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahab.Offline.WinUI
{
    public partial class frmConfigFinal : Form
    {
        public frmConfigFinal()
        {
            InitializeComponent();
        }

        private void HidePanels()
        {
            pnlStep1.Visible = false;
            pnlStep2.Visible = false;
            pnlStep3.Visible = false;
            pnlStep4.Visible = false;
            pnlStep5.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                pnl1.Visible = true;
                pnl2.Visible = false;
            }
            else
            {
                pnl2.Visible = true;
                pnl1.Visible = false;
            }
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files|*.jpg|PNG Files|*.png";
            op.Multiselect = true;
            if (op.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                foreach(string s in op.FileNames)
                {
                    PictureBox pic = new PictureBox();
                    pic.Size = new System.Drawing.Size(132, 100);
                    pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pic.Image = Image.FromFile(s);
                    flowLayoutPanel1.Controls.Add(pic);
                    Application.DoEvents();
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files|*.jpg|PNG Files|*.png";
            op.Multiselect = true;
            if (op.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel2.Controls.Clear();
                foreach (string s in op.FileNames)
                {
                    PictureBox pic = new PictureBox();
                    pic.Size = new System.Drawing.Size(132, 100);
                    pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pic.Image = Image.FromFile(s);
                    flowLayoutPanel2.Controls.Add(pic);
                    Application.DoEvents();
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked==true)
            {
                HidePanels();
                pnlStep1.Visible = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                HidePanels();
                pnlStep2.Visible = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                HidePanels();
                pnlStep3.Visible = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                HidePanels();
                pnlStep4.Visible = true;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                HidePanels();
                pnlStep5.Visible = true;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if(buttonX2.Checked==false)
            {
                panelEx3.Visible = true;
                panelEx1.Visible = false;
                buttonX2.Checked = true;
            }
            else
            {
                panelEx3.Visible = false;
                panelEx1.Visible = true;
                buttonX2.Checked = false;
            }
        }
    }
}
