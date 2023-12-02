using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;

namespace App.EndPoints.MvcUi.Models._Auctions
{
    public class CustomerAuctionsBidViewModel
    {
        public int Id { get; set; }

        public int? WinnerId { get; set; }

        public int CurrentCustomerId { get; set; }

        public AuctionStatus Status { get; set; }

        public virtual ICollection<Bid> Bids { get; set; } 

        public virtual ProductOutputDto ProductDto { get; set; } = null!;

    }
}

