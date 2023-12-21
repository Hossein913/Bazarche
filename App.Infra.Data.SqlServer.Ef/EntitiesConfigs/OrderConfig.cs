using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        entity.Property(e => e.PayedAt).HasColumnType("datetime");

        entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Orders_Customers");

        entity.HasData(
            new Order { Id = 1, CustomerId = 1, Status = Convert.ToBoolean(OrderStatus.Cart), TotalPrice = 0, CreatedAt = DateTime.Now, PayedAt = null },
            new Order { Id = 2, CustomerId = 2, Status = Convert.ToBoolean(OrderStatus.Cart), TotalPrice = 0, CreatedAt = DateTime.Now, PayedAt = null },
            new Order { Id = 3, CustomerId = 1, Status = true, TotalPrice = 1000, CreatedAt = DateTime.Now, PayedAt = DateTime.Now.AddMinutes(45) },
            new Order { Id = 4, CustomerId = 2, Status = false, TotalPrice = 100, CreatedAt = DateTime.Now, PayedAt = DateTime.Now.AddMinutes(45) }
            );
    }
}

