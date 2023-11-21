using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Common.Entities;

namespace App.Infra.Data.SqlServer.Ef.EntitiesConfigs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.Property(e => e.Brand).HasMaxLength(255);
        entity.Property(e => e.Description).HasMaxLength(300);
        entity.Property(e => e.Grantee).HasMaxLength(255);
        entity.Property(e => e.Name).HasMaxLength(255);

        entity.HasMany(p => p.Pictures).WithMany(a => a.Products);

        entity.HasOne(d => d.Category).WithMany(p => p.Products)
        .HasForeignKey(d => d.CategoryId)
        .HasConstraintName("FK_Products_Categories");

        entity.HasData(
            new Product { Id = 1, Name = "پیراهن سرمه ای نخی", Brand = "زاگرس پوش", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "جنس نخ پنبه ای", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = true, BasePrice = 100000, CategoryId = 54, IsDeleted = false },
            new Product { Id = 2, Name = "هودی آبی", Brand = "ال سی من", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "سایز ها ایکس و ایکس لارج", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = true, BasePrice = 1800000, CategoryId = 69, IsDeleted = false },
            new Product { Id = 3, Name = "کفش پیاده روی", Brand = "اسکیچر", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "جنس زیره پی یو", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = false, BasePrice = 100000, CategoryId = 68, IsDeleted = false },
            new Product { Id = 4, Name = "کلاه نمدی قهوه ای", Brand = "کرال", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "نمد ضد آب", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = true, BasePrice = 100000, CategoryId = 55, IsDeleted = false },
            new Product { Id = 5, Name = "هدفوت بلوتوث ", Brand = "تسکو", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "مخصوص بازی", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = false, BasePrice = 100000, CategoryId = 21, IsDeleted = false },
            new Product { Id = 6, Name = "ساعت هوشمند", Brand = "آیفون", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "باتری 800 میلی آمپر", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = true, BasePrice = 100000, CategoryId = 19, IsDeleted = false },
            new Product { Id = 7, Name = "ایر پاد سامسونگ", Brand = "سامسونگ", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "ضد آب", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = false, BasePrice = 100000, CategoryId = 21, IsDeleted = false },
            new Product { Id = 8, Name = "دوربین کامپکت", Brand = "سونی", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "سنسور 21 مگاپیکسل", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = true, BasePrice = 100000, CategoryId = 22, IsDeleted = false },
            new Product { Id = 9, Name = "گوشی آیفون 12", Brand = "آیفون", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = "ضد آب", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = true, BasePrice = 32000000, CategoryId = 12, IsDeleted = false },
            new Product { Id =10, Name = "لبتاب hp", Brand = "اچ پی", Grantee = "ضمانت تعویض هفت روزه", InformationDetails = " پردازنده نسل 13", Description = "محصول عالی", IncludedComponents = "", IsConfirmed = true, BasePrice = 28000000, CategoryId = 13, IsDeleted = false }
            );

    }
}

