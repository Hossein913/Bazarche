using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Entities;

public partial class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    #region Navigation properties
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    #endregion
}
