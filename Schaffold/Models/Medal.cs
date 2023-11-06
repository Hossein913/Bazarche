using System;
using System.Collections.Generic;

namespace Scaffold.Models;

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
