﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class BidConfig : IEntityTypeConfiguration<Bid>
{
    public void Configure(EntityTypeBuilder<Bid> entity)
    {

        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();

        entity.HasOne(d => d.Action).WithMany(p => p.Bids)
            .HasForeignKey(d => d.ActionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Bids_Actions");

        entity.HasOne(d => d.Customer).WithMany(p => p.Bids)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Bids_Customers");
    }
}
