using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Bid
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int AuctionId { get; set; }

    public int BidPrice { get; set; }

    public bool IsCancelled { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
