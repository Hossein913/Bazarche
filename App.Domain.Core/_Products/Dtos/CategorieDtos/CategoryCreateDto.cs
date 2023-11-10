﻿using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.CategorieDtos;

public class CategoryCreateDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public int? PictureId { get; set; }


    #region Navigation properties
    public virtual ICollection<Category> Subcategories { get; set; } = new List<Category>();
    public virtual ICollection<Attributes> Attributes { get; set; } = new List<Attributes>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Category? Parent { get; set; }

    public virtual Picture? Picture { get; set; } = null!;
    #endregion
}
