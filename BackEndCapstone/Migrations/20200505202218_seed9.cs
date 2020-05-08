using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Migrations
{
    public partial class seed9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                column: "ConcurrencyStamp",
                value: "7ad9b53b-a462-4dd8-94c7-dbb17dc1d7c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000011-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "362d2f8d-33f0-429e-80e7-baa8145a0b2c", "AQAAAAEAACcQAAAAEBuEM8oAy41UpdQ3+OUUWN6xT9xbetBieXuMXolrQlW9BLlK5wE3nudlfajXQ0WDPg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
