using App.Domain.Core.User.Entities;
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
        entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        entity.Property(e => e.Email).HasMaxLength(50);
        entity.Property(e => e.Firestname).HasMaxLength(50);
        entity.Property(e => e.Homenumber)
            .HasMaxLength(11)
            .IsFixedLength();
        entity.Property(e => e.Lastname).HasMaxLength(50);
        entity.Property(e => e.Password).HasMaxLength(10);
        entity.Property(e => e.Phonenumber)
            .HasMaxLength(11)
            .IsFixedLength();
        entity.Property(e => e.ShabaNumber)
            .HasMaxLength(25)
            .IsFixedLength();

        entity.HasOne(d => d.Address).WithMany(p => p.Sellers)
            .HasForeignKey(d => d.AddressId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Sellers_Addresses");

        entity.HasOne(d => d.Booth).WithMany(p => p.Sellers)
            .HasForeignKey(d => d.BoothId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Sellers_Booths");

        entity.HasOne(d => d.ProfilePicture).WithMany(p => p.Sellers)
            .HasForeignKey(d => d.ProfilePictureId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Sellers_Pictures");
    }
}
