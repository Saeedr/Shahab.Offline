using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shahab.Offline.Model;

namespace Shahab.Offline.DAL
{
    public class DataBaseContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// سازنده پیشفرض کلاس
        /// درصورت ایجاد تغییر در پراپرتی های کلاس های موجودیت بانک اطلاعاتی بازسازی خواهد شد
        /// </summary>
        static DataBaseContext()
        {
            //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DataBaseContext>());
            //System.Data.Entity.Database.SetInitializer(new dbInitial());
        }
        public System.Data.Entity.DbSet<M_FamilyMembers> FamilyMembers { get; set; }
        public System.Data.Entity.DbSet<M_PublicCategory> PublicCategory { get; set; }
        public System.Data.Entity.DbSet<M_Address> Address { get; set; }
        public System.Data.Entity.DbSet<M_Families> Families { get; set; }
        public System.Data.Entity.DbSet<M_FamilyAddress> FamilyAddress { get; set; }
        public System.Data.Entity.DbSet<M_UnitPlace> UnitPlace { get; set; }
        public System.Data.Entity.DbSet<M_Access> Access { get; set; }
        public System.Data.Entity.DbSet<M_Equipment> Equipment { get; set; }
        public System.Data.Entity.DbSet<M_HaveEquipment> HaveEquipment { get; set; }
        public System.Data.Entity.DbSet<M_Employee> Employee { get; set; }
        public System.Data.Entity.DbSet<M_EmployeeExprience> EmployeeExprience { get; set; }
        public System.Data.Entity.DbSet<M_EmployeeEducationalInformation> EmployeeEducationalInformation { get; set; }
        public System.Data.Entity.DbSet<M_Event> Event { get; set; }
        public System.Data.Entity.DbSet<M_CountryDivision> CountryDivision { get; set; }
        public System.Data.Entity.DbSet<M_EventMigrations> EventMigrations { get; set; }
    }
}
