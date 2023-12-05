using App.Domain.Core._Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.AuctionViewModels
{
    public class CreateAuctionViewModels
    {
        public int ProductId { get; set; }

        public int BoothId { get; set; } 

        [Display(Name ="سال")]
        public int StartYear { get; set; } 
        [Display(Name = "ماه")]
        public int StartMonth { get; set;  }
        [Display(Name = "روز") ]
        public int StartDay { get; set; }
        [Display(Name = "ساعت")]
        public int StartHour { get; set; }


        [Display(Name = "سال")]
        public int EndYear { get; set; }
        [Display(Name = "ماه")]
        public int EndMonth { get; set; }
        [Display(Name = "روز")]
        public int EndDay { get; set; }
        [Display(Name = "ساعت")]
        public int EndHour { get; set; }

        [Display(Name = "قیمت پایه")]
        public int BasePrice { get; set; }

        public string ProductName { get; set; }

        public string ProductBrand { get; set; }

        public Picture Avatar { get; set; }

        public string MainUrl { get; set; }
    }
}
