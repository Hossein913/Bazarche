using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Text).HasMaxLength(600);

        entity.HasOne(d => d.Customer).WithMany()
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Comments_Customers");

        entity.HasOne(d => d.OrderItem).WithMany()
            .HasForeignKey(d => d.OrderItemId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Comments_OrderItems");
    }
}
