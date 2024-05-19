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
using System.Text.RegularExpressions;
using Shahab.Offline.Logging;

namespace Shahab.Offline.WinUI
{
    public partial class frmPersonFamilyAdd : Form
    {
        /// <summary>
        /// تعریف متغییرها
        /// </summary>
        int AddressCount = 32;

        /// <summary>
        /// کد خانوار برای ویرایش
        /// </summary>
        public int FamilyCode = 0;

        public M_Families ThisFamily = null;
        public M_Address ThisAddress = null;
        public List<M_FamilyMembers> ThisFamilyMember;
        public bool IsFirstEditOK = false;
        bool CmbEnable = true;

        /// <summary>
        /// بررسی این که آیا خانوار تنها یک سرپرست دارد یا خیر و یونیک بودم کد ملی
        /// </summary>
        /// <param name="dgv">نام دیتا گرید ویو</param>
        /// <param name="code">کد ملی</param>
        /// <param name="nesbat">نسبت با سرپرست</param>
        /// <param name="PID">ای.دی شخص</param>
        /// <returns></returns>
        public bool IsUniqNationalCodeAndSarparast(DataGridViewX dgv, string code, string nesbat, int rowID, int PID, bool IsCheckNaionalCode)
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Cells[2].Value.ToString() == code && rowID != item.Index && code != string.Empty && IsCheckNaionalCode == true)
                {
                    err.SetError(txtParvandeAddNationalCode, "این کد ملی در این خانوار ثبت شده");
                    return false;
                }
                if (item.Cells[5].Value.ToString() == nesbat && nesbat == "سرپرست" && rowID != item.Index)
                {
                    err.SetError(cmbParvandeAddNesbat, "هر خانوار فقط یک سرپرست میتواند داشته باشد");
                    return false;
                }
            }
            if (code.Trim().Length != 10 && dgv.Rows[rowID].Cells["NationalityID"].Value.ToString() != "9" && IsCheckNaionalCode == true)
            {
                err.SetError(txtParvandeAddNationalCode, "کد ملی صحیح نیست");
                return false;
            }
            if (rowID != -1)
            {
                if (dgv.Rows[rowID].Cells["NationalityID"].Value.ToString() != "9")
                    if ((nesbat != "سرپرست" && B_PublicFunctions.ISUnicNationalCode(code, 1, PID) == true) && code != string.Empty && IsCheckNaionalCode == true)
                    {
                        err.SetError(txtParvandeAddNationalCode, "این کد ملی در خانوار دیگر ثبت شده");
                        return false;
                    }
                if (dgv.Rows[rowID].Cells["NationalityID"].Value.ToString() != "9")
                    if ((nesbat == "سرپرست" && B_PublicFunctions.ISUnicNationalCode(code, 2, PID) == true) && code != string.Empty && IsCheckNaionalCode == true)
                    {
                        err.SetError(txtParvandeAddNationalCode, "این کد ملی در خانوار دیگر ثبت شده");
                        return false;
                    }
            }
            return true;
        }

        /// <summary>
        /// هماهنگ شدن دکمه ثبت نهایی با اطلاعات خانوار
        /// </summary>
        /// <returns></returns>
        public bool FinalSubmitValidate()
        {
            err.Clear();
            if (B_PublicFunctions.CheckTextBox(panelEx1, err) == true)
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
                            if (cmbParvandeAddFamilyType.SelectedValue.ToString() == "84")
                            {
                                bool st = false;
                                foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                                {
                                    if (String.IsNullOrEmpty(dgvParvandeAddPerson.Rows[rw.Index].Cells[5].Value.ToString()) == false)
                                    {
                                        st = true;
                                    }
                                }
                                if (st == true)
                                {
                                    frmDeleteConfirm frm = new frmDeleteConfirm();
                                    frm.label1.Text = "شما در خانوار عضوهایی دارید که نسبت با سرپرست دارند در صورتی که خانوار موسسه ای سرپرست ندارد , برای ادامه کار لازم است نسبت آنها از بین برورد" + Environment.NewLine + "این کار را انجام دهیم ؟";
                                    frm.ShowDialog();
                                    if (frm.Status == true)
                                    {
                                        foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                                        {
                                            dgvParvandeAddPerson.Rows[rw.Index].Cells[5].Value = "";
                                            dgvParvandeAddPerson.Rows[rw.Index].Cells[16].Value = "0";
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            if (B_PublicFunctions.ISUnicFamilyCode(int.Parse(txtParvandeAddFamilyNumber.Text), FamilyCode) == true && txtParvandeAddFamilyNumber.Enabled == true)
                            {
                                err.SetError(txtParvandeAddFamilyNumber, "این کد در خانوار دیگر ثبت شده");
                                return false;
                            }
                            err.SetError(txtParvandeAddAdress, "");
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
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// ایجاد ستوها دیتاگرید ویوها
        /// </summary>
        public void IntializAddPersionDGV()
        {
            if (dgvParvandeAddPerson.Columns.Count == 0)
            {
                dgvParvandeAddPerson.Columns.Add("Name", "نام");//0
                dgvParvandeAddPerson.Columns.Add("Family", "نام خانوادگی");//1
                dgvParvandeAddPerson.Columns.Add("NationalCode", "کد ملی");//2
                dgvParvandeAddPerson.Columns.Add("Nationality", "ملیت");//3
                dgvParvandeAddPerson.Columns[3].Visible = false;
                dgvParvandeAddPerson.Columns.Add("Genser", "جنسیت");//4
                dgvParvandeAddPerson.Columns[4].Visible = false;
                dgvParvandeAddPerson.Columns.Add("Nesbat", "نسبت با سرپرست");//5
                dgvParvandeAddPerson.Columns.Add("BirthDay", "تاریخ تولد");//6
                dgvParvandeAddPerson.Columns.Add("VaziateEghamat", "اقامت");//7
                dgvParvandeAddPerson.Columns[7].Visible = false;
                dgvParvandeAddPerson.Columns.Add("Tahol", "وضعیت تاهل");//8
                dgvParvandeAddPerson.Columns[8].Visible = false;
                dgvParvandeAddPerson.Columns.Add("SathSavad", "سطح سواد");//9
                dgvParvandeAddPerson.Columns[9].Visible = false;
                dgvParvandeAddPerson.Columns.Add("Job", "شغل");//10
                dgvParvandeAddPerson.Columns[10].Visible = false;
                dgvParvandeAddPerson.Columns.Add("Activity", "فعالیت");//11
                dgvParvandeAddPerson.Columns[11].Visible = false;
                dgvParvandeAddPerson.Columns.Add("Bime1", "بیمه اول");//12
                dgvParvandeAddPerson.Columns[12].Visible = false;
                dgvParvandeAddPerson.Columns.Add("Bime2", "بیمه دوم");//13
                dgvParvandeAddPerson.Columns[13].Visible = false;
                dgvParvandeAddPerson.Columns.Add("NationalityID", "");//14
                dgvParvandeAddPerson.Columns.Add("GenderID", "");//15
                dgvParvandeAddPerson.Columns.Add("NesbatID", "");//16
                dgvParvandeAddPerson.Columns.Add("VaziateEghamatID", "");//17
                dgvParvandeAddPerson.Columns.Add("TaholID", "");//18
                dgvParvandeAddPerson.Columns.Add("SathSavadID", "");//19
                dgvParvandeAddPerson.Columns.Add("JobID", "");//20
                dgvParvandeAddPerson.Columns.Add("ActivityID", "");//21
                dgvParvandeAddPerson.Columns.Add("Bime1ID", "");//22
                dgvParvandeAddPerson.Columns.Add("Bime2ID", "");//23
                dgvParvandeAddPerson.Columns.Add("Tell", "");//24
                dgvParvandeAddPerson.Columns.Add("FamilyMemberID", "");//25
                dgvParvandeAddPerson.Columns[14].Visible = false;
                dgvParvandeAddPerson.Columns[15].Visible = false;
                dgvParvandeAddPerson.Columns[16].Visible = false;
                dgvParvandeAddPerson.Columns[17].Visible = false;
                dgvParvandeAddPerson.Columns[18].Visible = false;
                dgvParvandeAddPerson.Columns[19].Visible = false;
                dgvParvandeAddPerson.Columns[20].Visible = false;
                dgvParvandeAddPerson.Columns[21].Visible = false;
                dgvParvandeAddPerson.Columns[22].Visible = false;
                dgvParvandeAddPerson.Columns[23].Visible = false;
                dgvParvandeAddPerson.Columns[24].Visible = false;
                dgvParvandeAddPerson.Columns[25].Visible = false;
            }
        }

        /// <summary>
        /// اعتبار سنجی هنگام ثبت اطلاعات
        /// </summary>
        /// <returns></returns>
        public bool SubmitValidate()
        {
            if (!(cmbParvandeAddBime2.SelectedIndex != cmbParvandeAddBime1.SelectedIndex))
            {
                err.SetError(cmbParvandeAddBime2, "مقادیر دو بیمه نمیتواند برابر باشد");
                return false;
            }
            if (cmbParvandeAddJob.SelectedValue.ToString() == "27" && cmbParvandeAddActivity.SelectedValue.ToString() == "74")
            {
                err.SetError(cmbParvandeAddActivity, "فرد بیکار نمیتواند شاغل باشد");
                return false;
            }
            if (!(txtParvandeAddBirthDay.Text.IsValidBirthDay() == true))
            {
                err.SetError(txtParvandeAddBirthDay, "این تاریخ اشتباه است");
                return false;
            }
            var regex = new Regex("^[ا-یء-ی ]+$");
            if (!regex.IsMatch(txtParvandeAddName.Text))
            {
                err.SetError(txtParvandeAddName, "لطفا فقط از حروف فارسی استفاده کنید");
                return false;
            }
            if (!regex.IsMatch(txtParvandeAddFamily.Text))
            {
                err.SetError(txtParvandeAddFamily, "لطفا فقط از حروف فارسی استفاده کنید");
                return false;
            }
            if (txtParvandeAddBirthDay.Text.Length == 10)
            {
                string[] s = txtParvandeAddBirthDay.Text.Split('/');
                if (((int.Parse(s[1]) <= 6 && int.Parse(s[1]) >= 1) && (int.Parse(s[2]) <= 31 && int.Parse(s[1]) >= 1)) || ((int.Parse(s[1]) <= 12 && int.Parse(s[1]) >= 7) && (int.Parse(s[2]) <= 30 && int.Parse(s[1]) >= 1)))
                {
                    err.SetError(txtParvandeAddBirthDay, "");
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    DateTime dt1 = pc.ToDateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), 0, 0, 0, 0);
                    DateTime dt2 = DateTime.Today;
                    if (((dt2 - dt1).TotalDays / 365) > 6)
                    {
                        if (cmbParvandeAddEducation.SelectedValue.ToString() == "61")
                        {
                            err.SetError(cmbParvandeAddEducation, "برای افراد بالای 6 سال این مقدار صحیح نیست");
                            return false;
                        }
                        if (cmbParvandeAddJob.SelectedValue.ToString() == "123")
                        {
                            err.SetError(cmbParvandeAddJob, "برای افراد بالای 6 سال این مقدار صحیح نیست");
                            return false;
                        }
                        if (cmbParvandeAddActivity.SelectedValue.ToString() == "124")
                        {
                            err.SetError(cmbParvandeAddActivity, "برای افراد بالای 6 سال این مقدار صحیح نیست");
                            return false;
                        }
                        if (cmbParvandeAddTahol.SelectedValue.ToString() == "34")
                        {
                            err.SetError(cmbParvandeAddTahol, "برای افراد بالای 6 سال این مقدار صحیح نیست");
                            return false;
                        }
                    }
                }
            }

            int relation = int.Parse(cmbParvandeAddNesbat.SelectedValue.ToString());
            if (relation == 64 || relation == 66)
                if (int.Parse(cmbParvandeAddTahol.SelectedValue.ToString()) == 30 || int.Parse(cmbParvandeAddTahol.SelectedValue.ToString()) == 32 || int.Parse(cmbParvandeAddTahol.SelectedValue.ToString()) == 33)
                {
                    err.SetError(cmbParvandeAddTahol, "این مقدار با نسبت همخوانی ندارد");
                    return false;
                }


            foreach (DataGridViewRow item in dgvParvandeAddPerson.Rows)
            {
                if (item.Cells["NesbatID"].Value.ToString() == "63")
                {
                    int TaholID = int.Parse(item.Cells["TaholID"].Value.ToString());
                    int RelationID = int.Parse(cmbParvandeAddNesbat.SelectedValue.ToString());
                    if (B_PublicFunctions.CheckMaritalSarparast(TaholID, RelationID) == false)
                    {
                        err.SetError(cmbParvandeAddNesbat, "با توجه به وصعیت تاهل سرپرست این مقدار صحیح نیست");
                        return false;
                    }
                }
            }

            if (cmbParvandeAddNesbat.SelectedValue.ToString() == "63")
            {
                foreach (DataGridViewRow item in dgvParvandeAddPerson.Rows)
                {
                    int TaholID = int.Parse(cmbParvandeAddTahol.SelectedValue.ToString());
                    int RelationID = int.Parse(item.Cells["NesbatID"].Value.ToString());
                    if (B_PublicFunctions.CheckMaritalSarparast(TaholID, RelationID) == false)
                    {
                        err.SetError(cmbParvandeAddTahol, "با توجه به نسبت اعضا با سرپرست این مقدار صحیح نیست");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// چک کردن مقادیر تکست باکس ها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkTextboxValue(object sender, EventArgs e)
        {
            //B_PublicValidate.CheckTextBoxValue(sender, e, err);
        }
        /// <summary>
        /// چک کردن مقادیر کمبوباکس ها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkComboValue(object sender, EventArgs e)
        {
            //B_PublicValidate.CheckComboValue(sender, e, err);
        }

        private void btnDellClick(object sender, EventArgs e)
        {
            ButtonX btn = sender as ButtonX;
            string s = btn.Name.Replace("btnAddDel", "");
            TextBoxX txt = new TextBoxX();
            foreach (Control ctn in panelEx1.Controls)
            {
                if (ctn is TextBoxX && ctn.Name == "txtAddDel" + s)
                    txt = ctn as TextBoxX;
            }
            txt.Dispose();
            btn.Dispose();
            AddressCount = int.Parse(s);
        }

        public frmPersonFamilyAdd()
        {
            InitializeComponent();
            B_PublicFunctions.AddToCombo(7, cmbParvandeAddNasionality);
            B_PublicFunctions.AddToCombo(77, cmbParvandeAddMalekiat);
            B_PublicFunctions.AddToCombo(82, cmbParvandeAddFamilyType);
            B_PublicFunctions.AddToCombo(10, cmbParvandeAddGender);
            B_PublicFunctions.AddToCombo(29, cmbParvandeAddTahol);
            B_PublicFunctions.AddToCombo(35, cmbParvandeAddBime1);
            B_PublicFunctions.AddToCombo(43, cmbParvandeAddBime2);
            B_PublicFunctions.AddToCombo(62, cmbParvandeAddNesbat);
            B_PublicFunctions.AddToCombo(51, cmbParvandeAddEducation);
            B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity);
            B_PublicFunctions.AddToCombo(13, cmbParvandeAddJob);
            B_PublicFunctions.AddToCombo(109, cmbParvandeAddEghamat);
            B_GetDatas BG = new B_GetDatas();
            cmbParvandeAddCityOrVillage.DataSource = BG.GetUnitPlaces();
            cmbParvandeAddCityOrVillage.DisplayMember = "PlaceName";
            cmbParvandeAddCityOrVillage.ValueMember = "PlaceID";
        }

        public frmPersonFamilyAdd(int FamilyID)
        {
            InitializeComponent();
            B_PublicFunctions.AddToCombo(7, cmbParvandeAddNasionality);
            B_PublicFunctions.AddToCombo(77, cmbParvandeAddMalekiat);
            B_PublicFunctions.AddToCombo(82, cmbParvandeAddFamilyType);
            B_PublicFunctions.AddToCombo(10, cmbParvandeAddGender);
            B_PublicFunctions.AddToCombo(29, cmbParvandeAddTahol);
            B_PublicFunctions.AddToCombo(35, cmbParvandeAddBime1);
            B_PublicFunctions.AddToCombo(43, cmbParvandeAddBime2);
            B_PublicFunctions.AddToCombo(62, cmbParvandeAddNesbat);
            B_PublicFunctions.AddToCombo(51, cmbParvandeAddEducation);
            B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity);
            B_PublicFunctions.AddToCombo(13, cmbParvandeAddJob);
            B_PublicFunctions.AddToCombo(109, cmbParvandeAddEghamat);
            B_GetDatas BG = new B_GetDatas();
            cmbParvandeAddCityOrVillage.DataSource = BG.GetUnitPlaces();
            cmbParvandeAddCityOrVillage.DisplayMember = "PlaceName";
            cmbParvandeAddCityOrVillage.ValueMember = "PlaceID";
            FamilyCode = FamilyID;
            B_GetDatas bg = new B_GetDatas();
            M_Families fml = bg.GetFamily().Where(c => c.ID == FamilyCode).Single();
            try
            {
                cmbParvandeAddCityOrVillage.SelectedIndex = cmbParvandeAddCityOrVillage.FindString(BG.GetUnitPlaces().Where(c => c.PlaceID == fml.PlaceID).Single().PlaceName);
            }
            catch { }
            this.Tag = "Edit";
            FamilyCode = FamilyID;
            fml = bg.GetFamily().Where(c => c.ID == FamilyCode).Single();
            cmbParvandeAddFamilyType.SelectedValue = fml.FamilyTypeCode;
            cmbParvandeAddMalekiat.SelectedValue = fml.OwnrshipCode;
            txtParvandeAddTell1.Text = fml.HeaderMobileNumber;
            txtParvandeAddFamilyNumber.Text = fml.FamilyCode.ToString();
            M_Address address = bg.GetAdressByFamilyID(fml.ID);
            txtParvandeAddShomareSakhteman.Text = address.BuildingNumber.ToString();
            txtParvandeAddTell2.Text = address.TelephoneNumber;
            //Regex rg = new Regex(@"\d{10}");
            //if (rg.IsMatch(address.ZipCode) == false)
            if (address.ZipCode != string.Empty)
            {
                schParvandeAddPstalCode.Enabled = true;
                txtParvandeAddPostalCode.Text = address.ZipCode;
            }
            else
            {
                schParvandeAddPstalCode.Enabled = false;
            }
            txtParvandeAddAdress.Text = address.AddressString1;
            if (address.AddressString2 != null && address.AddressString2 != "")
            {
                btnAddDel1_Click(null, null);
                this.Controls.Find("txtAddDel32", true).Single().Text = address.AddressString2;
            }
            if (address.AddressString3 != null && address.AddressString3 != "")
            {
                btnAddDel1_Click(null, null);
                this.Controls.Find("txtAddDel64", true).Single().Text = address.AddressString3;
            }
            IntializAddPersionDGV();
            List<M_FamilyMembers> fmm = bg.GetFamilyMember().Where(c => c.FamilyID == fml.ID).ToList<M_FamilyMembers>();
            foreach (M_FamilyMembers fmm2 in fmm)
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                string Date = pc.GetYear(fmm2.BirthDate).ToString() + "/" + pc.GetMonth(fmm2.BirthDate).ToString() + "/" + pc.GetDayOfMonth(fmm2.BirthDate).ToString();
                string[] s = { 
                                         fmm2.FirstName
                                         ,fmm2.LastName
                                         ,fmm2.NationalCode
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Nationality).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Gender).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Relationship).PC_Title
                                         ,Date
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.ResidentStatus).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.MaritalStatus).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Education).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Job).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Activity).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.FirstInsurance).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.SecondInsurance).PC_Title
                                         ///////////////////////////////////////////////
                                         ,fmm2.Nationality.ToString()
                                         ,fmm2.Gender.ToString()
                                         ,fmm2.Relationship.ToString()
                                         ,fmm2.ResidentStatus.ToString()
                                         ,fmm2.MaritalStatus.ToString()
                                         ,fmm2.Education.ToString()
                                         ,fmm2.Job.ToString()
                                         ,fmm2.Activity.ToString()
                                         ,fmm2.FirstInsurance.ToString()
                                         ,fmm2.SecondInsurance.ToString()
                                         ,fmm2.MobileNumber
                                         ,fmm2.ID.ToString()
                                     };
                dgvParvandeAddPerson.Rows.Add(s);
                string ErrorMessage = "";
                if (B_PublicFunctions.IsLoadValidPerson(fmm2, fml, ref ErrorMessage) == false)
                {
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].ErrorText = ErrorMessage;
                }
                if (IsUniqNationalCodeAndSarparast(dgvParvandeAddPerson, fmm2.NationalCode, B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Relationship).PC_Title, dgvParvandeAddPerson.Rows.Count - 1, int.Parse(dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].Cells["FamilyMemberID"].Value.ToString()), true) == false)
                {
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].ErrorText = Environment.NewLine + "ممکن است کد ملی و نسبت صحیح نباشد";
                }
                err.Clear();
            }
            dgvParvandeAddPerson.Refresh();
            btnParvandeAddDelFamily.Enabled = true;
        }

        public frmPersonFamilyAdd(M_Families fml, List<M_FamilyMembers> fmm, M_Address address, bool Status = false, int Enable = 0, bool EnableCombo = true)
        {
            InitializeComponent();

            if (Enable == 1)
            {
                buttonX3.Enabled = false;
                panelEx1.Enabled = false;
                pnlParvandePerson.Enabled = true;
            }
            B_PublicFunctions.AddToCombo(7, cmbParvandeAddNasionality);
            B_PublicFunctions.AddToCombo(77, cmbParvandeAddMalekiat);
            B_PublicFunctions.AddToCombo(82, cmbParvandeAddFamilyType);
            B_PublicFunctions.AddToCombo(10, cmbParvandeAddGender);
            B_PublicFunctions.AddToCombo(29, cmbParvandeAddTahol);
            B_PublicFunctions.AddToCombo(35, cmbParvandeAddBime1);
            B_PublicFunctions.AddToCombo(43, cmbParvandeAddBime2);
            B_PublicFunctions.AddToCombo(62, cmbParvandeAddNesbat);
            B_PublicFunctions.AddToCombo(51, cmbParvandeAddEducation);
            B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity);
            B_PublicFunctions.AddToCombo(13, cmbParvandeAddJob);
            B_PublicFunctions.AddToCombo(109, cmbParvandeAddEghamat);
            B_GetDatas BG = new B_GetDatas();
            cmbParvandeAddCityOrVillage.DataSource = BG.GetUnitPlaces();
            cmbParvandeAddCityOrVillage.DisplayMember = "PlaceName";
            cmbParvandeAddCityOrVillage.ValueMember = "PlaceID";
            try
            {
                cmbParvandeAddCityOrVillage.SelectedIndex = cmbParvandeAddCityOrVillage.FindString(BG.GetUnitPlaces().Where(c => c.PlaceID == fml.PlaceID).Single().PlaceName);
            }
            catch { }
            cmbParvandeAddFamilyType.SelectedValue = fml.FamilyTypeCode;
            cmbParvandeAddMalekiat.SelectedValue = fml.OwnrshipCode;
            txtParvandeAddTell1.Text = fml.HeaderMobileNumber;
            txtParvandeAddFamilyNumber.Text = fml.FamilyCode.ToString();
            txtParvandeAddShomareSakhteman.Text = address.BuildingNumber.ToString();
            txtParvandeAddTell2.Text = address.TelephoneNumber;
            //Regex rg = new Regex(@"\d{10}");
            //if (rg.IsMatch(address.ZipCode) == false)
            if (address.ZipCode != string.Empty)
            {
                schParvandeAddPstalCode.Value = true;
                txtParvandeAddPostalCode.Text = address.ZipCode;
            }
            else
            {
                schParvandeAddPstalCode.Value = false;
                txtParvandeAddPostalCode.Enabled = false;
            }
            txtParvandeAddAdress.Text = address.AddressString1;
            if (address.AddressString2 != null && address.AddressString2 != "")
            {
                btnAddDel1_Click(null, null);
                this.Controls.Find("txtAddDel32", true).Single().Text = address.AddressString2;
            }
            if (address.AddressString3 != null && address.AddressString3 != "")
            {
                btnAddDel1_Click(null, null);
                this.Controls.Find("txtAddDel64", true).Single().Text = address.AddressString3;
            }
            IntializAddPersionDGV();
            foreach (M_FamilyMembers fmm2 in fmm)
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                string Date = pc.GetYear(fmm2.BirthDate).ToString() + "/" + pc.GetMonth(fmm2.BirthDate).ToString() + "/" + pc.GetDayOfMonth(fmm2.BirthDate).ToString();
                string[] s = { 
                                         fmm2.FirstName
                                         ,fmm2.LastName
                                         ,fmm2.NationalCode
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Nationality).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Gender).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Relationship).PC_Title
                                         ,Date
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.ResidentStatus).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.MaritalStatus).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Education).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Job).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Activity).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.FirstInsurance).PC_Title
                                         ,B_ReportPublicCategori.GetPublitCategoriByID(fmm2.SecondInsurance).PC_Title
                                         ///////////////////////////////////////////////
                                         ,fmm2.Nationality.ToString()
                                         ,fmm2.Gender.ToString()
                                         ,fmm2.Relationship.ToString()
                                         ,fmm2.ResidentStatus.ToString()
                                         ,fmm2.MaritalStatus.ToString()
                                         ,fmm2.Education.ToString()
                                         ,fmm2.Job.ToString()
                                         ,fmm2.Activity.ToString()
                                         ,fmm2.FirstInsurance.ToString()
                                         ,fmm2.SecondInsurance.ToString()
                                         ,fmm2.MobileNumber
                                         ,fmm.IndexOf(fmm2).ToString()
                                     };
                dgvParvandeAddPerson.Rows.Add(s);
                string ErrorMessage = "";
                if (B_PublicFunctions.IsLoadValidPerson(fmm2, fml, ref ErrorMessage) == false)
                {
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].ErrorText = ErrorMessage;
                }
                if (IsUniqNationalCodeAndSarparast(dgvParvandeAddPerson, fmm2.NationalCode, B_ReportPublicCategori.GetPublitCategoriByID(fmm2.Relationship).PC_Title, dgvParvandeAddPerson.Rows.Count - 1, int.Parse(dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].Cells["FamilyMemberID"].Value.ToString()), true) == false && Status == false)
                {
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                    dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.Rows.Count - 1].ErrorText = Environment.NewLine + "ممکن است کد ملی و نسبت صحیح نباشد";
                }
                err.Clear();
            }
            dgvParvandeAddPerson.Refresh();
            this.Tag = "EditFirst";
            ThisFamily = fml;
            ThisFamilyMember = fmm;
            ThisAddress = address;
            btnParvandeAddDelFamily.Image = buttonX3.Image;
            btnParvandeAddDelFamily.Text = "انجام تغییرات";
            btnParvandeAddDelFamily.Enabled = true;
            buttonX10.Enabled = false;
            buttonX12.Enabled = false;
            cmbParvandeAddNesbat.Enabled = EnableCombo;
            cmbParvandeAddTahol.Enabled = EnableCombo;
            cmbParvandeAddGender.Enabled = EnableCombo;
            CmbEnable = EnableCombo;
        }

        private void frmPersonFamilyAdd_Load(object sender, EventArgs e)
        {
        }

        private void txtParvandeAddShomareSakhteman_KeyPress(object sender, KeyPressEventArgs e)
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

        private void schParvandeAddPstalCode_ValueChanged(object sender, EventArgs e)
        {
            txtParvandeAddPostalCode.Enabled = schParvandeAddPstalCode.Value;
            if (schParvandeAddPstalCode.Value == false)
            {
                err.SetError(txtParvandeAddPostalCode, "");
            }
        }

        private void txtParvandeAddTell2_Leave(object sender, EventArgs e)
        {
            //if (txtParvandeAddTell2.Text.Length == 12)
            //{
            //    err.SetError(txtParvandeAddTell2, "");
            //}
            //else
            //{
            //    err.SetError(txtParvandeAddTell2, "این مقدار صحیح نیست");
            //}
        }

        private void txtParvandeAddTell1_Leave(object sender, EventArgs e)
        {
            //if (txtParvandeAddTell1.Text.Length == 12)
            //{
            //    err.SetError(txtParvandeAddTell1, "");
            //}
            //else
            //{
            //    err.SetError(txtParvandeAddTell1, "این مقدار صحیح نیست");
            //}
        }

        private void txtParvandeAddBirthDay_Leave(object sender, EventArgs e)
        {
            if (txtParvandeAddBirthDay.Text.Length == 10)
            {
                string[] s = txtParvandeAddBirthDay.Text.Split('/');
                if (((int.Parse(s[1]) <= 6 && int.Parse(s[1]) >= 1) && (int.Parse(s[2]) <= 31 && int.Parse(s[1]) >= 1)) || ((int.Parse(s[1]) <= 12 && int.Parse(s[1]) >= 7) && (int.Parse(s[2]) <= 30 && int.Parse(s[1]) >= 1)))
                {
                    err.SetError(txtParvandeAddBirthDay, "");
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    string[] SS = txtParvandeAddBirthDay.Text.Split('/');
                    DateTime dt1 = pc.ToDateTime(int.Parse(SS[0]), int.Parse(SS[1]), int.Parse(SS[2]), 0, 0, 0, 0);
                    DateTime dt2 = DateTime.Today;
                    lblParvandeAddDate.Text = Math.Round(((dt2 - dt1).TotalDays / 365)).ToString() + " سال";
                    if (Math.Round(((dt2 - dt1).TotalDays / 365)) == 0)
                    {
                        lblParvandeAddDate.Text = "زیر یک سال";
                    }
                    if (((dt2 - dt1).TotalDays / 365) < 0)
                    {
                        err.SetError(txtParvandeAddBirthDay, "هنوز متولد نشده");
                    }
                    if (((dt2 - dt1).TotalDays / 365) > 130)
                    {
                        err.SetError(txtParvandeAddBirthDay, "سن بالای 130 سال صحیح نیست");
                    }
                    if (((dt2 - dt1).TotalDays / 365) <= 6)
                    {
                        B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity);

                        cmbParvandeAddEducation.Enabled = false;
                        cmbParvandeAddEducation.SelectedIndex = cmbParvandeAddEducation.Items.Count - 1;
                        err.SetError(cmbParvandeAddEducation, "");

                        cmbParvandeAddJob.Enabled = false;
                        cmbParvandeAddJob.SelectedIndex = cmbParvandeAddJob.Items.Count - 1;
                        err.SetError(cmbParvandeAddJob, "");

                        cmbParvandeAddActivity.Enabled = false;
                        cmbParvandeAddActivity.SelectedIndex = cmbParvandeAddActivity.Items.Count - 1;
                        err.SetError(cmbParvandeAddActivity, "");

                        cmbParvandeAddTahol.Enabled = false;
                        cmbParvandeAddTahol.SelectedIndex = cmbParvandeAddTahol.Items.Count - 1;
                        err.SetError(cmbParvandeAddTahol, "");
                    }
                    else
                    {
                        cmbParvandeAddTahol.Enabled = CmbEnable;
                        cmbParvandeAddEducation.Enabled = true;
                        cmbParvandeAddJob.Enabled = true;
                        cmbParvandeAddActivity.Enabled = true;
                    }
                }
                else
                {
                    err.SetError(txtParvandeAddBirthDay, "این مقدار صحیح نیست");
                }
            }
            else
            {
                err.SetError(txtParvandeAddBirthDay, "این مقدار صحیح نیست");
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            err.Clear();
            if (B_PublicFunctions.CheckTextBox(panelEx1, err) == true)
            {
                if (txtParvandeAddTell1.Text.Length == 12)
                {
                    if (txtParvandeAddTell2.Text.Length == 12)
                    {
                        if (txtParvandeAddTell2.Text.Substring(0, 2) == "09")
                        {
                            err.SetError(txtParvandeAddTell2, "این مقدار صحیح نیست");
                            return;
                        }
                        if (string.IsNullOrEmpty(txtParvandeAddAdress.Text) == false)
                        {
                            if (cmbParvandeAddFamilyType.SelectedValue.ToString() == "84")
                            {
                                bool st = false;
                                foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                                {
                                    if (String.IsNullOrEmpty(dgvParvandeAddPerson.Rows[rw.Index].Cells[5].Value.ToString()) == false)
                                    {
                                        st = true;
                                    }
                                }
                                if (st == true)
                                {
                                    frmDeleteConfirm frm = new frmDeleteConfirm();
                                    frm.label1.Text = "شما در خانوار عضوهایی دارید که نسبت با سرپرست دارند در صورتی که خانوار موسسه ای سرپرست ندارد , برای ادامه کار لازم است نسبت آنها از بین برورد" + Environment.NewLine + "این کار را انجام دهیم ؟";
                                    frm.ShowDialog();
                                    if (frm.Status == true)
                                    {
                                        foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                                        {
                                            dgvParvandeAddPerson.Rows[rw.Index].ErrorText = dgvParvandeAddPerson.Rows[rw.Index].ErrorText.Replace("این عضو در خانوار موسسه ای نسبت با سرپرست دارد", "");
                                            if (dgvParvandeAddPerson.Rows[rw.Index].ErrorText.Trim().Replace(Environment.NewLine, "").Length == 0)
                                            {
                                                dgvParvandeAddPerson.Rows[rw.Index].DefaultCellStyle.BackColor = SystemColors.Window;
                                                dgvParvandeAddPerson.Rows[rw.Index].ErrorText = "";
                                            }
                                            dgvParvandeAddPerson.Rows[rw.Index].Cells[5].Value = "";
                                            dgvParvandeAddPerson.Rows[rw.Index].Cells[16].Value = "0";
                                        }
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                            }
                            if (this.Tag != "EditFirst")
                                if (B_PublicFunctions.ISUnicFamilyCode(int.Parse(txtParvandeAddFamilyNumber.Text), FamilyCode) == true && txtParvandeAddFamilyNumber.Enabled == true)
                                {
                                    err.SetError(txtParvandeAddFamilyNumber, "این کد در خانوار دیگر ثبت شده");
                                    return;
                                }
                            err.SetError(txtParvandeAddAdress, "");
                            pnlParvandePerson.Enabled = true;
                            panelEx1.Enabled = false;
                            txtParvandeAddName.Focus();
                            buttonX3.Enabled = false;
                            buttonX5.Enabled = true;
                        }
                        else
                        {
                            err.SetError(txtParvandeAddAdress, "این مقدار صحیح نیست");
                        }
                        err.SetError(txtParvandeAddTell2, "");
                    }
                    else
                    {
                        err.SetError(txtParvandeAddTell2, "این مقدار صحیح نیست");
                    }
                    err.SetError(txtParvandeAddTell1, "");
                }
                else
                {
                    err.SetError(txtParvandeAddTell1, "این مقدار صحیح نیست");
                }
            }
            else
            {
                pnlParvandePerson.Enabled = false;
                panelEx1.Enabled = true;
            }
        }

        private void btnAddDel1_Click(object sender, EventArgs e)
        {
            if (AddressCount <= 64)
            {
                if (this.Controls.Find("btnAddDel" + AddressCount, true).Length == 1)
                    return;
                TextBoxX txt = new TextBoxX();
                txt.Border.Class = "TextBoxBorder";
                txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                txt.HideSelection = false;
                this.highlighter1.SetHighlightOnFocus(txt, true);
                txt.Name = "txtAddDel" + AddressCount;
                txt.Size = new System.Drawing.Size(367, 26);
                txt.WatermarkColor = System.Drawing.SystemColors.ControlDark;
                txt.WatermarkText = "مثال : تهران , شهرک غرب , هرمزان , پیروزان جنوبی , کوچه 8 , پلاک 4";
                txt.Left = txtParvandeAddAdress.Left;
                txt.Top = 80 + AddressCount;
                txt.Anchor = AnchorStyles.None;
                panelEx1.Controls.Add(txt);

                ////////
                ButtonX btnx = new ButtonX();
                btnx.AccessibleRole = AccessibleRole.PushButton;
                btnx.Anchor = AnchorStyles.None;
                btnx.ColorTable = eButtonColor.BlueOrb;
                btnx.FocusCuesEnabled = false;
                btnx.Font = new Font("Tahoma", 9F);
                btnx.Image = global::Shahab.Offline.WinUI.Properties.Resources.cross_mark_304374_1280;
                btnx.ImageFixedSize = new Size(15, 15);
                btnx.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
                btnx.Left = txt.Left + txt.Width + 5;
                btnx.Top = txt.Top;
                btnx.Name = "btnAddDel" + AddressCount;
                btnx.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
                btnx.Size = new Size(24, 25);
                btnx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                btnx.Click += btnDellClick;
                panelEx1.Controls.Add(btnx);

                AddressCount += 32;
            }
            else
            {
                btnAddDel1.Enabled = false;
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            if ((B_PublicFunctions.CheckTextBox(pnlParvandePerson, err) == true))
            {
                if ((IsUniqNationalCodeAndSarparast(dgvParvandeAddPerson, txtParvandeAddNationalCode.Text, cmbParvandeAddNesbat.Text, -1, -1, txtParvandeAddNationalCode.Enabled)) == false)
                    return;

                if (SubmitValidate())
                {
                    IntializAddPersionDGV();
                    string d = "";
                    try
                    {
                        d = cmbParvandeAddNesbat.SelectedValue.ToString();
                    }
                    catch { }
                    string Tell = "";
                    if (txtParvandeAddTell.Text.Length == 12)
                    {
                        Tell = txtParvandeAddTell.Text.Replace("-", "");
                    }
                    string[] s = { 
                                         txtParvandeAddName.Text
                                         ,txtParvandeAddFamily.Text
                                         ,txtParvandeAddNationalCode.Text
                                         ,cmbParvandeAddNasionality.Text
                                         ,cmbParvandeAddGender.Text
                                         ,cmbParvandeAddNesbat.Text
                                         ,txtParvandeAddBirthDay.Text
                                         ,cmbParvandeAddEghamat.Text
                                         ,cmbParvandeAddTahol.Text
                                         ,cmbParvandeAddEducation.Text
                                         ,cmbParvandeAddJob.Text
                                         ,cmbParvandeAddActivity.Text
                                         ,cmbParvandeAddBime1.Text
                                         ,cmbParvandeAddBime2.Text
                                         ,cmbParvandeAddNasionality.SelectedValue.ToString()
                                         ,cmbParvandeAddGender.SelectedValue.ToString()
                                         ,d
                                         ,cmbParvandeAddEghamat.SelectedValue.ToString()
                                         ,cmbParvandeAddTahol.SelectedValue.ToString()
                                         ,cmbParvandeAddEducation.SelectedValue.ToString()
                                         ,cmbParvandeAddJob.SelectedValue.ToString()
                                         ,cmbParvandeAddActivity.SelectedValue.ToString()
                                         ,cmbParvandeAddBime1.SelectedValue.ToString()
                                         ,cmbParvandeAddBime2.SelectedValue.ToString()
                                         ,Tell
                                         ,"-1"
                                     };
                    dgvParvandeAddPerson.Rows.Add(s);
                    B_PublicFunctions.EmpTextBox(pnlParvandePerson);
                    lblParvandeAddDate.Text = "0 سال";
                    err.Clear();
                }
            }
        }

        private void dgvParvandeAddPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                {
                    rw.Selected = false;
                }
                dgvParvandeAddPerson.Rows[e.RowIndex].Selected = true;
                string[] s = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[6].Value.ToString().Split('/'); ;
                if (s[1].Length == 1)
                    s[1] = "0" + s[1];
                if (s[2].Length == 1)
                    s[2] = "0" + s[2];
                string date = s[0] + s[1] + s[2];
                txtParvandeAddName.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtParvandeAddFamily.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtParvandeAddNationalCode.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbParvandeAddNasionality.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbParvandeAddGender.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbParvandeAddNesbat.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtParvandeAddBirthDay.Text = date;
                cmbParvandeAddEghamat.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmbParvandeAddTahol.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[8].Value.ToString();
                cmbParvandeAddEducation.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[9].Value.ToString();
                cmbParvandeAddJob.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[10].Value.ToString();
                cmbParvandeAddActivity.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[11].Value.ToString();
                cmbParvandeAddBime1.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[12].Value.ToString();
                cmbParvandeAddBime2.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[13].Value.ToString();
                if (dgvParvandeAddPerson.Rows[e.RowIndex].Cells[24].Value != null)
                    txtParvandeAddTell.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[24].Value.ToString();
                err.Clear();
                txtParvandeAddBirthDay_Leave(null, null);
            }
        }

        private void dgvParvandeAddPerson_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                    {
                        rw.Selected = false;
                    }
                    dgvParvandeAddPerson.Rows[e.RowIndex].Selected = true;
                }
            }
            catch { };
        }

        private void انتخابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvParvandeAddPerson.SelectedRows.Count > 0)
            {
                string[] s = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[6].Value.ToString().Split('/');
                if (s[1].Length == 1)
                    s[1] = "0" + s[1];
                if (s[2].Length == 1)
                    s[2] = "0" + s[2];
                string date = s[0] + s[1] + s[2];
                txtParvandeAddName.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtParvandeAddFamily.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtParvandeAddNationalCode.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[2].Value.ToString();
                cmbParvandeAddNasionality.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[3].Value.ToString();
                cmbParvandeAddGender.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[4].Value.ToString();
                cmbParvandeAddNesbat.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[5].Value.ToString();
                txtParvandeAddBirthDay.Text = date;
                cmbParvandeAddEghamat.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[7].Value.ToString();
                cmbParvandeAddTahol.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[8].Value.ToString();
                cmbParvandeAddEducation.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[9].Value.ToString();
                cmbParvandeAddJob.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[10].Value.ToString();
                cmbParvandeAddActivity.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[11].Value.ToString();
                cmbParvandeAddBime1.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[12].Value.ToString();
                cmbParvandeAddBime2.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[13].Value.ToString();
                txtParvandeAddTell.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[24].Value.ToString();
                err.Clear();
                txtParvandeAddBirthDay_Leave(null, null);
            }
        }

        private void دیدنجزئییاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDetilas frm = new frmDetilas();
                frm.label1.Text = dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[0].Value.ToString();
                frm.label1.Text += " " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[1].Value.ToString();
                frm.label2.Text = "کد ملی : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[2].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "ملیت : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[3].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "جنسیت : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[4].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "نسبت با سرپرست : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[5].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "تاریخ تولد : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[6].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "وضعیت اقامت : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[7].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "وضعیت تاهل : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[8].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "میزان تحصیلات : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[9].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "شغل : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[10].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "فعالیت : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[11].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "بیمه یک : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[12].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "بیمه دو : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[13].Value.ToString() + Environment.NewLine;
                frm.label2.Text += "تلفن : " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[24].Value.ToString() + Environment.NewLine;
                frm.ShowDialog();
            }
            catch { };
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            pnlParvandePerson.Enabled = false;
            panelEx1.Enabled = true;
            buttonX3.Enabled = true;
            buttonX5.Enabled = false;
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeleteConfirm frm = new frmDeleteConfirm();
                frm.label1.Text = "آیا از حذف " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[0].Value.ToString();
                frm.label1.Text += " " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[1].Value.ToString() + " مطمئن هستید ؟";
                frm.ShowDialog();
                if (frm.Status == true)
                {
                    dgvParvandeAddPerson.Rows.RemoveAt(dgvParvandeAddPerson.SelectedRows[0].Index);
                    B_PublicFunctions.EmpTextBox(pnlParvandePerson);
                    lblParvandeAddDate.Text = "0 سال";
                    err.Clear();
                }
            }
            catch (Exception Ex) { L_ErrorLogs.Errors(Ex.Message); }
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeleteConfirm frm = new frmDeleteConfirm();
                frm.label1.Text = "آیا از حذف " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[0].Value.ToString();
                frm.label1.Text += " " + dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[1].Value.ToString() + " مطمئن هستید ؟";
                frm.ShowDialog();
                if (frm.Status == true)
                {
                    dgvParvandeAddPerson.Rows.RemoveAt(dgvParvandeAddPerson.SelectedRows[0].Index);
                    B_PublicFunctions.EmpTextBox(pnlParvandePerson);
                    lblParvandeAddDate.Text = "0 سال";
                    err.Clear();
                }
            }
            catch (Exception Ex) { L_ErrorLogs.Errors(Ex.Message); }
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            try
            {
                int PID = -1;
                try { PID = int.Parse(dgvParvandeAddPerson.SelectedRows[0].Cells["FamilyMemberID"].Value.ToString()); }
                catch { }
                if (B_PublicFunctions.CheckTextBox(pnlParvandePerson, err) == true)
                {
                    if ((IsUniqNationalCodeAndSarparast(dgvParvandeAddPerson, txtParvandeAddNationalCode.Text, cmbParvandeAddNesbat.Text, dgvParvandeAddPerson.SelectedRows[0].Index, int.Parse(dgvParvandeAddPerson.SelectedRows[0].Cells["FamilyMemberID"].Value.ToString()), txtParvandeAddNationalCode.Enabled)) == false)
                        return;

                    if (SubmitValidate())
                    {
                        string d = "";
                        try
                        {
                            d = cmbParvandeAddNesbat.SelectedValue.ToString();
                        }
                        catch { }
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[0].Value = txtParvandeAddName.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[1].Value = txtParvandeAddFamily.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[2].Value = txtParvandeAddNationalCode.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[3].Value = cmbParvandeAddNasionality.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[4].Value = cmbParvandeAddGender.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[5].Value = cmbParvandeAddNesbat.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[6].Value = txtParvandeAddBirthDay.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[7].Value = cmbParvandeAddEghamat.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[8].Value = cmbParvandeAddTahol.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[9].Value = cmbParvandeAddEducation.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[10].Value = cmbParvandeAddJob.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[11].Value = cmbParvandeAddActivity.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[12].Value = cmbParvandeAddBime1.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[13].Value = cmbParvandeAddBime2.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[14].Value = cmbParvandeAddNasionality.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[15].Value = cmbParvandeAddGender.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[16].Value = d;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[17].Value = cmbParvandeAddEghamat.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[18].Value = cmbParvandeAddTahol.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[19].Value = cmbParvandeAddEducation.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[20].Value = cmbParvandeAddJob.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[21].Value = cmbParvandeAddActivity.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[22].Value = cmbParvandeAddBime1.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[23].Value = cmbParvandeAddBime2.SelectedValue.ToString();
                        string Tell = "";
                        if (txtParvandeAddTell.Text.Length == 12)
                            Tell = txtParvandeAddTell.Text.Replace("-", "");
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[24].Value = Tell;
                        B_PublicFunctions.EmpTextBox(pnlParvandePerson);
                        lblParvandeAddDate.Text = "0 سال";
                        err.Clear();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].DefaultCellStyle.BackColor = SystemColors.Window;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].ErrorText = "";
                    }
                }
            }
            catch (Exception Ex) { L_ErrorLogs.Errors(Ex.Message); }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int PID = -1;
                try { PID = int.Parse(dgvParvandeAddPerson.SelectedRows[0].Cells["FamilyMemberID"].Value.ToString()); }
                catch { }
                if (B_PublicFunctions.CheckTextBox(pnlParvandePerson, err) == true)
                {
                    if ((IsUniqNationalCodeAndSarparast(dgvParvandeAddPerson, txtParvandeAddNationalCode.Text, cmbParvandeAddNesbat.Text, dgvParvandeAddPerson.SelectedRows[0].Index, int.Parse(dgvParvandeAddPerson.SelectedRows[0].Cells["FamilyMemberID"].Value.ToString()), txtParvandeAddNationalCode.Enabled)) == false)
                        return;

                    if (SubmitValidate())
                    {
                        string d = "";
                        try
                        {
                            d = cmbParvandeAddNesbat.SelectedValue.ToString();
                        }
                        catch { }
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[0].Value = txtParvandeAddName.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[1].Value = txtParvandeAddFamily.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[2].Value = txtParvandeAddNationalCode.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[3].Value = cmbParvandeAddNasionality.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[4].Value = cmbParvandeAddGender.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[5].Value = cmbParvandeAddNesbat.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[6].Value = txtParvandeAddBirthDay.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[7].Value = cmbParvandeAddEghamat.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[8].Value = cmbParvandeAddTahol.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[9].Value = cmbParvandeAddEducation.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[10].Value = cmbParvandeAddJob.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[11].Value = cmbParvandeAddActivity.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[12].Value = cmbParvandeAddBime1.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[13].Value = cmbParvandeAddBime2.Text;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[14].Value = cmbParvandeAddNasionality.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[15].Value = cmbParvandeAddGender.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[16].Value = d;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[17].Value = cmbParvandeAddEghamat.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[18].Value = cmbParvandeAddTahol.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[19].Value = cmbParvandeAddEducation.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[20].Value = cmbParvandeAddJob.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[21].Value = cmbParvandeAddActivity.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[22].Value = cmbParvandeAddBime1.SelectedValue.ToString();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[23].Value = cmbParvandeAddBime2.SelectedValue.ToString();
                        string Tell = "";
                        if (txtParvandeAddTell.Text.Length == 12)
                            Tell = txtParvandeAddTell.Text.Replace("-", "");
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].Cells[24].Value = Tell;
                        B_PublicFunctions.EmpTextBox(pnlParvandePerson);
                        lblParvandeAddDate.Text = "0 سال";
                        err.Clear();
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].DefaultCellStyle.BackColor = SystemColors.Window;
                        dgvParvandeAddPerson.Rows[dgvParvandeAddPerson.SelectedRows[0].Index].ErrorText = "";
                    }
                }
            }
            catch (Exception Ex) { L_ErrorLogs.Errors(Ex.Message); }
        }

        private void cmbParvandeAddNasionality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParvandeAddNasionality.SelectedIndex == 1)
            {
                txtParvandeAddNationalCode.Enabled = false;
                txtParvandeAddNationalCode.Text = "";
                err.SetError(txtParvandeAddNationalCode, "");
            }
            else
            {
                txtParvandeAddNationalCode.Enabled = true;
            }
        }

        private void cmbParvandeAddFamilyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParvandeAddFamilyType.SelectedIndex != -1)
            {
                if (cmbParvandeAddFamilyType.SelectedValue.ToString() == "84")
                {
                    cmbParvandeAddNesbat.Enabled = false;
                    cmbParvandeAddNesbat.SelectedIndex = -1;
                    err.SetError(cmbParvandeAddNesbat, "");
                }
                else
                {
                    cmbParvandeAddNesbat.Enabled = CmbEnable;
                }
            }
        }

        private void txtParvandeAddName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            var regex = new Regex("^[ا-یء-ی ]+$");
            if (!regex.IsMatch(txt.Text))
                err.SetError(txt, "لطفا فقط از حروف فارسی استفاده کنید");
        }

        private void btnParvandeAddDelFamily_Click(object sender, EventArgs e)
        {
            // try
            // {
            if (btnParvandeAddDelFamily.Text != "انجام تغییرات")
            {
                frmDeleteConfirm frm = new frmDeleteConfirm();
                frm.label1.Text = "آیا از حذف این خانواده مطمئن هستید ؟";
                frm.ShowDialog();
                if (frm.Status == true)
                {
                    B_DeleteDatas bd = new B_DeleteDatas();
                    bd.DeleteFamily(ThisFamily.ID);
                    frmMessage frm2 = new frmMessage();
                    frm2.label1.Text = "خانوار با موفقیت حذف شد";
                    frm2.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                if (B_PublicFunctions.CheckTextBox(panelEx1, err) == true)
                {
                    if (txtParvandeAddTell1.Text.Length == 12)
                    {
                        if (txtParvandeAddTell2.Text.Length == 12)
                        {
                            if (string.IsNullOrEmpty(txtParvandeAddAdress.Text) == false)
                            {
                                int i = 0;
                                foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                                {
                                    if (rw.Cells["NesbatID"].Value.ToString() == "63")
                                    {
                                        i++;
                                    }
                                }
                                if (i != 1 && cmbParvandeAddFamilyType.SelectedValue.ToString() != "84")
                                {
                                    this.Close();
                                }
                                if (cmbParvandeAddFamilyType.SelectedValue.ToString() == "84")
                                {
                                    bool st = false;
                                    foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                                    {
                                        if (String.IsNullOrEmpty(dgvParvandeAddPerson.Rows[rw.Index].Cells[5].Value.ToString()) == false)
                                        {
                                            st = true;
                                        }
                                    }
                                    if (st == true)
                                    {
                                        frmDeleteConfirm frm = new frmDeleteConfirm();
                                        frm.label1.Text = "شما در خانوار عضوهایی دارید که نسبت با سرپرست دارند در صورتی که خانوار موسسه ای سرپرست ندارد , برای ادامه کار لازم است نسبت آنها از بین برورد" + Environment.NewLine + "این کار را انجام دهیم ؟";
                                        frm.ShowDialog();
                                        if (frm.Status == true)
                                        {
                                            foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                                            {
                                                dgvParvandeAddPerson.Rows[rw.Index].Cells[5].Value = "";
                                                dgvParvandeAddPerson.Rows[rw.Index].Cells[16].Value = "0";
                                            }
                                        }
                                        else
                                        {
                                            IsFirstEditOK = false;
                                            this.Close();
                                        }
                                    }
                                }
                                if (B_PublicFunctions.ISUnicFamilyCode(int.Parse(txtParvandeAddFamilyNumber.Text), FamilyCode) == true && txtParvandeAddFamilyNumber.Enabled == true)
                                {
                                    this.Close();
                                }
                                IsFirstEditOK = true;
                            }
                        }
                    }
                    foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                    {
                        if (rw.DefaultCellStyle.BackColor == Color.LightPink)
                            IsFirstEditOK = false;
                        else
                        {
                            M_FamilyMembers fm = new M_FamilyMembers();
                            fm.Activity = int.Parse(rw.Cells["ActivityID"].Value.ToString());
                            string[] date1 = rw.Cells["BirthDay"].Value.ToString().Split('/');
                            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                            DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                            fm.BirthDate = dt1;
                            fm.Education = int.Parse(rw.Cells["SathSavadID"].Value.ToString());
                            fm.FirstInsurance = int.Parse(rw.Cells["Bime1ID"].Value.ToString());
                            fm.FirstName = rw.Cells["Name"].Value.ToString();
                            fm.Gender = int.Parse(rw.Cells["GenderID"].Value.ToString());
                            fm.Job = int.Parse(rw.Cells["JobID"].Value.ToString());
                            fm.LastName = rw.Cells["Family"].Value.ToString();
                            fm.MaritalStatus = int.Parse(rw.Cells["TaholID"].Value.ToString());
                            fm.NationalCode = rw.Cells["NationalCode"].Value.ToString();
                            fm.Nationality = int.Parse(rw.Cells["NationalityID"].Value.ToString());
                            try
                            {
                                fm.Relationship = int.Parse(rw.Cells["NesbatID"].Value.ToString());
                            }
                            catch { fm.Relationship = 0; }
                            fm.ResidentStatus = int.Parse(rw.Cells["VaziateEghamatID"].Value.ToString());
                            fm.SecondInsurance = int.Parse(rw.Cells["Bime2ID"].Value.ToString());
                            fm.MobileNumber = rw.Cells["Tell"].Value.ToString();
                            ThisFamilyMember[int.Parse(rw.Cells["FamilyMemberID"].Value.ToString())] = fm;
                        }
                    }
                    int CityOrVillageCode = int.Parse(((ComboBox)this.Controls.Find("cmbParvandeAddCityOrVillage", true).Single()).SelectedValue.ToString());
                    int ShomareSakhteman = int.Parse(((TextBox)this.Controls.Find("txtParvandeAddShomareSakhteman", true).Single()).Text);
                    int FamilyNumber = int.Parse(((TextBox)this.Controls.Find("txtParvandeAddFamilyNumber", true).Single()).Text);
                    int FamilyType = int.Parse(((ComboBox)this.Controls.Find("cmbParvandeAddFamilyType", true).Single()).SelectedValue.ToString());
                    int Malekiat = int.Parse(((ComboBox)this.Controls.Find("cmbParvandeAddMalekiat", true).Single()).SelectedValue.ToString());
                    string PostalCode = ((TextBox)this.Controls.Find("txtParvandeAddPostalCode", true).Single()).Text;
                    string Tell1 = ((MaskedTextBoxAdv)this.Controls.Find("txtParvandeAddTell1", true).Single()).Text.Replace("-", "");
                    string Tell2 = ((MaskedTextBoxAdv)this.Controls.Find("txtParvandeAddTell2", true).Single()).Text.Replace("-", "");
                    string Adrees1 = ((TextBox)this.Controls.Find("txtParvandeAddAdress", true).Single()).Text;
                    string Adrees2 = "";
                    try
                    {
                        Adrees2 = ((TextBox)this.Controls.Find("txtAddDel32", true).Single()).Text;
                    }
                    catch { }
                    string Adrees3 = "";
                    try
                    {
                        Adrees3 = ((TextBox)this.Controls.Find("txtAddDel64", true).Single()).Text;
                    }
                    catch { }
                    DateTime CreateDate = DateTime.Now;
                    ThisAddress.AddressString1 = Adrees1;
                    ThisAddress.AddressString2 = Adrees2;
                    ThisAddress.AddressString3 = Adrees3;
                    ThisAddress.BuildingNumber = ShomareSakhteman;
                    ThisAddress.PlaceID = CityOrVillageCode;
                    ThisAddress.TelephoneNumber = Tell2;
                    ThisAddress.ZipCode = PostalCode;

                    ThisFamily.FamilyTypeCode = FamilyType;
                    ThisFamily.FamilyCode = FamilyNumber;
                    ThisFamily.HeaderMobileNumber = Tell1;
                    ThisFamily.OwnrshipCode = Malekiat;
                    ThisFamily.PlaceID = CityOrVillageCode;
                    ThisFamily.UnitCode = 10;// HardCode
                }
                this.Close();
            }
            //}
            //catch (Exception Ex) { L_ErrorLogs.Errors(Ex.Message); }
        }

        private void dgvParvandeAddPerson_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                foreach (DataGridViewRow rw in dgvParvandeAddPerson.Rows)
                {
                    rw.Selected = false;
                }
                dgvParvandeAddPerson.Rows[e.RowIndex].Selected = true;
                string[] s = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[6].Value.ToString().Split('/');
                if (s[1].Length == 1)
                    s[1] = "0" + s[1];
                if (s[2].Length == 1)
                    s[2] = "0" + s[2];
                string date = s[0] + s[1] + s[2];
                txtParvandeAddName.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtParvandeAddFamily.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtParvandeAddNationalCode.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbParvandeAddNasionality.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbParvandeAddGender.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbParvandeAddNesbat.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtParvandeAddBirthDay.Text = date;
                cmbParvandeAddEghamat.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmbParvandeAddTahol.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[8].Value.ToString();
                cmbParvandeAddEducation.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[9].Value.ToString();
                cmbParvandeAddJob.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[10].Value.ToString();
                cmbParvandeAddActivity.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[11].Value.ToString();
                cmbParvandeAddBime1.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[12].Value.ToString();
                cmbParvandeAddBime2.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtParvandeAddTell.Text = dgvParvandeAddPerson.Rows[e.RowIndex].Cells[24].Value.ToString();
                err.Clear();
                txtParvandeAddBirthDay_Leave(null, null);
            }
        }

        private void cmbParvandeAddJob_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbParvandeAddJob.SelectedValue != null)
            {
                if (cmbParvandeAddJob.SelectedValue.ToString() == "24")
                    B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity, new int[] { 74, 124 });
                else if (cmbParvandeAddJob.SelectedValue.ToString() == "25")
                    B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity, new int[] { 124 });
                else if (cmbParvandeAddJob.SelectedValue.ToString() == "26")
                    B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity, new int[] { 124 });
                else if (cmbParvandeAddJob.SelectedValue.ToString() == "27")
                    B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity, new int[] { 74, 124 });
                else
                    B_PublicFunctions.AddToCombo(73, cmbParvandeAddActivity, new int[] { 75, 76, 124 });
            }
        }
    }
}
