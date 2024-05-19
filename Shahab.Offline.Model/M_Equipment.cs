using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Equipments")]
    public class M_Equipment
    {
        public M_Equipment()
        {
            EquipmentsUID = Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public long TerminologyCode { get; set; }
        public int InternalTerminologyCode { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public string TerminologyCategory { get; set; }
        public int Version { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public bool IsDeleted { get; set; } // IsDeleted. وضعیت حذف شدن
        public bool IsSend { get; set; } // IsSend. وضعیت ارسال به مرکز
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public DateTime? ExpireDate { get; set; }
        public Guid EquipmentsUID { get; set; }
    }
}
