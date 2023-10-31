using App.Domain.Core.Booths.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Booths.Dtos.Medals;

public partial class MedalOutputDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FeePercentage { get; set; }

    public int MinSalesRequired { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();
}
