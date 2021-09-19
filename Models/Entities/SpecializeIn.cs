using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace iRepair_BE_NET.Models.Entities
{
    [Keyless]
    [Table("SpecializeIn")]
    public partial class SpecializeIn
    {
        [Column("Company_Id")]
        public Guid? CompanyId { get; set; }
        [Column("Major_Id")]
        public Guid? MajorId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
        [ForeignKey(nameof(MajorId))]
        public virtual Major Major { get; set; }
    }
}
