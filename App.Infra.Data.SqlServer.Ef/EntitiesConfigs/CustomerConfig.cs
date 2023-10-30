using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
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

        entity.HasOne(d => d.Address).WithMany(p => p.Customers)
            .HasForeignKey(d => d.AddressId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customers_Addresses");

        entity.HasOne(d => d.ProfilePicture).WithMany(p => p.Customers)
            .HasForeignKey(d => d.ProfilePictureId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customers_Pictures");
    }
}