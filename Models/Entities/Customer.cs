using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("Customer")]
    [Index(nameof(Email), Name = "IX_Customer_EMAIL", IsUnique = true)]
    [Index(nameof(Username), Name = "UK_Customer_USERNAME", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Avatar { get; set; }
        [Required]
        [Column("Phone_Number")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Column("Create_Date", TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column("Full_Name")]
        [StringLength(50)]
        public string FullName { get; set; }

        [InverseProperty(nameof(Address.Customer))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
