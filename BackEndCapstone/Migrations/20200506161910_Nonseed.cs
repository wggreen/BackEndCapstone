using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class Nonseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Address2", "Bandcamp", "Blurb", "Capacity", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Facebook", "Instagram", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Spotify", "State", "Twitter", "TwoFactorEnabled", "UserName", "UserType", "Website", "Youtube", "Zip" },
                values: new object[] { "00000011-ffff-ffff-ffff-ffffffffffff", 0, null, null, null, null, null, "Nashville", "7f5882a9-5017-4b1e-80ae-76561d019a00", "venue@admin.com", true, null, null, false, null, "cool band", "VENUE@ADMIN.COM", "VENUE@ADMIN.COM", "AQAAAAEAACcQAAAAEEKwOB0FZ86aLw5tbnjyNnD+tTyMeRE4QzvL2REzX4yvniWs644XDAJaCteDYdz/Bw==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794588", null, "TN", null, false, "venue@admin.com", "venue", null, null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Address2", "Bandcamp", "Blurb", "Capacity", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Facebook", "Instagram", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Spotify", "State", "Twitter", "TwoFactorEnabled", "UserName", "UserType", "Website", "Youtube", "Zip" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, null, null, null, null, null, "Nashville", "6925e64e-dd67-4c4c-b4db-16121a462bf6", "band@admin.com", true, null, null, false, null, "cool band", "BAND@ADMIN.COM", "BAND@ADMIN.COM", "AQAAAAEAACcQAAAAEDiPhfIl6qvwE+GzJN27Abkxm9gE1JCXQux3UBkluT9QPdEFaQYNqrgxPDIB7EsiMw==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", null, "TN", null, false, "band@admin.com", "venue", null, null, null });
        }
    }
}
