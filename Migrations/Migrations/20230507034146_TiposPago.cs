using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class TiposPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Address_Location",
                table: "Actor");

            migrationBuilder.RenameColumn(
                name: "Address_Location",
                table: "Cinema",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Cinema",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Cinema",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Home_Location",
                table: "Actor",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Home_Country",
                table: "Actor",
                newName: "HomeCountry");

            migrationBuilder.RenameColumn(
                name: "Home_City",
                table: "Actor",
                newName: "HomeCity");

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ammont = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    PayType = table.Column<int>(type: "int", nullable: false),
                    LastFourDigits = table.Column<string>(type: "CHAR(4)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Ammont", "LastFourDigits", "PayType", "TransactionDate" },
                values: new object[,]
                {
                    { 1, 5000000m, "9897", 2, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2000000m, "3258", 2, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Pays",
                columns: new[] { "Id", "Ammont", "Email", "PayType", "TransactionDate" },
                values: new object[,]
                {
                    { 3, 157m, "pomek40395@saeoil.com", 1, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2000000m, "devilinme@bukanimers.com", 1, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pays");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Cinema",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Cinema",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Cinema",
                newName: "Address_Location");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Actor",
                newName: "Home_Location");

            migrationBuilder.RenameColumn(
                name: "HomeCountry",
                table: "Actor",
                newName: "Home_Country");

            migrationBuilder.RenameColumn(
                name: "HomeCity",
                table: "Actor",
                newName: "Home_City");

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
        }
    }
}
