using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("Address")]
    public partial class Address
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Customer_Id")]
        public Guid CustomerId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column("Is_Default")]
        [MaxLength(1)]
        public byte[] IsDefault { get; set; }
        [StringLength(250)]
        public string Detail { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Addresses")]
        public virtual Customer Customer { get; set; }
    }
}
