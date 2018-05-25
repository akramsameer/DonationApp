using System.ComponentModel.DataAnnotations;

namespace ChairtyApplication.Models.ViewModels.Authentication
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string  UserName { get; set; }

        public string NationalId { get; set; }
        public string BloodType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CreditNumber { get; set; }
        public int CreditId { get; set; }
        public int RuleId { get; set; }
    }
}