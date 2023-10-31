using App.Domain.Core.Products.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Dtos.Bids;

public class BidCreateDto
{
    public int CustomerId { get; set; }

    public int ActionId { get; set; }

    public int BidPrice { get; set; }

}
