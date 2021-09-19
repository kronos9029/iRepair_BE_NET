using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Keyless]
    [Table("OrderEvidence")]
    public partial class OrderEvidence
    {
        public Guid? Id { get; set; }
        public string Image { get; set; }
        [Column("Order_Id")]
        public Guid? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
    }
}
