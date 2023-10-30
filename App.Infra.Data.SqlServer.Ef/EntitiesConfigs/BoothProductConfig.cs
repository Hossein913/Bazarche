using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class BoothProductConfig : IEntityTypeConfiguration<BoothProduct>
{
    public void Configure(EntityTypeBuilder<BoothProduct> entity)
    {
        entity.ToTable("BoothProduct");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.CreatedAt).HasColumnType("datetime");

        entity.HasOne(d => d.Booth).WithMany(p => p.BoothProducts)
            .HasForeignKey(d => d.BoothId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BoothProduct_Booths");

        entity.HasOne(d => d.Product).WithMany(p => p.BoothProducts)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BoothProduct_Products");
    }
}