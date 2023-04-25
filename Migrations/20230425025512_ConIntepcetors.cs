using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef7_example.Migrations
{
    /// <inheritdoc />
    public partial class ConIntepcetors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Movie",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Movie",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Movie",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Movie",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Actor",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Actor",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Actor",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "CreatedBy", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Actor");
        }
    }
}
