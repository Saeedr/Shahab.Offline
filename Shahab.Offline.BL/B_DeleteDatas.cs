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
    public class B_DeleteDatas
    {
        /// <summary>
        /// حذف خانوار بر اثاث ای.دی
        /// </summary>
        /// <returns></returns>
        public void DeleteFamily(int FID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            List<M_FamilyMembers> fm = DAL.GetFamilyMember(FID);
            DAL.DeleteFamilyByFamilyID(FID);
            DeleteAdsress(FID);
            foreach (M_FamilyMembers fmm in fm)
            {
                DeleteFamilyMember(fmm);
            }
        }

        /// <summary>
        /// حذف عضو خانوار بر اثاث ای.دی
        /// </summary>
        /// <returns></returns>
        public void DeleteFamilyMember(M_FamilyMembers FM)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.DeleteFamilyMember(FM);
        }

        /// <summary>
        /// حذف آدرس بر اثاث کد خانوار
        /// </summary>
        /// <returns></returns>
        public void DeleteAdsress(int FamilyID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.DeleteAddressesByFamilyID(FamilyID);
        }

        /// <summary>
        /// حذف پرسنل از لیست منابع انسانی
        /// </summary>
        /// <param name="ID">آی.دی پرسنل مورد نظر</param>
        public void DetelePersonel(int ID)
        {
            DataAccessLayer DAL = new DataAccessLayer();
            DAL.DetelePersonel(ID);
        }
    }
}
