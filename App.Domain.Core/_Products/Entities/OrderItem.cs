using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Entities;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BoothProductid { get; set; }

    public int Count { get; set; }

    public bool IsActive { get; set; }


    #region Navigation properties
    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Wage Wages { get; set; } = new Wage();
    #endregion
}
