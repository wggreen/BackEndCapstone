using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                column: "ConcurrencyStamp",
                value: "c54b8371-a554-41f4-8aa3-54392d8865c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8b0c71f-969f-48cb-8732-b648b47846a7", "AQAAAAEAACcQAAAAEHIM56MIfCCqFrCy4u1Oh4ScsSEEKwbc2/zqQWdxupgFimZVrCHOy+4ZrhkwS8esjw==" });
        }
    }
}
