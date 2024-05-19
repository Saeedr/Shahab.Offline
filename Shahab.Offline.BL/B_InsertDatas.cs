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
    public class B_InsertDatas
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
        public void InsertFamilyAndPerson(int CityOrVillageCode, int ShomareSakhteman, int FamilyNumber, int FamilyType, int Malekiat, string PostalCode, string Tell1, string Tell2, string Adrees1, string Adrees2, string Adrees3, DateTime CreateDate, long UnitCode, DataGridView dgv)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_Families fml = new M_Families();
            fml.CreateDate = CreateDate;
            fml.FamilyCode = FamilyNumber;
            fml.FamilyTypeCode = FamilyType;
            fml.HeaderMobileNumber = Tell1;
            fml.OwnrshipCode = Malekiat;
            fml.PlaceID = CityOrVillageCode;
            fml.UnitCode = UnitCode;
            int id = DAL.InsertFamily(fml);
            InsertAddresses(Adrees1, Adrees2, Adrees3, ShomareSakhteman, CreateDate, id, CityOrVillageCode, Tell2, PostalCode);
            InsertPerson(id, dgv, CreateDate);
        }

        /// <summary>
        /// افزودن فرد در خانواده
        /// </summary>
        /// <param name="FamilyID">کد خانواده</param>
        /// <param name="dgv">گرید ویوای که شامل اسامی افراد است</param>
        /// <param name="CreateDate">تاریخ ایجاد</param>
        private void InsertPerson(int FamilyID, DataGridView dgv, DateTime CreateDate)
        {
            foreach (DataGridViewRow rw in dgv.Rows)
            {
                DataAccessLayer DAL = new DataAccessLayer();
                M_FamilyMembers fm = new M_FamilyMembers();
                fm.Activity = int.Parse(rw.Cells["ActivityID"].Value.ToString());

                string[] date1 = rw.Cells["BirthDay"].Value.ToString().Split('/');
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                DateTime dt1 = pc.ToDateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]), 0, 0, 0, 0);
                fm.BirthDate = dt1;

                fm.CreateDate = CreateDate;
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
                DAL.InsertFamilyMember(fm, FamilyID, CreateDate);
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
        private void InsertAddresses(string AddressString1, string AddressString2, string AddressString3, int BuildingNumber, DateTime CreateDate, int FamilyID, int PlaceID, string TelephoneNumber, string ZipCode)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_Address ad = new M_Address();
            ad.AddressString1 = AddressString1;
            ad.AddressString2 = AddressString2;
            ad.AddressString3 = AddressString3;
            ad.BuildingNumber = BuildingNumber;
            ad.CreateDate = CreateDate;
            ad.FamilyID = FamilyID;
            ad.PlaceID = PlaceID;
            ad.TelephoneNumber = TelephoneNumber;
            ad.ZipCode = ZipCode;
            DAL.InsertAddress(ad);
        }

        /// <summary>
        /// افزودن یک واحد تحت پوشش
        /// </summary>
        /// <param name="plc">واحد مورد نظر</param>
        public void InsertUnitPlace(M_UnitPlace plc)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertUnitPlace(plc);
        }

        /// <summary>
        /// افزودن لیستی از واحدهای تحت پوشش
        /// </summary>
        /// <param name="plc">واحدهای مورد نظر</param>
        public void InsertUnitPlace(List<M_UnitPlace> plc)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertUnitPlace(plc);
        }
        
        /// <summary>
        /// افزودن خانوار
        /// </summary>
        /// <param name="FM">خانوار</param>
        /// <param name="FMm">لیست اعضا</param>
        /// <param name="ad">آدرس</param>
        public void InsertFamily(M_Families FM,List<M_FamilyMembers> FMm,M_Address ad)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            FM.CreateDate = DateTime.Now;
            int id = DAL.InsertFamily(FM);
            foreach (M_FamilyMembers fm in FMm)
            {
                fm.FamilyID = id;
            }
            ad.FamilyID = id;
            InsertPerson(FMm);
            InsertAdsress(ad);
        }

        /// <summary>
        /// افزودن لیستی از اعضای خانوار
        /// </summary>
        /// <param name="FM">لیست اعضا</param>
        public void InsertPerson(List<M_FamilyMembers> FM)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertFamilyMember(FM);
        }
        
        /// <summary>
        /// افزودن آدرس
        /// </summary>
        /// <param name="ad">آدرس</param>
        public void InsertAdsress(M_Address ad)
        {
            ad.CreateDate = DateTime.Now;
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertAddress(ad);
        }


        /// <summary>
        /// افزودن مشخصات فردی منابع انسانی
        /// </summary>
        /// <param name="emp">مشخصالت فردی شخص مورد نظر</param>
        /// <param name="empe">اطلاعات خدمتی مورد نظر</param>
        /// <param name="empei">اطلاعات آموزشی مورد نظر</param>
        public void InsertEmployee(M_Employee emp, M_EmployeeExprience empe, M_EmployeeEducationalInformation empei)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            int id = DAL.InsertEmployee(emp);
            empe.EmployeeID = id;
            empei.EmployeeID = id;
            InsertEmployeeExprience(empe);
            InsertEmployeeEducationalInformation(empei);
        }

        /// <summary>
        /// افزودن اطلاعات خدمتی فرد برای منابع انسانی
        /// </summary>
        /// <param name="empe">اطلاعات خدمتی مورد نظر</param>
        public void InsertEmployeeExprience(M_EmployeeExprience empe)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertEmployeeExprience(empe);
        }

        /// <summary>
        /// افزودن اطلاعات آموزشی فرد برای منابع انسانی
        /// </summary>
        /// <param name="empei">اطلاعات آموزشی مورد نظر</param>
        public void InsertEmployeeEducationalInformation(M_EmployeeEducationalInformation empei)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertEmployeeEducationalInformation(empei);
        }

        /// <summary>
        /// تابع مربوط به افزودن لیتس از تجهیزات
        /// </summary>
        /// <param name="EqList">لیست تجهیزات مورد نظر</param>
        public void InsertHaveEquipment(List<M_HaveEquipment> EqList)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertHaveEquipment(EqList);
        }

        /// <summary>
        /// درج یک رویداد
        /// </summary>
        /// <param name="ev">رویداد</param>
        public void InsertEvent(M_Event ev)
        {
            ev.LastActionID = 215;
            ev.LastModifyDate = DateTime.Now;
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.InsertEvent(ev);
        }

        /// <summary>
        /// افزودن رویداد مهاجرت
        /// </summary>
        /// <param name="ev">مدل مهاجرت مربوطه</param>
        /// <returns>ای.دی مقدار اضافه شده</returns>
        public int InsertEventMigrations(M_EventMigrations ev)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            ev.CreateDate = DateTime.Now;
            ev.IsActive = true;
            ev.IsDeleted = false;
            ev.IsSent = false;
            return DAL.InsertEventMigrations(ev);
        }
    }
}
