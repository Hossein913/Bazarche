using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class AuctionConfig : IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.EndTime).HasColumnType("datetime");
        entity.Property(e => e.StartTime).HasColumnType("datetime");

        entity.HasOne(a => a.Booth).WithMany(b => b.Auctions)
            .HasForeignKey(a => a.BoothId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Auctions_Booths");


        entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Auctions_Products");

        entity.HasData(
            new Auction { Id = 1, ProductId = 10, BoothId = 1, WinnerId = null, StartTime = DateTime.Now,EndTime = DateTime.Now.AddDays(1), BasePrice = 22000000 ,Status = 1 ,IsConfirmed = true  },
            new Auction { Id = 2, ProductId = 2, BoothId = 1, WinnerId = null, StartTime = DateTime.Now.AddHours(1),EndTime = DateTime.Now.AddDays(1), BasePrice = 350000 ,Status = 0 ,IsConfirmed = true  },
            new Auction { Id = 3, ProductId = 8, BoothId = 2, WinnerId = null, StartTime = DateTime.Now.AddDays(1),EndTime = DateTime.Now.AddDays(1), BasePrice = 25000000 ,Status = 0 ,IsConfirmed = false }
            );
    }
}

