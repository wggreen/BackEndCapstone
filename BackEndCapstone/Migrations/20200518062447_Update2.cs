using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StopNumber",
                table: "Destinations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdded",
                table: "Destinations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeAdded",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
                name: "StopNumber",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
