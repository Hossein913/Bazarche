﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Birthdate).HasColumnType("datetime");
        entity.Property(e => e.LastName).HasMaxLength(50);

        entity.HasOne(d => d.Address).WithOne(p => p.Customers)
            .HasForeignKey<Customer>(c => c.AddressId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Customers_Addresses");

        entity.HasOne(c => c.ProfilePic).WithOne(p => p.Customers)
            .HasForeignKey<Customer>(c => c.ProfilePicId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Customers_Pictures");

        entity.HasOne(c => c.AppUser).WithOne(u => u.Customer).HasForeignKey<Customer>(c => c.AppUserId);

        entity.HasData(
        new Customer { Id = 1, FirstName = "جواد  ", LastName = "بیات", AddressId = 3, ProfilePicId = 15, Birthdate = new DateTime(1990 , 05 , 05), AppUserId = 4 }
        );
    }
}