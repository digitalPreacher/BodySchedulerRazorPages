using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseItems_Events_EventId",
                table: "ExerciseItems");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseItems_EventId",
                table: "ExerciseItems");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "aa404b1c-e605-4698-8a20-fc00edb75f34");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ce5c57fe-cfe8-44e5-b29c-930b2d9a6faa");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ExerciseItems");

            migrationBuilder.AddColumn<int>(
                name: "EventsId",
                table: "ExerciseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ff01c9c-9b34-4d2f-a89f-d9f9acb3a97e", null, "user", "user" },
                    { "aad8b562-8da5-41fa-a7e9-cba1e630084e", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseItems_EventsId",
                table: "ExerciseItems",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseItems_Events_EventsId",
                table: "ExerciseItems",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseItems_Events_EventsId",
                table: "ExerciseItems");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseItems_EventsId",
                table: "ExerciseItems");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "6ff01c9c-9b34-4d2f-a89f-d9f9acb3a97e");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "aad8b562-8da5-41fa-a7e9-cba1e630084e");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "ExerciseItems");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "ExerciseItems",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa404b1c-e605-4698-8a20-fc00edb75f34", null, "admin", "admin" },
                    { "ce5c57fe-cfe8-44e5-b29c-930b2d9a6faa", null, "user", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseItems_EventId",
                table: "ExerciseItems",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseItems_Events_EventId",
                table: "ExerciseItems",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
