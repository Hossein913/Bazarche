﻿using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.OrderItemDtos;

public class OrderItemCreateDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BoothProductid { get; set; }

    public int Count { get; set; }

    public bool IsActive { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}