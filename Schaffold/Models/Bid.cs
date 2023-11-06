using System;
using System.Collections.Generic;

namespace Scaffold.Models;

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
