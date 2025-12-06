using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class changing_name_of_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Boards_BoardId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elections",
                table: "Elections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidacy",
                table: "Candidacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "votes");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "members");

            migrationBuilder.RenameTable(
                name: "Elections",
                newName: "elections");

            migrationBuilder.RenameTable(
                name: "Candidacy",
                newName: "candidacy");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "boards");

            migrationBuilder.RenameIndex(
                name: "IX_Members_BoardId",
                table: "members",
                newName: "IX_members_BoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_votes",
                table: "votes",
                column: "VoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_members",
                table: "members",
                column: "member_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_elections",
                table: "elections",
                column: "election_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidacy",
                table: "candidacy",
                column: "candidacy_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boards",
                table: "boards",
                column: "board_id");

            migrationBuilder.AddForeignKey(
                name: "FK_members_boards_BoardId",
                table: "members",
                column: "BoardId",
                principalTable: "boards",
                principalColumn: "board_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_members_boards_BoardId",
                table: "members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_votes",
                table: "votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_members",
                table: "members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_elections",
                table: "elections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidacy",
                table: "candidacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boards",
                table: "boards");

            migrationBuilder.RenameTable(
                name: "votes",
                newName: "Votes");

            migrationBuilder.RenameTable(
                name: "members",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "elections",
                newName: "Elections");

            migrationBuilder.RenameTable(
                name: "candidacy",
                newName: "Candidacy");

            migrationBuilder.RenameTable(
                name: "boards",
                newName: "Boards");

            migrationBuilder.RenameIndex(
                name: "IX_members_BoardId",
                table: "Members",
                newName: "IX_Members_BoardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "VoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "member_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elections",
                table: "Elections",
                column: "election_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidacy",
                table: "Candidacy",
                column: "candidacy_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "board_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Boards_BoardId",
                table: "Members",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "board_id");
        }
    }
}
