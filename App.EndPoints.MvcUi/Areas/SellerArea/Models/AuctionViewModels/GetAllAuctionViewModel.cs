using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.AuctionViewModels
{
    public class GetAllAuctionViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BoothId { get; set; }

        public int? WinnerId { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int BasePrice { get; set; }

        public AuctionStatus Status { get; set; }

        public bool? IsConfirmed { get; set; }

        public virtual ProductOutputDto ProductDto { get; set; } = null!;

        public Bid MaxBid { get; set; } = null!;

    }
}

//Id { get; set; }
//ProductId { get; set; }
//BoothId { get; set; }
//WinnerId { get; set; }
//StartTime { get; set; }
//EndTime { get; set; }
//BasePrice { get; set; }
//Status { get; set; }
//IsConfirmed { get; set; }
//ProductDto { get; set; } 