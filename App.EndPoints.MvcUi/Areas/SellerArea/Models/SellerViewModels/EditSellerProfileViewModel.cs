using App.Domain.Core._Common.Entities;
using App.Domain.Core._User.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Dtos.ProvinceDto;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.SellerViewModels
{
    public class EditSellerProfileViewModel
    {
        [DisplayName("نام"), Required(ErrorMessage = "نام نمی تواند خالی باشد.")]
        public string? FirstName { get; set; }

        [DisplayName("نام خانوادگی"), Required(ErrorMessage = "نام خانوادگی نمی تواند خالی باشد.")]
        public string? LastName { get; set; }

        [DisplayName("تاریخ تولد")]
        public DateTime? Birthdate { get; set; }

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
        public string PostalCode { get; set; } 

        public string? ProfilePicUrl{ get; set; }
        public int? ProfilePicId{ get; set; }

        [DisplayName("آپلود تصویر")]
        public IFormFile? ProfilePicFile { get; set; }

        public List<ProvinceOutputDto> provinces { get; set; }

    }
}

