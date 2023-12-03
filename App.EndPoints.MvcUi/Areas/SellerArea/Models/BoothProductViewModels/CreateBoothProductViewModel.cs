using App.Domain.Core._Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothProductViewModels
{
    public class CreateBoothProductViewModel
    {
        public int ProductId { get; set; }

        public int BoothId { get; set; }

        [Display(Name ="قیمت")]
        public int Price { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        public string ProductName { get; set; } 

        public string ProductBrand { get; set; } 

        public Picture Avatar { get; set; } 

        public string MainUrl { get; set; } 

    }
}

//ProductId { get; set; }
//BoothId { get; set; }
//Price { get; set; }
//Count { get; set; }
//ProductName { get; set; }
//ProductBrand { get; set; }
//Avatar { get; set; }
//MmainUrl { get; set; }