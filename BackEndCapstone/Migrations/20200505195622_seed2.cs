using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Address2", "Bandcamp", "Blurb", "Capacity", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Facebook", "Instagram", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Spotify", "State", "Twitter", "TwoFactorEnabled", "UserName", "UserType", "Website", "Youtube", "Zip" },
                values: new object[] { "00000011-ffff-ffff-ffff-ffffffffffff", 0, null, null, null, null, null, "Nashville", "25c913c4-e709-4fef-b85c-c9c4571e6707", "venue@admin.com", true, null, null, false, null, "cool band", "VENUE@ADMIN.COM", "VENUE@ADMIN.COM", "AQAAAAEAACcQAAAAEC6kOAMaipBq5kEsqPpWtpP7fSFytXuBSMGsACKC4vv+luShoUWV16TnAi5M4N+DSw==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794588", null, "TN", null, false, "venue@admin.com", "band", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Address2", "Bandcamp", "Blurb", "Capacity", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Facebook", "Instagram", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Spotify", "State", "Twitter", "TwoFactorEnabled", "UserName", "UserType", "Website", "Youtube", "Zip" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, null, null, null, null, null, "Nashville", "3d4e71c6-3d48-4987-b918-e88391596b8b", "admin@admin.com", true, null, null, false, null, "cool band", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEHudo6YH0OU3V+6lgS5TmoIIqbPvW2rFRHl5dmHiwfU1Z9PB226aJcHC0Yez76IaeQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", null, "TN", null, false, "admin@admin.com", "band", null, null, null });
        }
    }
}
