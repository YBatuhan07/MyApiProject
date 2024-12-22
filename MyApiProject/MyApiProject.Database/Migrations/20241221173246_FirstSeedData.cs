using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApiProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class FirstSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Antalya" },
                    { 14, "Bolu" },
                    { 34, "İstanbul" },
                    { 58, "Sivas" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 58, "Kangal" },
                    { 2, 58, "Yıldızeli" },
                    { 3, 58, "Suşehri" },
                    { 4, 7, "Muratpaşa" },
                    { 5, 7, "Alanya" },
                    { 6, 14, "Gerede" },
                    { 7, 7, "Kemer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sivas" });
        }
    }
}
