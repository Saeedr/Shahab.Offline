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
    public partial class frmEventTalagh : Form
    {

        public bool Submit()
        {
            err.Clear();
            if (rdoNewFamily.Checked == true)
            {
                if (B_PublicFunctions.CheckTextBox(pnlStep2_2, err) == true)
                {
                    if (txtParvandeAddTell1.Text.Length == 12)
                    {
                        if (txtParvandeAddTell2.Text.Length == 12)
                        {
                            if (txtParvandeAddTell2.Text.Substring(0, 2) == "09")
                            {
                                err.SetError(txtParvandeAddTell2, "این مقدار صحیح نیست");
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtParvandeAddAdress.Text) == false)
                            {

                                if (B_PublicFunctions.ISUnicFamilyCode(int.Parse(txtParvandeAddFamilyNumber.Text), 0) == true && txtParvandeAddFamilyNumber.Enabled == true)
                                {
                                    err.SetError(txtParvandeAddFamilyNumber, "این کد در خانوار دیگر ثبت شده");
                                    return false;
                                }
                                B_InsertDatas BI = new B_InsertDatas();
                                B_UpdateDatas BU = new B_UpdateDatas();
                                B_DeleteDatas BD = new B_DeleteDatas();

                                M_Event ev = new M_Event();
                                ev.Activity = FirstMember.Activity;
                                ev.BirthDate = FirstMember.BirthDate;
                                ev.CreateDate = FirstMember.CreateDate;
                                ev.DeathDate = FirstMember.DeathDate;
                                ev.Description = FirstMember.Description;
                                ev.Education = FirstMember.Education;
                                ev.EventCreateDate = DateTime.Today;
                                ev.EventID = 0;
                                ev.FamilyID = FirstMember.FamilyID;
                                ev.FamilyMembersUID = FirstMember.FamilyMembersUID;
                                ev.FirstInsurance = FirstMember.FirstInsurance;
                                ev.FirstName = FirstMember.FirstName;
                                ev.Gender = FirstMember.Gender;
                                ev.IsSend = false;
                                ev.IsDeleted = false;
                                ev.Job = FirstMember.Job;
                                ev.LastActionID = 215;
                                ev.LastModifyDate = DateTime.Today;
                                ev.LastName = FirstMember.LastName;
                                ev.MaritalStatus = FirstMember.MaritalStatus;
                                ev.MobileNumber = FirstMember.MobileNumber;
                                ev.NationalCode = FirstMember.NationalCode;
                                ev.Nationality = FirstMember.Nationality;
                                ev.OccuredDate = DateTime.Today;
                                ev.Organization8DigitID = "12345678";//MostBeChange
                                ev.Relationship = FirstMember.Relationship;
                                ev.ResidentStatus = FirstMember.ResidentStatus;
                                ev.SecondInsurance = FirstMember.SecondInsurance;
                                ev.MasterID = 130;
                                BI.InsertEvent(ev);

                                BD.DeleteFamilyMember(FirstMember);

                                SecondMember.MaritalStatus = 33;
                                BU.UpdatePerson(SecondMember);

                                int CityOrVillageCode = int.Parse(cmbParvandeAddCityOrVillage.SelectedValue.ToString());
                                int ShomareSakhteman = int.Parse(txtParvandeAddShomareSakhteman.Text);
                                int FamilyNumber = int.Parse(txtParvandeAddFamilyNumber.Text);
                                int FamilyType = int.Parse(cmbParvandeAddFamilyType.SelectedValue.ToString());
                                int Malekiat = int.Parse(cmbParvandeAddMalekiat.SelectedValue.ToString());
                                string PostalCode = txtParvandeAddPostalCode.Text;
                                string Tell1 = txtParvandeAddTell1.Text.Replace("-", "");
                                string Tell2 = txtParvandeAddTell2.Text.Replace("-", "");
                                string Adrees1 = txtParvandeAddAdress.Text;
                                string Adrees2 = "";
                                string Adrees3 = "";
                                DateTime CreateDate = DateTime.Now;
                                long UnitCode = 10;
                                M_Families fml = new M_Families();
                                fml.CreateDate = CreateDate;
                                fml.FamilyCode = FamilyNumber;
                                fml.FamilyTypeCode = FamilyType;
                                fml.HeaderMobileNumber = Tell1;
                                fml.OwnrshipCode = Malekiat;
                                fml.PlaceID = CityOrVillageCode;
                                fml.UnitCode = UnitCode;
                                M_Address ad = new M_Address();
                                ad.AddressString1 = Adrees1;
                                ad.AddressString2 = Adrees2;
                                ad.AddressString3 = Adrees3;
                                ad.BuildingNumber = ShomareSakhteman;
                                ad.CreateDate = CreateDate;
                                ad.PlaceID = CityOrVillageCode;
                                ad.TelephoneNumber = Tell2;
                                ad.ZipCode = PostalCode;
                                FirstMember.MaritalStatus = 33;
                                if (cmbParvandeAddFamilyType.SelectedValue.ToString() == "84")
                                    FirstMember.Relationship = 0;
                                else
                                    FirstMember.Relationship = 63;
                                List<M_FamilyMembers> LFmm = new List<M_FamilyMembers>();
                                LFmm.Add(FirstMember);
                                BI.InsertFamily(fml, LFmm, ad);
                                frmMessage msg = new frmMessage();
                                msg.label1.Text = "عملیات با موفقیت انجام شد";
                                msg.ShowDialog();
                                return true;
                            }
                            else
                            {
                                err.SetError(txtParvandeAddAdress, "این مقدار صحیح نیست");
                                return false;
                            }
                            err.SetError(txtParvandeAddTell2, "");
                        }
                        else
                        {
                            err.SetError(txtParvandeAddTell2, "این مقدار صحیح نیست");
                            return false;
                        }
                        err.SetError(txtParvandeAddTell1, "");
                    }
                    else
                    {
                        err.SetError(txtParvandeAddTell1, "این مقدار صحیح نیست");
                        return false;
                    }
                }
            }
            else
            {
                if (SecondFamily != null)
                {
                    if (B_PublicFunctions.CheckTextBox(pnlStep2_1, err) == false)
                        return false;

                    B_InsertDatas BI = new B_InsertDatas();
                    B_UpdateDatas BU = new B_UpdateDatas();
                    B_DeleteDatas BD = new B_DeleteDatas();

                    M_Event ev = new M_Event();
                    ev.Activity = FirstMember.Activity;
                    ev.BirthDate = FirstMember.BirthDate;
                    ev.CreateDate = FirstMember.CreateDate;
                    ev.DeathDate = FirstMember.DeathDate;
                    ev.Description = FirstMember.Description;
                    ev.Education = FirstMember.Education;
                    ev.EventCreateDate = DateTime.Today;
                    ev.EventID = 0;
                    ev.FamilyID = FirstMember.FamilyID;
                    ev.FamilyMembersUID = FirstMember.FamilyMembersUID;
                    ev.FirstInsurance = FirstMember.FirstInsurance;
                    ev.FirstName = FirstMember.FirstName;
                    ev.Gender = FirstMember.Gender;
                    ev.IsSend = false;
                    ev.IsDeleted = false;
                    ev.Job = FirstMember.Job;
                    ev.LastActionID = 2015;
                    ev.LastModifyDate = DateTime.Today;
                    ev.LastName = FirstMember.LastName;
                    ev.MaritalStatus = FirstMember.MaritalStatus;
                    ev.MobileNumber = FirstMember.MobileNumber;
                    ev.NationalCode = FirstMember.NationalCode;
                    ev.Nationality = FirstMember.Nationality;
                    ev.OccuredDate = DateTime.Today;
                    ev.Organization8DigitID = "12345678";//MostBeChange
                    ev.Relationship = FirstMember.Relationship;
                    ev.ResidentStatus = FirstMember.ResidentStatus;
                    ev.SecondInsurance = FirstMember.SecondInsurance;
                    BI.InsertEvent(ev);

                    BD.DeleteFamilyMember(FirstMember);

                    SecondMember.MaritalStatus = 33;
                    BU.UpdatePerson(SecondMember);

                    FirstMember.MaritalStatus = 33;
                    FirstMember.Relationship = 0;
                    FirstMember.FamilyID = SecondFamily.ID;
                    try
                    {
                        FirstMember.Relationship = int.Parse(cmbParvandeAddNesbat.SelectedValue.ToString());
                    }
                    catch { }
                    List<M_FamilyMembers> LFmm = new List<M_FamilyMembers>();
                    LFmm.Add(FirstMember);
                    BI.InsertPerson(LFmm);
                    frmMessage msg = new frmMessage();
                    msg.label1.Text = "عملیات با موفقیت انجام شد";
                    msg.ShowDialog();
                    return true;
                }
                else
                {
                    frmMessage msg = new frmMessage();
                    msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                    msg.label1.Text = "خانواری را انتخاب کنید";
                    msg.ShowDialog();
                }
            }
            return false;
        }

        public frmEventTalagh()
        {
            InitializeComponent();
        }

        public int FmlID = 0;
        public int SecondFmlID = 0;
        public int FmlCode = 0;
        public List<M_FamilyMembers> AllMember;
        public M_FamilyMembers FirstMember;
        public M_FamilyMembers SecondMember;
        public M_Families SecondFamily = null;
        public bool IsSarparast = false;
        public M_FamilyMembers NewSarparast;

        private void frmEventTalagh_Load(object sender, EventArgs e)
        {
            B_PublicFunctions.AddToCombo(77, cmbParvandeAddMalekiat);
            B_PublicFunctions.AddToCombo(82, cmbParvandeAddFamilyType);
            B_GetDatas BG = new B_GetDatas();
            cmbParvandeAddCityOrVillage.DataSource = BG.GetUnitPlaces();
            cmbParvandeAddCityOrVillage.DisplayMember = "PlaceName";
            cmbParvandeAddCityOrVillage.ValueMember = "PlaceID";
        }

        private void buttonX14_Click(object sender, EventArgs e)
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

            frmPersonFamilyAdd frm = new frmPersonFamilyAdd(Fm.Single().ID);
            frm.Tag = "Edit";
            frm.FamilyCode = Fm.Single().ID;
            B_GetDatas bg = new B_GetDatas();
            M_Families fm2 = bg.GetFamily().Where(c => c.ID == frm.FamilyCode).Single<M_Families>();
            frm.ThisFamily = fm2;
            frm.Width = 0;
            frm.Height = 0;
            frm.Show();
            int Counter = 0;
            foreach(DataGridViewRow rw in frm.dgvParvandeAddPerson.Rows)
            {
                if(rw.DefaultCellStyle.BackColor==Color.LightPink)
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
            if(Counter>1)
            {
                frmMessage msg = new frmMessage();
                msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                msg.label1.Text = "این خانوار بیش از یک سرپرست دارد , لطفا به مورد رسیدگی و مجددا سعی نمایید";
                msg.ShowDialog();
                return;
            }
            FMem = BG.GetFamilyMember(Fm.Single().ID);
            FmlID = Fm.Single().ID;
            FmlCode = Fm.Single().FamilyCode;
            dgvActionTalagh.Rows.Clear();
            AllMember = FMem;
            foreach (M_FamilyMembers fm in FMem)
            {
                if (fm.MaritalStatus == 31)
                    dgvActionTalagh.Rows.Add(fm.FirstName, fm.LastName, fm.NationalCode, Math.Round(((DateTime.Today - fm.BirthDate).TotalDays / 365)) + " سال", fm.MobileNumber, fm.ID);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (buttonX3.Tag == "1")
            {
                if (dgvActionTalagh.SelectedRows.Count != 0)
                {
                    int id = int.Parse(dgvActionTalagh.SelectedRows[0].Cells["MemberID"].Value.ToString());
                    if (AllMember.Where(c => c.ID == id).Single().Relationship == 63)
                    {
                        frmMessage msg = new frmMessage();
                        msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                        msg.label1.Text = "شخص مورد نظر شما سرپرست میباشد , لطفا این شخص را از حالت سرپرست خارج و شخص دیگری را به عنوان سرپرست این خانوار معین نمایید و سپس مجددا سعی کنید";
                        msg.ShowDialog();
                        return;
                    }
                    FirstMember = AllMember.Where(c => c.ID == id).Single();
                    txtActionFirstFamilySearch.Enabled = false;
                    buttonX14.Enabled = false;
                    dgvActionTalagh.SelectedRows[0].Visible = false;
                    label1.Text = "مرحله 2 : لطفا زوج سابق را انتخاب کنید";
                    lblStatus.Text = FirstMember.FirstName + " " + FirstMember.LastName;
                    animator1.Hide(pnlStep1);
                    animator1.WaitAllAnimations();
                    animator1.Show(pnlStep1);
                    buttonX3.Tag = "2";
                }
            }
            else if (buttonX3.Tag == "2")
            {
                if (dgvActionTalagh.SelectedRows.Count != 0)
                {
                    int id = int.Parse(dgvActionTalagh.SelectedRows[0].Cells["MemberID"].Value.ToString());
                    SecondMember = AllMember.Where(c => c.ID == id).Single();
                    dgvActionTalagh.SelectedRows[0].Visible = false;
                    lblStatus.Text += " > " + SecondMember.FirstName + " " + SecondMember.LastName;
                    animator1.Hide(pnlStep1);
                    animator1.WaitAllAnimations();
                    animator1.Show(pnlStep2);
                    buttonX3.Tag = "3";
                    buttonX3.Enabled = false;
                }
            }
        }

        private void rdoSearchFamily_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSearchFamily.Checked == true)
            {
                pnlStep2_1.Enabled = true;
                pnlStep2_2.Enabled = false;
            }
            else
            {
                pnlStep2_1.Enabled = false;
                pnlStep2_2.Enabled = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtActionFamilySecondSearch.Text != FmlCode.ToString() && txtActionFamilySecondSearch.Text != "")
            {
                B_GetDatas BG = new B_GetDatas();
                List<M_Families> Fm = BG.GetFamily(int.Parse(txtActionFamilySecondSearch.Text));
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

                frmPersonFamilyAdd frm = new frmPersonFamilyAdd(Fm.Single().ID);
                frm.Tag = "Edit";
                frm.FamilyCode = Fm.Single().ID;
                B_GetDatas bg = new B_GetDatas();
                M_Families fm2 = bg.GetFamily().Where(c => c.ID == frm.FamilyCode).Single<M_Families>();
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
                    {
                        Counter++;
                        lblLastFamilyHeaderName.Text = rw.Cells["Name"].Value.ToString() + " " + rw.Cells["Family"].Value.ToString();
                    }
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
                SecondFamily = fm2;
                lblLastFamilyFamilyType.Text = B_ReportPublicCategori.GetPublitCategoriByID(fm2.FamilyTypeCode).PC_Title;
                lblLastFamilyOwner.Text = B_ReportPublicCategori.GetPublitCategoriByID(fm2.OwnrshipCode).PC_Title;
                lblLastFamilyTell.Text = fm2.HeaderMobileNumber;
                SecondFmlID = fm2.ID;
                if (fm2.FamilyTypeCode != 84)
                {
                    cmbParvandeAddNesbat.Enabled = true;
                    B_PublicFunctions.AddToCombo(62, cmbParvandeAddNesbat, new int[] { 63, 64, 66 });
                }
                else
                {
                    cmbParvandeAddNesbat.Enabled = false;
                    cmbParvandeAddNesbat.SelectedIndex = -1;
                }
            }
            else
            {
                frmMessage msg = new frmMessage();
                msg.pictureBox1.Image = global::Shahab.Offline.WinUI.Properties.Resources.caution;
                msg.label1.Text = "این خانوار قابل قبول نیست";
                msg.ShowDialog();
                return;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            M_Families fmA = new M_Families();
            List<M_FamilyMembers> fmmA = new List<M_FamilyMembers>();
            fmmA.Add(FirstMember);
            M_Address addA = new M_Address();
            frmPersonFamilyAdd frm = new frmPersonFamilyAdd(fmA, fmmA, addA);
            frm.WindowState = FormWindowState.Maximized;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (frm.IsFirstEditOK == true)
            {
                MessageBox.Show("OK");
            }
        }

        private void schParvandeAddPstalCode_ValueChanged(object sender, EventArgs e)
        {
            txtParvandeAddPostalCode.Enabled = schParvandeAddPstalCode.Value;
            if (schParvandeAddPstalCode.Value == false)
            {
                err.SetError(txtParvandeAddPostalCode, "");
            }
        }
    }
}
