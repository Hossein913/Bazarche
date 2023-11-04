using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class BidConfig : IEntityTypeConfiguration<Bid>
{
    public void Configure(EntityTypeBuilder<Bid> entity)
    {

        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();

        entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
            .HasForeignKey(d => d.AuctionId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Bids_Actions");

        entity.HasOne(d => d.Customer).WithMany(p => p.Bids)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Bids_Customers");
    }
}
