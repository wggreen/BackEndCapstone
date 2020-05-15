using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class Tours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandId",
                table: "Tours");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tours");

            migrationBuilder.AddColumn<string>(
                name: "BandId",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
