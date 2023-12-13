using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Booth.Dtos.BoothDtos;

public partial class BoothUpdateDto
{
    public int Id { get; set; }

    public string? Name { get; set; } = null!;

    public int? AvatarPictureId { get; set; }

    public int MedalId { get; set; }

    public int? AccountBalance { get; set; }

    public int? TotalSell { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }


    #region Navigation properties
    public virtual ICollection<Auction> Auctions { get; set; }

    public virtual Picture? AvatarPicture { get; set; } = null!;

    public virtual ICollection<BoothProduct> BoothProducts { get; set; }

    public virtual Medal? Medal { get; set; }

    public virtual Seller? Sellers { get; set; }
    #endregion
}
