using App.Domain.Core._User.Dtos.ProvinceDto;
using App.Domain.Core._User.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Models.Authenticate
{
    public class CustomerRegisterViewModel
    {
        [EmailAddress]
        [Display(Name = ":ایمیل")]
        [Required(ErrorMessage = "ایمیل وارد نشده است.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید.")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "رمز عبور باید تکرار شود")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن تطابق ندارد")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "نام خود را وارد نکرده اید.")]
        [Display(Name = "نام:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " نام خانوادگی را وارد نکرده اید.")]
        [Display(Name = "نام خانوادگی:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "نام استان را انتخاب کنید.")]
        [Display(Name = "استان :")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "نام شهر را وارد نکرده اید.")]
        [Display(Name = "شهر :")]
        public string? City { get; set; }

        [Required(ErrorMessage = "لطفا جزئیات آدرس خود را کامل کنید.")]
        [Display(Name = "آدرس :")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "لطفا کد پستی را کامل کنید.")]
        [Display(Name = "کد پستی :")]
        [MaxLength(10,ErrorMessage = "کد پستی را به اشتباه وارد کرده اید.")]
        public string? PostalCode { get; set; }

        public List<ProvinceOutputDto>? provinces { get; set; }


    }
}
