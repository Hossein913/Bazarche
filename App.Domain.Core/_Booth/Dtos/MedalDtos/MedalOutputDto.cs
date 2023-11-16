using App.Domain.Core._Booth.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Booth.Dtos.MedalDtos;

public partial class MedalOutputDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FeePercentage { get; set; }

    public int MinSalesRequired { get; set; }

    #region Navigation properties
    public virtual ICollection<Booth> Booths { get; set; }
    #endregion
}
