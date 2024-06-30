using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9da68ce1-97c4-4890-8bcc-f1f64e2667fe");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f787e32e-ca3d-4eb7-a247-1ae90e68ae97");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa404b1c-e605-4698-8a20-fc00edb75f34", null, "admin", "admin" },
                    { "ce5c57fe-cfe8-44e5-b29c-930b2d9a6faa", null, "user", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "aa404b1c-e605-4698-8a20-fc00edb75f34");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ce5c57fe-cfe8-44e5-b29c-930b2d9a6faa");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9da68ce1-97c4-4890-8bcc-f1f64e2667fe", null, "admin", "admin" },
                    { "f787e32e-ca3d-4eb7-a247-1ae90e68ae97", null, "user", "user" }
                });
        }
    }
}
