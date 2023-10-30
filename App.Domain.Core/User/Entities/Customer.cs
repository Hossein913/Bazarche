using App.Domain.Core.Common.Entities;
using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.User.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string Firestname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public bool Sexuality { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int AddressId { get; set; }

    public int ProfilePictureId { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string Homenumber { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public int Wallet { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ProductAction> Actions { get; set; } = new List<ProductAction>();

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Picture ProfilePicture { get; set; } = null!;
}
