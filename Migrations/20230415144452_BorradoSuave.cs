﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef7_example.Migrations
{
    /// <inheritdoc />
    public partial class BorradoSuave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Gender",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Gender");
        }
    }
}
