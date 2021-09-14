using System;
using Microsoft.EntityFrameworkCore;

namespace iRepair_BE_NET.Models.Entities
{
    [Owned]
    public class RefreshToken
    {
        public int Id{get; set;}

        public string Token{get; set;}
        public DateTime Expires{get; set;}
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created{get; set;}
        public DateTime Revoked{get; set;}
        public string RevokedByip{get; set;}
        public string ReplacedByToken{get; set;}
        public bool IsActive => Revoked == null && !IsExpired;


    }
}