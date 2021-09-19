using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iRepair_BE_NET.Models.Constants;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("Service_Id")]
        public Guid ServiceId { get; set; }
        [Column("Repairman_Id")]
        public Guid RepairmanId { get; set; }
        [Column("Customer_Id")]
        public Guid CustomerId { get; set; }
        [Column("Create_Time", TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        [Column("Payment_Time", TypeName = "datetime")]
        public DateTime PaymentTime { get; set; }
        public double Total { get; set; }
        [Required]
        [Column("Customer_Address")]
        [StringLength(250)]
        public string CustomerAddress { get; set; }
        [Column("Feedback_Point")]
        public int? FeedbackPoint { get; set; }
        [Column("Feedback_Message")]
        [StringLength(250)]
        public string FeedbackMessage { get; set; }
        [Column("Status")]
        [StringLength(50)]
        public StatusEnum Status { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(RepairmanId))]
        [InverseProperty(nameof(RepairMan.Orders))]
        public virtual RepairMan Repairman { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("Orders")]
        public virtual Service Service { get; set; }
        [InverseProperty(nameof(OrderHistory.Order))]
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
