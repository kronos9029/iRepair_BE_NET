using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iRepair_BE_NET.Models.Constants;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("OrderHistory")]
    public partial class OrderHistory
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Order_Id")]
        public Guid OrderId { get; set; }
        [Column("Update_Time", TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        [Column("Update_By")]
        [StringLength(50)]
        public string UpdateBy { get; set; }
        [Column("Status_From")]
        [StringLength(50)]
        public StatusEnum StatusFrom { get; set; }
        [Column("Status_To")]
        [StringLength(50)]
        public StatusEnum StatusTo { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderHistories")]
        public virtual Order Order { get; set; }
    }
}
