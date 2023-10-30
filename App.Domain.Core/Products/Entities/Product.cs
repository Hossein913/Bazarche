using App.Domain.Core.Common.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Grantee { get; set; } = null!;

    public string InformationDetails { get; set; } = null!;

    public string Describtion { get; set; } = null!;

    public string IncludedComponentes { get; set; } = null!;

    public bool IsConfirmed { get; set; }

    public int BasePrise { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ProductAction> Actions { get; set; } = new List<ProductAction>();

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();
    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
}
