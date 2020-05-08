using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24bf2eef-de50-47c8-9e92-3daa5ca2fd7f", "AQAAAAEAACcQAAAAEApxe1IORbeIlQ+r9tSmKx/f9pK69TDqtWimw8Jou5G0DiHPkisZtteaRNYk27XoKA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Address2", "Bandcamp", "Blurb", "Capacity", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Facebook", "Instagram", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Spotify", "State", "Twitter", "TwoFactorEnabled", "UserName", "UserType", "Website", "Youtube", "Zip" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, null, null, null, null, null, "Nashville", "455aa628-05b5-410a-85df-82ac3b1fb873", "venue@admin.com", true, null, null, false, null, "cool band", "VENUE@ADMIN.COM", "VENUE@ADMIN.COM", null, null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", null, "TN", null, false, "venue@admin.com", "band", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25c913c4-e709-4fef-b85c-c9c4571e6707", "AQAAAAEAACcQAAAAEC6kOAMaipBq5kEsqPpWtpP7fSFytXuBSMGsACKC4vv+luShoUWV16TnAi5M4N+DSw==" });
        }
    }
}
