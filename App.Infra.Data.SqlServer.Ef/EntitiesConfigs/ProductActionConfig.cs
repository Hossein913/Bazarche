using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class ProductActionConfig : IEntityTypeConfiguration<ProductAction>
{
    public void Configure(EntityTypeBuilder<ProductAction> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.EndTime).HasColumnType("datetime");
        entity.Property(e => e.StartTime).HasColumnType("datetime");

        entity.HasOne(d => d.Booth).WithMany(p => p.Actions)
            .HasForeignKey(d => d.BoothId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Actions_Booths");

        entity.HasOne(d => d.BoothNavigation).WithMany(p => p.Actions)
            .HasForeignKey(d => d.BoothId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Actions_Customers");

        entity.HasOne(d => d.Product).WithMany(p => p.Actions)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Actions_Products");
    }
}