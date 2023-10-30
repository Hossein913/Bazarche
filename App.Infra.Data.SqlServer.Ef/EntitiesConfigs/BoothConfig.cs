using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core.Booths.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class BoothConfig : IEntityTypeConfiguration<Booth>
{
    public void Configure(EntityTypeBuilder<Booth> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Description).HasMaxLength(300);
        entity.Property(e => e.Name).HasMaxLength(50);

        entity.HasOne(d => d.AvatarPicture).WithMany(p => p.Booths)
            .HasForeignKey(d => d.AvatarPictureId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Booths_Pictures");

        entity.HasOne(d => d.Medal).WithMany(p => p.Booths)
            .HasForeignKey(d => d.MedalId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Booths_Medals");
    }
}
