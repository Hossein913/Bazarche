using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.BidDtos;

public class BidCreateDto
{
    public int CustomerId { get; set; }

    public int ActionId { get; set; }

    public int BidPrice { get; set; }

}
