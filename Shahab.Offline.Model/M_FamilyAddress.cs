using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("FamilyAddress")]
    public class M_FamilyAddress
    {
        public M_FamilyAddress()
        {
            FamilyAddressUID = Guid.NewGuid();
        }

        public int Id { get; set; } // ID (Primary key)
        public int FamilyId { get; set; } // FamilyID. کلید اصلی خانوار
        public int PlaceCode { get; set; } // PlaceCode. کد روستا یا شهر
        public bool? CurrentPlace { get; set; } // CurrentPlace. آیا خانوار در این آدرس مستقر است؟
        public DateTime? StartDate { get; set; } // StartDate. ابتدای تاریخ اقامت
        public DateTime? EndDate { get; set; } // EndDate. انتهای تاریخ اقامت
        public string Description { get; set; } // Description. توضیحات
        public Guid FamilyAddressUID { get; set; }
    }
}
