using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class HerenciaTablaPorTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchandising",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EnableInInventory = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    IsClothe = table.Column<bool>(type: "bit", nullable: false),
                    IsCollectible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandising", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchandising_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieForRent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieForRent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieForRent_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinemaOffer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "InitialDate" },
                values: new object[] { new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "T-Shirt One Piece", 11m },
                    { 2, "Spider-Man", 5.99m }
                });

            migrationBuilder.InsertData(
                table: "Merchandising",
                columns: new[] { "Id", "EnableInInventory", "IsClothe", "IsCollectible", "Volume", "Weight" },
                values: new object[] { 1, true, true, false, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "MovieForRent",
                columns: new[] { "Id", "MovieId" },
                values: new object[] { 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchandising");

            migrationBuilder.DropTable(
                name: "MovieForRent");

            migrationBuilder.DropTable(
                name: "Products");

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
    }
}
