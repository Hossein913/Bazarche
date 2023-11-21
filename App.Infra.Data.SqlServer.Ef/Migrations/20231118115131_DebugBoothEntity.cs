using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Data.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class DebugBoothEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalSell",
                table: "Booths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fdda84f-918b-446f-a85e-678675236be4", new DateTime(2023, 11, 18, 15, 21, 30, 485, DateTimeKind.Local).AddTicks(3053), "AQAAAAIAAYagAAAAEB2/z4zTYUkCloIFcz0RygqosLSngH0DVYY9aeg3WK4DofXF6cY2fEM+gzUAt/qb9A==", "21430390-990a-453a-bdad-124f794c0dae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfc86c22-8c68-4116-80d1-8bc966811a18", new DateTime(2023, 11, 18, 15, 21, 30, 485, DateTimeKind.Local).AddTicks(3095), "AQAAAAIAAYagAAAAEADNRLXP0yUea/HPHMhdYIfZ7OqNTKNsIvXDJvYsGcFrKxOrgff16JcL/mBeGZv3vg==", "5cea09dc-b085-43dd-862f-30ccdc8d8e60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2aa21e6-b28e-4994-adba-af21148b5209", new DateTime(2023, 11, 18, 15, 21, 30, 485, DateTimeKind.Local).AddTicks(3114), "AQAAAAIAAYagAAAAENYvxvEDOe/20TIoB9FMMl1yYTLgyIg0OrjOSpArBMe+4hIiCx+OCnfZiWgMr6h21w==", "093d190e-34af-4917-ae50-0a31e8e0a3dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46c8ba00-8931-4a72-ba36-c9a9e3c001c4", new DateTime(2023, 11, 18, 15, 21, 30, 485, DateTimeKind.Local).AddTicks(3125), "AQAAAAIAAYagAAAAEPVPT8HnLFD2ZuLlC3tNIpEaJKDLCPDlrXAWOhzNklonYrrXJ/hQDT3qOtfkZy6FoA==", "27c58977-498a-4636-b68c-eef869446b0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4044c168-5dd9-48f5-97fa-014acb2233b2", new DateTime(2023, 11, 18, 15, 21, 30, 485, DateTimeKind.Local).AddTicks(3136), "AQAAAAIAAYagAAAAENmyAdcWpCDubGIHqGdU1uBrF/46UpYE1ImcDP9FIVBXSeCXnl4FfUdqh2UK78DlAg==", "c590fb1e-6e8c-415a-a218-9ea901d429e8" });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 19, 15, 21, 31, 29, DateTimeKind.Local).AddTicks(7189), new DateTime(2023, 11, 18, 15, 21, 31, 29, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 19, 15, 21, 31, 29, DateTimeKind.Local).AddTicks(7200), new DateTime(2023, 11, 18, 16, 21, 31, 29, DateTimeKind.Local).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 19, 15, 21, 31, 29, DateTimeKind.Local).AddTicks(7202), new DateTime(2023, 11, 19, 15, 21, 31, 29, DateTimeKind.Local).AddTicks(7202) });

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "BoothProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalSell",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Booths",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalSell",
                value: 2300000);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "ParentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 30, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 18, 15, 21, 31, 31, DateTimeKind.Local).AddTicks(6055), new DateTime(2023, 11, 18, 15, 51, 31, 31, DateTimeKind.Local).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 31, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PayedAt" },
                values: new object[] { new DateTime(2023, 11, 18, 15, 21, 31, 31, DateTimeKind.Local).AddTicks(6068), new DateTime(2023, 11, 18, 16, 6, 31, 31, DateTimeKind.Local).AddTicks(6069) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 31, 31, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(875));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 18, 15, 21, 30, 484, DateTimeKind.Local).AddTicks(900));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSell",
                table: "Booths");

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "ParentId",
                value: null);

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
    }
}
