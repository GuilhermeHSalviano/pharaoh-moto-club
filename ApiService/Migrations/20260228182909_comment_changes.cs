using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class comment_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorIdMemberId",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorMemberId",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comment_AuthorIdMemberId",
                table: "comment",
                column: "AuthorIdMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_AuthorMemberId",
                table: "comment",
                column: "AuthorMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_members_AuthorIdMemberId",
                table: "comment",
                column: "AuthorIdMemberId",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_members_AuthorMemberId",
                table: "comment",
                column: "AuthorMemberId",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_members_AuthorIdMemberId",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_members_AuthorMemberId",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_comment_AuthorIdMemberId",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_comment_AuthorMemberId",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "AuthorIdMemberId",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "AuthorMemberId",
                table: "comment");
        }
    }
}
