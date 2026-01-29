using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class membermigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_members_boards_board_id",
                table: "members");

            migrationBuilder.DropTable(
                name: "boards");

            migrationBuilder.DropIndex(
                name: "IX_members_board_id",
                table: "members");

            migrationBuilder.DropColumn(
                name: "birth_date",
                table: "members");

            migrationBuilder.DropColumn(
                name: "board_id",
                table: "members");

            migrationBuilder.DropColumn(
                name: "city",
                table: "members");

            migrationBuilder.DropColumn(
                name: "entry_date",
                table: "members");

            migrationBuilder.DropColumn(
                name: "has_been_abroad",
                table: "members");

            migrationBuilder.DropColumn(
                name: "motorcycle_brand",
                table: "members");

            migrationBuilder.DropColumn(
                name: "motorcycle_name",
                table: "members");

            migrationBuilder.DropColumn(
                name: "motorcycle_nickname",
                table: "members");

            migrationBuilder.DropColumn(
                name: "motorcycle_sign",
                table: "members");

            migrationBuilder.DropColumn(
                name: "profile_photo",
                table: "members");

            migrationBuilder.DropColumn(
                name: "state",
                table: "members");

            migrationBuilder.DropColumn(
                name: "states_visited",
                table: "members");

            migrationBuilder.DropColumn(
                name: "triennium",
                table: "members");

            migrationBuilder.DropColumn(
                name: "wife_name",
                table: "members");

            migrationBuilder.DropColumn(
                name: "wife_nickname",
                table: "members");

            migrationBuilder.RenameColumn(
                name: "is_first",
                table: "members",
                newName: "is_member_active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_member_active",
                table: "members",
                newName: "is_first");

            migrationBuilder.AddColumn<DateTime>(
                name: "birth_date",
                table: "members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "board_id",
                table: "members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "entry_date",
                table: "members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "has_been_abroad",
                table: "members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "motorcycle_brand",
                table: "members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motorcycle_name",
                table: "members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motorcycle_nickname",
                table: "members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motorcycle_sign",
                table: "members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "profile_photo",
                table: "members",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "states_visited",
                table: "members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "triennium",
                table: "members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "wife_name",
                table: "members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wife_nickname",
                table: "members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "boards",
                columns: table => new
                {
                    board_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    board_leader_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boards", x => x.board_id);
                    table.ForeignKey(
                        name: "FK_boards_members_board_leader_id",
                        column: x => x.board_leader_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_members_board_id",
                table: "members",
                column: "board_id");

            migrationBuilder.CreateIndex(
                name: "IX_boards_board_leader_id",
                table: "boards",
                column: "board_leader_id");

            migrationBuilder.AddForeignKey(
                name: "FK_members_boards_board_id",
                table: "members",
                column: "board_id",
                principalTable: "boards",
                principalColumn: "board_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
