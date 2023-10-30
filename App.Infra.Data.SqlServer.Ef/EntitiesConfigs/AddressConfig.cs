using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.City).HasMaxLength(50);
        entity.Property(e => e.FullAddress).HasMaxLength(255);
        entity.Property(e => e.PostalCode)
            .HasMaxLength(10)
            .IsFixedLength();
        entity.Property(e => e.Province).HasMaxLength(50);
    }
}