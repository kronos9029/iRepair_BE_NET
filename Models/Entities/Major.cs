using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Table("Major")]
    public partial class Major
    {
        public Major()
        {
            MajorFields = new HashSet<MajorField>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(10)]
        public string Picture { get; set; }

        [InverseProperty(nameof(MajorField.Major))]
        public virtual ICollection<MajorField> MajorFields { get; set; }
    }
}
