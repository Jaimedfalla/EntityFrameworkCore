using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef7_example.Migrations
{
    /// <inheritdoc />
    public partial class Logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
