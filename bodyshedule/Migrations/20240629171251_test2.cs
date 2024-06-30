using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventExerciseItem");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "743ea7f1-f63b-4a18-a665-023882cafa1e");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "bdd5a907-090c-4def-9328-281b88775afa");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseItemId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b1c6ed3-3dc8-406a-b674-551a25a83747", null, "admin", "admin" },
                    { "cd8fd133-b5c6-4a0d-bad5-413aef96e2a1", null, "user", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ExerciseItemId",
                table: "Events",
                column: "ExerciseItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ExerciseItems_ExerciseItemId",
                table: "Events",
                column: "ExerciseItemId",
                principalTable: "ExerciseItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ExerciseItems_ExerciseItemId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ExerciseItemId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "3b1c6ed3-3dc8-406a-b674-551a25a83747");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "cd8fd133-b5c6-4a0d-bad5-413aef96e2a1");

            migrationBuilder.DropColumn(
                name: "ExerciseItemId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "EventExerciseItem",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventExerciseItem", x => new { x.EventsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_EventExerciseItem_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventExerciseItem_ExerciseItems_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "ExerciseItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "743ea7f1-f63b-4a18-a665-023882cafa1e", null, "user", "user" },
                    { "bdd5a907-090c-4def-9328-281b88775afa", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventExerciseItem_ItemsId",
                table: "EventExerciseItem",
                column: "ItemsId");
        }
    }
}
