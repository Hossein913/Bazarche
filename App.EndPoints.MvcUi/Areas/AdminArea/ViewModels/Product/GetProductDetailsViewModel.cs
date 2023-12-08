using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Product
{
    public class GetProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Brand { get; set; }

        public string? Avatar { get; set; }

        public string Grantee { get; set; }

        public string InformationDetails { get; set; }

        public string Description { get; set; } 

        public string IncludedComponents { get; set; } 

        public bool? IsConfirmed { get; set; }

        public int BasePrice { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public int CategoryId { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual ICollection<CommentOutputDto> Comments { get; set; }

        public virtual ICollection<Picture>? Pictures { get; set; }

        public virtual List<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();
    }
}

//Id { get; set; }
//Name { get; set; }
//Brand { get; set; }
//Avatar { get; set; }
//Grantee { get; set; }
//InformationDetails { get; set; }
//Description { get; set; }
//IncludedComponents { get; set; }
//IsConfirmed { get; set; }
//BasePrice { get; set; }
//CreatedAt { get; set; }
//CreatedBy { get; set; }
//CategoryId { get; set; }
//Auctions { get; set; } = 
//Comments { get; set; }
//Pictures { get; set; }
//BoothProducts { get; set; } 