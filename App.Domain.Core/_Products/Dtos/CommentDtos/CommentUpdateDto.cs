using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.CommentDtos;

public class CommentUpdateDto
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public int OrderItemId { get; set; }

    public int? PictureId { get; set; }

    public string? Text { get; set; } = null!;

    //public DateTime CreatedAt { get; set; }

    public bool? IsConfirmed { get; set; }

    //public bool IsDeleted { get; set; }


    #region Navigation properties
    //public virtual Customer? Customer { get; set; } = null!;

    //public virtual Product? Product { get; set; } = null!;

    //public virtual OrderItem OrderItem { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
    #endregion
}
