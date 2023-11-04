using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.City).HasMaxLength(50);
        entity.Property(e => e.FullAddress).HasMaxLength(300);
        entity.Property(e => e.PostalCode).HasMaxLength(10).IsFixedLength();

        entity.HasOne(d => d.Province).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.ProvinceId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Addresses_Provinces");
    }
}