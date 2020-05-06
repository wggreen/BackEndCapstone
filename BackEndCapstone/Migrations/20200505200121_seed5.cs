using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "UserType" },
                values: new object[] { "d100984c-315f-4c20-9d1f-a9090d73d89c", "venue" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserType" },
                values: new object[] { "dd5aa989-5953-4583-82ae-c02f4ea21728", "AQAAAAEAACcQAAAAEKYfqxy2FREJT4EOG2qYKYvFoSbA6L+bp6MdRgfL+/GCbReyMamJALdzuLtuNfMuiw==", "venue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "UserType" },
                values: new object[] { "b4160e69-ff85-4246-b6f8-0a28b8a5f0b3", "band" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserType" },
                values: new object[] { "f39ba644-d543-4809-9b67-451b41fe262a", "AQAAAAEAACcQAAAAEF93hfXd0mWvwoFIjcGFkS/eAp3bsaFnhyyYBzXjY2rVN8/UX29yqaPqL2ayYzGafA==", "band" });
        }
    }
}
