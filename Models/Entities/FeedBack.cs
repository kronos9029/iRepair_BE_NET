using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Keyless]
    [Table("FeedBack")]
    public partial class FeedBack
    {
        public Guid Id { get; set; }
        [Column("Service_Id")]
        public Guid ServiceId { get; set; }
        [Column("Order_Id")]
        public Guid OrderId { get; set; }
        [Column("Feedback_Point")]
        public int? FeedbackPoint { get; set; }
        [Column("Feedback_Message")]
        [StringLength(250)]
        public string FeedbackMessage { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; }
    }
}
