using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public bool Status { get; set; }

    public int TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? PayedAt { get; set; }


    #region Navigation properties
    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    #endregion
}
