using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Employees")]
    public class M_Employee
    {
        public M_Employee()
        {
            EmployeeUID = Guid.NewGuid();
        }
        public int ID { get; set; } // ID (Primary key). آی.دی منحصر به فرد
        public string FirstName { get; set; } // FirstName. نام
        public string LastName { get; set; } // LastName. نام خانوادگی
        public string NationalCode { get; set; } // NationalCode. کد ملی
        public DateTime BirthDate { get; set; } // BirthDate. تاریخ تولد
        public int Gender { get; set; } // Gender. جنسیت
        public int MaritalStatus { get; set; } // MaritalStatus. وضعیت تاهل
        public string UserCode { get; set; } // UserCode. کد مستخدم
        public string OfficialCode { get; set; } // OfficialCode. کد نظام
        public string UserDescription { get; set; } // UserDescription. توضیحات مربوطه
        public byte[] Picture { get; set; } // Picture
        public DateTime CreateDate { get; set; } // CreateDate. تاریخ ایجاد
        public string Description { get; set; } // Description. توضیحات
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. آخرین زمان دسترسی
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public bool IsSent { get; set; } // IsSent. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت فعال یا غیر فعال بودن
        public bool IsDeleted { get; set; } // IsDeleted. وضعیت حذف شدن یا نشدن
        public DateTime? ExpiredDate { get; set; } // ExpiredDate. تاریخ انقضا
        public Guid EmployeeUID { get; set; } // EmployeeUID. کد منحصر به فرد
    }
}
