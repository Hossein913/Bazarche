using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Entities;

public partial class Wage
{
    public int Id { get; set; }

    public int? OrderitemId { get; set; }

    public int? AuctionId { get; set; }

    public int FeePercenteage { get; set; }

    public int WageAmount { get; set; }

    #region Navigation properties
    public virtual OrderItem Orderitem { get; set; } = null!;

    public virtual Auction Auction { get; set; } = null!;
    #endregion
}
