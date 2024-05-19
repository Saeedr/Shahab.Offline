using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Shahab.Offline.Model;
using Shahab.Offline.DAL;

namespace Shahab.Offline.BL
{
    public static class B_PublicFunctions
    {
        /// <summary>
        /// تعیین معتبر بودن کد ملی
        /// </summary>
        /// <param name="nationalCode">کد ملی وارد شده</param>
        /// <returns>
        /// در صورتی که کد ملی صحیح باشد خروجی <c>true</c> و در صورتی که کد ملی اشتباه باشد خروجی <c>false</c> خواهد بود
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        public static Boolean IsValidNationalCode(this String nationalCode)
        {
            //در صورتی که کد ملی وارد شده تهی باشد

            if (String.IsNullOrEmpty(nationalCode))
                return false;


            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
                return false;

            //در صورتی که کد ملی ده رقم عددی نباشد
            var regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                return false;

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode)) return false;


            //عملیات شرح داده شده در بالا
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

        /// <summary>
        /// چک کردن تاریخ تولد مثلا خللی نباشد , از تاریخ امروز نگذشته باشد , فورمت صحیح باشد و ...
        /// </summary>
        /// <param name="date">تاریخ تولد</param>
        /// <returns></returns>
        public static Boolean IsValidBirthDay(this String date)
        {
            if (date.Length == 10)
            {
                string[] s = date.Split('/');
                if (((int.Parse(s[1]) <= 6 && int.Parse(s[1]) >= 1) && (int.Parse(s[2]) <= 31 && int.Parse(s[1]) >= 1)) || ((int.Parse(s[1]) <= 12 && int.Parse(s[1]) >= 7) && (int.Parse(s[2]) <= 30 && int.Parse(s[1]) >= 1)))
                {
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    DateTime dt1 = pc.ToDateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), 0, 0, 0, 0);
                    DateTime dt2 = DateTime.Today;
                    if (((dt2 - dt1).TotalDays / 365) < 0 || ((dt2 - dt1).TotalDays / 365) > 130)
                    {
                        return false;
                    }
                }
                else
                {
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
        /// چک کردن خالی نبودن تکست باکس ها و کمبوها
        /// </summary>
        /// <param name="pnl">پنلی که کنترل ها در آن هستند</param>
        /// <returns></returns>
        public static bool CheckTextBox(Panel pnl, ErrorProvider err)
        {
            foreach (Control ctn in pnl.Controls)
            {
                if (ctn is TextBox)
                {
                    TextBox txt = ctn as TextBox;
                    if (txt.Name == "txtParvandeAddPostalCode" && txt.Enabled == true && txt.Text.Length < 10)
                    {
                        err.SetError(txt, "این مقدار صحیح نیست");
                        return false;
                    }
                    else
                    {
                        err.SetError(txt, "");
                    }
                    if (txt.Name == "txtParvandeAddNationalCode" && txt.Enabled == true && txt.Text.IsValidNationalCode() == false)
                    {
                        err.SetError(txt, "لطفا در وارد کردن مقدار دقت کنید");
                        return false;
                    }
                    else
                    {
                        err.SetError(txt, "");
                    }
                    if (txt.Tag == "Valid" && txt.Enabled == true && string.IsNullOrEmpty(txt.Text) == true)
                    {
                        err.SetError(txt, "این فیلد نمیتواند خالی باشد");
                        return false;
                    }
                    else
                    {
                        err.SetError(txt, "");
                    }
                }
                else if (ctn is ComboBox && ctn.Tag != "NotValid")
                {
                    ComboBox cmb = ctn as ComboBox;
                    if ((cmb.Enabled == true && cmb.Text.Length == 0) || (cmb.Enabled == true && cmb.FindString(cmb.Text) == -1))
                    {
                        if (cmb.Name != "cmbParvandeAddBime2")
                        {
                            err.SetError(cmb, "این گزینه وجود ندارد");
                            return false;
                        }
                    }
                    else
                    {
                        if (cmb.Name != "cmbParvandeAddBime2")
                        {
                            err.SetError(cmb, "");
                        }
                    }
                    if (cmb.Name == "cmbParvandeAddBime2" && cmb.SelectedIndex == -1)
                    {
                        cmb.SelectedIndex = cmb.Items.Count - 1;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// خالی کردن تکست باکس ها بعد از عملیات افزودن
        /// </summary>
        /// <param name="pnl">پنل مورد نظر</param>
        public static void EmpTextBox(Panel pnl)
        {
            foreach (Control ctn in pnl.Controls)
            {
                if (ctn is TextBox)
                {
                    TextBox txt = ctn as TextBox;
                    txt.Text = string.Empty;
                }
                else if (ctn is ComboBox)
                {
                    ComboBox cmb = ctn as ComboBox;
                    cmb.SelectedIndex = -1;
                }
                else if (ctn is MaskedTextBoxAdv)
                {
                    MaskedTextBoxAdv mtxt = ctn as MaskedTextBoxAdv;
                    mtxt.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// اعتبار سنجی کمبوها بعد از بلود شدن
        /// </summary>
        /// <param name="sender">کمبویی که بلور شده</param>
        /// <param name="e">ایونت های مربوطه</param>
        public static void CheckComboValue(object sender, EventArgs e, ErrorProvider err)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb.FindString(cmb.Text) == -1 || string.IsNullOrEmpty(cmb.Text))
            {
                err.SetError(cmb, "این گزینه وجود ندارد");
            }
            else
            {
                err.SetError(cmb, "");
            }
        }

        /// <summary>
        /// اعتبار سنجی تکست باکس ها بعد از بلور شدن
        /// </summary>
        /// <param name="sender">تکست باکس بلور شده</param>
        /// <param name="e">ایونت های مربوطه</param>
        public static void CheckTextBoxValue(object sender, EventArgs e, ErrorProvider err)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrEmpty(txt.Text) == true)
            {
                err.SetError(txt, "این فیلد نمیتواند خالی باشد");
            }
            else
            {
                if (txt.Name == "txtParvandeAddPostalCode" && txt.Text.Length < 10)
                    err.SetError(txt, "این مقدار صحیح نیست");
                else
                    err.SetError(txt, "");

                if (txt.Name == "txtParvandeAddNationalCode" && B_PublicFunctions.IsValidNationalCode(txt.Text) == false)
                    err.SetError(txt, "لطفا در وارد کردن مقدار دقت کنید");
                else
                    err.SetError(txt, "");
            }
        }

        /// <summary>
        /// چک کردن ثبت نبودن کد ملی در خانوار دیگر
        /// </summary>
        /// <param name="NationalCode">کـــد ملی</param>
        /// <returns></returns>
        public static bool ISUnicNationalCode(string NationalCode, int CompareMod, int PID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_FamilyMembers fm = DAL.GetFamilyMember(NationalCode);
            if (fm != null)
            {
                if (fm.NationalCode == NationalCode && CompareMod == 1 && fm.ID != PID)
                    return true;

                if (fm.Relationship != 63 && fm.NationalCode == NationalCode && CompareMod == 2 && fm.ID != PID)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// چک کردن یکتا بودن شماره خانوار
        /// </summary>
        /// <param name="FamilyCode">شماره خانوار</param>
        /// <returns></returns>
        public static bool ISUnicFamilyCode(int FamilyCode,int FmID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_Families> fm = DAL.GetFamilyByFamilyCode(FamilyCode).Where(c => c.ID != FmID).ToList<M_Families>();
            if (fm.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// چک کردن اعضای خانوار هنگام لود شدن فرم
        /// </summary>
        /// <param name="fm">عضو خانوار</param>
        /// <returns></returns>
        public static bool IsLoadValidPerson(M_FamilyMembers fm,M_Families Fm,ref string Err)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            bool Ret = true;
            Err = "";

            if (DAL.GetPublicCategori(35).Where(c => c.ID == fm.FirstInsurance).ToList().Count == 0)
            {
                Ret = false;
                Err += "بیمه نوع اول مشکل دارد" + Environment.NewLine;
            }
            if (DAL.GetPublicCategori(43).Where(c => c.ID == fm.SecondInsurance).ToList().Count == 0)
            {
                Ret = false;
                Err += "بیمه نوع دوم مشکل دارد" + Environment.NewLine;
            }

            if (fm.FirstInsurance == fm.SecondInsurance)
            {
                Ret = false;
                Err += "مقادیر دو بیمه یکی است" + Environment.NewLine;
            }

            if (!((fm.Job != 27) || (fm.Job == 27 && fm.Activity != 74)))
            {
                Ret = false;
                Err += "فرد بیکار نمیتواند شاغل باشد" + Environment.NewLine;
            }
            
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            string ss = pc.GetYear(fm.BirthDate).ToString() + "/" + pc.GetMonth(fm.BirthDate).ToString() + "/" + pc.GetDayOfMonth(fm.BirthDate).ToString();
            string[] s2 = ss.Split('/');
            if (s2[1].Length == 1)
                s2[1] = "0" + s2[1];
            if (s2[2].Length == 1)
                s2[2] = "0" + s2[2];
            ss = s2[0] + "/" + s2[1] + "/" + s2[2];

            if (IsValidBirthDay(ss) == false)
            {
                Ret = false;
                Err += "تاریخ تولد صحیح نیت" + Environment.NewLine;
            }

            if (Fm.FamilyTypeCode == 84 && fm.Relationship != 0)
            {
                Ret = false;
                Err += "این عضو در خانوار موسسه ای نسبت با سرپرست دارد" + Environment.NewLine;
            }
            
            var regex = new Regex("^[ا-یء-ی ]+$");
            if (!regex.IsMatch(fm.FirstName))
            {
                Ret = false;
                Err += "نام مشکل دارد" + Environment.NewLine;
            }

            if (!regex.IsMatch(fm.LastName))
            {
                Ret = false;
                Err += "نام خانوادگی مشکل دارد" + Environment.NewLine;
            }

            string[] s = ss.Split('/');
            if (((int.Parse(s[1]) <= 6 && int.Parse(s[1]) >= 1) && (int.Parse(s[2]) <= 31 && int.Parse(s[1]) >= 1)) || ((int.Parse(s[1]) <= 12 && int.Parse(s[1]) >= 7) && (int.Parse(s[2]) <= 30 && int.Parse(s[1]) >= 1)))
            {
                DateTime dt1 = pc.ToDateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), 0, 0, 0, 0);
                DateTime dt2 = DateTime.Today;
                if (Math.Round(((dt2 - dt1).TotalDays / 365)) > 6)
                {
                    if (fm.Education == 61)
                    {
                        Ret = false;
                        Err += "سطح تحصیلات برای افراد بالای 6 سال معتبر نیست" + Environment.NewLine;
                    }
                    if (fm.Job == 123)
                    {
                        Ret = false;
                        Err += "شغل برای افراد بالای 6 سال معتبر نیست" + Environment.NewLine;
                    }
                    if (fm.Activity == 124)
                    {
                        Ret = false;
                        Err += "فعالیت برای افراد بالای 6 سال معتبر نیست" + Environment.NewLine;
                    }
                    if (fm.MaritalStatus == 34)
                    {
                        Ret = false;
                        Err += "وضعیت تاهل برای افراد بالای 6 سال معتبر نیست" + Environment.NewLine;
                    }
                }
                if (Math.Round(((dt2 - dt1).TotalDays / 365)) <= 6)
                {
                    if (fm.Education != 61)
                    {
                        Ret = false;
                        Err += "تحصیلات برای افراد زیر 6 سال معتبر نیست" + Environment.NewLine;
                    }
                    if (fm.Job != 123)
                    {
                        Ret = false;
                        Err += "شغل برای افراد زیر 6 سال معتبر نیست" + Environment.NewLine;
                    }
                    if (fm.Activity != 124)
                    {
                        Ret = false;
                        Err += "فعالیت برای افراد زیر 6 سال معتبر نیست" + Environment.NewLine;
                    }
                    if (fm.MaritalStatus != 34)
                    {
                        Ret = false;
                        Err += "وضعیت تاهل برای افراد زیر 6 سال معتبر نیست" + Environment.NewLine;
                    }
                }
            }

            if (DAL.GetPublicCategori(7).Where(c => c.ID == fm.Nationality).ToList().Count == 0)
            {
                Ret = false;
                Err += "ملیت معتبر نیست" + Environment.NewLine;
            }

            if (DAL.GetPublicCategori(10).Where(c => c.ID == fm.Gender).ToList().Count == 0)
            {
                Ret = false;
                Err += "جنسیت معتبر نیست" + Environment.NewLine;
            }

            if (DAL.GetPublicCategori(29).Where(c => c.ID == fm.MaritalStatus).ToList().Count == 0)
            {
                Ret = false;
                if (Err.IndexOf("تاهل") == -1)
                Err += "وضعیت تاهل معتبر نیست" + Environment.NewLine;
            }

            if (DAL.GetPublicCategori(62).Where(c => c.ID == fm.Relationship).ToList().Count == 0)
            {
                if (Fm.FamilyTypeCode == 84 && fm.Relationship != 0)
                {
                    Ret = false;
                    Err += "نسبت با سرپرست معتبر نیست" + Environment.NewLine;
                }
            }

            if (DAL.GetPublicCategori(51).Where(c => c.ID == fm.Education).ToList().Count == 0)
            {
                Ret = false;
                if (Err.IndexOf("تحصیلات") == -1)
                    Err += "تحصیلات معتبر نیست" + Environment.NewLine;
            }

            if (DAL.GetPublicCategori(13).Where(c => c.ID == fm.Job).ToList().Count == 0)
            {
                Ret = false;
                if (Err.IndexOf("شغل") == -1)
                Err += "شغل معتبر نیست" + Environment.NewLine;
            }

            if (DAL.GetPublicCategori(73).Where(c => c.ID == fm.Activity).ToList().Count == 0)
            {
                Ret = false;
                if (Err.IndexOf("فعالیت") == -1)
                Err += "فعالیت معتبر نیست" + Environment.NewLine;
            }

            if (DAL.GetPublicCategori(109).Where(c => c.ID == fm.ResidentStatus).ToList().Count == 0)
            {
                Ret = false;
                Err += "وضعیت اقامت معتبر نیست" + Environment.NewLine;
            }

            return Ret;
        }

        /// <summary>
        /// چک کردن وضعیت تاهل سرپرست با نسبت اعضای خانواده با او
        /// </summary>
        /// <param name="MaritalStatus">وضعیت تاهل سرپرست</param>
        /// <param name="RalationShip">نسبت عضو با سرپرست</param>
        /// <returns></returns>
        public static bool CheckMaritalSarparast(int MaritalStatus,int RalationShip)
        {
            if (MaritalStatus == 30)
                if (RalationShip == 64 || RalationShip == 65)
                    return false;
            if (MaritalStatus == 32 || MaritalStatus == 33)
                if (RalationShip == 64)
                    return false;
            return true;
        }

        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// </summary>
        /// <param name="Date">تاریخ شمسی</param>
        /// <returns></returns>
        public static DateTime ConverShamsiToMiladi(string Date)
        {
            if (Date.Length == 10)
            {
                string[] s = Date.Split('/');
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                DateTime dt1 = pc.ToDateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), 0, 0, 0, 0);
                return dt1;
            }
            return new DateTime();
        }


        /// <summary>
        /// افزودن ایتم به کمبوباکس با محدودیت
        /// </summary>
        /// <param name="id">کد بالاسری</param>
        /// <param name="cmb">کمبو باکس مربوطه</param>
        /// <param name="DeleteValeus">شماره هایی که نبای اضافه شوند</param>
        public static void AddToCombo(int id, ComboBox cmb, int[] DeleteValeus = null)
        {
            List<int> intt = new List<int>();
            B_ReportPublicCategori BL = new B_ReportPublicCategori();
            List<M_PublicCategory> Lis2 = BL.GetPublicCategori(id);
            List<M_PublicCategory> Lis = new List<M_PublicCategory>();
            foreach (M_PublicCategory li in Lis2)
            {
                if (DeleteValeus == null)
                    Lis.Add(li);
                else
                    if (DeleteValeus.Contains(li.ID) == false)
                        Lis.Add(li);
            }
            cmb.DataSource = Lis;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "PC_Title";
            cmb.SelectedIndex = -1;
            cmb.Text = "انتخاب کنید";
        }

        /// <summary>
        /// افزودن تقسیمات کشوری به کمبوباکس ها
        /// </summary>
        /// <param name="ParentCode">کد والد</param>
        /// <param name="cmb">کمبوباکس مربوطه</param>
        public static void FillCountryDivision(string ParentCode, ComboBox cmb)
        {
            B_GetDatas BG = new B_GetDatas();
            List<M_CountryDivision> List = BG.GetCountryDivision(ParentCode);
            cmb.DisplayMember = "Value";
            cmb.ValueMember = "Code";
            cmb.DataSource = List;
            cmb.SelectedIndex = -1;
            cmb.Text = "انتخاب کنید";
        }

        /// <summary>
        /// چک کردن اینکه آیا تاریخ وارد شده صحیح است یا خیر
        /// </summary>
        /// <param name="date">تاریخ مورد نظر</param>
        /// <returns></returns>
        public static Boolean IsValidDate(this String date)
        {
            if (date.Length == 10)
            {
                string[] s = date.Split('/');
                if (((int.Parse(s[1]) <= 6 && int.Parse(s[1]) >= 1) && (int.Parse(s[2]) <= 31 && int.Parse(s[1]) >= 1)) || ((int.Parse(s[1]) <= 12 && int.Parse(s[1]) >= 7) && (int.Parse(s[2]) <= 30 && int.Parse(s[1]) >= 1)))
                {
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    DateTime dt1 = pc.ToDateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), 0, 0, 0, 0);
                    DateTime dt2 = DateTime.Today;
                    if (((dt2 - dt1).TotalDays / 365) < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
