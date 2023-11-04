using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Entities;

public partial class Attributes
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    #region Navigation properties
    public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    #endregion
}
