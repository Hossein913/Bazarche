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

    public int CreatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
