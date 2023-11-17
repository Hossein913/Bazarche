using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using App.Domain.Core._Products.Entities;
using System.Runtime.Intrinsics.X86;

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

        entity.HasData(
            new Category { Id = 1, Title = "کالای دیجیتال", ParentId = null ,PictureId =1},
            new Category { Id = 2, Title = "خانه و آشپزخانه", ParentId = null ,PictureId =2},
            new Category { Id = 3, Title = "مد و پوشاک", ParentId = null ,PictureId =3},
            new Category { Id = 4, Title = "کالاهای سوپر مارکتی", ParentId = null ,PictureId =4},
            new Category { Id = 5, Title = "کتاب و لوازم التحریر", ParentId = null ,PictureId =5},
            new Category { Id = 6, Title = "اسباب بازی ،کودک و نوزاد", ParentId = null ,PictureId =6},
            new Category { Id = 7, Title = "زیبایی و سلامت", ParentId = null ,PictureId =7},
            new Category { Id = 8, Title = "ورزش و سفر", ParentId = null ,PictureId =8},
            new Category { Id = 9, Title = "ابزار الات و تجهیزات", ParentId = null ,PictureId =9},
            new Category { Id = 10, Title = "خودرو و موتورسیکلت", ParentId = null ,PictureId =10},
            new Category { Id = 11, Title = "محصولات بومی محلی", ParentId = null ,PictureId =11},

            new Category { Id = 12, Title = "موبایل", ParentId = 1 ,PictureId =null},
            new Category { Id = 13, Title = "لبتاب", ParentId = 1 ,PictureId =null},
            new Category { Id = 14, Title = "لوازم جانبی لپ تاپ", ParentId = 1 ,PictureId =null},
            new Category { Id = 15, Title = "کامپیوتر", ParentId = 1 ,PictureId =null},
            new Category { Id = 16, Title = "لوازم جانبی گوشی", ParentId = 1 ,PictureId =null},
            new Category { Id = 17, Title = "کتابخوان", ParentId = 1 ,PictureId =null},
            new Category { Id = 18, Title = "واقعیت مجازی", ParentId = 1 ,PictureId =null},
            new Category { Id = 19, Title = "ساعت و مچ بند هوشمند", ParentId = 1 ,PictureId =null},
            new Category { Id = 20, Title = "تلوزیون", ParentId = 1 ,PictureId =null},
            new Category { Id = 21, Title = "هدفون، هدست، میکروفون", ParentId = 1 ,PictureId =null},
            new Category { Id = 22, Title = "اسپیکر بلوتوث و با سیم", ParentId = 1 ,PictureId =null},
            new Category { Id = 23, Title = "هارد، فلش و SSD", ParentId = 1 ,PictureId =null},
            new Category { Id = 24, Title = "دوربین", ParentId = 1 ,PictureId =null},
            new Category { Id = 25, Title = "لوازم جانبی دوربین", ParentId = 1 ,PictureId =null},
            new Category { Id = 26, Title = "تبلت", ParentId = 1 ,PictureId =null},
            new Category { Id = 27, Title = "کنسول بازی", ParentId = 1 ,PictureId =null},
            new Category { Id = 28, Title = "شارژر تبلت و موبایل", ParentId = 1 ,PictureId =null},
            new Category { Id = 29, Title = "کیف، کاور، لوازم جانبی تبلت", ParentId = 1 ,PictureId =null},
            new Category { Id = 30, Title = "باتری", ParentId = 1 ,PictureId =null},
            new Category { Id = 31, Title = "دوربین های تحت شبکه", ParentId = 1 ,PictureId =null},
            new Category { Id = 32, Title = "مودم و تجهیزات شبکه", ParentId = 1 ,PictureId =null},
            new Category { Id = 33, Title = "ماشین های اداری", ParentId = 1 ,PictureId =null},
            
            new Category { Id = 34, Title = "تلویزیون", ParentId = 2 ,PictureId =null},
            new Category { Id = 35, Title = "یخچال و فریزر", ParentId = 2 ,PictureId =null},
            new Category { Id = 36, Title = "دکوراتیو", ParentId = 2 ,PictureId =null},
            new Category { Id = 37, Title = "فرش ماشینی، دست بافت، تابلو", ParentId = 2 ,PictureId =null},
            new Category { Id = 38, Title = "لوازم برقی خانگی", ParentId = 2 ,PictureId =null},
            new Category { Id = 39, Title = "حیوانات خانگی، غذا و لوازم", ParentId = 2 ,PictureId =null},
            new Category { Id = 40, Title = "سرو و پذیرایی", ParentId = 2 ,PictureId =null},
            new Category { Id = 41, Title = "نور و روشنایی", ParentId = 2 ,PictureId =null},
            new Category { Id = 42, Title = "آشپزخانه", ParentId = 2 ,PictureId =null},
            new Category { Id = 43, Title = "مواد شوینده", ParentId = 2 ,PictureId =null},
            new Category { Id = 44, Title = "دستمال کاغذی", ParentId = 2 ,PictureId =null},
            new Category { Id = 45, Title = "ملحفه، سرویس، لوازم خواب", ParentId = 2 ,PictureId =null},
            new Category { Id = 46, Title = "حوله و وسایل حمام", ParentId = 2 ,PictureId =null},
            new Category { Id = 47, Title = "پادری، کمد، لوازم اتاق خواب", ParentId = 2 ,PictureId =null},
            new Category { Id = 48, Title = "لوازم دستشویی، روشویی", ParentId = 2 ,PictureId =null},
            new Category { Id = 49, Title = "فندک و لوازم جانبی", ParentId = 2 ,PictureId =null},
            new Category { Id = 50, Title = "گل، خاک، کود، لوازم باغبانی", ParentId = 2 ,PictureId =null},
            new Category { Id = 51, Title = "کولر گازی", ParentId = 2 ,PictureId =null},
            new Category { Id = 52, Title = "کولر آبی", ParentId = 2 ,PictureId =null},
            
            new Category { Id = 53, Title = "مردانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 54, Title = "لباس مردانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 55, Title = "اکسسوری مردانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 56, Title = "زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 57, Title = "لباس زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 58, Title = "کفش زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 59, Title = "اکسسوری زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 60, Title = "طلا", ParentId = 3 ,PictureId =null},
            new Category { Id = 61, Title = "زیورآلات زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 62, Title = "زیورآلات نقره زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 63, Title = "عینک آفتابی زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 64, Title = "عینک آفتابی مردانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 65, Title = "پوشاک ورزشی مردانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 66, Title = "پوشاک ورزشی زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 67, Title = "کفش ورزشی مردانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 68, Title = "کفش ورزشی زنانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 69, Title = "پوشاک ورزشی پسرانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 70, Title = "پوشاک ورزشی دخترانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 71, Title = "کفش ورزشی پسرانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 72, Title = "کفش ورزشی دخترانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 73, Title = "کوله پشتی مردانه", ParentId = 3 ,PictureId =null},
            new Category { Id = 74, Title = "بچگانه", ParentId = 3 ,PictureId =null},

            new Category { Id = 75, Title = "کالاهای اساسی و خوار و بار", ParentId = 4 ,PictureId =null},
            new Category { Id = 76, Title = "صبحانه ", ParentId = 4 ,PictureId =null},
            new Category { Id = 77, Title = "مواد پروتئینی", ParentId = 4 ,PictureId =null},
            new Category { Id = 78, Title = "لبنیات ", ParentId = 4 ,PictureId =null},
            new Category { Id = 79, Title = "نوشیدنی ها", ParentId = 4 ,PictureId =null},
            new Category { Id = 80, Title = "میوه و سبزی", ParentId = 4 ,PictureId =null},
            new Category { Id = 81, Title = "غذای آماده و نودل", ParentId = 4 ,PictureId =null},
            new Category { Id = 82, Title = "فرآورده‌های منجمد", ParentId = 4 ,PictureId =null},
            new Category { Id = 83, Title = "تنقلات", ParentId = 4 ,PictureId =null},
            new Category { Id = 84, Title = "کنسرو و کمپوت", ParentId = 4 ,PictureId =null},
            new Category { Id = 85, Title = "خشکبار و شیرینی", ParentId = 4 ,PictureId =null},

            new Category { Id = 86, Title = "کتاب و مجله", ParentId = 5 ,PictureId =null},
            new Category { Id = 87, Title = "کتاب صوتی", ParentId = 5 ,PictureId =null},
            new Category { Id = 88, Title = "محتوای آموزشی", ParentId = 5 ,PictureId =null},
            new Category { Id = 89, Title = "نرم افزار", ParentId = 5 ,PictureId =null},
            new Category { Id = 90, Title = "بازی کنسول و کامپیوتر", ParentId = 5 ,PictureId =null},
            new Category { Id = 91, Title = "فیلم سینمایی، سریال و مستند", ParentId = 5 ,PictureId =null},
            new Category { Id = 92, Title = "آلبوم موسیقی", ParentId = 5 ,PictureId =null},
            new Category { Id = 93, Title = "لوازم تحریر ", ParentId = 5 ,PictureId =null},
            new Category { Id = 94, Title = "آلات موسیقی", ParentId = 5 ,PictureId =null},
            new Category { Id = 95, Title = "فرش ماشینی، دستبافت، تابلو", ParentId = 5 ,PictureId =null},
            new Category { Id = 96, Title = "صنایع دستی", ParentId = 4 ,PictureId =null},
            
            new Category { Id = 97, Title = "بهداشت و حمام کودک و نوزاد", ParentId = 6 ,PictureId =null},
            new Category { Id = 98, Title = "پوشاک و کفش کودک و نوزاد ", ParentId = 6 ,PictureId =null},
            new Category { Id = 99, Title = "تبلت", ParentId = 6 ,PictureId =null},
            new Category { Id = 100, Title = "پلی استیشن، ایکس باکس و بازی", ParentId = 6 ,PictureId =null},
            new Category { Id = 101, Title = "اسباب بازی", ParentId = 6 ,PictureId =null},
            new Category { Id = 102, Title = "بازی و سرگرمی کودک ", ParentId = 6 ,PictureId =null},
            new Category { Id = 103, Title = "سلامت، ایمنی و مراقبت", ParentId = 6 ,PictureId =null},
            new Category { Id = 104, Title = "خواب کودک", ParentId = 6 ,PictureId =null},
            new Category { Id = 105, Title = "ملزومات گردش و سفر", ParentId = 6 ,PictureId =null},
            new Category { Id = 106, Title = "لوازم شخصی", ParentId = 6 ,PictureId =null},
            new Category { Id = 107, Title = "غذا خوری", ParentId = 6 ,PictureId =null},

            new Category { Id = 108, Title = "لوازم آرایشی", ParentId = 7 ,PictureId =null},
            new Category { Id = 109, Title = "مراقبت پوست", ParentId = 7 ,PictureId =null},
            new Category { Id = 110, Title = "مراقبت و زیبایی مو", ParentId = 7 ,PictureId =null},
            new Category { Id = 111, Title = "لوازم بهداشتی ", ParentId = 7 ,PictureId =null},
            new Category { Id = 112, Title = "عطر و ادکلن", ParentId = 7 ,PictureId =null},
            new Category { Id = 113, Title = "لوازم شخصی برقی", ParentId = 7 ,PictureId =null},
            new Category { Id = 114, Title = "ابزار سلامت", ParentId = 7 ,PictureId =null},
            
            new Category { Id = 115, Title = "پوشاک ورزشی ", ParentId = 8 ,PictureId =null},
            new Category { Id = 116, Title = "کفش ورزشی ", ParentId = 8 ,PictureId =null},
            new Category { Id = 117, Title = "تجهیزات سفر", ParentId = 8 ,PictureId =null},
            new Category { Id = 118, Title = "دوچرخه", ParentId = 8 ,PictureId =null},
            new Category { Id = 119, Title = "کوهنوردی و کمپینگ", ParentId = 8 ,PictureId =null},
            new Category { Id = 120, Title = "چتر", ParentId = 8 ,PictureId =null},
            new Category { Id = 121, Title = "ساک ورزشی", ParentId = 8 ,PictureId =null},
            new Category { Id = 122, Title = "قمقمه و شیکر", ParentId = 8 ,PictureId =null},
            new Category { Id = 123, Title = "لوازم ورزشی", ParentId = 8 ,PictureId =null},
            new Category { Id = 124, Title = "اسکوتر برقی", ParentId = 8 ,PictureId =null},
            new Category { Id = 125, Title = "v", ParentId = 8 ,PictureId =null},

            new Category { Id = 126, Title = "ابزار برقی ", ParentId = 9 ,PictureId =null},
            new Category { Id = 127, Title = "ابزار غیر برقی ", ParentId = 9 ,PictureId =null},
            new Category { Id = 128, Title = "لوازم الکتریکی و یراق آلات", ParentId = 9 ,PictureId =null},
            new Category { Id = 129, Title = "لوازم باغبانی و کشاورزی", ParentId = 9 ,PictureId =null},
            new Category { Id = 130, Title = "تجهیزات ایمنی و کار ", ParentId = 9 ,PictureId =null},
            new Category { Id = 131, Title = "حفاظتی و امنیتی", ParentId = 9 ,PictureId =null},
            new Category { Id = 132, Title = "دستگاه های حمل و بالابر صنعتی", ParentId = 9 ,PictureId =null},

            new Category { Id = 133, Title = "خودرو", ParentId = 10 ,PictureId =null},
            new Category { Id = 134, Title = "موتور سیکلت", ParentId = 10 ,PictureId =null},
            new Category { Id = 135, Title = "لوازم مصرفی خودرو ", ParentId = 10 ,PictureId =null},
            new Category { Id = 136, Title = "لوازم یدکی خودرو", ParentId = 10 ,PictureId =null},
            new Category { Id = 137, Title = "لوازم صوتی و تصویری", ParentId = 10 ,PictureId =null},
            new Category { Id = 138, Title = "لوازم جانبی خودرو ", ParentId = 10 ,PictureId =null},
            new Category { Id = 139, Title = "لوازم موتور سیکلت", ParentId = 10 ,PictureId =null},

            new Category { Id = 140, Title = "مواد غذایی ارگانیک", ParentId = 11 ,PictureId =null},
            new Category { Id = 141, Title = "خواروبار محلی", ParentId = 11 ,PictureId =null},
            new Category { Id = 142, Title = "صبحانه محلی", ParentId = 11 ,PictureId =null},
            new Category { Id = 143, Title = "کیک و شیرینی خانگی", ParentId = 11 ,PictureId =null},
            new Category { Id = 144, Title = "تنقلات خانگی", ParentId = 11 ,PictureId =null},
            new Category { Id = 145, Title = "لبنیات سنتی ", ParentId = 11 ,PictureId =null},
            new Category { Id = 146, Title = "خشکبار و آجیل سنتی", ParentId = 11 ,PictureId =null},
            new Category { Id = 147, Title = "غلات و حبوبات ارگانیک", ParentId = 11 ,PictureId =null},
            new Category { Id = 148, Title = "ادویه و چاشنی ارگانیک", ParentId = 11 ,PictureId =null},
            new Category { Id = 149, Title = "عطاری", ParentId = 11 ,PictureId =null},
            new Category { Id = 150, Title = "ترشیجات و شور خانگی", ParentId = 11 ,PictureId =null},
            new Category { Id = 151, Title = "دکوراتیو سنتی", ParentId = 11 ,PictureId =null},
            new Category { Id = 152, Title = "خانه و کاشانه", ParentId = 11 ,PictureId =null},
            new Category { Id = 153, Title = "نوشیدنی‌های ارگانیک", ParentId = 11 ,PictureId =null},
            new Category { Id = 154, Title = "نوشیدنی‌های ارگانیک", ParentId = 11 ,PictureId =null},
            new Category { Id = 155, Title = "اکسسوری و زیورآلات دست ساز", ParentId = 11 ,PictureId =null},
            new Category { Id = 156, Title = "پوشاک بومی و محلی", ParentId = 11 ,PictureId =null},
            new Category { Id = 157, Title = "قالی و قالیچه", ParentId = 11 ,PictureId =null},
            new Category { Id = 158, Title = "ظروف سنتی", ParentId = 11 ,PictureId =null},
            new Category { Id = 159, Title = "لوازم آشپزخانه سنتی", ParentId = 11 ,PictureId =null},
            new Category { Id = 160, Title = "رومیزی، رانر و زیربشقابی سنتی", ParentId = 11 ,PictureId =null}
        );
    }
}