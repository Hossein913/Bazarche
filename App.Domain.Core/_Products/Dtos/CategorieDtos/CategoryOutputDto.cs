using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.CategorieDtos;

public class CategoryOutputDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public string PictureFileName { get; set; }



    #region Navigation properties
    public ICollection<Category> Subcategories { get; set; } 
    public ICollection<Attributes> Attributes { get; set; }  
    public IEnumerable<List<Product>> products { get; set; } 
    public Category? Parent { get; set; }
    public Picture? Picture { get; set; }
    #endregion
}
