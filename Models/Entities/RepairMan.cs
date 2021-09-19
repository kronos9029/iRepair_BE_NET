using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("RepairMan")]
    [Index(nameof(Email), Name = "UK_RepairMan_Email", IsUnique = true)]
    [Index(nameof(PhoneNumber), Name = "UK_RepairMan_Phone", IsUnique = true)]
    [Index(nameof(Email), Name = "UK_RepairMan_Username", IsUnique = true)]
    public partial class RepairMan
    {
        public RepairMan()
        {
            Orders = new HashSet<Order>();
            WorkOns = new HashSet<WorkOn>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Avatar { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("Phone_Number")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Column("Is_Online")]
        public int? IsOnline { get; set; }
        [Column("Company_Id")]
        public Guid? CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty("RepairMen")]
        public virtual Company Company { get; set; }
        [InverseProperty(nameof(Order.Repairman))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(WorkOn.Repairman))]
        public virtual ICollection<WorkOn> WorkOns { get; set; }
    }
}
