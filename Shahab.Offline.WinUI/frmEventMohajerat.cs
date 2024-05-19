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
using System.Data.SqlClient;

namespace Shahab.Offline.WinUI
{
    public partial class frmEventMohajerat : Form
    {
        /// <summary>
        /// سازنده پیشفرض که فرم را در حالت عادی باز میکند
        /// </summary>
        public frmEventMohajerat()
        {
            InitializeComponent();
            B_PublicFunctions.AddToCombo(218, comboBoxEx2);
        }


        public M_EventMigrations M_EM = null;
        public List<int> DeleteFamily = new List<int>();
        public frmEventMohajerat(List<M_FamilyMembers> MemberList,int[] DelParam,bool Enable = true)
        {
            InitializeComponent();
            B_PublicFunctions.AddToCombo(218, comboBoxEx2, DelParam);
            comboBoxEx2.Enabled = Enable;
            comboBoxEx2.SelectedIndex = 0;
            foreach (M_FamilyMembers li in MemberList)
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                string Date = pc.GetYear(li.BirthDate).ToString() + "/" + pc.GetMonth(li.BirthDate).ToString() + "/" + pc.GetDayOfMonth(li.BirthDate).ToString();
                dgvActionMohajerat.Rows.Add(li.FirstName, li.LastName, li.NationalCode, Date, li.MobileNumber, li.ID);
            }
            pnlStep1.Enabled = Enable;
            buttonX1.Visible = true;
            buttonX2.Visible = true;
            buttonX14.Visible = false;
        }
        
        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        public bool Submit()
        {
            err.Clear();
            if (dgvActionMohajerat.SelectedRows.Count == 1)
            {
                M_FamilyMembers fm = new M_FamilyMembers();
                M_Families Fm = new M_Families();
                B_GetDatas BG = new B_GetDatas();
                B_DeleteDatas BD = new B_DeleteDatas();
                B_InsertDatas BI = new B_InsertDatas();
                bool IsDeleteFamily = false;

                if (B_PublicFunctions.CheckTextBox(groupPanel1, err) == false)
                    return false;
                if (B_PublicFunctions.CheckTextBox(panelEx2, err) == false)
                    return false;
                if (B_PublicFunctions.IsValidDate(txtParvandeAddBirthDay.Text) == false)
                {
                    err.SetError(txtParvandeAddBirthDay, "این تاریخ صحیح نیست");
                    return false;
                }
                if (checkBoxX1.Checked == false)
                    if (B_PublicFunctions.IsValidDate(maskedTextBoxAdv1.Text) == false)
                    {
                        err.SetError(maskedTextBoxAdv1, "این تاریخ صحیح نیست");
                        return false;
                    }

                fm = BG.GetFamilyMember(int.Parse(dgvActionMohajerat.SelectedRows[0].Cells["MemberID"].Value.ToString()), "None");
                if (BG.GetFamilyMember(fm.FamilyID).Count == 1)
                {
                    frmDeleteConfirm frm = new frmDeleteConfirm();
                    frm.label1.Text = "این شخص تنها عضو خانوار است و با مهاجرت او خانوار هم حذف خواهد شد ." + Environment.NewLine + "مایل به ادامه کار هستید ؟";
                    frm.ShowDialog();
                    if (frm.Status == true)
                        IsDeleteFamily = true;
                    else
                        return false;
                }
                if (fm.Relationship == 63 && IsDeleteFamily == false)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "شخصی مورد نظر شما سرپرست خانوار است و این خانوار نمیتواند بدون سرپرست باقی بماند , لطفا به مورد رسیدگی و مجددا اقدام نمایید";
                    msg.ShowDialog();
                    return false;
                }
                M_EventMigrations EM = new M_EventMigrations();
                EM.FamilyMemberID = fm.ID;
                EM.FromDate = B_PublicFunctions.ConverShamsiToMiladi(txtParvandeAddBirthDay.Text);
                if (checkBoxX1.Checked == false)
                    EM.ToDate = B_PublicFunctions.ConverShamsiToMiladi(maskedTextBoxAdv1.Text);
                EM.IsActive = true;
                EM.IsSent = false;
                EM.IsDeleted = false;
                EM.MigrationReasonCode = int.Parse(comboBoxEx2.SelectedValue.ToString());
                EM.PlaceID = 0;
                EM.ParentPlaceID = 0;
                if (cmbCountry.SelectedIndex == 0)
                {
                    if (cmbCounty.SelectedIndex != -1)
                    {
                        EM.PlaceID = int.Parse(cmbCityOrVillage.SelectedValue.ToString());
                        EM.ParentPlaceID = int.Parse(cmbCounty.SelectedValue.ToString());
                    }
                    else
                    {
                        EM.PlaceID = int.Parse(cmbTownship.SelectedValue.ToString());
                        EM.ParentPlaceID = int.Parse(cmbProvince.SelectedValue.ToString());
                    }
                }
                int ID = BI.InsertEventMigrations(EM);
                M_Event EV = new M_Event();
                EV.Activity = fm.Activity;
                EV.BirthDate = fm.BirthDate;
                EV.CreateDate = fm.CreateDate;
                EV.DeathDate = fm.DeathDate;
                EV.Description = fm.Description;
                EV.Education = fm.Education;
                EV.EventCreateDate = DateTime.Now;
                EV.EventID = ID;
                EV.ExpireDate = fm.ExpireDate;
                EV.FamilyID = fm.FamilyID;
                EV.FamilyMembersUID = fm.FamilyMembersUID;
                EV.FirstInsurance = fm.FirstInsurance;
                EV.FirstName = fm.FirstName;
                EV.Gender = fm.Gender;
                EV.IsActive = true;
                EV.IsDeleted = false;
                EV.IsSend = false;
                EV.Job = fm.Job;
                EV.LastName = fm.LastName;
                EV.MaritalStatus = fm.MaritalStatus;
                EV.MobileNumber = fm.MobileNumber;
                EV.NationalCode = fm.NationalCode;
                EV.Nationality = fm.Nationality;
                EV.OccuredDate = DateTime.Today;
                EV.Organization8DigitID = "12345678";//MostBeChange
                EV.Relationship = fm.Relationship;
                EV.ResidentStatus = fm.ResidentStatus;
                EV.SecondInsurance = fm.SecondInsurance;
                EV.MasterID = 128;
                BI.InsertEvent(EV);
                BD.DeleteFamilyMember(fm);
                if (IsDeleteFamily == true)
                    BD.DeleteFamily(fm.FamilyID);
                frmMessage msg1 = new frmMessage();
                msg1.label1.Text = "عملیات با موفقت انجام شد";
                msg1.ShowDialog();
                return true;
            }
            else
            {
                frmMessage msg = new frmMessage();
                msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                msg.label1.Text = "شخصی توسط شما انتخاب نشده";
                msg.ShowDialog();
                return false;
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            if (txtActionFirstFamilySearch.Text != "")
            {
                B_GetDatas BG = new B_GetDatas();
                List<M_FamilyMembers> FMem = new List<M_FamilyMembers>();
                List<M_Families> Fm = BG.GetFamily(int.Parse(txtActionFirstFamilySearch.Text));
                if (Fm.Count > 1)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "بیش از یک خانوار با این شماره پرونده وجود دارد , لطفا شماره خانوار را تصحیح و مجددا سعی نمایید";
                    msg.ShowDialog();
                    return;
                }
                if (Fm.Count == 0)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "خانواری با این شماره پرونده یافت نشد";
                    msg.ShowDialog();
                    return;
                }

