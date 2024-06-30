using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseItems_Events_EventsId",
                table: "ExerciseItems");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "6ff01c9c-9b34-4d2f-a89f-d9f9acb3a97e");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "aad8b562-8da5-41fa-a7e9-cba1e630084e");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "ExerciseItems",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseItems_EventsId",
                table: "ExerciseItems",
                newName: "IX_ExerciseItems_EventId");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12d1ab2d-3038-419d-997f-a00a54a52c16", null, "user", "user" },
                    { "771d9886-08c0-451e-a563-707497fcb8e9", null, "admin", "admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseItems_Events_EventId",
                table: "ExerciseItems",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseItems_Events_EventId",
                table: "ExerciseItems");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "12d1ab2d-3038-419d-997f-a00a54a52c16");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "771d9886-08c0-451e-a563-707497fcb8e9");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "ExerciseItems",
                newName: "EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseItems_EventId",
                table: "ExerciseItems",
                newName: "IX_ExerciseItems_EventsId");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ff01c9c-9b34-4d2f-a89f-d9f9acb3a97e", null, "user", "user" },
                    { "aad8b562-8da5-41fa-a7e9-cba1e630084e", null, "admin", "admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseItems_Events_EventsId",
                table: "ExerciseItems",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
