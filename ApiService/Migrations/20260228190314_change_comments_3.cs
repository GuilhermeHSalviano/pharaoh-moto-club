using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class change_comments_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AuthorIdMemberId",
                table: "comment");

            migrationBuilder.RenameColumn(
                name: "AuthorMemberId",
                table: "comment",
                newName: "author_id");

            migrationBuilder.RenameIndex(
                name: "IX_comment_AuthorMemberId",
                table: "comment",
                newName: "IX_comment_author_id");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_members_author_id",
                table: "comment",
                column: "author_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_members_author_id",
                table: "comment");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "comment",
                newName: "AuthorMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_comment_author_id",
                table: "comment",
                newName: "IX_comment_AuthorMemberId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorIdMemberId",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comment_AuthorIdMemberId",
                table: "comment",
                column: "AuthorIdMemberId");

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
    }
}
