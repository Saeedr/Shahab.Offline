using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Shahab.Offline.Model;
using Shahab.Offline.Logging;
using System.Data.Entity;

namespace Shahab.Offline.DAL
{
    public class DataAccessLayer
    {
        /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////Insert Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        #region توابع مربوطه به افزودن رکورد

        /// <summary>
        /// افزودن خانوار
        /// </summary>
        /// <param name="fml">کلاس خانواده</param>
        /// <returns></returns>
        /// 
        public int InsertFamily(M_Families fml)
        {
            DataBaseContext db = new DataBaseContext();
            fml.LastActionID = 215;
            fml.LastModifiedDate = DateTime.Now;
            db.Families.Add(fml);
            db.SaveChanges();
            return fml.ID;
        }

        /// <summary>
        /// افزودن آدرس برای خانوار
        /// </summary>
        /// <param name="ad">کلاس آدرس خانوار</param>
        public void InsertAddress(M_Address ad)
        {
            DataBaseContext db = new DataBaseContext();
            ad.LastActionID = 215;
            ad.LastModifiedDate = DateTime.Now;
            db.Address.Add(ad);
            db.SaveChanges();
        }

        /// <summary>
        /// افزودن عضو خانوار
        /// </summary>
        /// <param name="fm">کلاس عضو خانوار</param>
        /// <param name="FamilyID">کد خانوار</param>
        /// <param name="CreateDate">تاریخ ایجاد</param>
        public void InsertFamilyMember(M_FamilyMembers fm, int FamilyID, DateTime CreateDate)
        {
            DataBaseContext db = new DataBaseContext();
            fm.LastActionID = 215;
            fm.LastModifiedDate = DateTime.Now;
            db.FamilyMembers.Add(fm);
            db.SaveChanges();
        }

