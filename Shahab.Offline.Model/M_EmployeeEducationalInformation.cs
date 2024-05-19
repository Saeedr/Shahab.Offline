using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("EmployeeEducationalInformations")]
    public class M_EmployeeEducationalInformation
    {
        public M_EmployeeEducationalInformation()
        {
            EmployeeEducationalInformationsUID = Guid.NewGuid();
        }
        public int ID { get; set; } // ID (Primary key). آی.دی منحصر به فرد
        public int EmployeeID { get; set; } // EmployeeID. کد پرسنل مورد نظر
        public string CourseTitle { get; set; } // CourseTitle. عنوان دوره
        public DateTime? CourseStartTime { get; set; } // CourseStartTime. تاریخ شروع دوره
        public int? CourceDurationTime { get; set; } // CourceDurationTime. طول مدت دوره
        public int? CertificationTypeCode { get; set; } // CertificationTypeCode
        public string EducationalInformationDescription { get; set; } // EducationalInformationDescription. توضیحات مربوطه
        public DateTime CreateDate { get; set; } // CreateDate. تاریخ ایجاد
        public string Description { get; set; } // Description. توضیحات
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. آخرین زمان دسترسی
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public bool IsSent { get; set; } // IsSent. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت فعال یا غیر فعال بودن
        public bool IsDeleted { get; set; } // IsDeleted. وضعیت حذف شدن یا نشدن
        public DateTime? ExpiredDate { get; set; } // ExpiredDate. تاریخ انقضا
        public Guid EmployeeEducationalInformationsUID { get; set; } // EmployeeEducationalInformationsUID. کد منحصر به فرد
    }
}
