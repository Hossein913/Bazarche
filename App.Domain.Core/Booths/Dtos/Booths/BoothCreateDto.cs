using App.Domain.Core.Booths.Entities;
using App.Domain.Core.Common.Entities;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Booths.Dtos.Booths;

public partial class BoothCreateDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AvatarPictureId { get; set; }

    public int MedalId { get; set; }

    public int AccountBalance { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Auction> Actions { get; set; } = new List<Auction>();

    public virtual Picture AvatarPicture { get; set; } = null!;

    public virtual ICollection<BoothProduct> BoothProducts { get; set; } = new List<BoothProduct>();

    public virtual Medal Medal { get; set; } = null!;

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
