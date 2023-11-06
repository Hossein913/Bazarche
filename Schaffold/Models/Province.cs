using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    #region Navigation properties
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    #endregion
}
