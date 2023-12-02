using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Models._Bid
{
    public class CreateBidViewModel
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public int CurrentCustomerId { get; set; }

        public DateTime EndTime { get; set; }

        public int BidPrice { get; set; }

        public List<Bid> Bids { get; set; }




        #region Navigation properties

        public virtual Booth Booth { get; set; } = null!;

        public virtual ProductOutputDto ProductDto { get; set; } = null!;
        #endregion
    }
}


//Id { get; set; }
//EndTime { get; set; }
//BidPrice { get; set; }
//BoothName { get; set; }
//Bids { get; set; }
//Booth { get; set; }
//ProductDto { get; set; }