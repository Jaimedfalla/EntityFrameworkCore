using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class EjemploPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EmittingId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_People_EmittingId",
                        column: x => x.EmittingId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_People_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Felipe" },
                    { 2, "Claudia" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "EmittingId", "RecipientId" },
                values: new object[,]
                {
                    { 1, "Hola Claudia", 1, 2 },
                    { 2, "Hola Felipe, ¿Como te va?", 2, 1 },
                    { 3, "Todo bien, ¿Y tu?", 1, 2 },
                    { 4, "Muy bien :)", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EmittingId",
                table: "Messages",
                column: "EmittingId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "People");

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
    }
}
