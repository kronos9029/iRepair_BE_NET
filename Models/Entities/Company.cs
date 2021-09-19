using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            RepairMen = new HashSet<RepairMan>();
            Services = new HashSet<Service>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("Company_Name")]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column("Is_Online")]
        [MaxLength(1)]
        public byte[] IsOnline { get; set; }
        [StringLength(11)]
        public string Hotline { get; set; }
        public string Picture { get; set; }

        [InverseProperty(nameof(RepairMan.Company))]
        public virtual ICollection<RepairMan> RepairMen { get; set; }
        [InverseProperty(nameof(Service.Company))]
        public virtual ICollection<Service> Services { get; set; }
    }
}
