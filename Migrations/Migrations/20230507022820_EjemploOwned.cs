using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class EjemploOwned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Location",
                table: "Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Location",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_City",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_Country",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Billing_Location",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Home_City",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Home_Country",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Home_Location",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "Address_Location",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Address_Location",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Billing_City",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Billing_Country",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Billing_Location",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Home_City",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Home_Country",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Home_Location",
                table: "Actor");

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
