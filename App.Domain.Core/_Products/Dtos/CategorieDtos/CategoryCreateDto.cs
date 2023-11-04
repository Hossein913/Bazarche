using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.CategorieDtos;

public class CategoryCreateDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public int PictureId { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual Picture Picture { get; set; } = null!;
}
