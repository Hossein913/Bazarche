using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Count).HasColumnName("count");

        entity.HasOne(d => d.BoothProduct).WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.BoothProductid)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_OrderItems_BoothProduct");

        //Orderitems has relation with wage histori therefor if a Customer get deleted its Orders can be get Delete but 
        //  orderitems should be keep in Db
        entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_OrderItems_Orders");
    }
}
