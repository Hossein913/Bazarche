using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Auctions
{
    public class GatAllAuctionsViewModel
    {
        public int Id { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int BasePrice { get; set; }

        public bool? IsConfirmed { get; set; }

        public string? WinnerName { get; set; }

        public AuctionStatus status { get; set; }

        #region Navigation properties

        public virtual Booth Booth { get; set; } = null!;

        public virtual ProductOutputDto ProductDto { get; set; } = null!;
        #endregion
    }
}

//Id { get; set; }
//StartTime { get; set; }
//EndTime { get; set; }
//BasePrice { get; set; }
//Confirmation { get; set; }
//Bids { get; set; }
//Booth { get; set; } 
//ProductDto { get; set; } 
