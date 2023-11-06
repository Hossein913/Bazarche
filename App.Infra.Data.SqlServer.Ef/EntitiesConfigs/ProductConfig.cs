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
        entity.Property(e => e.Describtion).HasMaxLength(300);
        entity.Property(e => e.Grantee).HasMaxLength(255);
        entity.Property(e => e.Name).HasMaxLength(255);

        entity.HasMany(p => p.Pictures).WithMany(a => a.Products);

        entity.HasData(
            new Product { Id = 1, Name = "پیراهن سرمه ای نخی", Brand = "زاگرس پوش", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "جنس نخ پنبه ای", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = true, BasePrise = 100000, IsDeleted = false },
            new Product { Id = 2, Name = "هودی آبی", Brand = "ال سی من", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "سایز ها ایکس و ایکس لارج", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = true, BasePrise = 1800000, IsDeleted = false },
            new Product { Id = 3, Name = "کفش پیاده روی", Brand = "اسکیچر", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "جنس زیره پی یو", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = false, BasePrise = 100000, IsDeleted = false },
            new Product { Id = 4, Name = "کلاه نمدی قهوه ای", Brand = "کرال", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "نمد ضد آب", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = true, BasePrise = 100000, IsDeleted = false },
            new Product { Id = 5, Name = "هدفوت بلوتوث ", Brand = "تسکو", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "مخصوص بازی", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = false, BasePrise = 100000, IsDeleted = false },
            new Product { Id = 6, Name = "ساعت هوشمند", Brand = "آیفون", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "باتری 800 میلی آمپر", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = true, BasePrise = 100000, IsDeleted = false },
            new Product { Id = 7, Name = "ایر پاد سامسونگ", Brand = "سامسونگ", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "ضد آب", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = false, BasePrise = 100000, IsDeleted = false },
            new Product { Id = 8, Name = "دوربین کامپکت", Brand = "سونی", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "سنسور 21 مگاپیکسل", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = true, BasePrise = 100000, IsDeleted = false },
            new Product { Id = 9, Name = "گوشی آیفون 12", Brand = "آیفون", Grantee = "زمانت تعویض هفت روزه", InformationDetails = "ضد آب", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = true, BasePrise = 32000000, IsDeleted = false },
            new Product { Id =10, Name = "لبتاب hp", Brand = "اچ پی", Grantee = "زمانت تعویض هفت روزه", InformationDetails = " پردازنده نسل 13", Describtion = "محصول عالی", IncludedComponentes = "", IsConfirmed = true, BasePrise = 28000000, IsDeleted = false }
            );

    }
}

