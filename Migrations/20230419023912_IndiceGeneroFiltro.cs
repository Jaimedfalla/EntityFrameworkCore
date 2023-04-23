using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef7_example.Migrations
{
    /// <inheritdoc />
    public partial class IndiceGeneroFiltro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gender_Name",
                table: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Name",
                table: "Gender",
                column: "Name",
                unique: true,
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gender_Name",
                table: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Name",
                table: "Gender",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
