using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("UnitPlaces")]
    public class M_UnitPlace
    {
        public M_UnitPlace()
        {
            UnitPlacesUID = Guid.NewGuid();
            IsAdded = false;
        }
        public int ID { get; set; } // ID (Primary key)
        public long UnitCode { get; set; } // UnitCode
        public int PlaceID { get; set; } // PlaceID
        public int PlaceTypeID { get; set; }
        public string PlaceName { get; set; } // PlaceName
        public Guid UnitPlacesUID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Discription { get; set; }
        public int? ParentPlaceCode { get; set; } // ParentPlaceCode
        public bool IsDeleted { get; set; } // IsDeleted
        public bool IsSend { get; set; } // IsSend. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. تاریخ آخرین عملیات انجام شده

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool IsAdded { get; set; }
    }
}
