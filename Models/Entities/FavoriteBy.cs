using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Keyless]
    [Table("FavoriteBy")]
    public partial class FavoriteBy
    {
        [Column("Customer_Id")]
        public Guid? CustomerId { get; set; }
        [Column("Repairman_Id")]
        public Guid? RepairmanId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(RepairmanId))]
        public virtual RepairMan Repairman { get; set; }
    }
}
