using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.CommentDtos;

public class CommentOutputDto
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public int OrderItemId { get; set; }

    public int? PictureId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool? IsConfirmed { get; set; }

    public bool IsDeleted { get; set; }


    #region Navigation properties
    public virtual Customer? Customer { get; set; } = null!;

    public virtual ProductOutputDto? Product { get; set; } = null!;

    public virtual OrderItem OrderItem { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
    #endregion
}


//Id { get; set; }
//CustomerId { get; set; }
//ProductId { get; set; }
//OrderItemId { get; set; }
//PictureId { get; set; }
//Text { get; set; }
//CreatedAt { get; set; }
//IsConfirmed { get; set; }
//IsDeleted { get; set; }
//Customer { get; set; }
//Picture { get; set; } 