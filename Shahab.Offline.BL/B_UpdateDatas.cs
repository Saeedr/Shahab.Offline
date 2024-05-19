using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shahab.Offline.Model;
using Shahab.Offline.Logging;
using Shahab.Offline.DAL;

namespace Shahab.Offline.BL
{
    public class B_UpdateDatas
    {
        /// <summary>
        /// افزودن خانوار
        /// </summary>
        /// <param name="CityOrVillageCode">کد شهر یا روستا</param>
        /// <param name="ShomareSakhteman">شماره ساختمان خانوار</param>
        /// <param name="FamilyNumber">کد خانوار</param>
        /// <param name="FamilyType">کد مربوط به نوع خانوار</param>
        /// <param name="Malekiat">کد مربوط به نوع مالکیت</param>
        /// <param name="PostalCode">کد پستی</param>
        /// <param name="Tell1">شماره تلفن همراه</param>
        /// <param name="Tell2">شماره تلفن ثابت</param>
        /// <param name="Adrees1">آدرس اول</param>
        /// <param name="Adrees2">آدرس دوم</param>
        /// <param name="Adrees3">آدرس سوم</param>
        /// <param name="CreateDate">تاریخ ایجاد خانوار</param>
        /// <param name="UnitCode">کد واحدی که خانوار را ثبت میکند</param>
        /// <param name="dgv">دیتا گرید ویو مربوط به لیست اعضای خانوار</param>
        /// <param name="FM">افراد این خانواده</param>
        public void UpdateFamilyAndPerson(int id, int CityOrVillageCode, int ShomareSakhteman, int FamilyNumber, int FamilyType, int Malekiat, string PostalCode, string Tell1, string Tell2, string Adrees1, string Adrees2, string Adrees3, DateTime CreateDate, long UnitCode, DataGridView dgv, List<M_FamilyMembers> FM)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_Families fml = new M_Families();
            fml.FamilyCode = FamilyNumber;
            fml.FamilyTypeCode = FamilyType;
            fml.HeaderMobileNumber = Tell1;
            fml.OwnrshipCode = Malekiat;
            fml.PlaceID = CityOrVillageCode;
            fml.UnitCode = UnitCode;
            DAL.UpdateFamily(fml, id);
            UpdateAddresses(Adrees1, Adrees2, Adrees3, ShomareSakhteman, CreateDate, id, CityOrVillageCode, Tell2, PostalCode);
            UpdatePerson(id, dgv, CreateDate, FM);
        }

        /// <summary>
        /// افزودن فرد در خانواده
        /// </summary>
        /// <param name="FamilyID">کد خانواده</param>
        /// <param name="dgv">گرید ویوای که شامل اسامی افراد است</param>
        /// <param name="CreateDate">تاریخ ایجاد</param>
        /// <param name="FM">افراد این خانواده</param>
        private void UpdatePerson(int FamilyID, DataGridView dgv, DateTime CreateDate, List<M_FamilyMembers> FM)
        {
            List<M_FamilyMembers> FMDel = FM;
            List<int> ids = new List<int>();
            foreach (DataGridViewRow rw in dgv.Rows)
            {
                bool ISin = false;
                M_FamilyMembers fm = new M_FamilyMembers();
                fm.Activity = int.Parse(rw.Cells["ActivityID"].Value.ToString());
                string[] date1 = rw.Cells["BirthDay"].Value.ToString().Split('/');
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                fm.BirthDate = dt1;
                fm.Education = int.Parse(rw.Cells["SathSavadID"].Value.ToString());
                fm.FamilyID = FamilyID;
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
                foreach (M_FamilyMembers mmb in FM)
                {
                    if (rw.Cells["FamilyMemberID"].Value != null)
                    {
                        if (int.Parse(rw.Cells["FamilyMemberID"].Value.ToString()) == mmb.ID)
                        {
                            DataAccessLayer DAL = new DataAccessLayer();
                            DAL.UpdateFamilyMember(fm, mmb.ID);
                            ISin = true;
                            FMDel.Remove(mmb);
                            break;
                        }
                    }
                }
                if (ISin == false && ids.IndexOf(fm.ID) == -1)
                {
                    DataAccessLayer DAL = new DataAccessLayer();
                    DAL.InsertFamilyMember(fm, FamilyID, CreateDate);
                    ids.Add(fm.ID);
                }
            }
            foreach (M_FamilyMembers mmb in FMDel)
            {
                DataAccessLayer DAL = new DataAccessLayer();
                DAL.DeleteFamilyMember(mmb);
            }
        }

        /// <summary>
        /// افزودن آدرس
        /// </summary>
        /// <param name="AddressString1">آدرس اول</param>
        /// <param name="AddressString2">آدرس دوم</param>
        /// <param name="AddressString3">آدرس سوم</param>
        /// <param name="BuildingNumber">شماره ساختمان</param>
        /// <param name="CreateDate">تاریخ ایجاد</param>
        /// <param name="FamilyID">شماره خانواده</param>
        /// <param name="PlaceID">کد شهر یا روستا</param>
        /// <param name="TelephoneNumber">شماره تلفن</param>
        /// <param name="ZipCode">کد پستی</param>
        private void UpdateAddresses(string AddressString1, string AddressString2, string AddressString3, int BuildingNumber, DateTime CreateDate, int FamilyID, int PlaceID, string TelephoneNumber, string ZipCode)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_Address ad = new M_Address();
            ad.AddressString1 = AddressString1;
            ad.AddressString2 = AddressString2;
            ad.AddressString3 = AddressString3;
            ad.BuildingNumber = BuildingNumber;
            ad.FamilyID = FamilyID;
            ad.PlaceID = PlaceID;
            ad.TelephoneNumber = TelephoneNumber;
            ad.ZipCode = ZipCode;
            DAL.UpdateAddress(ad,FamilyID);
        }

        /// <summary>
        /// ویرایش مشخصات فردی - کاری  - تحصیلی در منابع انسانی
        /// </summary>
        /// <param name="emp">اطلاعات شخص</param>
        /// <param name="empe">اطلاعات کاری</param>
        /// <param name="empi">اطلاعات تحصیلی</param>
        /// <param name="EmployeeID">آی.دی شخص</param>
        public void UpdateEmployee(M_Employee emp, M_EmployeeExprience empe, M_EmployeeEducationalInformation empi, int EmployeeID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.UpdateEmployee(emp, empe, empi, EmployeeID);
        }

        /// <summary>
        /// ویرایش یک شخص
        /// </summary>
        /// <param name="Fmm">شخص مورد نظر</param>
        public void UpdatePerson(M_FamilyMembers Fmm)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.UpdateFamilyMember(Fmm, Fmm.ID);
        }
    }
}
