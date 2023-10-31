using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public class Comment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int OrderItemId { get; set; }

    public string Text { get; set; } = null!;

    public bool IsConfirmed { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual OrderItem OrderItem { get; set; } = null!;
}
