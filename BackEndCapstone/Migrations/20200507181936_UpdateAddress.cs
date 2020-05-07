using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class UpdateAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lng",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Addresses");
        }
    }
}
