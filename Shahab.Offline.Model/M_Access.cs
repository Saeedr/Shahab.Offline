using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Access")]
    public class M_Access
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int OrganizationId8Digit { get; set; } // OrganizationID8Digit (Primary key)
        public string OrganizationId { get; set; } // OrganizationID
        public string LongName { get; set; } // LongName
        public int? MarkazOrganizationId8Digit { get; set; } // MarkazOrganizationID8Digit
        public string MarkazOrganizationId { get; set; } // MarkazOrganizationID
        public string MarkazLongName { get; set; } // MarkazLongName
        public int? ShabakeOrganizationId8Digit { get; set; } // ShabakeOrganizationID8Digit
        public string ShabakeOrganizationId { get; set; } // ShabakeOrganizationID
        public string ShabakeLongName { get; set; } // ShabakeLongName
        public int? UniversityOrganizationId8Digit { get; set; } // UniversityOrganizationID8Digit
        public string UniversityOrganizationId { get; set; } // UniversityOrganizationID
        public string UniversityLongName { get; set; } // UniversityLongName
        public string RuralDistinctCode { get; set; } // RuralDistinctCode
        public string CityCode { get; set; } // CityCode
        public string CountyCode { get; set; } // CountyCode
        public string TownshipCode { get; set; } // TownshipCode
        public string ProvinceCode { get; set; } // ProvinceCode
        public string Township { get; set; } // Township
        public string Province { get; set; } // Province
        public string ShortName { get; set; } // ShortName
        public string OrganizationTypeName { get; set; } // OrganizationTypeName
    }
}
