using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("EmployeeExpriences")]
    public class M_EmployeeExprience
    {
        public M_EmployeeExprience()
        {
            EmployeeExprienxesUID = Guid.NewGuid();
        }
        public int ID { get; set; } // ID (Primary key). آی.دی منحصر به فرد
        public int EmployeeID { get; set; } // EmployeeID. کد پرسنل مورد نظر
        public DateTime StartDate { get; set; } // StartDate. تاریخ شروع به کار
        public int Degree { get; set; } // Degree. مقطع تحصیلی
        public int AcceptableYears { get; set; } // AcceptableYears. سنوات قابل قبول
        public int JobGrade { get; set; } // JobGrade. رسته شغلی
        public int OrganizationalUnit { get; set; } // OrganizationalUnit. واحد سازمانی
        public int ServiceUnitPlace { get; set; } // ServiceUnitPlace. واحد محل خدمت
        public int ServicePostPlace { get; set; } // ServicePostPlace. پست در محل خدمت
        public int ServicePostPlace2 { get; set; } // ServicePostPlace2. پست در محل خدمت
        public int OrganizationalPostTitle { get; set; } // OrganizationalPostTitle. عنوان پست سازمانی
        public int Post { get; set; } // Post. سمت
        public int EmploymentType { get; set; } // EmploymentType نو استخدامی
        public long Salary { get; set; } // Salary حقوق
        public DateTime? LastCertificateDate { get; set; } // LastCertificateDate زمان دریافت آخرین مدرک تحصیلی
        public DateTime CreateDate { get; set; } // CreateDate. تاریخ ایجاد
        public string Description { get; set; } // Description. توضیحات
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. آخرین زمان دسترسی
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public bool IsSent { get; set; } // IsSent. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت فعال یا غیر فعال بودن
        public bool IsDeleted { get; set; } // IsDeleted. وضعیت حذف شدن یا نشدن
        public DateTime? ExpiredDate { get; set; } // ExpiredDate. تاریخ انقضا
        public Guid EmployeeExprienxesUID { get; set; } // EmployeeExprienxesUID. کد منحصر به فرد
    }
}
