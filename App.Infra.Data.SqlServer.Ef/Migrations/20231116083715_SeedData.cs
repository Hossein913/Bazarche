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
                name: "FK_Admins_AspNetUsers_AppuserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AspNetUsers_AppuserId",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Booths",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Sellers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Sellers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "AppuserId",
                table: "Sellers",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_AppuserId",
                table: "Sellers",
                newName: "IX_Sellers_AppUserId");

            migrationBuilder.RenameColumn(
                name: "IncludedComponentes",
                table: "Products",
                newName: "IncludedComponents");

            migrationBuilder.RenameColumn(
                name: "Describtion",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "BasePrise",
                table: "Products",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Admins",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Admins",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "AppuserId",
                table: "Admins",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_AppuserId",
                table: "Admins",
                newName: "IX_Admins_AppUserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasePrice",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Pictures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CartOrderId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                table: "Auctions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "FullAddress", "PostalCode", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "پردیس", "خیابان 29", "2185217412", 1 },
                    { 2, "شهریار", "خیابان 92،کوچه اول", "8745123951", 1 },
                    { 3, "اراک", "خیابان شهید شیرودی ،نبش دبستان دین ودانش", "3851775124", 28 },
                    { 4, "اراک", "خیابان شهید شیرودی ،نبش دبستان ", "3851775124", 28 }
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
                    { 1, 0, "74bef2d9-ad09-4594-9198-13b1a537c731", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9167), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin@mail.com", true, true, false, false, null, null, "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEHRsddfTauO+aEDqZu/PagJvSti01YFvu39jOI2t1RYCHrut3vbX4ViiKgXG99oCTw==", null, false, "027bf6ef-b3ea-47b1-841f-1dc63c639e0c", false, "Admin@mail.com" },
                    { 2, 0, "3f7f15a7-d11a-4384-b599-4cb62b7ea22f", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9180), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seller1@mail.com", true, true, false, false, null, null, "SELLER1@MAIL.COM", "AQAAAAIAAYagAAAAECudeR5m/I/Zc3rEYMMrybFxGKOJNY3VTOp5bGPaBPQUJ0qBKONK04sPBv5NutrylA==", null, false, "9aecb35f-5e34-4ec0-a958-8932fa6e67d1", false, "Seller1@mail.com" },
                    { 3, 0, "a6a6c911-2bcd-4379-9d67-75267efe7d6e", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9415), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seller2@mail.com", true, true, false, false, null, null, "SELLER2@MAIL.COM", "AQAAAAIAAYagAAAAEO5Y46uMuJfSW8cD5l61136tWMxQ6MH8NfHqRHTQAoSJFcLGF4gezoITYWXW1wFUAw==", null, false, "4af4988c-0a25-4e5b-8aea-a8d3b33eaf12", false, "Seller2@mail.com" },
                    { 4, 0, "c9f7072f-1bcf-4693-a0ac-13ec0e893c99", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9473), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer1@mail.com", true, true, false, false, null, null, "CUSTOMER1@MAIL.COM", "AQAAAAIAAYagAAAAEH34mVZyzPk0JvgDozAUkkFlX8A8bFY35f3aMjy9+GfDYWVelHy8yYrbGGEON6FCuQ==", null, false, "70fa5e63-07e7-42a3-94ad-727727a64193", false, "customer1@mail.com" },
                    { 5, 0, "4f59503b-85a5-4124-a36f-2f5e19368fc5", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9479), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer2@mail.com", true, true, false, false, null, null, "CUSTOMER2@MAIL.COM", "AQAAAAIAAYagAAAAEEzk1zdb01XqMzOdvDtkw6eUHkTfwvABxZvc/P3pHF5Smyrp/vcCM4Ur7q3tamt30Q==", null, false, "9ac0a6a1-3509-42f9-97b7-060166645d18", false, "customer2@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentId", "PictureId", "Title" },
                values: new object[] { 14, null, null, "لوازم جانبی لپ تاپ" });

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
                    { 1, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9402), null, "102140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 2, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9417), null, "202140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 3, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9419), null, "302140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 4, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9420), null, "402140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 5, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9430), null, "502140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 6, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9432), null, "602140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 7, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9433), null, "702140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 8, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9439), null, "802140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 9, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9448), null, "902140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 10, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9450), null, "102140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 11, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9451), null, "112140ea60e0fd478b09b279976a095c95615b6_1656161174.png", false },
                    { 12, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9452), null, "5522140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 13, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9453), null, "5502140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 14, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9455), null, "5512140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 15, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9456), null, "5532140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 16, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9457), null, "9902140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 17, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9458), null, "9912140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 18, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9460), null, "8802140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 19, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9461), null, "8812140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 20, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9462), null, "8822140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 21, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9464), null, "8832140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 22, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9465), null, "8842140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 23, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9467), null, "8852140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 24, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9468), null, "8862140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 25, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9469), null, "8872140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 26, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9470), null, "8882140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 27, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9472), null, "8892140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false },
                    { 28, new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9473), null, "5532140ea60e0fd478b09b279976a095c95615b6_1656161174.jpg", false }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AppUserId", "Birthdate", "FirstName", "LastName", "ProfilePicId", "ShabaNumber", "Wallet" },
                values: new object[] { 1, 1, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "حسین", "بشارتی", 12, "Ir89752140000007800125", 800000 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 3, 5 }
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
                columns: new[] { "Id", "AddressId", "AppUserId", "Birthdate", "CartOrderId", "FirstName", "LastName", "ProfilePicId", "Sexuality", "Wallet" },
                values: new object[,]
                {
                    { 1, 3, 4, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "جواد  ", "بیات", 15, null, null },
                    { 2, 4, 5, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "محمد", "پارسایی", 28, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "AddressId", "AppUserId", "Birthdate", "BoothId", "FirstName", "LastName", "ProfilePicId", "ShabaNumber" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "حامد", "کریمی", 13, "Ir89752140000007800125" },
                    { 2, 2, 3, new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "میلاد", "بداقی", 14, "Ir89752140000007800125" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentId", "PictureId", "Title" },
                values: new object[,]
                {
                    { 12, 1, null, "موبایل" },
                    { 13, 1, null, "لبتاب" },
                    { 15, 1, null, "کامپیوتر" },
                    { 16, 1, null, "لوازم جانبی گوشی" },
                    { 17, 1, null, "کتابخوان" },
                    { 18, 1, null, "واقعیت مجازی" },
                    { 19, 1, null, "ساعت و مچ بند هوشمند" },
                    { 20, 1, null, "تلوزیون" },
                    { 21, 1, null, "هدفون، هدست، میکروفون" },
                    { 22, 1, null, "اسپیکر بلوتوث و با سیم" },
                    { 23, 1, null, "هارد، فلش و SSD" },
                    { 24, 1, null, "دوربین" },
                    { 25, 1, null, "لوازم جانبی دوربین" },
                    { 26, 1, null, "تبلت" },
                    { 27, 1, null, "کنسول بازی" },
                    { 28, 1, null, "شارژر تبلت و موبایل" },
                    { 29, 1, null, "کیف، کاور، لوازم جانبی تبلت" },
                    { 30, 1, null, "باتری" },
                    { 31, 1, null, "دوربین های تحت شبکه" },
                    { 32, 1, null, "مودم و تجهیزات شبکه" },
                    { 33, 1, null, "ماشین های اداری" },
                    { 34, 2, null, "تلویزیون" },
                    { 35, 2, null, "یخچال و فریزر" },
                    { 36, 2, null, "دکوراتیو" },
                    { 37, 2, null, "فرش ماشینی، دست بافت، تابلو" },
                    { 38, 2, null, "لوازم برقی خانگی" },
                    { 39, 2, null, "حیوانات خانگی، غذا و لوازم" },
                    { 40, 2, null, "سرو و پذیرایی" },
                    { 41, 2, null, "نور و روشنایی" },
                    { 42, 2, null, "آشپزخانه" },
                    { 43, 2, null, "مواد شوینده" },
                    { 44, 2, null, "دستمال کاغذی" },
                    { 45, 2, null, "ملحفه، سرویس، لوازم خواب" },
                    { 46, 2, null, "حوله و وسایل حمام" },
                    { 47, 2, null, "پادری، کمد، لوازم اتاق خواب" },
                    { 48, 2, null, "لوازم دستشویی، روشویی" },
                    { 49, 2, null, "فندک و لوازم جانبی" },
                    { 50, 2, null, "گل، خاک، کود، لوازم باغبانی" },
                    { 51, 2, null, "کولر گازی" },
                    { 52, 2, null, "کولر آبی" },
                    { 53, 3, null, "مردانه" },
                    { 54, 3, null, "لباس مردانه" },
                    { 55, 3, null, "اکسسوری مردانه" },
                    { 56, 3, null, "زنانه" },
                    { 57, 3, null, "لباس زنانه" },
                    { 58, 3, null, "کفش زنانه" },
                    { 59, 3, null, "اکسسوری زنانه" },
                    { 60, 3, null, "طلا" },
                    { 61, 3, null, "زیورآلات زنانه" },
                    { 62, 3, null, "زیورآلات نقره زنانه" },
                    { 63, 3, null, "عینک آفتابی زنانه" },
                    { 64, 3, null, "عینک آفتابی مردانه" },
                    { 65, 3, null, "پوشاک ورزشی مردانه" },
                    { 66, 3, null, "پوشاک ورزشی زنانه" },
                    { 67, 3, null, "کفش ورزشی مردانه" },
                    { 68, 3, null, "کفش ورزشی زنانه" },
                    { 69, 3, null, "پوشاک ورزشی پسرانه" },
                    { 70, 3, null, "پوشاک ورزشی دخترانه" },
                    { 71, 3, null, "کفش ورزشی پسرانه" },
                    { 72, 3, null, "کفش ورزشی دخترانه" },
                    { 73, 3, null, "کوله پشتی مردانه" },
                    { 74, 3, null, "بچگانه" },
                    { 75, 4, null, "کالاهای اساسی و خوار و بار" },
                    { 76, 4, null, "صبحانه " },
                    { 77, 4, null, "مواد پروتئینی" },
                    { 78, 4, null, "لبنیات " },
                    { 79, 4, null, "نوشیدنی ها" },
                    { 80, 4, null, "میوه و سبزی" },
                    { 81, 4, null, "غذای آماده و نودل" },
                    { 82, 4, null, "فرآورده‌های منجمد" },
                    { 83, 4, null, "تنقلات" },
                    { 84, 4, null, "کنسرو و کمپوت" },
                    { 85, 4, null, "خشکبار و شیرینی" },
                    { 86, 5, null, "کتاب و مجله" },
                    { 87, 5, null, "کتاب صوتی" },
                    { 88, 5, null, "محتوای آموزشی" },
                    { 89, 5, null, "نرم افزار" },
                    { 90, 5, null, "بازی کنسول و کامپیوتر" },
                    { 91, 5, null, "فیلم سینمایی، سریال و مستند" },
                    { 92, 5, null, "آلبوم موسیقی" },
                    { 93, 5, null, "لوازم تحریر " },
                    { 94, 5, null, "آلات موسیقی" },
                    { 95, 5, null, "فرش ماشینی، دستبافت، تابلو" },
                    { 96, 4, null, "صنایع دستی" },
                    { 97, 6, null, "بهداشت و حمام کودک و نوزاد" },
                    { 98, 6, null, "پوشاک و کفش کودک و نوزاد " },
                    { 99, 6, null, "تبلت" },
                    { 100, 6, null, "پلی استیشن، ایکس باکس و بازی" },
                    { 101, 6, null, "اسباب بازی" },
                    { 102, 6, null, "بازی و سرگرمی کودک " },
                    { 103, 6, null, "سلامت، ایمنی و مراقبت" },
                    { 104, 6, null, "خواب کودک" },
                    { 105, 6, null, "ملزومات گردش و سفر" },
                    { 106, 6, null, "لوازم شخصی" },
                    { 107, 6, null, "غذا خوری" },
                    { 108, 7, null, "لوازم آرایشی" },
                    { 109, 7, null, "مراقبت پوست" },
                    { 110, 7, null, "مراقبت و زیبایی مو" },
                    { 111, 7, null, "لوازم بهداشتی " },
                    { 112, 7, null, "عطر و ادکلن" },
                    { 113, 7, null, "لوازم شخصی برقی" },
                    { 114, 7, null, "ابزار سلامت" },
                    { 115, 8, null, "پوشاک ورزشی " },
                    { 116, 8, null, "کفش ورزشی " },
                    { 117, 8, null, "تجهیزات سفر" },
                    { 118, 8, null, "دوچرخه" },
                    { 119, 8, null, "کوهنوردی و کمپینگ" },
                    { 120, 8, null, "چتر" },
                    { 121, 8, null, "ساک ورزشی" },
                    { 122, 8, null, "قمقمه و شیکر" },
                    { 123, 8, null, "لوازم ورزشی" },
                    { 124, 8, null, "اسکوتر برقی" },
                    { 125, 8, null, "v" },
                    { 126, 9, null, "ابزار برقی " },
                    { 127, 9, null, "ابزار غیر برقی " },
                    { 128, 9, null, "لوازم الکتریکی و یراق آلات" },
                    { 129, 9, null, "لوازم باغبانی و کشاورزی" },
                    { 130, 9, null, "تجهیزات ایمنی و کار " },
                    { 131, 9, null, "حفاظتی و امنیتی" },
                    { 132, 9, null, "دستگاه های حمل و بالابر صنعتی" },
                    { 133, 10, null, "خودرو" },
                    { 134, 10, null, "موتور سیکلت" },
                    { 135, 10, null, "لوازم مصرفی خودرو " },
                    { 136, 10, null, "لوازم یدکی خودرو" },
                    { 137, 10, null, "لوازم صوتی و تصویری" },
                    { 138, 10, null, "لوازم جانبی خودرو " },
                    { 139, 10, null, "لوازم موتور سیکلت" },
                    { 140, 11, null, "مواد غذایی ارگانیک" },
                    { 141, 11, null, "خواروبار محلی" },
                    { 142, 11, null, "صبحانه محلی" },
                    { 143, 11, null, "کیک و شیرینی خانگی" },
                    { 144, 11, null, "تنقلات خانگی" },
                    { 145, 11, null, "لبنیات سنتی " },
                    { 146, 11, null, "خشکبار و آجیل سنتی" },
                    { 147, 11, null, "غلات و حبوبات ارگانیک" },
                    { 148, 11, null, "ادویه و چاشنی ارگانیک" },
                    { 149, 11, null, "عطاری" },
                    { 150, 11, null, "ترشیجات و شور خانگی" },
                    { 151, 11, null, "دکوراتیو سنتی" },
                    { 152, 11, null, "خانه و کاشانه" },
                    { 153, 11, null, "نوشیدنی‌های ارگانیک" },
                    { 154, 11, null, "نوشیدنی‌های ارگانیک" },
                    { 155, 11, null, "اکسسوری و زیورآلات دست ساز" },
                    { 156, 11, null, "پوشاک بومی و محلی" },
                    { 157, 11, null, "قالی و قالیچه" },
                    { 158, 11, null, "ظروف سنتی" },
                    { 159, 11, null, "لوازم آشپزخانه سنتی" },
                    { 160, 11, null, "رومیزی، رانر و زیربشقابی سنتی" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "PayedAt", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1112), 1, new DateTime(2023, 11, 16, 12, 37, 14, 882, DateTimeKind.Local).AddTicks(1116), true, 100 },
                    { 2, new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1123), 1, null, false, 100 },
                    { 3, new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1125), 2, new DateTime(2023, 11, 16, 12, 52, 14, 882, DateTimeKind.Local).AddTicks(1126), true, 100 },
                    { 4, new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1127), 2, null, false, 100 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BasePrice", "Brand", "CategoryId", "CreatedAt", "CreatedBy", "Description", "Grantee", "IncludedComponents", "InformationDetails", "IsConfirmed", "IsDeleted", "Name" },
                values: new object[] { 9, 32000000, "آیفون", 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "ضد آب", true, false, "گوشی آیفون 12" });

            migrationBuilder.InsertData(
                table: "BoothProducts",
                columns: new[] { "Id", "BoothId", "Count", "CreatedAt", "IsDeleted", "Price", "ProductId", "Status" },
                values: new object[,]
                {
                    { 2, 1, 5, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6145), false, 900000, 9, true },
                    { 8, 2, 5, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6156), false, 10000000, 9, true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BasePrice", "Brand", "CategoryId", "CreatedAt", "CreatedBy", "Description", "Grantee", "IncludedComponents", "InformationDetails", "IsConfirmed", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 100000, "زاگرس پوش", 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "جنس نخ پنبه ای", true, false, "پیراهن سرمه ای نخی" },
                    { 2, 1800000, "ال سی من", 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "سایز ها ایکس و ایکس لارج", true, false, "هودی آبی" },
                    { 3, 100000, "اسکیچر", 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "جنس زیره پی یو", false, false, "کفش پیاده روی" },
                    { 4, 100000, "کرال", 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "نمد ضد آب", true, false, "کلاه نمدی قهوه ای" },
                    { 5, 100000, "تسکو", 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "مخصوص بازی", false, false, "هدفوت بلوتوث " },
                    { 6, 100000, "آیفون", 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "باتری 800 میلی آمپر", true, false, "ساعت هوشمند" },
                    { 7, 100000, "سامسونگ", 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "ضد آب", false, false, "ایر پاد سامسونگ" },
                    { 8, 100000, "سونی", 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", "سنسور 21 مگاپیکسل", true, false, "دوربین کامپکت" },
                    { 10, 28000000, "اچ پی", 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "محصول عالی", "زمانت تعویض هفت روزه", "", " پردازنده نسل 13", true, false, "لبتاب hp" }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BasePrice", "BoothId", "CustomerId", "EndTime", "IsConfirmed", "ProductId", "StartTime", "Status", "WinnerId" },
                values: new object[,]
                {
                    { 1, 22000000, 1, null, new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(224), true, 10, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(213), 1, null },
                    { 2, 350000, 1, null, new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(238), true, 2, new DateTime(2023, 11, 16, 13, 7, 14, 880, DateTimeKind.Local).AddTicks(234), 0, null },
                    { 3, 25000000, 2, null, new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(241), false, 8, new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(240), 0, null }
                });

            migrationBuilder.InsertData(
                table: "BoothProducts",
                columns: new[] { "Id", "BoothId", "Count", "CreatedAt", "IsDeleted", "Price", "ProductId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 10, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6139), false, 800000, 1, true },
                    { 3, 1, 10, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6147), false, 1000000, 8, true },
                    { 4, 1, 5, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6149), false, 2000000, 3, true },
                    { 5, 2, 10, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6150), false, 3000000, 6, true },
                    { 6, 2, 5, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6152), false, 4000000, 2, true },
                    { 7, 2, 10, new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6154), false, 5000000, 4, true }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "BoothProductid", "count", "IsActive", "OrderId" },
                values: new object[,]
                {
                    { 1, 1, 1, true, 1 },
                    { 2, 3, 1, true, 2 },
                    { 3, 4, 1, true, 3 },
                    { 4, 6, 1, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsConfirmed", "IsDeleted", "OrderItemId", "PictureId", "ProductId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 16, 12, 7, 14, 881, DateTimeKind.Local).AddTicks(4612), 1, true, false, 1, null, 1, "محصول فوق العاده ای بود. سپاس1" },
                    { 2, new DateTime(2023, 11, 16, 12, 7, 14, 881, DateTimeKind.Local).AddTicks(4619), 2, false, false, 3, null, 3, "2محصول فوق العاده ای بود. سپاس" }
                });

            migrationBuilder.InsertData(
                table: "Wages",
                columns: new[] { "Id", "FeePercenteage", "OrderitemId", "WageAmount" },
                values: new object[] { 1, 25, 1, 80000 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_AppUserId",
                table: "Admins",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Product",
                table: "Comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AspNetUsers_AppUserId",
                table: "Sellers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Admins_AspNetUsers_AppUserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Product",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AspNetUsers_AppUserId",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Booths",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductId",
                table: "Comments");

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
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 5);

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
                keyValue: 18);

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

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
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

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
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
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
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66);

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

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartOrderId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Sellers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Sellers",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Sellers",
                newName: "AppuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_AppUserId",
                table: "Sellers",
                newName: "IX_Sellers_AppuserId");

            migrationBuilder.RenameColumn(
                name: "IncludedComponents",
                table: "Products",
                newName: "IncludedComponentes");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Describtion");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Products",
                newName: "BasePrise");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Admins",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Admins",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Admins",
                newName: "AppuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                newName: "IX_Admins_AppuserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sellers",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                table: "Auctions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_AppuserId",
                table: "Admins",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AspNetUsers_AppuserId",
                table: "Sellers",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
