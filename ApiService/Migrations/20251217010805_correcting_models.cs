using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class correcting_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    member_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    states_visited = table.Column<int>(type: "int", nullable: false),
                    entry_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    triennium = table.Column<int>(type: "int", nullable: false),
                    has_been_abroad = table.Column<bool>(type: "bit", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_first = table.Column<bool>(type: "bit", nullable: false),
                    wife_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wife_nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coat_of_arms = table.Column<bool>(type: "bit", nullable: false),
                    profile_photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    motorcycle_sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motorcycle_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motorcycle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motorcycle_nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    board_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.member_id);
                    table.ForeignKey(
                        name: "FK_members_boards_board_id",
                        column: x => x.board_id,
                        principalTable: "boards",
                        principalColumn: "board_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "elections",
                columns: table => new
                {
                    election_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_to_be_elected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beggining_of_election = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ending_of_election = table.Column<DateTime>(type: "datetime2", nullable: false),
                    winner_id = table.Column<int>(type: "int", nullable: true),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    is_election_closed = table.Column<bool>(type: "bit", nullable: false)
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "offboardings",
                columns: table => new
                {
                    offboarding_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_id = table.Column<int>(type: "int", nullable: false),
                    offboarding_beggining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    offboarding_end = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offboardings", x => x.offboarding_id);
                    table.ForeignKey(
                        name: "FK_offboardings_members_member_id",
                        column: x => x.member_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidacy",
                columns: table => new
                {
                    candidacy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    election_id = table.Column<int>(type: "int", nullable: false),
                    candidate_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidacy", x => x.candidacy_id);
                    table.ForeignKey(
                        name: "FK_candidacy_elections_election_id",
                        column: x => x.election_id,
                        principalTable: "elections",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidacy_members_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "votes",
                columns: table => new
                {
                    vote_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voter_id = table.Column<int>(type: "int", nullable: false),
                    election_id = table.Column<int>(type: "int", nullable: false),
                    candidate_id = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_votes_members_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "members",
                        principalColumn: "member_id");
                    table.ForeignKey(
                        name: "FK_votes_members_voter_id",
                        column: x => x.voter_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_boards_board_leader_id",
                table: "boards",
                column: "board_leader_id");

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
                name: "IX_members_board_id",
                table: "members",
                column: "board_id");

            migrationBuilder.CreateIndex(
                name: "IX_offboardings_member_id",
                table: "offboardings",
                column: "member_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_boards_members_board_leader_id",
                table: "boards",
                column: "board_leader_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boards_members_board_leader_id",
                table: "boards");

            migrationBuilder.DropTable(
                name: "candidacy");

            migrationBuilder.DropTable(
                name: "offboardings");

            migrationBuilder.DropTable(
                name: "votes");

            migrationBuilder.DropTable(
                name: "elections");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "boards");
        }
    }
}
