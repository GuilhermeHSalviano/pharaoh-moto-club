using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class refactoring_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidacy");

            migrationBuilder.DropTable(
                name: "votes");

            migrationBuilder.DropTable(
                name: "elections");

            migrationBuilder.DropColumn(
                name: "coat_of_arms",
                table: "members");

            migrationBuilder.DropColumn(
                name: "is_member_active",
                table: "members");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "members",
                newName: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "members",
                newName: "cpf");

            migrationBuilder.AddColumn<bool>(
                name: "coat_of_arms",
                table: "members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_member_active",
                table: "members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "elections",
                columns: table => new
                {
                    election_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    winner_id = table.Column<int>(type: "int", nullable: true),
                    beggining_of_election = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ending_of_election = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_election_closed = table.Column<bool>(type: "bit", nullable: false),
                    position_to_be_elected = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elections", x => x.election_id);
                    table.ForeignKey(
                        name: "FK_elections_members_author_id",
                        column: x => x.author_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_elections_members_winner_id",
                        column: x => x.winner_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "candidacy",
                columns: table => new
                {
                    candidacy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    candidate_id = table.Column<int>(type: "int", nullable: false),
                    election_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidacy", x => x.candidacy_id);
                    table.ForeignKey(
                        name: "FK_candidacy_elections_election_id",
                        column: x => x.election_id,
                        principalTable: "elections",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_candidacy_members_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "votes",
                columns: table => new
                {
                    vote_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    candidate_id = table.Column<int>(type: "int", nullable: true),
                    election_id = table.Column<int>(type: "int", nullable: false),
                    voter_id = table.Column<int>(type: "int", nullable: false),
                    is_candidates_rejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votes", x => x.vote_id);
                    table.ForeignKey(
                        name: "FK_votes_elections_election_id",
                        column: x => x.election_id,
                        principalTable: "elections",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_votes_members_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_votes_members_voter_id",
                        column: x => x.voter_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidacy_candidate_id",
                table: "candidacy",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_candidacy_election_id",
                table: "candidacy",
                column: "election_id");

            migrationBuilder.CreateIndex(
                name: "IX_elections_author_id",
                table: "elections",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_elections_winner_id",
                table: "elections",
                column: "winner_id");

            migrationBuilder.CreateIndex(
                name: "IX_votes_candidate_id",
                table: "votes",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_votes_election_id",
                table: "votes",
                column: "election_id");

            migrationBuilder.CreateIndex(
                name: "IX_votes_voter_id",
                table: "votes",
                column: "voter_id");
        }
    }
}
