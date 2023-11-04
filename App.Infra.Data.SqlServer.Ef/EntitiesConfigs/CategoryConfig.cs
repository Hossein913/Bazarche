using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Title).HasMaxLength(50);

        entity.HasOne(d => d.Parent).WithMany(p => p.Subcategories)
            .HasForeignKey(d => d.ParentId)
            .HasConstraintName("FK_Categories_Categories");

        entity.HasOne(d => d.Picture).WithOne(p => p.Categories)
            .HasForeignKey<Category>(d => d.PictureId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Categories_Pictures");

        entity.HasMany(c => c.Attributes).WithMany(a => a.Categories);
    }
}