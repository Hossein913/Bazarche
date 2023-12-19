using App.Domain.Core._User.Dtos.ProvinceDto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Sellers
{
    public class UpdateSellerViewModel
    {
        public int Id { get; set; }

        [DisplayName("نام"), Required(ErrorMessage = "نام نمی تواند خالی باشد.")]
        public string? FirstName { get; set; }

        [DisplayName("نام خانوادگی"), Required(ErrorMessage = "نام خانوادگی نمی تواند خالی باشد.")]
        public string? LastName { get; set; }

        [DisplayName("تاریخ تولد")]
        [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|([1-2][0-9])|(0[1-9]))))$", ErrorMessage = "تاریخ وارد شده معتبر نمی باشد.")]
        public string? Birthdate { get; set; }

        [DisplayName("شاره شبا بانکی"), Required(ErrorMessage = "شماره شبا بانکی نمی تواند خالی باشد.")]
        [MaxLength(26, ErrorMessage = " شبا بانکی را بررسی کنید.")]
        [RegularExpression(@"^(?:IR)(?=.{24}$)[0-9]*$", ErrorMessage = "شماره شبا معتبر نمی باشد.")]
        public string? ShabaNumber { get; set; }

        [DisplayName(" استان"), Required(ErrorMessage = "نام استان را انتخال کنید.")]
        public int? ProvinceId { get; set; }

        [DisplayName("شهر"), Required(ErrorMessage = "نام شهر نمی تواند خالی باشد.")]
        public string City { get; set; }

        [DisplayName("آدرس کامل"), Required(ErrorMessage = "آدرس نمی تواند خالی باشد.")]
        public string FullAddress { get; set; }

        [DisplayName("کد پستی"), Required(ErrorMessage = "کد پستی نمی تواند خالی باشد.")]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        public string? ProfilePicUrl { get; set; }

        public int? ProfilePicId { get; set; }

        [DisplayName("آپلود تصویر")]
        public IFormFile? ProfilePicFile { get; set; }

        public List<ProvinceOutputDto>? Provinces { get; set; }
    }
}

//FirstName { get; set; }
//LastName { get; set; }
//Birthdate { get; set; }
//ShabaNumber { get; set; }
//ProvinceId { get; set; }
//City { get; set; }
//FullAddress { get; set; }
//PostalCode { get; set; }
//ProfilePicUrl { get; set; }
//ProfilePicId { get; set; }
//ProfilePicFile { get; set; }
//provinces { get; set; }