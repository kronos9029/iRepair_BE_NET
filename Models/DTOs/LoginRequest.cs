using System.ComponentModel.DataAnnotations;

namespace iRepair_BE_NET.Models.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string username;
        [Required]
        public string password;
    }
}