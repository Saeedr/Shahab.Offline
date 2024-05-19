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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Text == "admin" && textBoxX2.Text == "admin")
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                frmMessage msg = new frmMessage();
                msg.label1.Text = "نام کاربری یا گذرواژه صحیح نیست";
                msg.ShowDialog();
            }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
