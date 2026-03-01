using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class creating_comments_controller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment_date",
                table: "comment");

            migrationBuilder.AddColumn<int>(
                name: "event_id",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comment_event_id",
                table: "comment",
                column: "event_id");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_events_event_id",
                table: "comment",
                column: "event_id",
                principalTable: "events",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_events_event_id",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_comment_event_id",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "event_id",
                table: "comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "comment_date",
                table: "comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
