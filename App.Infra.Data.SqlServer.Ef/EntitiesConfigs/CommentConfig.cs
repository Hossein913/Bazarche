using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Text).HasMaxLength(600);


        // Comments are for Products therefor Delete customer Or Orderitems not effect on comments
        entity.HasOne(cs => cs.Customer).WithMany(cm => cm.Comments)
            .HasForeignKey(cm => cm.CustomerId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Comments_Customers");

        entity.HasOne(cm => cm.OrderItem).WithMany(cm => cm.Comments)
            .HasForeignKey(cm => cm.OrderItemId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Comments_OrderItems");
    }
}
