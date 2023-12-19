using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using App.Domain.Core._User.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using App.Frameworks.Web.DateConverter;
using App.Domain.Core._User.Dtos.ProvinceDto;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Customers;

    public class UpdateCustomerViewModel
    {
        public int Id { get; set; }

        [DisplayName("نام"), Required(ErrorMessage = "نام نمی تواند خالی باشد.")]
        public string? Firstname { get; set; }

        [DisplayName("نام خانوادگی"), Required(ErrorMessage = "نام خانوادگی نمی تواند خالی باشد.")]
        public string? Lastname { get; set; }

        [DisplayName("جنسیت:")]
        public int SexualityId { get; set; }

        public string? ProfilePicFile { get; set; }

        public int? ProfilePicId { get; set; }

        [DisplayName("انتخاب تصویر")]
        public IFormFile? UploadProfilePic { get; set; }

        [DisplayName("تاریخ تولد")]
        [RegularExpression(@"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|([1-2][0-9])|(0[1-9]))))$", ErrorMessage = "تاریخ وارد شده معتبر نمی باشد.")]
        public string? Birthdate { get; set; }


        #region UpdateAddress
        [DisplayName(" استان"), Required(ErrorMessage = "نام استان را انتخاب کنید.")]
        public int? ProvinceId { get; set; }

        [DisplayName("شهر"), Required(ErrorMessage = "نام شهر نمی تواند خالی باشد.")]
        public string City { get; set; } = null!;

        [DisplayName("آدرس کامل"), Required(ErrorMessage = "آدرس نمی تواند خالی باشد.")]
        public string FullAddress { get; set; } = null!;

        [DisplayName("کد پستی"), Required(ErrorMessage = "کد پستی نمی تواند خالی باشد.")]
        [MaxLength(10)]
        public string PostalCode { get; set; } = null!;

        public List<ProvinceOutputDto>? Provinces { get; set; }
    #endregion

}