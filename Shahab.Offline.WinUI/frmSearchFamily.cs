using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Shahab.Offline.Model;
using Shahab.Offline.BL;
using System.Runtime.InteropServices;
using Shahab.Offline.Logging;

namespace Shahab.Offline.WinUI
{
    public partial class frmSearchFamily : Form
    {
        public frmSearchFamily()
        {
            InitializeComponent();
        }

        private void frmSearchFamily_Load(object sender, EventArgs e)
        {
            try
            {
                B_GetDatas bg = new B_GetDatas();
                List<M_Families> fm = bg.GetFamily().OrderBy(c => c.FamilyCode).ToList();
                List<M_FamilyMembers> fmm = bg.GetFamilyMember();
                label24.Text = "تعداد کل پرونده های ثبت شده : " + fm.Count.ToString() + " .:::. تعداد کل افراد ثبت شده : " + fmm.Count.ToString();
                foreach (M_Families li in fm)
                {
                    List<M_FamilyMembers> fmm2 = fmm.Where(c => c.Relationship == 63 && c.FamilyID == li.ID).ToList();
                    string Name = "";
                    if (fmm2.Count > 0)
                        Name = fmm2[0].FirstName + " " + fmm2[0].LastName;
                    M_Address ad = bg.GetAdressByFamilyID(li.ID);
                    string[] s = { 
                                     li.FamilyCode.ToString()
                                     , B_ReportPublicCategori.GetPublitCategoriByID(li.FamilyTypeCode).PC_Title
                                     , B_ReportPublicCategori.GetPublitCategoriByID(li.OwnrshipCode).PC_Title
                                     ,Name
                                     ,li.HeaderMobileNumber
                                     ,ad.ZipCode
                                     , li.ID.ToString()
                                 };
                    dgvParvandeSearch.Rows.Add(s);
                }
            }
            catch(Exception Ex)
            {
                L_ErrorLogs.Errors(Ex.Message);
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            try
            {
                dgvParvandeSearch.Rows.Clear();
                if (txtParvandeSearchParvandeNumber.Text != "")
                {
                    B_GetDatas bg = new B_GetDatas();
                    List<M_Families> fm = bg.GetFamily(int.Parse(txtParvandeSearchParvandeNumber.Text));
                    if (fm.Count > 0)
                    {
                        foreach (M_Families li in fm)
                        {
                            List<M_FamilyMembers> fmm2 = bg.GetFamilyMember(li.ID).Where(c => c.Relationship == 63).ToList();
                            string Name = "";
                            if (fmm2.Count > 0)
                                Name = fmm2[0].FirstName + " " + fmm2[0].LastName;
                            M_Address ad = bg.GetAdressByFamilyID(li.ID);
                            string[] s = { 
                                     li.FamilyCode.ToString()
                                     , B_ReportPublicCategori.GetPublitCategoriByID(li.FamilyTypeCode).PC_Title
                                     , B_ReportPublicCategori.GetPublitCategoriByID(li.OwnrshipCode).PC_Title
                                     ,Name
                                     ,li.HeaderMobileNumber
                                     ,ad.ZipCode
                                     , li.ID.ToString()
                                 };
                            dgvParvandeSearch.Rows.Add(s);
                        }
                    }
                }
                else if (txtParvandeSearchNationalCode.Text != "")
                {
                    B_GetDatas bg = new B_GetDatas();
                    M_FamilyMembers fmm = bg.GetFamilyMember(txtParvandeSearchNationalCode.Text);
                    if (fmm != null)
                    {
                        List<M_Families> fm = bg.GetFamily().Where(c => c.ID == fmm.FamilyID).ToList();
                        foreach (M_Families li in fm)
                        {
                            List<M_FamilyMembers> fmm2 = bg.GetFamilyMember(li.ID).Where(c => c.Relationship == 63).ToList();
                            string Name = "";
                            if (fmm2.Count > 0)
                                Name = fmm2[0].FirstName + " " + fmm2[0].LastName;
                            M_Address ad = bg.GetAdressByFamilyID(li.ID);
                            string[] s = { 
                                     li.FamilyCode.ToString()
                                     , B_ReportPublicCategori.GetPublitCategoriByID(li.FamilyTypeCode).PC_Title
                                     , B_ReportPublicCategori.GetPublitCategoriByID(li.OwnrshipCode).PC_Title
                                     ,Name
                                     ,li.HeaderMobileNumber
                                     ,ad.ZipCode
                                     , li.ID.ToString()
                                 };
                            dgvParvandeSearch.Rows.Add(s);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                L_ErrorLogs.Errors(Ex.Message);
            }
            if (txtParvandeSearchNationalCode.Text == "" && txtParvandeSearchParvandeNumber.Text == "")
                frmSearchFamily_Load(null, null);
        }

        private void dgvParvandeSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow rw in dgvParvandeSearch.Rows)
                {
                    rw.Selected = false;
                }
                dgvParvandeSearch.Rows[e.RowIndex].Selected = true;
            }
            catch { };
        }

        private void dgvParvandeSearch_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow rw in dgvParvandeSearch.Rows)
                {
                    rw.Selected = false;
                }
                dgvParvandeSearch.Rows[e.RowIndex].Selected = true;
            }
            catch { };
        }

        private void txtParvandeSearchNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dgvParvandeSearch_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow rw in dgvParvandeSearch.Rows)
                {
                    rw.Selected = false;
                }
                dgvParvandeSearch.Rows[e.RowIndex].Selected = true;
            }
            catch { };
        }
    }
}
