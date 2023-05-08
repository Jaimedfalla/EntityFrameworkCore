using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DeleteMovieError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Cinema_CinemaId",
                table: "MovieTheaters",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
