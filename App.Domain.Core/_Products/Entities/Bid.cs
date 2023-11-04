using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Entities;

public class Bid
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int AuctionId { get; set; }

    public int BidPrice { get; set; }

    public bool IsCancelled { get; set; }


    #region Navigation properties
    public virtual Auction Auction { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    #endregion
}
