using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("HaveEquipments")]
    public class M_HaveEquipment
    {
        public M_HaveEquipment()
        {
            EquipmentUID = Guid.NewGuid();
        }
        public int ID { get; set; } // ID (Primary key)
        public int EquipmentID { get; set; } // EquipmentID
        public string Name { get; set; } // Name
        public string EquipmentDescription { get; set; } // EquipmentDescription
        public int EquipmentCount { get; set; } // EquipmentCount
        public int EquipmentStatus { get; set; } // EquipmentStatus
        public DateTime CreateDate { get; set; } // CreateDate. تاریخ ایجاد
        public string Description { get; set; } // Description. توضیحات
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. آخرین زمان دسترسی
        public bool IsSent { get; set; } // IsSent. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت فعال یا غیر فعال بودن
        public bool IsDeleted { get; set; } // IsDeleted. وضعیت حذف شدن یا نشدن
        public DateTime? ExpiredDate { get; set; } // ExpiredDate. تاریخ انقضا
        public Guid EquipmentUID { get; set; } // EquipmentUID. کد منحصر به فرد
    }
}
