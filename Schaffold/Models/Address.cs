using System;
using System.Collections.Generic;

namespace Schaffold.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Province { get; set; } = null!;

    public string City { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
