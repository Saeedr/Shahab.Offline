using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("PublicCategory")]
    public class M_PublicCategory
    {
        /// <summary>
        /// سازنده پیشفرض
        /// </summary>
        public M_PublicCategory()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PC_REF { get; set; }
        public int SiteID { get; set; }
        public string PC_Title { get; set; }
        public string PC_Code { get; set; }
        public string PC_Desc { get; set; }
    }
}
