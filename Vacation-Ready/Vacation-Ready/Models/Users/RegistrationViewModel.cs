using System.ComponentModel.DataAnnotations;

namespace Vacation_Ready.Models.Users
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Username must be 6 to 16 characters long.")]
        public string Username { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Password must be 6 to 64 characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Password must include lowercase, uppercase and the last 3 digits of Pi.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(35, ErrorMessage = "First name cannot be more than 35 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, ErrorMessage = "Last name cannot be more than 35 characters long.")]
        public string LastName { get; set; }
    }
}