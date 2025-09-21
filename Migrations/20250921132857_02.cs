using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Boards_BoardId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Boards_BoardId",
                table: "Members",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Boards_BoardId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Boards_BoardId",
                table: "Members",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "BoardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
