using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Wage
{
    public int Id { get; set; }

    public int OrderitemId { get; set; }

    public int FeePercenteage { get; set; }

    public int WageAmount { get; set; }

    #region Navigation properties
    public virtual OrderItem Orderitem { get; set; } = null!;
    #endregion
}
