using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Shahab.Offline.DAL;
using Shahab.Offline.Model;

namespace Shahab.Offline.BL
{
    public class B_ReportPublicCategori
    {
        /// <summary>
        /// دریافت مقادیر لازمه از بانک اطلاعاتی پابلیک کتگوری
        /// </summary>
        /// <param name="ParentID">ای.دی فیلد پدر</param>
        /// <returns></returns>
        public List<M_PublicCategory> GetPublicCategori(int ParentID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_PublicCategory> Res = DAL.GetPublicCategori(ParentID).ToList<M_PublicCategory>();
            return Res;
        }

        /// <summary>
        /// دریافت یک مقدار از پابکیک کتگوری به وسیله آی.دی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static M_PublicCategory GetPublitCategoriByID(int id)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            M_PublicCategory Res = DAL.GetPublicCategoriByID(id);
            return Res;
        }

        /// <summary>
        /// دریافت کد با نوجه به نام و کد والد در پابلیک کتگوری
        /// </summary>
        /// <param name="ParentCode">کد والد</param>
        /// <param name="Name">نامو مورد نظر</param>
        /// <returns></returns>
        public M_PublicCategory GetPublicCategoriByNameAndParentCode(int ParentCode, string Name)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            return DAL.GetPublicCategoriByNameAndParentCode(ParentCode, Name);
        }
    }
}