        /// <summary>
        /// افزودن کالکشنی از اعضا
        /// </summary>
        /// <param name="fm">کالکشن مورد نظر</param>
        public void InsertFamilyMember(List<M_FamilyMembers> fm)
        {
            DataBaseContext db = new DataBaseContext();
            foreach(M_FamilyMembers Fm in fm)
            {
                Fm.LastActionID = 215;
                Fm.LastModifiedDate = DateTime.Now;
                Fm.CreateDate = DateTime.Now;
                Fm.IsActive = true;
                db.FamilyMembers.Add(Fm);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// افزودن یک واحد تحت پوشش
        /// </summary>
        /// <param name="plc">واحد مورد نظر</param>
        public void InsertUnitPlace(M_UnitPlace plc)
        {
            DataBaseContext db = new DataBaseContext();
            db.UnitPlace.Where(c => c.PlaceID != plc.PlaceID).Load();
            if (db.UnitPlace.Local.Count == 0)
            {
                plc.LastActionID = 215;
                plc.LastModifiedDate = DateTime.Now;
                db.UnitPlace.Add(plc);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// افزودن یک واحد تحت پوشش
        /// </summary>
        /// <param name="plc">واحدهای مورد نظر</param>
        public void InsertUnitPlace(List<M_UnitPlace> plc)
        {
            foreach(M_UnitPlace up in plc)
            {
                DataBaseContext db = new DataBaseContext();
                db.UnitPlace.Where(c => c.PlaceID != up.PlaceID).Load();
                if (db.UnitPlace.Local.Count == 0)
                {
                    up.LastActionID = 215;
                    up.LastModifiedDate = DateTime.Now;
                    db.UnitPlace.Add(up);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// افزودن مشخصات فردی منابع انسانی
        /// </summary>
        /// <param name="emp">مشخصالت فردی شخص مورد نظر</param>
        public int InsertEmployee(M_Employee emp)
        {
            DataBaseContext db = new DataBaseContext();
            emp.LastActionID = 215;
            emp.LastModifiedDate = DateTime.Now;
            db.Employee.Add(emp);
            db.SaveChanges();
            return emp.ID;
        }

        /// <summary>
        /// افزودن اطلاعات خدمتی فرد برای منابع انسانی
        /// </summary>
        /// <param name="empe">اطلاعات خدمتی مورد نظر</param>
        public void InsertEmployeeExprience(M_EmployeeExprience empe)
        {
            DataBaseContext db = new DataBaseContext();
            empe.LastActionID = 215;
            empe.LastModifiedDate = DateTime.Now;
            db.EmployeeExprience.Add(empe);
            db.SaveChanges();
        }

        /// <summary>
        /// افزودن اطلاعات آموزشی فرد برای منابع انسانی
        /// </summary>
        /// <param name="empei">اطلاعات آموزشی مورد نظر</param>
        public void InsertEmployeeEducationalInformation(M_EmployeeEducationalInformation empei)
        {
            DataBaseContext db = new DataBaseContext();
            empei.LastActionID = 215;
            empei.LastModifiedDate = DateTime.Now;
            db.EmployeeEducationalInformation.Add(empei);
            db.SaveChanges();
        }
        
        /// <summary>
        /// تابع مربوط به افزودن لیتس از تجهیزات
        /// </summary>
        /// <param name="EqList">لیست تجهیزات مورد نظر</param>
        public void InsertHaveEquipment(List<M_HaveEquipment> EqList)
        {
            DataBaseContext db = new DataBaseContext();
            foreach(M_HaveEquipment em in EqList)
            {
                em.LastModifiedDate = DateTime.Now;
            }
            db.HaveEquipment.Load();
            db.HaveEquipment.Local.Clear();
            db.HaveEquipment.AddRange(EqList);
            db.SaveChanges();
        }

        /// <summary>
        /// درج یک رویداد
        /// </summary>
        /// <param name="ev">رویداد</param>
        public void InsertEvent(M_Event ev)
        {
            DataBaseContext db = new DataBaseContext();
            db.Event.Add(ev);
            db.SaveChanges();
        }

        /// <summary>
        /// افزودن رویداد مهاجرت
        /// </summary>
        /// <param name="ev">مدل مهاجرت مربوطه</param>
        /// <returns>ای.دی مقدار اضافه شده</returns>
        public int InsertEventMigrations(M_EventMigrations ev)
        {
            DataBaseContext db = new DataBaseContext();
            db.EventMigrations.Add(ev);
            db.SaveChanges();
            return ev.ID;
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////Insert Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////Update Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        #region توابع مربوطه به ویرایش رکورد

        /// <summary>
        /// ویرایش خانوار
        /// </summary>
        /// <param name="fml">کلاس خانواده</param>
        /// <param name="FamilyID">کد خانوار</param>
        /// <returns></returns>
        public int UpdateFamily(M_Families fml,int FamilyID)
        {
            DataBaseContext db = new DataBaseContext();
            db.Families.Where(c => c.ID == FamilyID).Load();
            db.Families.Local[0].FamilyTypeCode = fml.FamilyTypeCode;
            db.Families.Local[0].HeaderMobileNumber = fml.HeaderMobileNumber;
            db.Families.Local[0].OwnrshipCode = fml.OwnrshipCode;
            db.Families.Local[0].PlaceID = fml.PlaceID;
            db.Families.Local[0].UnitCode = fml.UnitCode;
            db.Families.Local[0].FamilyCode = fml.FamilyCode;
            db.Families.Local[0].LastActionID = 216;
            db.Families.Local[0].LastModifiedDate = DateTime.Now;
            db.SaveChanges();
            return fml.ID;
        }

        /// <summary>
        /// ویرایش آدرس برای خانوار
        /// </summary>
        /// <param name="ad">کلاس آدرس خانوار</param>
        /// <param name="FamilyID">کد خانوار</param>
        public void UpdateAddress(M_Address ad, int FamilyID)
        {
            DataBaseContext db = new DataBaseContext();
            db.Address.Where(c => c.FamilyID == FamilyID).Load();
            db.Address.Local[0].AddressString1 = ad.AddressString1;
            db.Address.Local[0].AddressString2 = ad.AddressString2;
            db.Address.Local[0].AddressString3 = ad.AddressString3;
            db.Address.Local[0].BuildingNumber = ad.BuildingNumber;
            db.Address.Local[0].PlaceID = ad.PlaceID;
            db.Address.Local[0].TelephoneNumber = ad.TelephoneNumber;
            db.Address.Local[0].ZipCode = ad.ZipCode;
            db.Address.Local[0].LastActionID = 216;
            db.Address.Local[0].LastModifiedDate = DateTime.Now;
            db.SaveChanges();
        }

        /// <summary>
        /// ویرایش عضو خانوار
        /// </summary>
        /// <param name="fm">کلاس عضو خانوار</param>
        /// <param name="FamilyMemberID">کد شخص</param>
        public void UpdateFamilyMember(M_FamilyMembers fm, int FamilyMemberID)
        {
            DataBaseContext db = new DataBaseContext();
            db.FamilyMembers.Where(c => c.ID == FamilyMemberID).Load();
            db.FamilyMembers.Local[0].Activity = fm.Activity;
            db.FamilyMembers.Local[0].BirthDate = fm.BirthDate;
            db.FamilyMembers.Local[0].Education = fm.Education;
            db.FamilyMembers.Local[0].FirstInsurance = fm.FirstInsurance;
            db.FamilyMembers.Local[0].FirstName = fm.FirstName;
            db.FamilyMembers.Local[0].Gender = fm.Gender;
            db.FamilyMembers.Local[0].Job = fm.Job;
            db.FamilyMembers.Local[0].LastName = fm.LastName;
            db.FamilyMembers.Local[0].MaritalStatus = fm.MaritalStatus;
            db.FamilyMembers.Local[0].MobileNumber = fm.MobileNumber;
            db.FamilyMembers.Local[0].NationalCode = fm.NationalCode;
            db.FamilyMembers.Local[0].Nationality = fm.Nationality;
            db.FamilyMembers.Local[0].Relationship = fm.Relationship;
            db.FamilyMembers.Local[0].ResidentStatus = fm.ResidentStatus;
            db.FamilyMembers.Local[0].SecondInsurance = fm.SecondInsurance;
            db.FamilyMembers.Local[0].LastActionID = 216;
            db.FamilyMembers.Local[0].LastModifiedDate = DateTime.Now;
            db.SaveChanges();
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
            DataBaseContext db = new DataBaseContext();
            db.Employee.Where(c => c.ID == EmployeeID).Load();
            db.Employee.Local[0].BirthDate = emp.BirthDate;
            db.Employee.Local[0].FirstName = emp.FirstName;
            db.Employee.Local[0].Gender = emp.Gender;
            db.Employee.Local[0].LastName = emp.LastName;
            db.Employee.Local[0].MaritalStatus = emp.MaritalStatus;
            db.Employee.Local[0].NationalCode = emp.NationalCode;
            db.Employee.Local[0].OfficialCode = emp.OfficialCode;
            db.Employee.Local[0].Picture = emp.Picture;
            db.Employee.Local[0].UserCode = emp.UserCode;
            db.Employee.Local[0].UserDescription = emp.UserDescription;
            db.Employee.Local[0].LastActionID = 216;
            db.Employee.Local[0].LastModifiedDate = DateTime.Now;
            db.SaveChanges();
            db.EmployeeExprience.Where(c => c.EmployeeID == EmployeeID).Load();
            db.EmployeeExprience.Local[0].AcceptableYears = empe.AcceptableYears;
            db.EmployeeExprience.Local[0].Degree = empe.Degree;
            db.EmployeeExprience.Local[0].EmploymentType = empe.EmploymentType;
            db.EmployeeExprience.Local[0].LastCertificateDate = empe.LastCertificateDate;
            db.EmployeeExprience.Local[0].OrganizationalPostTitle = empe.OrganizationalPostTitle;
            db.EmployeeExprience.Local[0].OrganizationalUnit = empe.OrganizationalUnit;
            db.EmployeeExprience.Local[0].Post = empe.Post;
            db.EmployeeExprience.Local[0].Salary = empe.Salary;
            db.EmployeeExprience.Local[0].ServicePostPlace = empe.ServicePostPlace;
            db.EmployeeExprience.Local[0].ServicePostPlace2 = empe.ServicePostPlace2;
            db.EmployeeExprience.Local[0].ServiceUnitPlace = empe.ServiceUnitPlace;
            db.EmployeeExprience.Local[0].LastActionID = 216;
            db.EmployeeExprience.Local[0].LastModifiedDate = DateTime.Now;
            db.SaveChanges();
            db.EmployeeEducationalInformation.Where(c => c.EmployeeID == EmployeeID).Load();
            db.EmployeeEducationalInformation.Local[0].CertificationTypeCode = empi.CertificationTypeCode;
            db.EmployeeEducationalInformation.Local[0].CourceDurationTime = empi.CourceDurationTime;
            db.EmployeeEducationalInformation.Local[0].CourseStartTime = empi.CourseStartTime;
            db.EmployeeEducationalInformation.Local[0].CourseTitle = empi.CourseTitle;
            db.EmployeeEducationalInformation.Local[0].EducationalInformationDescription = empi.EducationalInformationDescription;
            db.EmployeeEducationalInformation.Local[0].LastActionID = 216;
            db.EmployeeEducationalInformation.Local[0].LastModifiedDate = DateTime.Now;
            db.SaveChanges();
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////Update Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////Delete Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        #region توابع مربوطه به حذف ایتم
        /// <summary>
        /// حذف خانواده بر اثاث ای.دی خانواده
        /// </summary>
        /// <param name="FamilyID">کد خانوار</param>
        /// <returns></returns>
        public void DeleteFamilyByFamilyID(int FamilyID)
        {
            DataBaseContext db = new DataBaseContext();
            db.Families.Where(c => c.ID == FamilyID).Load();
            db.Families.Local[0].LastActionID = 217;
            db.Families.Local[0].LastModifiedDate = DateTime.Now;
            db.Families.Local[0].IsDeleted = true;
            db.SaveChanges();
        }

        /// <summary>
        /// حذف عضو خانواده
        /// </summary>
        /// <param name="FamilyMember">عضو مورد نظر</param>
        /// <returns></returns>
        public void DeleteFamilyMember(M_FamilyMembers FamilyMember)
        {
            DataBaseContext db = new DataBaseContext();
            db.FamilyMembers.Where(c => c.ID == FamilyMember.ID).Load();
            db.FamilyMembers.Local[0].LastActionID = 217;
            db.FamilyMembers.Local[0].LastModifiedDate = DateTime.Now;
            db.FamilyMembers.Local[0].IsDeleted=true;
            db.SaveChanges();
        }

        /// <summary>
        /// حذف آدرس بر اثاث ای.دی خانواده
        /// </summary>
        /// <param name="FamilyID">کد خانوار</param>
        /// <returns></returns>
        public void DeleteAddressesByFamilyID(int FamilyID)
        {
            DataBaseContext db = new DataBaseContext();
            db.Address.Where(c => c.FamilyID == FamilyID).Load();
            db.Address.Local[0].LastActionID = 217;
            db.Address.Local[0].LastModifiedDate = DateTime.Now;
            db.Address.Local[0].IsDeleted = true;
            db.SaveChanges();
        }

        /// <summary>
        /// حذف پرسنل از لیست منابع انسانی
        /// </summary>
        /// <param name="ID">آی.دی پرسنل مورد نظر</param>
        public void DetelePersonel(int ID)
        {
            DataBaseContext db = new DataBaseContext();
            db.Employee.Where(c => c.ID == ID).Load();
            db.Employee.Local[0].LastActionID = 217;
            db.Employee.Local[0].LastModifiedDate = DateTime.Now;
            db.Employee.Local[0].IsDeleted = true;
            db.EmployeeExprience.Where(c => c.EmployeeID == ID).Load();
            db.EmployeeExprience.Local[0].LastActionID = 217;
            db.EmployeeExprience.Local[0].LastModifiedDate = DateTime.Now;
            db.EmployeeExprience.Local[0].IsDeleted = true;
            db.EmployeeEducationalInformation.Where(c => c.EmployeeID == ID).Load();
            db.EmployeeEducationalInformation.Local[0].LastActionID = 217;
            db.EmployeeEducationalInformation.Local[0].LastModifiedDate = DateTime.Now;
            db.EmployeeEducationalInformation.Local[0].IsDeleted = true;
            db.SaveChanges();
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////Delete Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////Read Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        #region توابع مربوطه به خواندن ایتم

        /// <summary>
        /// گرفتن مقادیر از جدول پالیک کتگوری
        /// </summary>
        /// <param name="id">کد ستون والد</param>
        /// <returns></returns>
        public List<M_PublicCategory> GetPublicCategori(int id)
        {
            DataBaseContext db = new DataBaseContext();
            db.PublicCategory.Where(c => c.PC_REF == id).Load();
            return db.PublicCategory.Local.ToList<M_PublicCategory>();
        }

        /// <summary>
        /// گرفتن مقادیر از جدول پالیک کتگوری با ای.دی
        /// </summary>
        /// <param name="id">ادی مد نظر</param>
        /// <returns></returns>
        public M_PublicCategory GetPublicCategoriByID(int id)
        {
            DataBaseContext db = new DataBaseContext();
            db.PublicCategory.Where(c => c.ID == id).Load();
            try
            {
                return db.PublicCategory.Local.Single<M_PublicCategory>();
            }
            catch { return new M_PublicCategory { ID = 0, PC_Title = "", PC_REF = 0, SiteID = 0 }; }
        }

        /// <summary>
        /// گرفتن کل اعضای خانوار
        /// </summary>
        /// <returns></returns>
        public List<M_FamilyMembers> GetFamilyMember()
        {
            DataBaseContext db = new DataBaseContext();
            db.FamilyMembers.Where(c => c.IsDeleted == false).Load();
            return db.FamilyMembers.Local.ToList<M_FamilyMembers>();
        }

        /// <summary>
        /// گرفتن عضوی از خانوار بر اثاث کد ملی
        /// </summary>
        /// <param name="NationalCode">کد ملی</param>
        /// <returns></returns>
        public M_FamilyMembers GetFamilyMember(string NationalCode)
        {
            DataBaseContext db = new DataBaseContext();
            db.FamilyMembers.Where(c => c.NationalCode == NationalCode).Where(c => c.IsDeleted == false).Load();
            if (db.FamilyMembers.Local.Count > 0)
                return db.FamilyMembers.Local[0];
            else
                return null;
        }

        /// <summary>
        /// گرفتن عضوی از خانوار بر اثاث ای.دی
        /// </summary>
        /// <param name="ID">ای.دی شخص</param>
        /// <param name="Refrense">شناسه متود</param>
        /// <returns></returns>
        public M_FamilyMembers GetFamilyMember(int ID,string Refrense)
        {
            DataBaseContext db = new DataBaseContext();
            db.FamilyMembers.Where(c => c.ID == ID).Where(c => c.IsDeleted == false).Load();
            if (db.FamilyMembers.Local.Count > 0)
                return db.FamilyMembers.Local[0];
            else
                return null;
        }

        /// <summary>
        /// گرفتن اضای خانوار بر اثاث آی.دی خانوار
        /// </summary>
        /// <param name="FamilyID">آی.دی خانواده</param>
        /// <returns></returns>
        public List<M_FamilyMembers> GetFamilyMember(int FamilyID)
        {
            DataBaseContext db = new DataBaseContext();
            db.FamilyMembers.Where(c => c.FamilyID == FamilyID).Where(c => c.IsDeleted == false).Load();
            return db.FamilyMembers.Local.ToList<M_FamilyMembers>();
        }

        /// <summary>
        /// گرفتن خانوار بر اثاث شماره پرونده
        /// </summary>
        /// <param name="FamilyCode">کد خانوار</param>
        /// <returns></returns>
        public List<M_Families> GetFamilyByFamilyCode(int FamilyCode)
        {
            DataBaseContext db = new DataBaseContext();
            db.Families.Where(c => c.FamilyCode == FamilyCode).Where(c => c.IsDeleted == false).Load();
            return db.Families.Local.ToList<M_Families>();
        }

        /// <summary>
        /// گرفتن کل خانوارهای ثبت شده
        /// </summary>
        /// <returns></returns>
        public List<M_Families> GetAllFamily()
        {
            DataBaseContext db = new DataBaseContext();
            db.Families.Where(c => c.IsDeleted == false).Load();
            return db.Families.Local.ToList<M_Families>();
        }

        /// <summary>
        /// دریافت یک آدرس با توجه به کد خانوار
        /// </summary>
        /// <param name="FamilyID">کد خانوار</param>
        /// <returns></returns>
        public M_Address GetAdressByFamilyID(int FamilyID)
        {
            DataBaseContext db = new DataBaseContext();
            db.Address.Where(c => c.FamilyID == FamilyID).Where(c => c.IsDeleted == false).Load();
            return db.Address.Local.Single<M_Address>();
        }

        /// <summary>
        /// دریافت کد با نوجه به نام و کد والد در پابلیک کتگوری
        /// </summary>
        /// <param name="ParentCode">کد والد</param>
        /// <param name="Name">نامو مورد نظر</param>
        /// <returns></returns>
        public M_PublicCategory GetPublicCategoriByNameAndParentCode(int ParentCode, string Name)
        {
            try
            {
                DataBaseContext db = new DataBaseContext();
                db.PublicCategory.Where(c => c.PC_REF == ParentCode && c.PC_Title == Name).Load();
                return db.PublicCategory.Local.Single<M_PublicCategory>();
            }
            catch
            { return new M_PublicCategory(); }
        }

        /// <summary>
        /// دریافت لیست کامل همه تجهیزات موجود و حذف نشده درون انبار
        /// </summary>
        /// <returns></returns>
        public List<M_Equipment> GetEquipment()
        {
            try
            {
                DataBaseContext db = new DataBaseContext();
                db.Equipment.Where(c => c.IsActive == true).Load();
                return db.Equipment.Local.ToList<M_Equipment>();
            }
            catch { return null; }
        }

        /// <summary>
        /// تعداد افراد به تفکیک مقادیر مشخص از پابلیک کتگوری
        /// </summary>
        /// <param name="ParentCode">کد پدر مقدار پابلیک کتگوری</param>
        /// <returns></returns>
        public List<M_ReportFamilyMainChart> GetFamilyMainChart(int ParentCode)
        {
            DataBaseContext db = new DataBaseContext();
            List<M_ReportFamilyMainChart> Result = new List<M_ReportFamilyMainChart>();
            if (ParentCode == 51)
            {
                Result = db.FamilyMembers.Where(c => c.IsDeleted == false).GroupBy(c => c.Education).Select(g => new M_ReportFamilyMainChart { Title = g.Key.ToString(), Value = g.Count() }).ToList<M_ReportFamilyMainChart>();
            }
            else if (ParentCode == 10)
            {
                Result = db.FamilyMembers.Where(c => c.IsDeleted == false).GroupBy(c => c.Gender).Select(g => new M_ReportFamilyMainChart { Title = g.Key.ToString(), Value = g.Count() }).ToList<M_ReportFamilyMainChart>();
            }
            else if (ParentCode == 7)
            {
                Result = db.FamilyMembers.Where(c => c.IsDeleted == false).GroupBy(c => c.Nationality).Select(g => new M_ReportFamilyMainChart { Title = g.Key.ToString(), Value = g.Count() }).ToList<M_ReportFamilyMainChart>();
            }
            else if (ParentCode == 29)
            {
                Result = db.FamilyMembers.Where(c => c.IsDeleted == false).GroupBy(c => c.MaritalStatus).Select(g => new M_ReportFamilyMainChart { Title = g.Key.ToString(), Value = g.Count() }).ToList<M_ReportFamilyMainChart>();
            }
            else if (ParentCode == 35)
            {
                Result = db.FamilyMembers.Where(c => c.IsDeleted == false).GroupBy(c => c.FirstInsurance).Select(g => new M_ReportFamilyMainChart { Title = g.Key.ToString(), Value = g.Count() }).ToList<M_ReportFamilyMainChart>();
            }
            else if (ParentCode == 43)
            {
                Result = db.FamilyMembers.Where(c => c.IsDeleted == false).GroupBy(c => c.SecondInsurance).Select(g => new M_ReportFamilyMainChart { Title = g.Key.ToString(), Value = g.Count() }).ToList<M_ReportFamilyMainChart>();
            }
            return Result;
        }

        /// <summary>
        /// دریافت اطلاعات چارت گزارش خانوار
        /// </summary>
        /// <returns></returns>
        public List<M_ReportFamilyMainChart> GetFamilyMainChart()
        {
            DataBaseContext db = new DataBaseContext();
            List<M_ReportFamilyMainChart> Result = new List<M_ReportFamilyMainChart>();
            Result = db.FamilyMembers.GroupBy(c => c.Education).Select(g => new M_ReportFamilyMainChart { Title = g.Key.ToString(), Value = g.Count() }).ToList<M_ReportFamilyMainChart>();
            Result = (from a in db.UnitPlace
                      join b in db.Address on a.ID equals b.PlaceID
                      select new M_ReportFamilyMainChart
                      {
                          Value = 0,
                          Title = b.PlaceID.ToString()
                      }).ToList<M_ReportFamilyMainChart>();
            return Result;
        }

        /// <summary>
        /// دریافت لیست تمام مناطق تحت پوشش 
        /// </summary>
        /// <returns></returns>
        public List<M_UnitPlace> GetUnitPlaces()
        {
            DataBaseContext db = new DataBaseContext();
            db.UnitPlace.Where(c => c.IsDeleted == false).Load();
            return db.UnitPlace.Local.ToList<M_UnitPlace>();
        }

        /// <summary>
        /// دریافت لیستی از پرسنل موجود
        /// </summary>
        /// <returns></returns>
        public List<M_Employee> GetEmployee()
        {
            DataBaseContext db = new DataBaseContext();
            db.Employee.Where(c => c.IsDeleted == false).Load();
            List<M_Employee> Res = db.Employee.Local.ToList();
            return Res;
        }

        /// <summary>
        /// دریافت لیستی از اطلاعات خدمتی پرسنل موجود
        /// </summary>
        /// <returns></returns>
        public List<M_EmployeeExprience> GetEmployeeExprience()
        {
            DataBaseContext db = new DataBaseContext();
            db.EmployeeExprience.Where(c => c.IsDeleted == false).Load();
            List<M_EmployeeExprience> Res = db.EmployeeExprience.Local.ToList();
            return Res;
        }

        /// <summary>
        /// دریافت لیستی اطلاعات تحصیلی از پرسنل موجود
        /// </summary>
        /// <returns></returns>
        public List<M_EmployeeEducationalInformation> GetEmployeeEducationalInformation()
        {
            DataBaseContext db = new DataBaseContext();
            db.EmployeeEducationalInformation.Where(c => c.IsDeleted == false).Load();
            List<M_EmployeeEducationalInformation> Res = db.EmployeeEducationalInformation.Local.ToList();
            return Res;
        }

        /// <summary>
        /// دریافت لیست تمام تجهیزات اضافه شده
        /// </summary>
        /// <returns></returns>
        public List<M_HaveEquipment> GetHaveEquipment()
        {
            DataBaseContext db = new DataBaseContext();
            db.HaveEquipment.Where(c => c.IsDeleted == false).Load();
            List<M_HaveEquipment> Res = db.HaveEquipment.Local.ToList();
            return Res;
        }

        /// <summary>
        /// دریافت لیتی از تقسیمات کشوری با توجه به کد والد
        /// </summary>
        /// <param name="ParentCode">کد والد</param>
        /// <returns></returns>
        public List<M_CountryDivision> GetCountryDivision(string ParentCode)
        {
            List<M_CountryDivision> Res = new List<M_CountryDivision>();
            DataBaseContext db = new DataBaseContext();
            db.CountryDivision.Where(c => c.ParentAreaCode == ParentCode).Load();
            Res = db.CountryDivision.Local.ToList();
            return Res;
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////Read Methods///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
    }
}
