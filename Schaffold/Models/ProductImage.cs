using System;
using System.Collections.Generic;

namespace Schaffold.Models;

public partial class ProductImage
{
    public int ProductId { get; set; }

    public int PictureId { get; set; }

    public virtual Picture Picture { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
