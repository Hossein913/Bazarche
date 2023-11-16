using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Common.Dtos.PictureDtos;

public partial class PictureOutputDto
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public bool IsDeleted { get; set; }


    #region Navigation properties
    public virtual Admin? Admins { get; set; }

    public virtual Booth? Booths { get; set; }

    public virtual Category? Categories { get; set; }

    public virtual Customer? Customers { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

    public virtual Seller? Sellers { get; set; }
    public virtual Comment? Comment { get; set; }
    #endregion
}
