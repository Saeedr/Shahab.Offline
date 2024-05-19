using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shahab.Offline.BL;
using Shahab.Offline.Logging;
using Shahab.Offline.Model;

namespace Shahab.Offline.WinUI
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            B_GetDatas BG = new B_GetDatas();
            foreach (M_UnitPlace up in BG.GetUnitPlaces())
            {
                dgvParvandeConfig.Rows.Add(up.PlaceID, B_ReportPublicCategori.GetPublitCategoriByID(up.PlaceTypeID).PC_Title, up.PlaceName, up.UnitCode);
            }
        }
    }
}
