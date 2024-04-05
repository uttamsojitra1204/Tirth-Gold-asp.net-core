using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace Tirth_Gold.Models
{
    public class LoginModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
