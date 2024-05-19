using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("CountryDivision")]
    public class M_CountryDivision
    {
        public int ID { get; set; } // ID (Primary key)
        public string Code { get; set; } // Code
        public string Value { get; set; } // Value
        public int? AreaTypeCode { get; set; } // AreaTypeCode
        public string ParentAreaCode { get; set; } // ParentAreaCode
        public int? ParentAreaTypeCode { get; set; } // ParentAreaTypeCode
        public string CountryCode { get; set; } // CountryCode
        public int? ProvinceCode { get; set; } // ProvinceCode
        public int? TownshipCode { get; set; } // TownshipCode
        public int? CountyCode { get; set; } // CountyCode
        public int? CityCode { get; set; } // CityCode
        public int? RuralDistinctCode { get; set; } // RuralDistinctCode
        public string Province { get; set; } // Province
        public string Township { get; set; } // Township
        public string County { get; set; } // County
        public string City { get; set; } // City
        public string RuralDistinct { get; set; } // RuralDistinct
    }
}