                B_GetDatas bg = new B_GetDatas();
                M_Families fm2 = bg.GetFamily().Where(c => c.ID == Fm.Single().ID).Single<M_Families>();
                frmPersonFamilyAdd frm = new frmPersonFamilyAdd(fm2.ID);
                frm.Tag = "Edit";
                frm.FamilyCode = Fm.Single().ID;
                frm.ThisFamily = fm2;
                frm.Width = 0;
                frm.Height = 0;
                frm.Show();
                int Counter = 0;
                foreach (DataGridViewRow rw in frm.dgvParvandeAddPerson.Rows)
                {
                    if (rw.DefaultCellStyle.BackColor == Color.LightPink)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "اطلاعات اعضای خانوار شما مشکل دارد , لطفا آنهارا تصحیح و مجددا سعی نمایید";
                        frm.Close();
                        msg.ShowDialog();
                        return;
                    }
                    if (fm2.FamilyTypeCode == 84 && rw.Cells["NesbatID"].Value.ToString() != "")
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "این خانوار موسسه ای است و نسبت با سرپرست دارد , لطفا مورد را تصحیح و مجددا سعی نمایید";
                        frm.Close();
                        msg.ShowDialog();
                        return;
                    }
                    if (rw.Cells["NesbatID"].Value.ToString() == "63")
                        Counter++;
                }
                frm.Close();
                if (Counter > 1)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "این خانوار بیش از یک سرپرست دارد , لطفا به مورد رسیدگی و مجددا سعی نمایید";
                    msg.ShowDialog();
                    return;
                }
                FMem = BG.GetFamilyMember(Fm.Single().ID);
                dgvActionMohajerat.Rows.Clear();
                foreach (M_FamilyMembers fm in FMem)
                {
                    dgvActionMohajerat.Rows.Add(fm.FirstName, fm.LastName, fm.NationalCode, Math.Round(((DateTime.Today - fm.BirthDate).TotalDays / 365)) + " سال", fm.MobileNumber, fm.ID);
                }
            }
            else if (textBoxX1.Text != "")
            {
                B_GetDatas bg = new B_GetDatas();
                M_FamilyMembers fmm = bg.GetFamilyMember(textBoxX1.Text);
                if (fmm != null)
                {
                    M_Families fm2 = bg.GetFamily().Where(c => c.ID == fmm.FamilyID).Single();
                    frmPersonFamilyAdd frm = new frmPersonFamilyAdd(fm2.ID);
                    frm.Tag = "Edit";
                    frm.FamilyCode = fm2.ID;
                    frm.ThisFamily = fm2;
                    frm.Width = 0;
                    frm.Height = 0;
                    frm.Show();
                    int Counter = 0; foreach (DataGridViewRow rw in frm.dgvParvandeAddPerson.Rows)
                    {
                        if (rw.DefaultCellStyle.BackColor == Color.LightPink)
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "اطلاعات اعضای خانوار شما مشکل دارد , لطفا آنهارا تصحیح و مجددا سعی نمایید";
                            frm.Close();
                            msg.ShowDialog();
                            return;
                        }
                        if (fm2.FamilyTypeCode == 84 && rw.Cells["NesbatID"].Value.ToString() != "")
                        {
                            frmMessage msg = new frmMessage();
                            msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                            msg.label1.Text = "این خانوار موسسه ای است و نسبت با سرپرست دارد , لطفا مورد را تصحیح و مجددا سعی نمایید";
                            frm.Close();
                            msg.ShowDialog();
                            return;
                        }
                        if (rw.Cells["NesbatID"].Value.ToString() == "63")
                            Counter++;
                    }
                    frm.Close();
                    if (Counter > 1)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "این خانوار بیش از یک سرپرست دارد یا فاقد سرپرست است , لطفا به مورد رسیدگی و مجددا سعی نمایید";
                        msg.ShowDialog();
                        return;
                    }
                    dgvActionMohajerat.Rows.Clear();
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    string Date = pc.GetYear(fmm.BirthDate).ToString() + "/" + pc.GetMonth(fmm.BirthDate).ToString() + "/" + pc.GetDayOfMonth(fmm.BirthDate).ToString();
                    dgvActionMohajerat.Rows.Add(fmm.FirstName, fmm.LastName, fmm.NationalCode, Date, fmm.MobileNumber, fmm.ID);
                }
                else
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "چنین شخصی پیدا نشد";
                    msg.ShowDialog();
                }
            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTownship.DataSource = null;
            if (cmbProvince.SelectedIndex != -1)
            {
                B_PublicFunctions.FillCountryDivision(cmbProvince.SelectedValue.ToString(), cmbTownship);
            }
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProvince.DataSource = null;
            if (cmbCountry.SelectedIndex == 0)
            {
                B_PublicFunctions.FillCountryDivision("IR", cmbProvince);
                cmbTownship.Enabled = true;
                cmbProvince.Enabled = true;
                cmbCounty.Enabled = true;
            }
            else
            {
                cmbTownship.Enabled = false;
                cmbProvince.Enabled = false;
                cmbCounty.Enabled = false;
                cmbTownship.SelectedIndex = -1;
                cmbProvince.SelectedIndex = -1;
                cmbCounty.SelectedIndex = -1;
            }
        }

        private void cmbTownship_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCounty.DataSource = null;
            if (cmbTownship.SelectedIndex != -1)
                B_PublicFunctions.FillCountryDivision(cmbTownship.SelectedValue.ToString(), cmbCounty);
        }

        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCityOrVillage.DataSource = null;
            if (cmbCounty.SelectedIndex != -1)
            {
                B_PublicFunctions.FillCountryDivision(cmbCounty.SelectedValue.ToString(), cmbCityOrVillage);
                cmbCityOrVillage.Enabled = true;
            }
            else
            {
                cmbCityOrVillage.Enabled = false;
                cmbCityOrVillage.SelectedIndex = -1;
            }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == true)
            {
                maskedTextBoxAdv1.Enabled = false;
                maskedTextBoxAdv1.Text = "";
            }
            else
                maskedTextBoxAdv1.Enabled = true;
        }

        private void frmEventMohajerat_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DeleteFamily.Clear();
            M_EM = null;
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            err.Clear();
            DeleteFamily.Clear();
            M_EM = null;

            if (B_PublicFunctions.CheckTextBox(groupPanel1, err) == false)
                return;
            if (B_PublicFunctions.CheckTextBox(panelEx2, err) == false)
                return;
            if (B_PublicFunctions.IsValidDate(txtParvandeAddBirthDay.Text) == false)
            {
                err.SetError(txtParvandeAddBirthDay, "این تاریخ صحیح نیست");
                return;
            }
            if (checkBoxX1.Checked == false)
                if (B_PublicFunctions.IsValidDate(maskedTextBoxAdv1.Text) == false)
                {
                    err.SetError(maskedTextBoxAdv1, "این تاریخ صحیح نیست");
                    return;
                }

            foreach (DataGridViewRow rw in dgvActionMohajerat.Rows)
            {
                M_FamilyMembers fm = new M_FamilyMembers();
                M_Families Fm = new M_Families();
                B_GetDatas BG = new B_GetDatas();
                B_DeleteDatas BD = new B_DeleteDatas();
                B_InsertDatas BI = new B_InsertDatas();
                fm = BG.GetFamilyMember(int.Parse(rw.Cells["MemberID"].Value.ToString()), "None");
                if (BG.GetFamilyMember(fm.FamilyID).Count == 1)
                {
                    frmDeleteConfirm frm = new frmDeleteConfirm();
                    frm.label1.Text = "این شخص تنها عضو خانوار است و با مهاجرت او خانوار هم حذف خواهد شد ." + Environment.NewLine + "مایل به ادامه کار هستید ؟";
                    frm.ShowDialog();
                    if (frm.Status == true)
                        DeleteFamily.Add(fm.FamilyID);
                    else
                        return;
                }
                if (fm.Relationship == 63 && DeleteFamily.Count == 0)
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "شخصی مورد نظر شما سرپرست خانوار است و این خانوار نمیتواند بدون سرپرست باقی بماند , لطفا به مورد رسیدگی و مجددا اقدام نمایید";
                    msg.ShowDialog();
                    return ;
                }
                M_EventMigrations EM = new M_EventMigrations();
                EM.FamilyMemberID = fm.ID;
                EM.FromDate = B_PublicFunctions.ConverShamsiToMiladi(txtParvandeAddBirthDay.Text);
                if (checkBoxX1.Checked == false)
                    EM.ToDate = B_PublicFunctions.ConverShamsiToMiladi(maskedTextBoxAdv1.Text);
                EM.IsActive = true;
                EM.IsSent = false;
                EM.IsDeleted = false;
                EM.MigrationReasonCode = int.Parse(comboBoxEx2.SelectedValue.ToString());
                EM.PlaceID = 0;
                EM.ParentPlaceID = 0;
                if (cmbCountry.SelectedIndex == 0)
                {
                    if (cmbCounty.SelectedIndex != -1)
                    {
                        EM.PlaceID = int.Parse(cmbCityOrVillage.SelectedValue.ToString());
                        EM.ParentPlaceID = int.Parse(cmbCounty.SelectedValue.ToString());
                    }
                    else
                    {
                        EM.PlaceID = int.Parse(cmbTownship.SelectedValue.ToString());
                        EM.ParentPlaceID = int.Parse(cmbProvince.SelectedValue.ToString());
                    }
                }
                M_EM = EM;
                this.Close();
            }
        }
    }
}
