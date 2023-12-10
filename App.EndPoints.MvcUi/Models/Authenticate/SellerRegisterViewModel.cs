using App.Domain.Core._User.Dtos.ProvinceDto;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Models.Authenticate
{
    public class SellerRegisterViewModel
    {

        #region SellerViewModel
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
        #endregion

        #region SellerViewModel

        [Required(ErrorMessage = "نام خود را وارد نکرده اید.")]
        [Display(Name = "نام:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " نام خانوادگی را وارد نکرده اید.")]
        [Display(Name = "نام خانوادگی:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = " شبا بانکی را وارد نکرده اید.")]
        [Display(Name = "شبا بانکی :")]
        [MaxLength(26, ErrorMessage = " شبا بانکی را بررسی کنید.")]
        [RegularExpression(@"^(?:IR)(?=.{24}$)[0-9]*$", ErrorMessage = "شماره شبا معتبر نمی باشد.")]
        public string ShabaNumber { get; set; }
        #endregion

        #region AddressViewModel 
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
        [MaxLength(10, ErrorMessage = "کد پستی را به اشتباه وارد کرده اید.")]
        public string? PostalCode { get; set; }
        #endregion

        #region BoothViewModel
        [Required(ErrorMessage = "نام غرفه را وارد نکرده اید.")]
        [Display(Name = "نام غرفه:")]
        public string BoothName { get; set; }

        [Required(ErrorMessage = "غرفه خود را معرفی کنید.")]
        [Display(Name = "توضیحات:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "یک تصویر برای آواتار غرفه انتخاب کنید.")]
        [Display(Name = "آواتار:")]
        public IFormFile BoothAvatar { get; set; }
        #endregion


        public List<ProvinceOutputDto>? provinces { get; set; }



    }
}
