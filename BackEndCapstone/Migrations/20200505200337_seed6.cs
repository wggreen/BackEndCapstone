using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                column: "ConcurrencyStamp",
                value: "d100984c-315f-4c20-9d1f-a9090d73d89c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd5aa989-5953-4583-82ae-c02f4ea21728", "AQAAAAEAACcQAAAAEKYfqxy2FREJT4EOG2qYKYvFoSbA6L+bp6MdRgfL+/GCbReyMamJALdzuLtuNfMuiw==" });
        }
    }
}
