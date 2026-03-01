using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class changing_comment_factory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "comment_date",
                table: "comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment_date",
                table: "comment");
        }
    }
}
