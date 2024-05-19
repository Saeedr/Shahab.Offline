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
    public partial class frmTajhizat : Form
    {
        public frmTajhizat()
        {
            InitializeComponent();
        }

        public bool Submit()
        {
            List<M_HaveEquipment> Param = new List<M_HaveEquipment>();
            foreach (DataGridViewRow rw in dgvTajhizat2.Rows)
            {
                M_HaveEquipment param = new M_HaveEquipment();
                param.CreateDate = DateTime.Today;
                param.EquipmentCount = int.Parse(rw.Cells["Count1"].Value.ToString());
                param.EquipmentDescription = rw.Cells["Description1"].Value.ToString();
                param.EquipmentID = int.Parse(rw.Cells["Code1"].Value.ToString());
                param.EquipmentStatus = int.Parse(rw.Cells["Status1"].Value.ToString());
                param.Name = rw.Cells["Name1"].Value.ToString();
                param.IsActive = true;
                param.IsDeleted = false;
                param.IsSent = false;
                Param.Add(param);
            }
            B_InsertDatas BI = new B_InsertDatas();
            BI.InsertHaveEquipment(Param);

            frmMessage msg = new frmMessage();
            msg.label1.Text = "عملیات با موفقیت انجارم شد";
            msg.ShowDialog();
            return true;
        }

        List<M_Equipment> Equ;

        /// <summary>
        /// آیا این کد در دیتا گرید ویو وجود دارد
        /// </summary>
        /// <param name="Code">کد مورد نظر</param>
        /// <param name="dgv">گرید ویو مورد نظر</param>
        /// <returns>true = وجود دارد | false = وجود ندارد</returns>
        private bool IsRowExist(string Code, DataGridView dgv)
        {
            foreach (DataGridViewRow rw in dgv.Rows)
            {
                if (rw.Cells[0].Value.ToString() == Code)
                    return true;
            }
            return false;
        }

        private void frmTajhizat_Load(object sender, EventArgs e)
        {
            try
            {
                B_GetDatas BG = new B_GetDatas();
                cmbTajhizName.AutoCompleteCustomSource.Clear();
                Equ = BG.GetEquipment();
                cmbTajhizName.DataSource = Equ;
                cmbTajhizName.DisplayMember = "EquipmentName";
                cmbTajhizName.ValueMember = "ID";
                List<M_HaveEquipment> HE = BG.GetHaveEquipment();
                foreach(M_HaveEquipment li in HE)
                {
                    dgvTajhizat2.Rows.Add(li.EquipmentID, li.Name, li.EquipmentDescription, li.EquipmentCount, li.EquipmentStatus);
                }
                B_PublicFunctions.AddToCombo(211, comboBoxEx1);
            }
            catch (Exception Ex) { L_ErrorLogs.Errors(Ex.Message); }


        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            //dgvTajhizat1.Rows.Clear();
            //if (txtSearchCode.Text != string.Empty)
            //{
            //    foreach (M_Equipment li in Equ.Where(c => c.Code == int.Parse(txtSearchCode.Text)))
            //    {
            //        if (IsRowExist(li.Code.ToString(), dgvTajhizat2) == false)
            //            dgvTajhizat1.Rows.Add(li.Code, li.Value, li.Version);
            //        Application.DoEvents();
            //    }
            //}
            //else if (txtSearchName.Text != string.Empty)
            //{
            //    foreach (M_Equipment li in Equ.Where(c => c.Value.Contains(txtSearchName.Text)))
            //    {
            //        if (IsRowExist(li.Code.ToString(), dgvTajhizat2) == false)
            //            dgvTajhizat1.Rows.Add(li.Code, li.Value, li.Version);
            //        Application.DoEvents();
            //    }
            //}
            //if (txtSearchCode.Text == string.Empty && txtSearchName.Text == string.Empty)
            //{
            //    foreach (M_Equipment li in Equ)
            //    {
            //        if (IsRowExist(li.Code.ToString(), dgvTajhizat2) == false)
            //            dgvTajhizat1.Rows.Add(li.Code, li.Value, li.Version);
            //        Application.DoEvents();
            //    }
            //}
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            if (cmbTajhizName.SelectedIndex != -1 && IsRowExist(Equ[cmbTajhizName.SelectedIndex].ID.ToString(), dgvTajhizat2) == false)
            {
                if (B_PublicFunctions.CheckTextBox(groupPanel1, err) == true)
                {
                    dgvTajhizat2.Rows.Add(
                        Equ[cmbTajhizName.SelectedIndex].ID.ToString(),
                        textBoxX1.Text,
                        textBoxX2.Text,
                        textBoxX3.Text,
                        comboBoxEx1.SelectedValue.ToString()
                        );
                    textBoxX1.Text = textBoxX2.Text = textBoxX3.Text = txtActionFirstFamilySearch.Text = string.Empty;
                    cmbTajhizName.SelectedIndex = comboBoxEx1.SelectedIndex = -1;
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dgvTajhizat2.SelectedRows.Count == 1)
            {
                dgvTajhizat2.Rows.RemoveAt(dgvTajhizat2.SelectedRows[0].Index);
            }
        }

        private void cmbTajhizName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTajhizName.SelectedIndex != -1)
            {
                txtActionFirstFamilySearch.Text = Equ[cmbTajhizName.SelectedIndex].Quantity.ToString();
            }
        }
    }
}
