using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class DesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Destinations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Destinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Destinations");
        }
    }
}
