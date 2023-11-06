using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Booth.Entities;
using App.Infra.Data.SqlServer.Ef.Migrations;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class BoothConfig : IEntityTypeConfiguration<Booth>
{
    public void Configure(EntityTypeBuilder<Booth> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Description).HasMaxLength(300);
        entity.Property(e => e.Name).HasMaxLength(50);

        entity.HasOne(d => d.AvatarPicture).WithOne(p => p.Booths)
            .HasForeignKey<Booth>(d => d.AvatarPictureId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Booths_Pictures");

        entity.HasOne(d => d.Medal).WithMany(p => p.Booths)
            .HasForeignKey(d => d.MedalId)
            .OnDelete(DeleteBehavior.NoAction)
        .HasConstraintName("FK_Booths_Medals");

        entity.HasData(
        new Booth { Id = 1, Name = "رویال ", AvatarPictureId = 16, MedalId = 1, AccountBalance = 0, Description = "عرضه کننده انواع محصولات", IsActive =true , IsDeleted = false },
        new Booth { Id = 2, Name = "نوین", AvatarPictureId = 17, MedalId = 2, AccountBalance = 2300000, Description = "شیک پوشی شما با ما", IsActive = true, IsDeleted = false }

    );
    }
}

