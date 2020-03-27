using System.ComponentModel.DataAnnotations;

namespace Vacation_Ready.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Username must be 6 to 16 characters long.")]
        public string Username { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Password must be 6 to 64 characters long.")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}