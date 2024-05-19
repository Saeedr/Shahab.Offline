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
    public partial class frmDetilas : Form
    {
        public frmDetilas()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetilas_Load(object sender, EventArgs e)
        {
            animator1.Show(panel1);
        }
    }
}
