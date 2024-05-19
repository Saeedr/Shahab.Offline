using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Events")]
    public class M_Event
    {
        public M_Event()
        {
            EventUID = Guid.NewGuid();
        }
        public int ID { get; set; } // ID (Primary key)
        public string FirstName { get; set; } // FirstName. نام
        public string LastName { get; set; } // LastName. نام خانوادگی
        public string NationalCode { get; set; } // NationalCode. کد ملی
        public DateTime BirthDate { get; set; } // BirthDate. تاریخ تولد
        public int Nationality { get; set; } // Nationality. ملیت
        public int Gender { get; set; } // Gender. جنسیت
        public int FirstInsurance { get; set; } // FirstInsurance. نوع بیمه اول
        public int SecondInsurance { get; set; } // SecondInsurance. نوع بیمه دوم
        public int Education { get; set; } // Education. تحصیلات
        public int? Relationship { get; set; } // Relationship. نسبت با سرپرست
        public int Activity { get; set; } // Activity. نوع فعالیت
        public int Job { get; set; } // Job. شغل
        public int MaritalStatus { get; set; } // MaritalStatus. وضعیت تاهل
        public int ResidentStatus { get; set; } // ResidentStatus. وضعیت اقامت
        public string MobileNumber { get; set; } // MobileNumber. شماره همراه
        public int FamilyID { get; set; } // FamilyID. کد خانوار
        public DateTime CreateDate { get; set; } // CreateDate. تاریخ ایجاد
        public DateTime? ExpireDate { get; set; } // ExpireDate. تاریخ انقضا
        public DateTime? DeathDate { get; set; } // DeathDate. تاریخ مرگ
        public int LastActionID { get; set; } // LastActionID. آخرین نوع تغییر
        public string Description { get; set; } // Description. توضیحات
        public Guid FamilyMembersUID { get; set; } // FamilyMembersUID. کد جی.یو.آی.دی
        public DateTime OccuredDate { get; set; } // OccuredDate. زمان وقوع
        public DateTime EventCreateDate { get; set; } // EventCreateDate. زمان ایجاد رویداد
        public Guid EventUID { get; set; } // EventUID. کی جی.یو.آی.دی رویداد
        public int MasterID { get; set; } // MasterID. نوع رویداد
        public string Organization8DigitID { get; set; } // Organization8DigitID. کد 8 رقمی
        public bool IsSend { get; set; } // IsSend. وضعیت ارسال
        public bool IsActive { get; set; } // IsActive. وضعیت
        public int EventID { get; set; } // EventID. کد واقعه
        public bool IsDeleted { get; set; } //IsDeleted. وضعیت حذف شدن یا نشدن
        public DateTime? LastModifyDate { get; set; } //LastModifyDate. آخرین زمان تغییرات
    }
}
