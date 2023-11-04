using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Address
{
    public int Id { get; set; }

    public int ProvinceId { get; set; }

    public string City { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();

}
