using App.Domain.Core._User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class SellerConfig : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Birthdate).HasColumnType("datetime");
        entity.Property(e => e.Lastname).HasMaxLength(50);
        entity.Property(e => e.ShabaNumber)
            .HasMaxLength(25)
            .IsFixedLength();

        entity.HasOne(d => d.Address).WithOne(p => p.Sellers)
            .HasForeignKey<Seller>(s => s.AddressId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Sellers_Addresses");

        entity.HasOne(d => d.Booth).WithOne(p => p.Sellers)
            .HasForeignKey<Seller>(d => d.BoothId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Sellers_Booths");

        entity.HasOne(s => s.ProfilePic).WithOne(p => p.Sellers)
            .HasForeignKey<Seller>(s => s.ProfilePicId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Sellers_Pictures");
    }
}
