using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public class Comment
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int OrderItemId { get; set; }

    public int? PictureId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsConfirmed { get; set; }

    public bool IsDeleted { get; set; }


    #region Navigation properties
    public virtual Customer? Customer { get; set; } = null!;

    public virtual OrderItem OrderItem { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
    #endregion
}
