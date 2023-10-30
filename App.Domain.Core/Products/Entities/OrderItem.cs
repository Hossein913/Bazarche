﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BoothProductid { get; set; }

    public int Count { get; set; }

    public bool IsActive { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
