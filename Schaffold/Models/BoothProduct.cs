using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public class BoothProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int BoothId { get; set; }

    public int Price { get; set; }

    public int Count { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }


    #region Navigation properties
    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    #endregion
}
