﻿using App.Domain.Core.Booths.Entities;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Dtos.Auctions;

public class AuctionCreateDto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int BoothId { get; set; }

    public int? WinnerId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int BasePrice { get; set; }

    public int Status { get; set; }

    public bool IsConfirmed { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual Booth Booth { get; set; } = null!;

    public virtual Customer BoothNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
