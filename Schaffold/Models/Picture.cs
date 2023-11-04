using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Picture
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Admin Admins { get; set; } = new Admin();

    public virtual Booth Booths { get; set; } = new Booth();

    public virtual Category Categories { get; set; } = new Category();

    public virtual Customer Customers { get; set; } = new Customer();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Seller Sellers { get; set; } = new Seller();
    public virtual Comment Comment { get; set; } = new Comment();
}
