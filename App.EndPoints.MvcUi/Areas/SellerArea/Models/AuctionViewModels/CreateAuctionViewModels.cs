using App.Domain.Core._Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.AuctionViewModels
{
    public class CreateAuctionViewModels
    {
        public int ProductId { get; set; }

        public int BoothId { get; set; } 
        [Display(Name ="سال"),MaxLength(1500,ErrorMessage ="سال اغاز را اشتباه وارد کرده اید.")]
        public int StartYear { get; set; } 
        [Display(Name = "ماه"), MaxLength(12, ErrorMessage = "ماه اغاز را اشتباه وارد کرده اید.")]
        public int StartMonth { get; set;  }
        [Display(Name = "روز"), MaxLength(29, ErrorMessage = "روز اغاز را اشتباه وارد کرده اید.")]
        public int StartDay { get; set; }
        [Display(Name = "ساعت"), MaxLength(24, ErrorMessage = "ساعت اغاز را اشتباه وارد کرده اید.")]
        public int StartHour { get; set; }


        [Display(Name = "سال"), MaxLength(1500, ErrorMessage = "سال پایان را اشتباه وارد کرده اید.")]
        public int EndYear { get; set; }
        [Display(Name = "ماه"), MaxLength(12, ErrorMessage = "ماه پایان را اشتباه وارد کرده اید.")]
        public int EndMonth { get; set; }
        [Display(Name = "روز"), MaxLength(29, ErrorMessage = "روز پایان را اشتباه وارد کرده اید.")]
        public int EndDay { get; set; }
        [Display(Name = "ساعت"), MaxLength(24, ErrorMessage = "ساعت پایان را اشتباه وارد کرده اید.")]
        public int EndHour { get; set; }

        [Display(Name = "قیمت پایه"), MinLength(1, ErrorMessage = "قیمت پایه را وارده نکرده اید.")]
        public int BasePrice { get; set; }

        public string ProductName { get; set; }

        public string ProductBrand { get; set; }

        public Picture Avatar { get; set; }

        public string MainUrl { get; set; }
    }
}
