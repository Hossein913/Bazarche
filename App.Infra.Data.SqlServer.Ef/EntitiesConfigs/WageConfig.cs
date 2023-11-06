using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._User.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs
{
    public class WageConfig : IEntityTypeConfiguration<Wage>
    {
        public void Configure(EntityTypeBuilder<Wage> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Orderitem).WithOne(p => p.Wages)
                .HasForeignKey<Wage>(d => d.OrderitemId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Wages_OrderItems");

            entity.HasData(
                new Wage { Id = 1, OrderitemId = 1, FeePercenteage = 25, WageAmount = 80000 }
                );
        }
    
    }
}


