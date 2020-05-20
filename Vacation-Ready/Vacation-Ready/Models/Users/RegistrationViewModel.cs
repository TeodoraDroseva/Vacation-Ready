using System.ComponentModel.DataAnnotations;

namespace Vacation_Ready.Models.Users
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Please enter username.")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Username must be 6 to 16 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "Password must be 6 to 64 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        [StringLength(35, ErrorMessage = "First name cannot be more than 35 characters long.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [StringLength(35, ErrorMessage = "Last name cannot be more than 35 characters long.")]
        public string LastName { get; set; }
    }
}