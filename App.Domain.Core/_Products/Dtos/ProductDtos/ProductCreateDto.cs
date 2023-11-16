using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.ProductDtos;

public class ProductCreateDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Grantee { get; set; } = null!;

    public string InformationDetails { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string IncludedComponents { get; set; } = null!;

    public bool IsConfirmed { get; set; }

    public int BasePrice { get; set; }
    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public bool IsDeleted { get; set; }


    #region Navigation properties
    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<Comment> Comments { get; set; }

    public virtual ICollection<Picture>? Pictures { get; set; }

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
    #endregion
}
