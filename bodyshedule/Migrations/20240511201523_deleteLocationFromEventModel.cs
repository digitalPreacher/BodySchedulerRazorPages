using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class deleteLocationFromEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "6d174e4f-f0ad-4a7e-bca4-847e1c7d0ea8");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "ef18932b-592c-4feb-9118-50eaae41f769");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "id", "ConcurrencyStamp", "name", "NormalizedName" },
                values: new object[,]
                {
                    { "537722a4-35ad-4b56-adde-8a0f452c6b8e", null, "user", "user" },
                    { "dcbb7e19-81cd-4add-91a3-22883146c525", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "537722a4-35ad-4b56-adde-8a0f452c6b8e");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "dcbb7e19-81cd-4add-91a3-22883146c525");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "id", "ConcurrencyStamp", "name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d174e4f-f0ad-4a7e-bca4-847e1c7d0ea8", null, "admin", "admin" },
                    { "ef18932b-592c-4feb-9118-50eaae41f769", null, "user", "user" }
                });
        }
    }
}
