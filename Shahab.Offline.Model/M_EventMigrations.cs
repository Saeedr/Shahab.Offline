using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("EventMigrations")]
    public class M_EventMigrations
    {
        public M_EventMigrations()
        {
            IsSent = false;
            IsActive = true;
            IsDeleted = false;
            MigrationUID = Guid.NewGuid();
        }
        public int ID { get; set; } // ID (Primary key). کد منحصر به فرد
        public int ParentPlaceID { get; set; } // ParentPlaceID. کد منطقه بالاسری مقصد مهاجرت
        public int PlaceID { get; set; } // PlaceID. کد مقصد مهاجرت
        public int MigrationReasonCode { get; set; } // MigrationReasonCode. علت مهاجرت
        public int FamilyMemberID { get; set; } // FamilyMemberID. کد شخص مهاجرت کننده
        public DateTime FromDate { get; set; } // FromDate. تاریخ رفت
        public DateTime? ToDate { get; set; } // ToDate. تاریخ برگشت
        public bool IsSent { get; set; } // IsSent. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت فعال یا غیر فعال بودن
        public bool IsDeleted { get; set; } // IsDeleted. وضعیت حذف شدن یا نشدن
        public DateTime? ExpiredDate { get; set; } // ExpiredDate. تاریخ انقضا
        public Guid MigrationUID { get; set; } // MigrationUID. کد منحصر به فرد
        public DateTime CreateDate { get; set; } // CreateDate. تاریخ ایجاد رکورد
        public DateTime? ExpireDate { get; set; } // ExpireDate. تاریخ انقضا رکورد
        public string Description { get; set; } // Description. توضیحات
    }
}
