using App.Domain.Core._Common.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Grantee { get; set; } = null!;

    public string InformationDetails { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string IncludedComponents { get; set; } = null!;

    public bool? IsConfirmed { get; set; }

    public int BasePrice { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public bool IsDeleted { get; set; }


    #region Navigation properties
    public virtual Category Category { get; set; } 
    public virtual ICollection<Auction> Auctions { get; set; } 
    public virtual ICollection<Comment> Comments { get; set; } 

    public virtual ICollection<Picture>? Pictures { get; set; }

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } 

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    #endregion
}
