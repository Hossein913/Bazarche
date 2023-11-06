using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Booth.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class MedalConfig : IEntityTypeConfiguration<Medal>
{
    public void Configure(EntityTypeBuilder<Medal> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Name).HasMaxLength(50);

        entity.HasData(
            new Medal { Id = 1 , Name = "Default" , FeePercentage =10 , MinSalesRequired = 0 },
            new Medal { Id = 2 , Name = "Silver" , FeePercentage =8 , MinSalesRequired = 3000000 },
            new Medal { Id = 3 , Name = "Gold" , FeePercentage =5 , MinSalesRequired = 10000000 }
            );
    }
}