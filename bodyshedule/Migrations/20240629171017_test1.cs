using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ExerciseItems_ItemsId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ItemsId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "78791b2a-9338-41e5-ac2f-9df273b85e24");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "eb3ec920-8f33-485d-bd0c-c32e0dbfa46f");

            migrationBuilder.DropColumn(
                name: "ItemsId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ItemsId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78791b2a-9338-41e5-ac2f-9df273b85e24", null, "admin", "admin" },
                    { "eb3ec920-8f33-485d-bd0c-c32e0dbfa46f", null, "user", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ItemsId",
                table: "Events",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ExerciseItems_ItemsId",
                table: "Events",
                column: "ItemsId",
                principalTable: "ExerciseItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
