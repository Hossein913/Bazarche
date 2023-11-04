﻿using App.Domain.Core._Booth.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Booth.Dtos.MedalDtos;

public partial class MedalCreateDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FeePercentage { get; set; }

    public int MinSalesRequired { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();
}