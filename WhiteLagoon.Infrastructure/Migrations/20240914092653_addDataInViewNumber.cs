using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDataInViewNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villaNumbers",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 103, null, 1 },
                    { 104, null, 1 },
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 203, null, 2 },
                    { 301, null, 3 },
                    { 302, null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 302);
        }
    }
}
