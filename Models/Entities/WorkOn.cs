using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("WorkOn")]
    public partial class WorkOn
    {
        [Key]
        [Column("Repairman_Id")]
        public Guid RepairmanId { get; set; }
        [Key]
        [Column("Service_Id")]
        public Guid ServiceId { get; set; }
        public int? Status { get; set; }

        [ForeignKey(nameof(RepairmanId))]
        [InverseProperty(nameof(RepairMan.WorkOns))]
        public virtual RepairMan Repairman { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("WorkOns")]
        public virtual Service Service { get; set; }
    }
}
