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
    public class B_GetDatas
    {
        /// <summary>
        /// دریافت کل افراد ثبت شده
        /// </summary>
        /// <returns></returns>
        public List<M_FamilyMembers> GetFamilyMember()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_FamilyMembers> fm = DAL.GetFamilyMember();
            return fm;
        }

        /// <summary>
        /// دریافت یک شخص با توجه به کد ملی
        /// </summary>
        /// <param name="NationalCode">کد ملی</param>
        /// <returns></returns>
        public M_FamilyMembers GetFamilyMember(string NationalCode)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_FamilyMembers fm = DAL.GetFamilyMember(NationalCode);
            return fm;
        }

        /// <summary>
        /// دریافت یک شخص با توجه به ای دی
        /// </summary>
        /// <param name="ID">کد ملی</param>
        /// <param name="Refrense">شناسه متود</param>
        /// <returns></returns>
        public M_FamilyMembers GetFamilyMember(int ID, string Refrense)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_FamilyMembers fm = DAL.GetFamilyMember(ID, "None");
            return fm;
        }

        /// <summary>
        /// دریافت اعضای خانواده با توجه به کد خانواده
        /// </summary>
        /// <param name="FamilyID">کد خانواده</param>
        /// <returns></returns>
        public List<M_FamilyMembers> GetFamilyMember(int FamilyID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_FamilyMembers> fm = DAL.GetFamilyMember(FamilyID);
            return fm;
        }

        /// <summary>
        /// دریافت کل خانوار ثبت شده
        /// </summary>
        /// <returns></returns>
        public List<M_Families> GetFamily()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_Families> fm = DAL.GetAllFamily();
            return fm;
        }

        /// <summary>
        /// دریافت یک خانوار با توجه به کد خانوار
        /// </summary>
        /// <param name="NationalCode">کد خانوار</param>
        /// <returns></returns>
        public List<M_Families> GetFamily(int FamilyCode)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_Families> fm = DAL.GetFamilyByFamilyCode(FamilyCode);
            return fm;
        }


        /// <summary>
        /// دریافت یک آدرس با توجه به کد خانوار
        /// </summary>
        /// <param name="FamilyID">کد خانوار</param>
        /// <returns></returns>
        public M_Address GetAdressByFamilyID(int FamilyID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_Address fm = DAL.GetAdressByFamilyID(FamilyID);
            return fm;
        }

        /// <summary>
        /// دریافت لیست کامل همه تجهیزات موجود و حذف نشده درون انبار
        /// </summary>
        /// <returns></returns>
        public List<M_Equipment> GetEquipment ()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetEquipment();
        }

        /// <summary>
        /// درسافت لیست مقادیر چارت گزارش خانوار
        /// </summary>
        /// <param name="ParentCode"></param>
        /// <returns></returns>
        public List<M_ReportFamilyMainChart> GetFamilyMainChart(int ParentCode)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_ReportFamilyMainChart> Result1 = DAL.GetFamilyMainChart(ParentCode);
            List<M_ReportFamilyMainChart> Result2 = new List<M_ReportFamilyMainChart>();
            B_GetDatas BG = new B_GetDatas();
            int Counter = 0;
            foreach (M_ReportFamilyMainChart li in Result1)
            {
                M_PublicCategory mp = B_ReportPublicCategori.GetPublitCategoriByID(int.Parse(li.Title.Trim()));
                if (mp.PC_Title != "")
                {
                    Result2.Add(new M_ReportFamilyMainChart { Title = mp.PC_Title, Value = li.Value });
                }
                else
                {
                    Counter++;
                }
            }
            if (Counter > 0)
            {
                Result2.Add(new M_ReportFamilyMainChart { Title = "نا مشخص", Value = Counter });
            }
            //DAL.GetFamilyMainChart();
            return Result2;
        }

        /// <summary>
        /// دریافت لیست تمام مناطق تحت پوشش
        /// </summary>
        /// <returns></returns>
        public List<M_UnitPlace> GetUnitPlaces()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetUnitPlaces();
        }

        /// <summary>
        /// دریافت لیستی از پرسنل موجود
        /// </summary>
        /// <returns></returns>
        public List<M_Employee> GetEmployee()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetEmployee();
        }

        /// <summary>
        /// دریافت لیستی از اطلاعات خدمتی پرسنل موجود
        /// </summary>
        /// <returns></returns>
        public List<M_EmployeeExprience> GetEmployeeExprience()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetEmployeeExprience();
        }

        /// <summary>
        /// دریافت لیستی اطلاعات تحصیلی از پرسنل موجود
        /// </summary>
        /// <returns></returns>
        public List<M_EmployeeEducationalInformation> GetEmployeeEducationalInformation()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetEmployeeEducationalInformation();
        }

        /// <summary>
        /// دریافت لیست تمام تجهیزات اضافه شده
        /// </summary>
        /// <returns></returns>
        public List<M_HaveEquipment> GetHaveEquipment()
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetHaveEquipment();
        }


        /// <summary>
        /// دریافت لیتی از تقسیمات کشوری با توجه به کد والد
        /// </summary>
        /// <param name="ParentCode">کد والد</param>
        /// <returns></returns>
        public List<M_CountryDivision> GetCountryDivision(string ParentCode)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetCountryDivision(ParentCode);
        }
    }
}
