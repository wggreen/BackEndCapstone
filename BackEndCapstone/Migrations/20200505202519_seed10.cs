using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6925e64e-dd67-4c4c-b4db-16121a462bf6", "AQAAAAEAACcQAAAAEDiPhfIl6qvwE+GzJN27Abkxm9gE1JCXQux3UBkluT9QPdEFaQYNqrgxPDIB7EsiMw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f5882a9-5017-4b1e-80ae-76561d019a00", "AQAAAAEAACcQAAAAEEKwOB0FZ86aLw5tbnjyNnD+tTyMeRE4QzvL2REzX4yvniWs644XDAJaCteDYdz/Bw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ad9b53b-a462-4dd8-94c7-dbb17dc1d7c3", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "362d2f8d-33f0-429e-80e7-baa8145a0b2c", "AQAAAAEAACcQAAAAEBuEM8oAy41UpdQ3+OUUWN6xT9xbetBieXuMXolrQlW9BLlK5wE3nudlfajXQ0WDPg==" });
        }
    }
}
