using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations
{
    /// <inheritdoc />
    public partial class ConInterceptor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
