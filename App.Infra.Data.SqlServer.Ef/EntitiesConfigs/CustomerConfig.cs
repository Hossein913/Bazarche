using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        entity.Property(e => e.Lastname).HasMaxLength(50);

        entity.HasOne(d => d.Address).WithOne(p => p.Customers)
            .HasForeignKey<Customer>(c => c.AddressId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Customers_Addresses");

        entity.HasOne(c => c.ProfilePic).WithOne(p => p.Customers)
            .HasForeignKey<Customer>(c => c.ProfilePicId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Customers_Pictures");
    }
}