using System.ComponentModel.DataAnnotations;

namespace GymWebsite.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public required string Username { get; set; } // Username should be non-nullable

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
