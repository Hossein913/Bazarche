using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.BoothProductDtos;

public class BoothProductOutputDto
{

    public int Id { get; set; }

    public int ProductId { get; set; }

    public int BoothId { get; set; }

    public int Price { get; set; }

    public int Count { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }


    #region Navigation properties
    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    #endregion
}


//Id { get; set; }
//ProductId { get; set; }
//BoothId { get; set; }
//Price { get; set; }
//Count { get; set; }
//Status { get; set; }
//CreatedAt { get; set; }
//Booth { get; set; } 
//OrderItems { get; set; } 
//Product { get; set; }