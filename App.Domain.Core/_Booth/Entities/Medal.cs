using System;
using System.Collections.Generic;

namespace App.Domain.Core._Booth.Entities;

public partial class Medal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FeePercentage { get; set; }

    public int MinSalesRequired { get; set; }

    #region Navigation properties
    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();
    #endregion
}
