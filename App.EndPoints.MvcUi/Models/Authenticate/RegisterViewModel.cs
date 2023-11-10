using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Models.Authenticate
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = ":ایمیل")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور:")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "Password and confirm Password are different.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "نام:")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی:")]
        public string LastName { get; set; }

        [Display(Name = "آدرس :")]
        public string? Address { get; set; }

        [Display(Name = "Amin:")]
        public bool IsAdmin { get; set; }
    }
}
