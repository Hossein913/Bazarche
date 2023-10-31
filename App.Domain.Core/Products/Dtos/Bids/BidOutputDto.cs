using App.Domain.Core.Products.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Dtos.Bids;

public class BidOutputDto
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ActionId { get; set; }

    public int BidPrice { get; set; }

    public bool IsCancelled { get; set; }

    public virtual Auction Action { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
