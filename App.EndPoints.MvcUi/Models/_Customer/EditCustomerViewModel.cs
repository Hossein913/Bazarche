using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using App.Domain.Core._User.Dtos.ProvinceDto;

namespace App.EndPoints.MvcUi.Models._Customer
{
    public class EditCustomerViewModel
    {

        [DisplayName("نام"), Required(ErrorMessage = "نام نمی تواند خالی باشد.")]
        public string? FirstName { get; set; }

        [DisplayName("نام خانوادگی"), Required(ErrorMessage = "نام خانوادگی نمی تواند خالی باشد.")]
        public string? LastName { get; set; }

        [DisplayName("تاریخ تولد")]
        public string? Birthdate { get; set; }

        [DisplayName(" استان"), Required(ErrorMessage = "نام استان را انتخال کنید.")]
        public int? ProvinceId { get; set; }

        [DisplayName("شهر"), Required(ErrorMessage = "نام شهر نمی تواند خالی باشد.")]
        public string City { get; set; }

        [DisplayName("آدرس کامل"), Required(ErrorMessage = "آدرس نمی تواند خالی باشد.")]
        public string FullAddress { get; set; }

        [DisplayName("کد پستی"), Required(ErrorMessage = "کد پستی نمی تواند خالی باشد.")]
        public string PostalCode { get; set; }

        public List<ProvinceOutputDto>? Provinces { get; set; }
    }
}

//FirstName { get; set; }
//LastName { get; set; }
//Birthdate { get; set; }
//ProvinceId { get; set; }
//City { get; set; }
//FullAddress { get; set; }
//PostalCode { get; set; }