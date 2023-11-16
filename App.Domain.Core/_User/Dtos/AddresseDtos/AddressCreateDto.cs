using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Dtos.AddresseDtos;

public partial class AddressCreateDto
{
    //public int Id { get; set; }

    public int? ProvinceId { get; set; } = null!;

    public string City { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    //public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    //public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
