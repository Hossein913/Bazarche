using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Grantee { get; set; } = null!;

    public int AvatarId { get; set; }

    public string InformationDetails { get; set; } = null!;

    public string Describtion { get; set; } = null!;

    public string IncludedComponentes { get; set; } = null!;

    public bool IsConfirmed { get; set; }

    public int BasePrise { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual Picture Avatar { get; set; } = null!;

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();

}
