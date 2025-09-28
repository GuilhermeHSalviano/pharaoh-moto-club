using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    board_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    board_leader_id = table.Column<int>(type: "int", nullable: true),
                    board_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.board_id);
                });

            migrationBuilder.CreateTable(
                name: "Candidacy",
                columns: table => new
                {
                    candidacy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    election_id = table.Column<int>(type: "int", nullable: false),
                    voter_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidacy", x => x.candidacy_id);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    election_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_to_be_elected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beggining_of_election = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ending_of_election = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.election_id);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoterId = table.Column<int>(type: "int", nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
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
                    rank = table.Column<int>(type: "int", nullable: true),
                    triennium = table.Column<int>(type: "int", nullable: false),
                    has_been_abroad = table.Column<bool>(type: "bit", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_first = table.Column<bool>(type: "bit", nullable: false),
                    wife_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wife_nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coat_of_arms = table.Column<bool>(type: "bit", nullable: false),
                    off_boarding = table.Column<bool>(type: "bit", nullable: false),
                    profile_photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    motorcycle_sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motorcycle_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motorcycle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motorcycle_nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_system_manager = table.Column<bool>(type: "bit", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.member_id);
                    table.ForeignKey(
                        name: "FK_Members_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "board_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_BoardId",
                table: "Members",
                column: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidacy");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
