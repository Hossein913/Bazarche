using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Models.Authenticate
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "فیلد نام کاربری نمی تواند خالی باشد.")]
        [EmailAddress]
        [Display(Name = "نام کاربری")]
        public string Email { get; set; }

        [Required(ErrorMessage ="فیلد رمز عبور نمی تواند خالی باشد.")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
