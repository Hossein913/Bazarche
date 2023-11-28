using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Models.Home
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string? AvatarFileUrl { get; set; } = null!;

        public string Grantee { get; set; } = null!;

        public string InformationDetails { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string IncludedComponents { get; set; } = null!;


        public int BasePrice { get; set; }

        public int MaxPrice { get; set; }

        public int MinPrice { get; set; }
        public BoothProduct BoothPrice { get; set; }


        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        //public bool IsDeleted { get; set; }


        #region Navigation properties
        //public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Picture>? Pictures { get; set; }

        public virtual List<ProductBoothPricesViewModel> BoothProducts { get; set; } 
        #endregion
    }
}

//Id { get; set; }
//Name { get; set; } 
//Brand { get; set; }
//AvatarFileUrl { get; set; }
//Grantee { get; set; } 
//InformationDetails { get; set; } 
//Description { get; set; }
//IncludedComponents { get; set; }
//BasePrice { get; set; }
//MaxPrice { get; set; }
//MinPrice { get; set; }
//BoothPrice { get; set; }
//CreatedAt { get; set; }
//CreatedBy { get; set; }
//Comments { get; set; }
//Pictures { get; set; }
//BoothProducts { get; set; } 
//ProductAttributeValues { get; set; } 
