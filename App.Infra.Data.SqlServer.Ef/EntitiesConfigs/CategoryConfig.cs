using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Title).HasMaxLength(50);

        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
            .HasForeignKey(d => d.ParentId)
            .HasConstraintName("FK_Categories_Categories");

        entity.HasOne(d => d.Picture).WithMany(p => p.Categories)
            .HasForeignKey(d => d.PictureId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Categories_Pictures");
    }
}