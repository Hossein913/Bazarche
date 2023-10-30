using System;
using System.Collections.Generic;

namespace Schaffold.Models;

public partial class Bid
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ActionId { get; set; }

    public int BidPrice { get; set; }

    public bool IsCancelled { get; set; }

    public virtual ProductAction Action { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
