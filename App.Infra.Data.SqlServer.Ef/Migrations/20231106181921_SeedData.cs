using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.Data.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Booths",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sellers");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Pictures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "FullAddress", "PostalCode", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "پردیس", "خیابان 29", "2185217412", 1 },
                    { 2, "شهریار", "خیابان 92،کوچه اول", "8745123951", 1 },
                    { 3, "اراک", "خیابان شهید شیرودی ،نبش دبستان دین ودانش", "3851775124", 28 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PermissionName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN", "SuperAdmin" },
                    { 2, null, "Seller", "SELLER", "DefaultSeller" },
                    { 3, null, "Customer", "CUSTOMER", "DefaultCustomer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b3ff5bed-a006-448e-8f4d-37ec7d737a3f", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(323), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin@mail.com", true, true, false, false, null, null, "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEGz0GYwWHVTcS6WDst21j4iWOpf5dcXtW5alWd308pwpya/ZgQjxtzzGY9o4C7PYig==", null, false, null, false, "Admin@mail.com" },
                    { 2, 0, "d88601a4-f509-4a29-886f-f94832158d21", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(335), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seller1@mail.com", true, true, false, false, null, null, "SELLER1@MAIL.COM", "AQAAAAIAAYagAAAAELOkDVqw5VM9gJkZdbDBUDoDV8G40Ul335omeJREctLlIyYM1I6XjnBJvv3+3bcWjQ==", null, false, null, false, "Seller1@mail.com" },
                    { 3, 0, "4f2efd0f-4ea1-4457-899f-ba39c6453141", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(340), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seller2@mail.com", true, true, false, false, null, null, "SELLER2@MAIL.COM", "AQAAAAIAAYagAAAAEE+K6MnprVXAWp5zI9V5q0KqPaAeuaUxP7boxQsUuaj+oSFbXSx32iXrtT/cZS9H9Q==", null, false, null, false, "Seller2@mail.com" },
                    { 4, 0, "1c3bae04-1a16-475f-8361-3b6922eba736", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer@mail.com", true, true, false, false, null, null, "CUSTOMER@MAIL.COM", "AQAAAAIAAYagAAAAEBMWN/AKojskUngHVkSwMaS3NJXaNzlrsrbmked8HGKIGtDVBJ5Koso+gO/bGUKDYQ==", null, false, null, false, "customer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentId", "PictureId", "Title" },
                values: new object[] { 13, null, null, "لوازم جانبی لپ تاپ" });

            migrationBuilder.InsertData(
                table: "Medals",
                columns: new[] { "Id", "FeePercentage", "MinSalesRequired", "Name" },
                values: new object[,]
                {
                    { 1, 10, 0, "Default" },
                    { 2, 8, 3000000, "Silver" },
                    { 3, 5, 10000000, "Gold" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ImageUrl", "IsDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8017), null, "102140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 2, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8032), null, "202140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 3, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8034), null, "302140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 4, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8035), null, "402140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 5, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8037), null, "502140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 6, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8038), null, "602140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 7, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8040), null, "702140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 8, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8041), null, "802140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 9, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8043), null, "902140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 10, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8044), null, "102140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 11, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8058), null, "112140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 12, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8059), null, "5522140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 13, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8061), null, "5502140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 14, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8062), null, "5512140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 15, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8063), null, "5532140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 16, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8072), null, "9902140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 17, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8073), null, "9912140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 18, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8075), null, "8802140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 19, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8081), null, "8812140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 20, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8092), null, "8822140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 21, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8093), null, "8832140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 22, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8095), null, "8842140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 23, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8096), null, "8852140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 24, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8097), null, "8862140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 25, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8099), null, "8872140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 26, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8100), null, "8882140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 27, new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8102), null, "8892140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BasePrise", "Brand", "CategoryId", "Describtion", "Grantee", "IncludedComponentes", "InformationDetails", "IsConfirmed", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 100000, "زاگرس پوش", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "جنس نخ پنبه ای", true, false, "پیراهن سرمه ای نخی" },
                    { 2, 1800000, "ال سی من", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "سایز ها ایکس و ایکس لارج", true, false, "هودی آبی" },
                    { 3, 100000, "اسکیچر", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "جنس زیره پی یو", false, false, "کفش پیاده روی" },
                    { 4, 100000, "کرال", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "نمد ضد آب", true, false, "کلاه نمدی قهوه ای" },
                    { 5, 100000, "تسکو", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "مخصوص بازی", false, false, "هدفوت بلوتوث " },
                    { 6, 100000, "آیفون", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "باتری 800 میلی آمپر", true, false, "ساعت هوشمند" },
                    { 7, 100000, "سامسونگ", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "ضد آب", false, false, "ایر پاد سامسونگ" },
                    { 8, 100000, "سونی", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "سنسور 21 مگاپیکسل", true, false, "دوربین کامپکت" },
                    { 9, 32000000, "آیفون", null, "محصول عالی", "زمانت تعویض هفت روزه", "", "ضد آب", true, false, "گوشی آیفون 12" },
                    { 10, 28000000, "اچ پی", null, "محصول عالی", "زمانت تعویض هفت روزه", "", " پردازنده نسل 13", true, false, "لبتاب hp" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AppuserId", "Birthdate", "Firstname", "Lastname", "ProfilePicId", "ShabaNumber", "Wallet" },
                values: new object[] { 1, 1, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسین", "بشارتی", 12, "Ir89752140000007800125", 800000 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Booths",
                columns: new[] { "Id", "AccountBalance", "AvatarPictureId", "Description", "IsActive", "IsDeleted", "MedalId", "Name" },
                values: new object[,]
                {
                    { 1, 0, 16, "عرضه کننده انواع محصولات", true, false, 1, "رویال " },
                    { 2, 2300000, 17, "شیک پوشی شما با ما", true, false, 2, "نوین" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentId", "PictureId", "Title" },
                values: new object[,]
                {
                    { 1, null, 1, "کالای دیجیتال" },
                    { 2, null, 2, "خانه و آشپزخانه" },
                    { 3, null, 3, "مد و پوشاک" },
                    { 4, null, 4, "کالاهای سوپر مارکتی" },
                    { 5, null, 5, "کتاب و لوازم التحریر" },
                    { 6, null, 6, "اسباب بازی ،کودک و نوزاد" },
                    { 7, null, 7, "زیبایی و سلامت" },
                    { 8, null, 8, "ورزش و سفر" },
                    { 9, null, 9, "ابزار الات و تجهیزات" },
                    { 10, null, 10, "خودرو و موتورسیکلت" },
                    { 11, null, 11, "محصولات بومی محلی" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "AppUserId", "Birthdate", "Firstname", "Lastname", "ProfilePicId", "Sexuality", "Wallet" },
                values: new object[] { 1, 3, 4, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "جواد  ", "بیات", 15, null, null });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "AddressId", "AppuserId", "Birthdate", "BoothId", "Firstname", "Lastname", "ProfilePicId", "ShabaNumber" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "حامد", "کریمی", 13, "Ir89752140000007800125" },
                    { 2, 2, 3, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "میلاد", "بداقی", 14, "Ir89752140000007800125" }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BasePrice", "BoothId", "CustomerId", "EndTime", "IsConfirmed", "ProductId", "StartTime", "Status", "WinnerId" },
                values: new object[] { 1, 700000, 1, null, new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null });

            migrationBuilder.InsertData(
                table: "BoothProducts",
                columns: new[] { "Id", "BoothId", "Count", "CreatedAt", "IsDeleted", "Price", "ProductId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 10, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8037), false, 800000, 1, true },
                    { 2, 1, 5, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8051), false, 800000, 9, true },
                    { 3, 1, 10, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8053), false, 800000, 8, true },
                    { 4, 1, 5, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8055), false, 800000, 3, true },
                    { 5, 2, 10, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8056), false, 800000, 6, true },
                    { 6, 2, 5, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8058), false, 800000, 2, true },
                    { 7, 2, 10, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8060), false, 800000, 4, true },
                    { 8, 2, 5, new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8062), false, 800000, 9, true }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentId", "PictureId", "Title" },
                values: new object[,]
                {
                    { 12, 1, null, "موبایل" },
                    { 14, 1, null, "کامپیوتر" },
                    { 15, 1, null, "لوازم جانبی گوشی" },
                    { 16, 1, null, "کتابخوان" },
                    { 17, 1, null, "واقعیت مجازی" },
                    { 18, 1, null, "ساعت و مچ بند هوشمند" },
                    { 19, 1, null, "تلوزیون" },
                    { 20, 1, null, "هدفون، هدست، میکروفون" },
                    { 21, 1, null, "اسپیکر بلوتوث و با سیم" },
                    { 22, 1, null, "هارد، فلش و SSD" },
                    { 23, 1, null, "دوربین" },
                    { 24, 1, null, "لوازم جانبی دوربین" },
                    { 25, 1, null, "تبلت" },
                    { 26, 1, null, "کنسول بازی" },
                    { 27, 1, null, "شارژر تبلت و موبایل" },
                    { 28, 1, null, "کیف، کاور، لوازم جانبی تبلت" },
                    { 29, 1, null, "باتری" },
                    { 30, 1, null, "دوربین های تحت شبکه" },
                    { 31, 1, null, "مودم و تجهیزات شبکه" },
                    { 32, 1, null, "ماشین های اداری" },
                    { 33, 2, null, "تلویزیون" },
                    { 34, 2, null, "یخچال و فریزر" },
                    { 35, 2, null, "دکوراتیو" },
                    { 36, 2, null, "فرش ماشینی، دست بافت، تابلو" },
                    { 37, 2, null, "لوازم برقی خانگی" },
                    { 38, 2, null, "حیوانات خانگی، غذا و لوازم" },
                    { 39, 2, null, "سرو و پذیرایی" },
                    { 40, 2, null, "نور و روشنایی" },
                    { 41, 2, null, "آشپزخانه" },
                    { 42, 2, null, "مواد شوینده" },
                    { 43, 2, null, "دستمال کاغذی" },
                    { 44, 2, null, "ملحفه، سرویس، لوازم خواب" },
                    { 45, 2, null, "حوله و وسایل حمام" },
                    { 46, 2, null, "پادری، کمد، لوازم اتاق خواب" },
                    { 47, 2, null, "لوازم دستشویی، روشویی" },
                    { 48, 2, null, "فندک و لوازم جانبی" },
                    { 49, 2, null, "گل، خاک، کود، لوازم باغبانی" },
                    { 50, 2, null, "کولر گازی" },
                    { 51, 2, null, "کولر آبی" },
                    { 52, 3, null, "مردانه" },
                    { 53, 3, null, "لباس مردانه" },
                    { 54, 3, null, "اکسسوری مردانه" },
                    { 55, 3, null, "زنانه" },
                    { 56, 3, null, "لباس زنانه" },
                    { 57, 3, null, "کفش زنانه" },
                    { 58, 3, null, "اکسسوری زنانه" },
                    { 59, 3, null, "طلا" },
                    { 60, 3, null, "زیورآلات زنانه" },
                    { 61, 3, null, "زیورآلات نقره زنانه" },
                    { 62, 3, null, "عینک آفتابی زنانه" },
                    { 63, 3, null, "عینک آفتابی مردانه" },
                    { 64, 3, null, "پوشاک ورزشی مردانه" },
                    { 65, 3, null, "پوشاک ورزشی زنانه" },
                    { 66, 3, null, "کفش ورزشی مردانه" },
                    { 67, 3, null, "کفش ورزشی زنانه" },
                    { 68, 3, null, "پوشاک ورزشی پسرانه" },
                    { 69, 3, null, "پوشاک ورزشی دخترانه" },
                    { 70, 3, null, "کفش ورزشی پسرانه" },
                    { 71, 3, null, "کفش ورزشی دخترانه" },
                    { 72, 3, null, "کوله پشتی مردانه" },
                    { 73, 3, null, "بچگانه" },
                    { 74, 4, null, "کالاهای اساسی و خوار و بار" },
                    { 75, 4, null, "صبحانه " },
                    { 76, 4, null, "مواد پروتئینی" },
                    { 77, 4, null, "لبنیات " },
                    { 78, 4, null, "نوشیدنی ها" },
                    { 79, 4, null, "میوه و سبزی" },
                    { 80, 4, null, "غذای آماده و نودل" },
                    { 81, 4, null, "فرآورده‌های منجمد" },
                    { 82, 4, null, "تنقلات" },
                    { 83, 4, null, "کنسرو و کمپوت" },
                    { 84, 4, null, "خشکبار و شیرینی" },
                    { 85, 5, null, "کتاب و مجله" },
                    { 86, 5, null, "کتاب صوتی" },
                    { 87, 5, null, "محتوای آموزشی" },
                    { 88, 5, null, "نرم افزار" },
                    { 89, 5, null, "بازی کنسول و کامپیوتر" },
                    { 90, 5, null, "فیلم سینمایی، سریال و مستند" },
                    { 91, 5, null, "آلبوم موسیقی" },
                    { 92, 5, null, "لوازم تحریر " },
                    { 93, 5, null, "آلات موسیقی" },
                    { 94, 5, null, "فرش ماشینی، دستبافت، تابلو" },
                    { 95, 4, null, "صنایع دستی" },
                    { 96, 6, null, "بهداشت و حمام کودک و نوزاد" },
                    { 97, 6, null, "پوشاک و کفش کودک و نوزاد " },
                    { 98, 6, null, "تبلت" },
                    { 99, 6, null, "پلی استیشن، ایکس باکس و بازی" },
                    { 100, 6, null, "اسباب بازی" },
                    { 101, 6, null, "بازی و سرگرمی کودک " },
                    { 102, 6, null, "سلامت، ایمنی و مراقبت" },
                    { 103, 6, null, "خواب کودک" },
                    { 104, 6, null, "ملزومات گردش و سفر" },
                    { 105, 6, null, "لوازم شخصی" },
                    { 106, 6, null, "غذا خوری" },
                    { 107, 7, null, "لوازم آرایشی" },
                    { 108, 7, null, "مراقبت پوست" },
                    { 109, 7, null, "مراقبت و زیبایی مو" },
                    { 110, 7, null, "لوازم بهداشتی " },
                    { 111, 7, null, "عطر و ادکلن" },
                    { 112, 7, null, "لوازم شخصی برقی" },
                    { 113, 7, null, "ابزار سلامت" },
                    { 114, 8, null, "پوشاک ورزشی " },
                    { 115, 8, null, "کفش ورزشی " },
                    { 116, 8, null, "تجهیزات سفر" },
                    { 117, 8, null, "دوچرخه" },
                    { 118, 8, null, "کوهنوردی و کمپینگ" },
                    { 119, 8, null, "چتر" },
                    { 120, 8, null, "ساک ورزشی" },
                    { 121, 8, null, "قمقمه و شیکر" },
                    { 122, 8, null, "لوازم ورزشی" },
                    { 123, 8, null, "اسکوتر برقی" },
                    { 124, 8, null, "v" },
                    { 125, 9, null, "ابزار برقی " },
                    { 126, 9, null, "ابزار غیر برقی " },
                    { 127, 9, null, "لوازم الکتریکی و یراق آلات" },
                    { 128, 9, null, "لوازم باغبانی و کشاورزی" },
                    { 129, 9, null, "تجهیزات ایمنی و کار " },
                    { 130, 9, null, "حفاظتی و امنیتی" },
                    { 131, 9, null, "دستگاه های حمل و بالابر صنعتی" },
                    { 132, 10, null, "خودرو" },
                    { 133, 10, null, "موتور سیکلت" },
                    { 134, 10, null, "لوازم مصرفی خودرو " },
                    { 135, 10, null, "لوازم یدکی خودرو" },
                    { 136, 10, null, "لوازم صوتی و تصویری" },
                    { 137, 10, null, "لوازم جانبی خودرو " },
                    { 138, 10, null, "لوازم موتور سیکلت" },
                    { 139, 11, null, "مواد غذایی ارگانیک" },
                    { 140, 11, null, "خواروبار محلی" },
                    { 141, 11, null, "صبحانه محلی" },
                    { 142, 11, null, "کیک و شیرینی خانگی" },
                    { 143, 11, null, "تنقلات خانگی" },
                    { 144, 11, null, "لبنیات سنتی " },
                    { 145, 11, null, "خشکبار و آجیل سنتی" },
                    { 146, 11, null, "غلات و حبوبات ارگانیک" },
                    { 147, 11, null, "ادویه و چاشنی ارگانیک" },
                    { 148, 11, null, "عطاری" },
                    { 149, 11, null, "ترشیجات و شور خانگی" },
                    { 150, 11, null, "دکوراتیو سنتی" },
                    { 151, 11, null, "خانه و کاشانه" },
                    { 152, 11, null, "نوشیدنی‌های ارگانیک" },
                    { 153, 11, null, "نوشیدنی‌های ارگانیک" },
                    { 154, 11, null, "اکسسوری و زیورآلات دست ساز" },
                    { 155, 11, null, "پوشاک بومی و محلی" },
                    { 156, 11, null, "قالی و قالیچه" },
                    { 157, 11, null, "ظروف سنتی" },
                    { 158, 11, null, "لوازم آشپزخانه سنتی" },
                    { 159, 11, null, "رومیزی، رانر و زیربشقابی سنتی" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "PayedAt", "Status", "TotalPrice" },
                values: new object[] { 1, new DateTime(2023, 11, 6, 21, 49, 21, 192, DateTimeKind.Local).AddTicks(2020), 1, new DateTime(2023, 11, 6, 21, 49, 21, 192, DateTimeKind.Local).AddTicks(2024), true, 1 });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "BoothProductid", "count", "IsActive", "OrderId" },
                values: new object[] { 1, 1, 1, true, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsConfirmed", "IsDeleted", "OrderItemId", "PictureId", "Text" },
                values: new object[] { 1, new DateTime(2023, 11, 6, 21, 49, 21, 191, DateTimeKind.Local).AddTicks(4898), 1, false, false, 1, null, "محصول فوق العاده ای بود. سپاس" });

            migrationBuilder.InsertData(
                table: "Wages",
                columns: new[] { "Id", "FeePercenteage", "OrderitemId", "WageAmount" },
                values: new object[] { 1, 25, 1, 80000 });

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Booths",
                table: "Sellers",
                column: "BoothId",
                principalTable: "Booths",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Booths",
                table: "Sellers");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sellers",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Booths",
                table: "Sellers",
                column: "BoothId",
                principalTable: "Booths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
