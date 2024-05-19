using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
  
    [System.ComponentModel.DataAnnotations.Schema.Table("Addresses")]
    public class M_Address
    {
        public M_Address()
        {
            AddressesUID = Guid.NewGuid();
        }
        public int ID { get; set; } // ID (Primary key)
        public int FamilyID { get; set; } // ID (Primary key)
        public string AddressString1 { get; set; } // AddressString1
        public string AddressString2 { get; set; } // AddressString2
        public string AddressString3 { get; set; } // AddressString3
        public int BuildingNumber { get; set; } // BuildingNumber
        public string ZipCode { get; set; } // ZipCode
        public string TelephoneNumber { get; set; } // TelephoneNumber
        public DateTime CreateDate { get; set; } // CreateDate
        public DateTime? ExpireDate { get; set; } // ExpireDate
        public string Description { get; set; } // Description
        public int PlaceID { get; set; } // PlaceID
        public Guid? AddressesUID { get; set; } // AddressesUID
        public bool IsDeleted { get; set; } // IsDeleted. وضعیت حذف شدن
        public bool IsSend { get; set; } // IsSend. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. تاریخ آخرین عملیات انجام شده

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int FamilyIDNotMap { get; set; }
    }
}
