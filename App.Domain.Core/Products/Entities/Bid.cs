using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

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
