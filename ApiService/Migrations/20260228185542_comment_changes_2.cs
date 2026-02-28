using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharaoh_moto_club.Migrations
{
    /// <inheritdoc />
    public partial class comment_changes_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "state_id",
                table: "events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city_id",
                table: "events");

            migrationBuilder.DropColumn(
                name: "state_id",
                table: "events");
        }
    }
}
