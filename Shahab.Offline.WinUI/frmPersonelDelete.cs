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
using System.Globalization;

namespace Shahab.Offline.WinUI
{
    public partial class frmPersonelDelete : Form
    {
        List<int> DeletedIDs = new List<int>();

        public bool Submit()
        {
            foreach (int id in DeletedIDs)
            {
                B_DeleteDatas BD = new B_DeleteDatas();
                BD.DetelePersonel(id);
            }
            frmMessage msg = new frmMessage();
            msg.label1.Text = "عملیات با موفقیت انجارم شد";
            msg.ShowDialog();
            return true;
        }


        public frmPersonelDelete()
        {
            InitializeComponent();
        }

        private void txtInserPersonelFamily_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonX13_Click(object sender, EventArgs e)
        {
            if (txtDeletePersonelSearch.Text != "")
            {
                dgvParvandeAddPerson1.Rows.Clear();
                B_GetDatas BG = new B_GetDatas();
                List<M_Employee> em = BG.GetEmployee().Where(c => c.UserCode.Trim() == txtDeletePersonelSearch.Text.Trim()).ToList();
                foreach (M_Employee li in em)
                {
                    if (DeletedIDs.IndexOf(li.ID) == -1)
                        dgvParvandeAddPerson1.Rows.Add(li.ID, li.FirstName, li.LastName, li.NationalCode, B_ReportPublicCategori.GetPublitCategoriByID(li.Gender).PC_Title);
                }
                dgvParvandeAddPerson1_Click(null, null);
            }
            else
            {
                frmPersonelDelete_Load(null, null);
            }
        }

        private void frmPersonelDelete_Load(object sender, EventArgs e)
        {
            dgvParvandeAddPerson1.Rows.Clear();
            B_GetDatas BG = new B_GetDatas();
            List<M_Employee> em = BG.GetEmployee();
            foreach (M_Employee li in em)
            {
                if (DeletedIDs.IndexOf(li.ID) == -1)
                    dgvParvandeAddPerson1.Rows.Add(li.ID, li.FirstName, li.LastName, li.NationalCode, B_ReportPublicCategori.GetPublitCategoriByID(li.Gender).PC_Title);
            }
            dgvParvandeAddPerson1_Click(null, null);
        }

        private void dgvParvandeAddPerson1_Click(object sender, EventArgs e)
        {
            if (dgvParvandeAddPerson1.SelectedRows.Count != 0)
            {
                int id = int.Parse(dgvParvandeAddPerson1.SelectedRows[0].Cells["ID"].Value.ToString());
                B_GetDatas BG = new B_GetDatas();
                M_Employee em = BG.GetEmployee().Where(c => c.ID == id).Single();
                byte[] data = em.Picture;
                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(data));
                PersianCalendar pc = new PersianCalendar();
                lblBirthDate.Text = pc.GetYear(em.BirthDate) + " / " + pc.GetMonth(em.BirthDate) + " / " + pc.GetDayOfMonth(em.BirthDate);
                lblEstekhdamCode.Text = em.UserCode;
                lblFamily.Text = em.LastName;
                lblName.Text = em.FirstName;
                lblNationalCode.Text = em.NationalCode;
                lblOfficicalCode.Text = em.OfficialCode;
                lblMaritalStatus.Text = B_ReportPublicCategori.GetPublitCategoriByID(em.MaritalStatus).PC_Title;
                lblGender.Text = B_ReportPublicCategori.GetPublitCategoriByID(em.Gender).PC_Title;
            }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            if (dgvParvandeAddPerson1.SelectedRows.Count != 0)
            {
                int id = int.Parse(dgvParvandeAddPerson1.SelectedRows[0].Cells["ID"].Value.ToString());
                frmDeleteConfirm frm = new frmDeleteConfirm();
                frm.label1.Text = "آیا از حذف " + dgvParvandeAddPerson1.SelectedRows[0].Cells["Column1"].Value.ToString() + " " + dgvParvandeAddPerson1.SelectedRows[0].Cells["Column2"].Value.ToString() +" مطمئن هستید ؟";
                frm.ShowDialog();
                if (frm.Status == true)
                {
                    DeletedIDs.Add(id);
                    dgvParvandeAddPerson1.Rows.RemoveAt(dgvParvandeAddPerson1.SelectedRows[0].Index);
                    dgvParvandeAddPerson1_Click(null, null);
                }
            }
        }
    }
}
