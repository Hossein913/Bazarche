using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Data.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class DebugEntitiesPropertyName : Migration
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
                newName: "BasePrice");

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

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9aaf9b38-bc75-42e6-a7a0-99d8fa6cedac", new DateTime(2023, 11, 13, 23, 42, 57, 798, DateTimeKind.Local).AddTicks(5856), "AQAAAAIAAYagAAAAEML5rKoe8phbf0amXf6AaLoD+BAkHke0pTumN5anT/wZI8b6CyCtl5cyNB2ZYQD0Yw==", "f078bd8a-ae9e-4584-acc9-dda37aef1748" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a2b5827-7023-4400-be7f-bfabbb909546", new DateTime(2023, 11, 13, 23, 42, 57, 798, DateTimeKind.Local).AddTicks(5876), "AQAAAAIAAYagAAAAEHCccn1Ctw3EFLsVSnX723Oz9fa11N/anz4QNeEVfL9OvFRKU5+WVcQOETKV9cr1BQ==", "f67ba206-e6d2-417d-a03d-e073d29876e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76fce0f4-eb0c-4d4d-b944-45ecf88e1943", new DateTime(2023, 11, 13, 23, 42, 57, 798, DateTimeKind.Local).AddTicks(5899), "AQAAAAIAAYagAAAAEO/9seDMwS2I30sXckQMbHmm/6bEi1rOLH1TGXjKBOBKRFu+FtmeYWa1xJduHAVlUA==", "fd7c85ab-c20d-4da7-b1c8-57a2d1ee48fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32bd3c5c-b678-41e5-89ec-84af57168e31", new DateTime(2023, 11, 13, 23, 42, 57, 798, DateTimeKind.Local).AddTicks(5907), "AQAAAAIAAYagAAAAELAndEELzk+/OI2rzQtuoZcDU1KjpJxaSSn8NwxsLiMi8YYXuxzSv+ZRCHNLCpYTWA==", "94831f92-066b-4f65-ade8-da6e0d6e0fd9" });

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 154, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 1, "لبتاب" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { null, "لوازم جانبی لپ تاپ" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "کامپیوتر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "Title",
                value: "لوازم جانبی گوشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "Title",
                value: "کتابخوان");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "Title",
                value: "واقعیت مجازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "Title",
                value: "ساعت و مچ بند هوشمند");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "Title",
                value: "تلوزیون");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "Title",
                value: "هدفون، هدست، میکروفون");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "Title",
                value: "اسپیکر بلوتوث و با سیم");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "Title",
                value: "هارد، فلش و SSD");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "Title",
                value: "دوربین");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "Title",
                value: "لوازم جانبی دوربین");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "Title",
                value: "تبلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "Title",
                value: "کنسول بازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "Title",
                value: "شارژر تبلت و موبایل");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "Title",
                value: "کیف، کاور، لوازم جانبی تبلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "Title",
                value: "باتری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31,
                column: "Title",
                value: "دوربین های تحت شبکه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32,
                column: "Title",
                value: "مودم و تجهیزات شبکه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 1, "ماشین های اداری" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34,
                column: "Title",
                value: "تلویزیون");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35,
                column: "Title",
                value: "یخچال و فریزر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36,
                column: "Title",
                value: "دکوراتیو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37,
                column: "Title",
                value: "فرش ماشینی، دست بافت، تابلو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38,
                column: "Title",
                value: "لوازم برقی خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39,
                column: "Title",
                value: "حیوانات خانگی، غذا و لوازم");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40,
                column: "Title",
                value: "سرو و پذیرایی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41,
                column: "Title",
                value: "نور و روشنایی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42,
                column: "Title",
                value: "آشپزخانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43,
                column: "Title",
                value: "مواد شوینده");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44,
                column: "Title",
                value: "دستمال کاغذی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45,
                column: "Title",
                value: "ملحفه، سرویس، لوازم خواب");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46,
                column: "Title",
                value: "حوله و وسایل حمام");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47,
                column: "Title",
                value: "پادری، کمد، لوازم اتاق خواب");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48,
                column: "Title",
                value: "لوازم دستشویی، روشویی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49,
                column: "Title",
                value: "فندک و لوازم جانبی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50,
                column: "Title",
                value: "گل، خاک، کود، لوازم باغبانی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51,
                column: "Title",
                value: "کولر گازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 2, "کولر آبی" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53,
                column: "Title",
                value: "مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54,
                column: "Title",
                value: "لباس مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55,
                column: "Title",
                value: "اکسسوری مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56,
                column: "Title",
                value: "زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57,
                column: "Title",
                value: "لباس زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58,
                column: "Title",
                value: "کفش زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59,
                column: "Title",
                value: "اکسسوری زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60,
                column: "Title",
                value: "طلا");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61,
                column: "Title",
                value: "زیورآلات زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62,
                column: "Title",
                value: "زیورآلات نقره زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63,
                column: "Title",
                value: "عینک آفتابی زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64,
                column: "Title",
                value: "عینک آفتابی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65,
                column: "Title",
                value: "پوشاک ورزشی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66,
                column: "Title",
                value: "پوشاک ورزشی زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67,
                column: "Title",
                value: "کفش ورزشی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 68,
                column: "Title",
                value: "کفش ورزشی زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 69,
                column: "Title",
                value: "پوشاک ورزشی پسرانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70,
                column: "Title",
                value: "پوشاک ورزشی دخترانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 71,
                column: "Title",
                value: "کفش ورزشی پسرانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 72,
                column: "Title",
                value: "کفش ورزشی دخترانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 73,
                column: "Title",
                value: "کوله پشتی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 3, "بچگانه" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 75,
                column: "Title",
                value: "کالاهای اساسی و خوار و بار");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76,
                column: "Title",
                value: "صبحانه ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77,
                column: "Title",
                value: "مواد پروتئینی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78,
                column: "Title",
                value: "لبنیات ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 79,
                column: "Title",
                value: "نوشیدنی ها");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 80,
                column: "Title",
                value: "میوه و سبزی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 81,
                column: "Title",
                value: "غذای آماده و نودل");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 82,
                column: "Title",
                value: "فرآورده‌های منجمد");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 83,
                column: "Title",
                value: "تنقلات");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 84,
                column: "Title",
                value: "کنسرو و کمپوت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 4, "خشکبار و شیرینی" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 86,
                column: "Title",
                value: "کتاب و مجله");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 87,
                column: "Title",
                value: "کتاب صوتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 88,
                column: "Title",
                value: "محتوای آموزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 89,
                column: "Title",
                value: "نرم افزار");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 90,
                column: "Title",
                value: "بازی کنسول و کامپیوتر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 91,
                column: "Title",
                value: "فیلم سینمایی، سریال و مستند");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 92,
                column: "Title",
                value: "آلبوم موسیقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 93,
                column: "Title",
                value: "لوازم تحریر ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 94,
                column: "Title",
                value: "آلات موسیقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 5, "فرش ماشینی، دستبافت، تابلو" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 4, "صنایع دستی" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 97,
                column: "Title",
                value: "بهداشت و حمام کودک و نوزاد");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 98,
                column: "Title",
                value: "پوشاک و کفش کودک و نوزاد ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 99,
                column: "Title",
                value: "تبلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100,
                column: "Title",
                value: "پلی استیشن، ایکس باکس و بازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 101,
                column: "Title",
                value: "اسباب بازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 102,
                column: "Title",
                value: "بازی و سرگرمی کودک ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 103,
                column: "Title",
                value: "سلامت، ایمنی و مراقبت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 104,
                column: "Title",
                value: "خواب کودک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 105,
                column: "Title",
                value: "ملزومات گردش و سفر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 106,
                column: "Title",
                value: "لوازم شخصی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 6, "غذا خوری" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 108,
                column: "Title",
                value: "لوازم آرایشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 109,
                column: "Title",
                value: "مراقبت پوست");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 110,
                column: "Title",
                value: "مراقبت و زیبایی مو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 111,
                column: "Title",
                value: "لوازم بهداشتی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 112,
                column: "Title",
                value: "عطر و ادکلن");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 113,
                column: "Title",
                value: "لوازم شخصی برقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 7, "ابزار سلامت" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 115,
                column: "Title",
                value: "پوشاک ورزشی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 116,
                column: "Title",
                value: "کفش ورزشی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 117,
                column: "Title",
                value: "تجهیزات سفر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 118,
                column: "Title",
                value: "دوچرخه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 119,
                column: "Title",
                value: "کوهنوردی و کمپینگ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 120,
                column: "Title",
                value: "چتر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 121,
                column: "Title",
                value: "ساک ورزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 122,
                column: "Title",
                value: "قمقمه و شیکر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 123,
                column: "Title",
                value: "لوازم ورزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 124,
                column: "Title",
                value: "اسکوتر برقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 8, "v" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 126,
                column: "Title",
                value: "ابزار برقی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 127,
                column: "Title",
                value: "ابزار غیر برقی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 128,
                column: "Title",
                value: "لوازم الکتریکی و یراق آلات");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 129,
                column: "Title",
                value: "لوازم باغبانی و کشاورزی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 130,
                column: "Title",
                value: "تجهیزات ایمنی و کار ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 131,
                column: "Title",
                value: "حفاظتی و امنیتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 9, "دستگاه های حمل و بالابر صنعتی" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 133,
                column: "Title",
                value: "خودرو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 134,
                column: "Title",
                value: "موتور سیکلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 135,
                column: "Title",
                value: "لوازم مصرفی خودرو ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 136,
                column: "Title",
                value: "لوازم یدکی خودرو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 137,
                column: "Title",
                value: "لوازم صوتی و تصویری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 138,
                column: "Title",
                value: "لوازم جانبی خودرو ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 10, "لوازم موتور سیکلت" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 140,
                column: "Title",
                value: "مواد غذایی ارگانیک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 141,
                column: "Title",
                value: "خواروبار محلی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 142,
                column: "Title",
                value: "صبحانه محلی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 143,
                column: "Title",
                value: "کیک و شیرینی خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 144,
                column: "Title",
                value: "تنقلات خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 145,
                column: "Title",
                value: "لبنیات سنتی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 146,
                column: "Title",
                value: "خشکبار و آجیل سنتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 147,
                column: "Title",
                value: "غلات و حبوبات ارگانیک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 148,
                column: "Title",
                value: "ادویه و چاشنی ارگانیک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 149,
                column: "Title",
                value: "عطاری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 150,
                column: "Title",
                value: "ترشیجات و شور خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 151,
                column: "Title",
                value: "دکوراتیو سنتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 152,
                column: "Title",
                value: "خانه و کاشانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 154,
                column: "Title",
                value: "نوشیدنی‌های ارگانیک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 155,
                column: "Title",
                value: "اکسسوری و زیورآلات دست ساز");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 156,
                column: "Title",
                value: "پوشاک بومی و محلی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 157,
                column: "Title",
                value: "قالی و قالیچه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 158,
                column: "Title",
                value: "ظروف سنتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 159,
                column: "Title",
                value: "لوازم آشپزخانه سنتی");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentId", "PictureId", "Title" },
                values: new object[] { 160, 11, null, "رومیزی، رانر و زیربشقابی سنتی" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 58, 155, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 13, 23, 42, 58, 156, DateTimeKind.Local).AddTicks(1122), new DateTime(2023, 11, 13, 23, 42, 58, 156, DateTimeKind.Local).AddTicks(1127) });

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 13, 23, 42, 57, 797, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 67);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoryId",
                value: 13);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_AppUserId",
                table: "Admins",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_AppUserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AspNetUsers_AppUserId",
                table: "Sellers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 160);

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
                name: "BasePrice",
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

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3ff5bed-a006-448e-8f4d-37ec7d737a3f", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(323), "AQAAAAIAAYagAAAAEGz0GYwWHVTcS6WDst21j4iWOpf5dcXtW5alWd308pwpya/ZgQjxtzzGY9o4C7PYig==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d88601a4-f509-4a29-886f-f94832158d21", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(335), "AQAAAAIAAYagAAAAELOkDVqw5VM9gJkZdbDBUDoDV8G40Ul335omeJREctLlIyYM1I6XjnBJvv3+3bcWjQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f2efd0f-4ea1-4457-899f-ba39c6453141", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(340), "AQAAAAIAAYagAAAAEE+K6MnprVXAWp5zI9V5q0KqPaAeuaUxP7boxQsUuaj+oSFbXSx32iXrtT/cZS9H9Q==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c3bae04-1a16-475f-8361-3b6922eba736", new DateTime(2023, 11, 6, 21, 49, 20, 810, DateTimeKind.Local).AddTicks(352), "AQAAAAIAAYagAAAAEBMWN/AKojskUngHVkSwMaS3NJXaNzlrsrbmked8HGKIGtDVBJ5Koso+gO/bGUKDYQ==", null });

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 190, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "PictureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { null, "لوازم جانبی لپ تاپ" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 1, "کامپیوتر" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Title",
                value: "لوازم جانبی گوشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "Title",
                value: "کتابخوان");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "Title",
                value: "واقعیت مجازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "Title",
                value: "ساعت و مچ بند هوشمند");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "Title",
                value: "تلوزیون");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "Title",
                value: "هدفون، هدست، میکروفون");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "Title",
                value: "اسپیکر بلوتوث و با سیم");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "Title",
                value: "هارد، فلش و SSD");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "Title",
                value: "دوربین");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "Title",
                value: "لوازم جانبی دوربین");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "Title",
                value: "تبلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "Title",
                value: "کنسول بازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "Title",
                value: "شارژر تبلت و موبایل");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "Title",
                value: "کیف، کاور، لوازم جانبی تبلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "Title",
                value: "باتری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "Title",
                value: "دوربین های تحت شبکه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31,
                column: "Title",
                value: "مودم و تجهیزات شبکه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32,
                column: "Title",
                value: "ماشین های اداری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 2, "تلویزیون" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34,
                column: "Title",
                value: "یخچال و فریزر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35,
                column: "Title",
                value: "دکوراتیو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36,
                column: "Title",
                value: "فرش ماشینی، دست بافت، تابلو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37,
                column: "Title",
                value: "لوازم برقی خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38,
                column: "Title",
                value: "حیوانات خانگی، غذا و لوازم");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39,
                column: "Title",
                value: "سرو و پذیرایی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40,
                column: "Title",
                value: "نور و روشنایی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41,
                column: "Title",
                value: "آشپزخانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42,
                column: "Title",
                value: "مواد شوینده");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43,
                column: "Title",
                value: "دستمال کاغذی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44,
                column: "Title",
                value: "ملحفه، سرویس، لوازم خواب");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45,
                column: "Title",
                value: "حوله و وسایل حمام");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46,
                column: "Title",
                value: "پادری، کمد، لوازم اتاق خواب");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47,
                column: "Title",
                value: "لوازم دستشویی، روشویی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48,
                column: "Title",
                value: "فندک و لوازم جانبی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49,
                column: "Title",
                value: "گل، خاک، کود، لوازم باغبانی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50,
                column: "Title",
                value: "کولر گازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51,
                column: "Title",
                value: "کولر آبی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 3, "مردانه" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53,
                column: "Title",
                value: "لباس مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54,
                column: "Title",
                value: "اکسسوری مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55,
                column: "Title",
                value: "زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56,
                column: "Title",
                value: "لباس زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57,
                column: "Title",
                value: "کفش زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58,
                column: "Title",
                value: "اکسسوری زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59,
                column: "Title",
                value: "طلا");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60,
                column: "Title",
                value: "زیورآلات زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61,
                column: "Title",
                value: "زیورآلات نقره زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62,
                column: "Title",
                value: "عینک آفتابی زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63,
                column: "Title",
                value: "عینک آفتابی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64,
                column: "Title",
                value: "پوشاک ورزشی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65,
                column: "Title",
                value: "پوشاک ورزشی زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66,
                column: "Title",
                value: "کفش ورزشی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67,
                column: "Title",
                value: "کفش ورزشی زنانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 68,
                column: "Title",
                value: "پوشاک ورزشی پسرانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 69,
                column: "Title",
                value: "پوشاک ورزشی دخترانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70,
                column: "Title",
                value: "کفش ورزشی پسرانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 71,
                column: "Title",
                value: "کفش ورزشی دخترانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 72,
                column: "Title",
                value: "کوله پشتی مردانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 73,
                column: "Title",
                value: "بچگانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 4, "کالاهای اساسی و خوار و بار" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 75,
                column: "Title",
                value: "صبحانه ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76,
                column: "Title",
                value: "مواد پروتئینی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77,
                column: "Title",
                value: "لبنیات ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78,
                column: "Title",
                value: "نوشیدنی ها");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 79,
                column: "Title",
                value: "میوه و سبزی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 80,
                column: "Title",
                value: "غذای آماده و نودل");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 81,
                column: "Title",
                value: "فرآورده‌های منجمد");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 82,
                column: "Title",
                value: "تنقلات");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 83,
                column: "Title",
                value: "کنسرو و کمپوت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 84,
                column: "Title",
                value: "خشکبار و شیرینی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 5, "کتاب و مجله" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 86,
                column: "Title",
                value: "کتاب صوتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 87,
                column: "Title",
                value: "محتوای آموزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 88,
                column: "Title",
                value: "نرم افزار");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 89,
                column: "Title",
                value: "بازی کنسول و کامپیوتر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 90,
                column: "Title",
                value: "فیلم سینمایی، سریال و مستند");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 91,
                column: "Title",
                value: "آلبوم موسیقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 92,
                column: "Title",
                value: "لوازم تحریر ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 93,
                column: "Title",
                value: "آلات موسیقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 94,
                column: "Title",
                value: "فرش ماشینی، دستبافت، تابلو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 4, "صنایع دستی" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 6, "بهداشت و حمام کودک و نوزاد" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 97,
                column: "Title",
                value: "پوشاک و کفش کودک و نوزاد ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 98,
                column: "Title",
                value: "تبلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 99,
                column: "Title",
                value: "پلی استیشن، ایکس باکس و بازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100,
                column: "Title",
                value: "اسباب بازی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 101,
                column: "Title",
                value: "بازی و سرگرمی کودک ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 102,
                column: "Title",
                value: "سلامت، ایمنی و مراقبت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 103,
                column: "Title",
                value: "خواب کودک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 104,
                column: "Title",
                value: "ملزومات گردش و سفر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 105,
                column: "Title",
                value: "لوازم شخصی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 106,
                column: "Title",
                value: "غذا خوری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 7, "لوازم آرایشی" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 108,
                column: "Title",
                value: "مراقبت پوست");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 109,
                column: "Title",
                value: "مراقبت و زیبایی مو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 110,
                column: "Title",
                value: "لوازم بهداشتی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 111,
                column: "Title",
                value: "عطر و ادکلن");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 112,
                column: "Title",
                value: "لوازم شخصی برقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 113,
                column: "Title",
                value: "ابزار سلامت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 8, "پوشاک ورزشی " });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 115,
                column: "Title",
                value: "کفش ورزشی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 116,
                column: "Title",
                value: "تجهیزات سفر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 117,
                column: "Title",
                value: "دوچرخه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 118,
                column: "Title",
                value: "کوهنوردی و کمپینگ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 119,
                column: "Title",
                value: "چتر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 120,
                column: "Title",
                value: "ساک ورزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 121,
                column: "Title",
                value: "قمقمه و شیکر");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 122,
                column: "Title",
                value: "لوازم ورزشی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 123,
                column: "Title",
                value: "اسکوتر برقی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 124,
                column: "Title",
                value: "v");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 9, "ابزار برقی " });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 126,
                column: "Title",
                value: "ابزار غیر برقی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 127,
                column: "Title",
                value: "لوازم الکتریکی و یراق آلات");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 128,
                column: "Title",
                value: "لوازم باغبانی و کشاورزی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 129,
                column: "Title",
                value: "تجهیزات ایمنی و کار ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 130,
                column: "Title",
                value: "حفاظتی و امنیتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 131,
                column: "Title",
                value: "دستگاه های حمل و بالابر صنعتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 10, "خودرو" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 133,
                column: "Title",
                value: "موتور سیکلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 134,
                column: "Title",
                value: "لوازم مصرفی خودرو ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 135,
                column: "Title",
                value: "لوازم یدکی خودرو");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 136,
                column: "Title",
                value: "لوازم صوتی و تصویری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 137,
                column: "Title",
                value: "لوازم جانبی خودرو ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 138,
                column: "Title",
                value: "لوازم موتور سیکلت");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 11, "مواد غذایی ارگانیک" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 140,
                column: "Title",
                value: "خواروبار محلی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 141,
                column: "Title",
                value: "صبحانه محلی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 142,
                column: "Title",
                value: "کیک و شیرینی خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 143,
                column: "Title",
                value: "تنقلات خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 144,
                column: "Title",
                value: "لبنیات سنتی ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 145,
                column: "Title",
                value: "خشکبار و آجیل سنتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 146,
                column: "Title",
                value: "غلات و حبوبات ارگانیک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 147,
                column: "Title",
                value: "ادویه و چاشنی ارگانیک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 148,
                column: "Title",
                value: "عطاری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 149,
                column: "Title",
                value: "ترشیجات و شور خانگی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 150,
                column: "Title",
                value: "دکوراتیو سنتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 151,
                column: "Title",
                value: "خانه و کاشانه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 152,
                column: "Title",
                value: "نوشیدنی‌های ارگانیک");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 154,
                column: "Title",
                value: "اکسسوری و زیورآلات دست ساز");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 155,
                column: "Title",
                value: "پوشاک بومی و محلی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 156,
                column: "Title",
                value: "قالی و قالیچه");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 157,
                column: "Title",
                value: "ظروف سنتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 158,
                column: "Title",
                value: "لوازم آشپزخانه سنتی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 159,
                column: "Title",
                value: "رومیزی، رانر و زیربشقابی سنتی");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 21, 191, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 6, 21, 49, 21, 192, DateTimeKind.Local).AddTicks(2020), new DateTime(2023, 11, 6, 21, 49, 21, 192, DateTimeKind.Local).AddTicks(2024) });

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 6, 21, 49, 20, 808, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoryId",
                value: null);

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
        }
    }
}
