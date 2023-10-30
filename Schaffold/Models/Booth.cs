using System;
using System.Collections.Generic;

namespace Schaffold.Models;

public partial class Booth
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AvatarPictureId { get; set; }

    public int MedalId { get; set; }

    public int AccountBalance { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Picture AvatarPicture { get; set; } = null!;

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();

    public virtual Medal Medal { get; set; } = null!;

    public virtual ICollection<ProductAction> ProductActions { get; set; } = new List<ProductAction>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
