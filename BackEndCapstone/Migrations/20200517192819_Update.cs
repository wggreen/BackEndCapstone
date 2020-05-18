using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StopNumber",
                table: "Destinations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_TourId",
                table: "Destinations",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Tours_TourId",
                table: "Destinations",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Tours_TourId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_TourId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "StopNumber",
                table: "Destinations");
        }
    }
}
