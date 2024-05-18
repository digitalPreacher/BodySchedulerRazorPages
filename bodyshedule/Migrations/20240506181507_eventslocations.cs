using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class eventslocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "17a84c65-97d1-4380-ab57-7869b6a61495");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "id",
                keyValue: "6e139f7b-51a2-4bfb-97e9-2ad5ca7f4938");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "id", "ConcurrencyStamp", "name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d174e4f-f0ad-4a7e-bca4-847e1c7d0ea8", null, "admin", "admin" },
                    { "ef18932b-592c-4feb-9118-50eaae41f769", null, "user", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Locations");

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
                    { "17a84c65-97d1-4380-ab57-7869b6a61495", null, "admin", "admin" },
                    { "6e139f7b-51a2-4bfb-97e9-2ad5ca7f4938", null, "user", "user" }
                });
        }
    }
}
