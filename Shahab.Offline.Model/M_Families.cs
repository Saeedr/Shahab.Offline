using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Families")]
    public class M_Families
    {
        public M_Families()
        {
            FamilyUID = Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } // ID (Primary key)
        public int FamilyCode { get; set; } // FamilyCode. کد خانوار
        public int FamilyTypeCode { get; set; } // FamilyTypeCode. نوع خانوار
        public int PlaceID { get; set; } // PlaceID. کد روستایی که خانوار در آن مستقر می باشد. از جدول CountryDivision استخراج می شود
        public int OwnrshipCode { get; set; } // OwnrshipCode. نوع مالکیت مسکن
        public long UnitCode { get; set; } // UnitCode. کد خانه یا پایگاه بهداشت
        public Guid FamilyUID { get; set; } // FamilyUID. کد جی.یو.آیدی
        public DateTime CreateDate { get; set; } // CreateDate. تاریخ ایجاد
        public DateTime? ExpireDate { get; set; } // ExpireDate. تاریخ انقضا
        public string Description { get; set; } // Description. توضیحات
        public string HeaderMobileNumber { get; set; } // HeaderMobileNumber. شماره تماس سرپرست خانوار
        public bool IsDeleted { get; set; } //IsDeleted. وضعیت حذف شدن یا نشدن
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. تاریخ آخرین عملیات انجام شده
        public bool IsSend { get; set; } // IsSend. وضعیت ارسال
        public bool IsActive { get; set; } // IsActive. وضعیت
        public DateTime? LastModifyDate { get; set; } // LastModifyDate

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool IsValid { get; set; }
    }
}
