using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Entities;

public class Address
{
    public int Id { get; set; }

    public int? ProvinceId { get; set; }

    public string City { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    # region Navigation properties

    public virtual Customer Customers { get; set; }

    public virtual Province? Province { get; set; }

    public virtual Seller Sellers { get; set; }


    #endregion
}
