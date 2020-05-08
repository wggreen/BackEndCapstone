using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                column: "ConcurrencyStamp",
                value: "69bb6fc2-7574-4f1f-8dc3-ebdc60c52369");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd3c476c-b59d-4d99-ab7c-91b14c0e9618", "AQAAAAEAACcQAAAAEG2BNeBakp7VwH8OmavD1q2blBPxEcgdY4iE0IoHBuqj+RuMQi7NGUUla2/IFbd48A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                column: "ConcurrencyStamp",
                value: "aa530b8e-b216-49c6-845d-42dcf8bb44bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cdb980b0-b822-4c5d-8de2-a407d99aaff8", "AQAAAAEAACcQAAAAEJBPn2n61c4fpu2lyB/Flqa1mFCLLsr0GlTgwJ8NUftbOTyUDmOhkoi1EH+KTU6Pnw==" });
        }
    }
}
