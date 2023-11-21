using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels
{
    public class BoothDetailsViewModel
    {

        public int BoothId { get; set; }

        public int sellerId { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string BoothName { get; set; } = null!;

        public string AvatarPictureFile { get; set; }

        public int AccountBalance { get; set; }

        public int TotalSell { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }
        public virtual string MedalName { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<ProductOutputDto> Products { get; set; }
        public virtual Picture? AvatarPicture { get; set; } = null!;
        public virtual ICollection<BoothProduct> BoothProducts { get; set; }
        public virtual Medal? Medal { get; set; }

    }
}

//BoothId { get; set; }
//sellerId { get; set; }
//Firstname { get; set; }
//Lastname { get; set; }
//BoothName { get; set; } 
//AvatarPictureFile { get; set; }
//AccountBalance { get; set; }
//Description { get; set; }
//IsActive { get; set; }
//Auctions { get; set; }
//Products { get; set; }
//AvatarPicture { get; set; } 
//BoothProducts { get; set; }
//Medal { get; set; }