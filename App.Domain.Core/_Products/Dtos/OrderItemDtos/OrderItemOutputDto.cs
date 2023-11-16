using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._Products.Dtos.OrderItemDtos;

public class OrderItemOutputDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BoothProductid { get; set; }

    public int Count { get; set; }

    public bool IsActive { get; set; }


    #region Navigation properties
    public virtual BoothProduct BoothProduct { get; set; }

    public virtual Order Order { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }

    public virtual Wage Wages { get; set; }
    #endregion
}
