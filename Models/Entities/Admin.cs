using System;
using System.ComponentModel.DataAnnotations;
using iRepair_BE_NET.Models.Constants;

namespace iRepair_BE_NET.Models.Entities
{
    public class Admin
    {
        [Key]
        public Guid accountId{ get; set; }
        public string username{ get; set; }
        public string password{ get; set; }
        public RoleEnum role{get;}
    }
}