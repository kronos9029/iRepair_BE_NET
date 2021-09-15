using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using iRepair_BE_NET.Models.Constants;

namespace iRepair_BE_NET.Models.Entities
{
    public class Account
    {
        [Key]
        public Guid accountId{ get; set; }
        public string username{ get; set; }
        public string password{ get; set; }
        public string firstName{get; set;}
        public string lastName{get; set;}
        public RoleEnum role{get; set;}

    }
}