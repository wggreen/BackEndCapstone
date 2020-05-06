using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "b4160e69-ff85-4246-b6f8-0a28b8a5f0b3", "band@admin.com", "BAND@ADMIN.COM", "BAND@ADMIN.COM", "band@admin.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f39ba644-d543-4809-9b67-451b41fe262a", "AQAAAAEAACcQAAAAEF93hfXd0mWvwoFIjcGFkS/eAp3bsaFnhyyYBzXjY2rVN8/UX29yqaPqL2ayYzGafA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "455aa628-05b5-410a-85df-82ac3b1fb873", "venue@admin.com", "VENUE@ADMIN.COM", "VENUE@ADMIN.COM", "venue@admin.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24bf2eef-de50-47c8-9e92-3daa5ca2fd7f", "AQAAAAEAACcQAAAAEApxe1IORbeIlQ+r9tSmKx/f9pK69TDqtWimw8Jou5G0DiHPkisZtteaRNYk27XoKA==" });
        }
    }
}
