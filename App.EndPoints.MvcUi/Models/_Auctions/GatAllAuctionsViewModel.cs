using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Models._Auctions
{
    public class GatAllAuctionsViewModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int BasePrice { get; set; }

        public string BoothName { get; set; }

        public List<Bid> Bids { get; set; }




        #region Navigation properties

        public virtual Booth Booth { get; set; } = null!;

        public virtual ProductOutputDto ProductDto { get; set; } = null!;
        #endregion
    }
}
