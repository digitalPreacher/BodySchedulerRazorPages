using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class deleteLocationFKfromEventDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "537722a4-35ad-4b56-adde-8a0f452c6b8e");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "dcbb7e19-81cd-4add-91a3-22883146c525");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Events");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "id", "ConcurrencyStamp", "name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f5cd723-16a9-44da-88e1-f4574918850c", null, "user", "user" },
                    { "9a0a74ee-8fa6-430f-bd30-89d06c5e8077", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "5f5cd723-16a9-44da-88e1-f4574918850c");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "9a0a74ee-8fa6-430f-bd30-89d06c5e8077");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "id", "ConcurrencyStamp", "name", "NormalizedName" },
                values: new object[,]
                {
                    { "537722a4-35ad-4b56-adde-8a0f452c6b8e", null, "user", "user" },
                    { "dcbb7e19-81cd-4add-91a3-22883146c525", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
