using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs
{
    public class ProductAttributeValueConfig : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> entity)
        {
            entity.HasKey(a => a.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Value).HasMaxLength(250);

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ProductAttributeValue_Attribute");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProductAttributeValue_Products");

        }
    }
}
