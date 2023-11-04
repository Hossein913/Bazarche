using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Entities;

public partial class ProductAttributeValue
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? AttributeId { get; set; }

    public string Value { get; set; } = null!;

    #region Navigation properties
    public virtual Attributes? Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
    #endregion
}
