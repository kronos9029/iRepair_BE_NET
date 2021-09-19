using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("MajorField")]
    public partial class MajorField
    {
        public MajorField()
        {
            Services = new HashSet<Service>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Description { get; set; }
        [Column("Major_Id")]
        public Guid? MajorId { get; set; }
        [StringLength(50)]
        public string Picture { get; set; }

        [ForeignKey(nameof(MajorId))]
        [InverseProperty("MajorFields")]
        public virtual Major Major { get; set; }
        [InverseProperty(nameof(Service.Field))]
        public virtual ICollection<Service> Services { get; set; }
    }
}
