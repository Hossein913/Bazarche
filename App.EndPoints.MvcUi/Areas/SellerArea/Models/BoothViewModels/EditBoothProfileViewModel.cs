using App.Domain.Core._Common.Entities;
using App.Domain.Core._User.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels
{
    public class EditBoothProfileViewModel
    {
        [DisplayName("نام"), Required(ErrorMessage = "نام نمی تواند خالی باشد.")]
        public string? SellerFirstName { get; set; }

        [DisplayName("نام خانوادگی"), Required(ErrorMessage = "نام خانوادگی نمی تواند خالی باشد.")]
        public string? SellerLastName { get; set; }

        [DisplayName("تاریخ تولد")]
        public DateTime? SellerBirthdate { get; set; }

        [DisplayName("شاره شبا بانکی"), Required(ErrorMessage = "شماره شبا بانکی نمی تواند خالی باشد.")]
        public string? SellerShabaNumber { get; set; }

        [DisplayName(" استان"), Required(ErrorMessage = "نام استان را انتخال کنید.")]
        public int? ProvinceId { get; set; }

        [DisplayName("شهر"), Required(ErrorMessage = "نام شهر نمی تواند خالی باشد.")]
        public string City { get; set; }

        [DisplayName("آدرس کامل"), Required(ErrorMessage = "آدرس نمی تواند خالی باشد.")]
        public string FullAddress { get; set; }

        [DisplayName("کد پستی"), Required(ErrorMessage = "کد پستی نمی تواند خالی باشد.")]
        public string PostalCode { get; set; }

        public string ProfilePicUrl { get; set; }
        public int ProfilePicId { get; set; }

        [DisplayName("آپلود تصویر")]
        public IFormFile? SellerProfilePicFile { get; set; }

        [DisplayName("نام غرفه"), Required(ErrorMessage = "نام غرفه نمی تواند خالی باشد .")]
        public string BoothName { get; set; }

        [DisplayName("معرفی غرفه"), Required(ErrorMessage = "توضیحات معرفی غرفه را کامل کنید .")]
        public string? Description { get; set; }


        public string AvatarPictureUrl { get; set; }
        public string AvatarPictureId { get; set; }

        [DisplayName("ارسال فایل")]
        public IFormFile? BoothAvatarFile { get; set; }

    }
}

