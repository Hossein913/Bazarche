using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class AdminConfig : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Birthdate).HasColumnType("datetime");
        entity.Property(e => e.LastName).HasMaxLength(50);
        entity.Property(e => e.ShabaNumber)
            .HasMaxLength(25)
            .IsFixedLength();

        entity.HasOne(a => a.ProfilePic).WithOne(p =>p.Admins )
            .HasForeignKey<Admin>(a => a.ProfilePicId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Admins_Pictures");

        entity.HasOne(c => c.AppUser).WithOne(u => u.Admin)
        .HasForeignKey<Admin>(a => a.AppUserId);


        entity.HasData(
            new Admin { Id = 1, FirstName = "حسین", LastName = "بشارتی", ProfilePicId = 12, Birthdate = new DateTime(1990 , 05 , 05), Wallet = 800000, ShabaNumber = "Ir89752140000007800125", AppUserId = 1 }
            ) ;
    }
}

