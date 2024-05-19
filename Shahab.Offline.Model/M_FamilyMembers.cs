using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("FamilyMembers")]
    public class M_FamilyMembers
    {
        public M_FamilyMembers()
        {
            FamilyMembersUID = Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("ID")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
        public int Nationality { get; set; }
        public int Gender { get; set; }
        public int FirstInsurance { get; set; }
        public int SecondInsurance { get; set; }
        public int Education { get; set; }
        public int Relationship { get; set; }
        public int Activity { get; set; }
        public int Job { get; set; }
        public int MaritalStatus { get; set; }
        public int ResidentStatus { get; set; }
        public string MobileNumber { get; set; }
        public int FamilyID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Description { get; set; }
        public Guid FamilyMembersUID { get; set; }
        public bool IsDeleted { get; set; } //IsDeleted. وضعیت حذف شدن یا نشدن
        public bool IsSend { get; set; } // IsSend. وضعیت ارسال به مرکز
        public bool IsActive { get; set; } // IsActive. وضعیت
        public int? LastActionID { get; set; } // LastActionID. نوع آخرین عملیات انجام شده
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate. تاریخ آخرین عملیات انجام شده

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int FamilyIDNotMap { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public String NameAndFamily { get; set; }
    }
}
