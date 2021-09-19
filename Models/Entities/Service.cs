using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("Service")]
    public partial class Service
    {
        public Service()
        {
            Orders = new HashSet<Order>();
            WorkOns = new HashSet<WorkOn>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("Company_Id")]
        public Guid CompanyId { get; set; }
        [Column("Field_Id")]
        public Guid FieldId { get; set; }
        [Column("Service_Name")]
        [StringLength(50)]
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Picture { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty("Services")]
        public virtual Company Company { get; set; }
        [ForeignKey(nameof(FieldId))]
        [InverseProperty(nameof(MajorField.Services))]
        public virtual MajorField Field { get; set; }
        [InverseProperty(nameof(Order.Service))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(WorkOn.Service))]
        public virtual ICollection<WorkOn> WorkOns { get; set; }
    }
}
