using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class event_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidacy_elections_election_id",
                table: "candidacy");

            migrationBuilder.DropForeignKey(
                name: "FK_candidacy_members_candidate_id",
                table: "candidacy");

            migrationBuilder.DropForeignKey(
                name: "FK_elections_members_winner_id",
                table: "elections");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_elections_election_id",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_members_candidate_id",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_members_voter_id",
                table: "votes");

            migrationBuilder.DropTable(
                name: "offboardings");

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment_text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.comment_id);
                });

            migrationBuilder.CreateTable(
                name: "type_of_event",
                columns: table => new
                {
                    type_of_event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_of_event", x => x.type_of_event_id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beginning_of_event = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    type_of_event_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_events_members_author_id",
                        column: x => x.author_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_events_type_of_event_type_of_event_id",
                        column: x => x.type_of_event_id,
                        principalTable: "type_of_event",
                        principalColumn: "type_of_event_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "event_attendant",
                columns: table => new
                {
                    event_attendant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendant_id = table.Column<int>(type: "int", nullable: false),
                    event_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_attendant", x => x.event_attendant_id);
                    table.ForeignKey(
                        name: "FK_event_attendant_events_event_id",
                        column: x => x.event_id,
                        principalTable: "events",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_event_attendant_members_attendant_id",
                        column: x => x.attendant_id,
                        principalTable: "members",
                        principalColumn: "member_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_attendant_attendant_id",
                table: "event_attendant",
                column: "attendant_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_attendant_event_id",
                table: "event_attendant",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_author_id",
                table: "events",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_type_of_event_id",
                table: "events",
                column: "type_of_event_id");

            migrationBuilder.AddForeignKey(
                name: "FK_candidacy_elections_election_id",
                table: "candidacy",
                column: "election_id",
                principalTable: "elections",
                principalColumn: "election_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_candidacy_members_candidate_id",
                table: "candidacy",
                column: "candidate_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_elections_members_winner_id",
                table: "elections",
                column: "winner_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_elections_election_id",
                table: "votes",
                column: "election_id",
                principalTable: "elections",
                principalColumn: "election_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_members_candidate_id",
                table: "votes",
                column: "candidate_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_members_voter_id",
                table: "votes",
                column: "voter_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidacy_elections_election_id",
                table: "candidacy");

            migrationBuilder.DropForeignKey(
                name: "FK_candidacy_members_candidate_id",
                table: "candidacy");

            migrationBuilder.DropForeignKey(
                name: "FK_elections_members_winner_id",
                table: "elections");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_elections_election_id",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_members_candidate_id",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_members_voter_id",
                table: "votes");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "event_attendant");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "type_of_event");

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

            migrationBuilder.CreateIndex(
                name: "IX_offboardings_member_id",
                table: "offboardings",
                column: "member_id");

            migrationBuilder.AddForeignKey(
                name: "FK_candidacy_elections_election_id",
                table: "candidacy",
                column: "election_id",
                principalTable: "elections",
                principalColumn: "election_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidacy_members_candidate_id",
                table: "candidacy",
                column: "candidate_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_elections_members_winner_id",
                table: "elections",
                column: "winner_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_elections_election_id",
                table: "votes",
                column: "election_id",
                principalTable: "elections",
                principalColumn: "election_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_members_candidate_id",
                table: "votes",
                column: "candidate_id",
                principalTable: "members",
                principalColumn: "member_id");

            migrationBuilder.AddForeignKey(
                name: "FK_votes_members_voter_id",
                table: "votes",
                column: "voter_id",
                principalTable: "members",
                principalColumn: "member_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
