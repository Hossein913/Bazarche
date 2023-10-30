using System;
using System.Collections.Generic;

namespace Schaffold.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int OrderItemId { get; set; }

    public string Text { get; set; } = null!;

    public bool IsConfirmed { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual OrderItem OrderItem { get; set; } = null!;
}
