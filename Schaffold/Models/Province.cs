using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
