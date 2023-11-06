using App.Domain.Core._Booth.Entities;
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
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Sellers_Booths");

        entity.HasOne(s => s.ProfilePic).WithOne(p => p.Sellers)
            .HasForeignKey<Seller>(s => s.ProfilePicId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Sellers_Pictures");

        entity.HasOne(c => c.AppUser).WithOne(u => u.Seller)
       .HasForeignKey<Seller>(s => s.AppuserId);

        entity.HasData(
        new Seller { Id = 1, Firstname = "حامد", Lastname = "کریمی", AddressId = 1, ProfilePicId = 13, Birthdate = new DateTime(1990, 05, 05), BoothId = null, ShabaNumber = "Ir89752140000007800125", AppuserId = 2 },
        new Seller { Id = 2, Firstname = "میلاد", Lastname = "بداقی", AddressId = 2, ProfilePicId = 14, Birthdate = new DateTime(1990, 05, 05), BoothId = null, ShabaNumber = "Ir89752140000007800125", AppuserId = 3 }
        ) ;

    }
}
