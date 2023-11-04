using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public int PictureId { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();
    public virtual ICollection<Attributes> Attributes { get; set; } = new List<Attributes>();

    public virtual Category? Parent { get; set; }

    public virtual Picture Picture { get; set; } = null!;
}
