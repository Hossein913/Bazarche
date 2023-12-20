using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.AuctionDtos;

public class AuctionUpdateDto
{

    public int Id { get; set; }

    public int ProductId { get; set; }

    public int BoothId { get; set; }

    public int? WinnerId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? BasePrice { get; set; }

    public AuctionStatus Status { get; set; }

    public bool? IsConfirmed { get; set; }

    #region Navigation properties
    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual Booth Booth { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
    #endregion
}
