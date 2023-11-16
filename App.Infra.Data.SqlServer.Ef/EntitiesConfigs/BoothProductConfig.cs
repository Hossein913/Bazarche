using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class BoothProductConfig : IEntityTypeConfiguration<BoothProduct>
{
    public void Configure(EntityTypeBuilder<BoothProduct> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.CreatedAt).HasColumnType("datetime");

        entity.HasOne(d => d.Booth).WithMany(p => p.BoothProducts)
            .HasForeignKey(d => d.BoothId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_BoothProduct_Booths");

        entity.HasOne(d => d.Product).WithMany(p => p.BoothProducts)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_BoothProduct_Products");

        entity.HasData(
            new BoothProduct { Id = 1 , ProductId = 1, BoothId = 1, Price = 800000, Count = 10, Status = true, CreatedAt = DateTime.Now, IsDeleted = false},
            new BoothProduct { Id = 2 , ProductId = 9, BoothId = 1, Price = 900000, Count = 5, Status = true, CreatedAt = DateTime.Now, IsDeleted = false},
            new BoothProduct { Id = 3 , ProductId = 8, BoothId = 1, Price = 1000000, Count = 10, Status = true, CreatedAt = DateTime.Now, IsDeleted = false},
            new BoothProduct { Id = 4 , ProductId = 3, BoothId = 1, Price = 2000000, Count = 5, Status = true, CreatedAt = DateTime.Now, IsDeleted = false},
            new BoothProduct { Id = 5 , ProductId = 6, BoothId = 2, Price = 3000000, Count = 10, Status = true, CreatedAt = DateTime.Now, IsDeleted = false},
            new BoothProduct { Id = 6 , ProductId = 2, BoothId = 2, Price = 4000000, Count = 5, Status = true, CreatedAt = DateTime.Now, IsDeleted = false},
            new BoothProduct { Id = 7 , ProductId = 4, BoothId = 2, Price = 5000000, Count = 10, Status = true, CreatedAt = DateTime.Now, IsDeleted = false},
            new BoothProduct { Id = 8 , ProductId = 9, BoothId = 2, Price = 10000000, Count = 5, Status = true, CreatedAt = DateTime.Now, IsDeleted = false}
            );
    }
}
