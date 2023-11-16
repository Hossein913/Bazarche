using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Data.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class DebugBidEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51bcef4c-5693-49da-b69a-87f4eedaa83c", new DateTime(2023, 11, 16, 15, 58, 43, 957, DateTimeKind.Local).AddTicks(9711), "AQAAAAIAAYagAAAAEGog98brlc/4BdjFPpuD3nC1vhrIt38MPbB2AOlVqrC6MFb0SSb18U1daO1VLm2KHQ==", "41f60252-d4a0-4cc9-be93-196496ca36f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f9691e6-bc67-4336-8a68-d724bcb5a468", new DateTime(2023, 11, 16, 15, 58, 43, 957, DateTimeKind.Local).AddTicks(9726), "AQAAAAIAAYagAAAAEOLARIQuz49KMaLAwHGOOsDr9odP25GgDLVmXsJ4RP5fMPIOHYlSeovdtGgQqfsguQ==", "4b044072-4ba5-482b-8a0d-e26b81e6cdff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f997373-d5ed-4f63-a1df-9f9551f6fbec", new DateTime(2023, 11, 16, 15, 58, 43, 957, DateTimeKind.Local).AddTicks(9742), "AQAAAAIAAYagAAAAEEmPiJpjdN9VotduUD8mNeWKZbTmKW6WzcLpVWaCRjJ8bufIWpXV70gDlP5Ep7HFIw==", "c1b33b16-cfa1-4ae4-a4d8-70b8c5278569" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "204a6109-d7e7-4879-b484-542136c32e80", new DateTime(2023, 11, 16, 15, 58, 43, 957, DateTimeKind.Local).AddTicks(9756), "AQAAAAIAAYagAAAAEGcWLBu/92KS7vpY8zBBsLTlPJXwdWCKHOQRhCd6jFzse82lZoEc+steH9uhKrhh5A==", "b0ac1ada-6de1-467b-9a0f-d1482b5078b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "779f7c59-6139-41c1-a59a-b1755fca562c", new DateTime(2023, 11, 16, 15, 58, 43, 957, DateTimeKind.Local).AddTicks(9762), "AQAAAAIAAYagAAAAEOjWkmPSmBjNrYoa/5GePlgGJ/0Dc9lXMMlO95dIdCxAL6szDw4dn3GuCn5vxweI8w==", "57fb0d05-f72f-4ada-9545-8555076a2236" });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 17, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(4302), new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 17, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(4315), new DateTime(2023, 11, 16, 16, 58, 44, 430, DateTimeKind.Local).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 17, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(4318), new DateTime(2023, 11, 17, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9872));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 430, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 431, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 431, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 16, 15, 58, 44, 432, DateTimeKind.Local).AddTicks(5448), new DateTime(2023, 11, 16, 16, 28, 44, 432, DateTimeKind.Local).AddTicks(5452) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 432, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 16, 15, 58, 44, 432, DateTimeKind.Local).AddTicks(5461), new DateTime(2023, 11, 16, 16, 43, 44, 432, DateTimeKind.Local).AddTicks(5461) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 44, 432, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 15, 58, 43, 956, DateTimeKind.Local).AddTicks(5916));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bids");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74bef2d9-ad09-4594-9198-13b1a537c731", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9167), "AQAAAAIAAYagAAAAEHRsddfTauO+aEDqZu/PagJvSti01YFvu39jOI2t1RYCHrut3vbX4ViiKgXG99oCTw==", "027bf6ef-b3ea-47b1-841f-1dc63c639e0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f7f15a7-d11a-4384-b599-4cb62b7ea22f", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9180), "AQAAAAIAAYagAAAAECudeR5m/I/Zc3rEYMMrybFxGKOJNY3VTOp5bGPaBPQUJ0qBKONK04sPBv5NutrylA==", "9aecb35f-5e34-4ec0-a958-8932fa6e67d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6a6c911-2bcd-4379-9d67-75267efe7d6e", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9415), "AQAAAAIAAYagAAAAEO5Y46uMuJfSW8cD5l61136tWMxQ6MH8NfHqRHTQAoSJFcLGF4gezoITYWXW1wFUAw==", "4af4988c-0a25-4e5b-8aea-a8d3b33eaf12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9f7072f-1bcf-4693-a0ac-13ec0e893c99", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9473), "AQAAAAIAAYagAAAAEH34mVZyzPk0JvgDozAUkkFlX8A8bFY35f3aMjy9+GfDYWVelHy8yYrbGGEON6FCuQ==", "70fa5e63-07e7-42a3-94ad-727727a64193" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f59503b-85a5-4124-a36f-2f5e19368fc5", new DateTime(2023, 11, 16, 12, 7, 14, 446, DateTimeKind.Local).AddTicks(9479), "AQAAAAIAAYagAAAAEEzk1zdb01XqMzOdvDtkw6eUHkTfwvABxZvc/P3pHF5Smyrp/vcCM4Ur7q3tamt30Q==", "9ac0a6a1-3509-42f9-97b7-060166645d18" });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(224), new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(213) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(238), new DateTime(2023, 11, 16, 13, 7, 14, 880, DateTimeKind.Local).AddTicks(234) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(241), new DateTime(2023, 11, 17, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 880, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 881, DateTimeKind.Local).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 881, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1112), new DateTime(2023, 11, 16, 12, 37, 14, 882, DateTimeKind.Local).AddTicks(1116) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1125), new DateTime(2023, 11, 16, 12, 52, 14, 882, DateTimeKind.Local).AddTicks(1126) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 882, DateTimeKind.Local).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 12, 7, 14, 445, DateTimeKind.Local).AddTicks(9473));
        }
    }
}
