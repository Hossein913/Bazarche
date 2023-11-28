using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Models.Home
{
    public class AuctionViewModel
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BoothId { get; set; }

        public int? WinnerId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int BasePrice { get; set; }

        public int Status { get; set; }

        public bool? IsConfirmed { get; set; }
        public string BoothName { get; set; }

        

        #region Navigation properties
        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual Booth Booth { get; set; } = null!;

        public virtual ProductOutputDto ProductDto { get; set; } = null!;
        #endregion
    }
}


//Id { get; set; }
//ProductId { get; set; }
//BoothId { get; set; }
//WinnerId { get; set; }
//StartTime { get; set; }
//EndTime { get; set; }
//BasePrice { get; set;}
//Bids { get; set; } 
//Booth { get; set; } 