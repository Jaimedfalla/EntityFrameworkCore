using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class CinemaDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters");

            migrationBuilder.AddColumn<string>(
                name: "EthicalCode",
                table: "Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "History",
                table: "Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mission",
                table: "Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Principles",
                table: "Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters");

            migrationBuilder.DropColumn(
                name: "EthicalCode",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "Mission",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "Principles",
                table: "Cinema");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
