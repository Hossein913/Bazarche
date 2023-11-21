using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Models.Authenticate
{
    public class CustomerRegisterViewModel
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
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن با هم مطابقت ندارد")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "نام:")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی:")]
        public string LastName { get; set; }

        [Display(Name = "آدرس :")]
        public string? Address { get; set; }

    }
}
