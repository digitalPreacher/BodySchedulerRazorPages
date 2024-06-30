using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
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
                keyValue: "7b716b61-85e4-4df2-a942-65233d4178ed");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9eb31532-e2d8-40d8-879e-f61f50068c54");

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
                    { "4f2864a9-c04a-4d8e-b4ea-f514f7592f17", null, "user", "user" },
                    { "ae0c68a9-4983-48be-8458-a891160756b2", null, "admin", "admin" }
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
                keyValue: "4f2864a9-c04a-4d8e-b4ea-f514f7592f17");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ae0c68a9-4983-48be-8458-a891160756b2");

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
                    { "7b716b61-85e4-4df2-a942-65233d4178ed", null, "user", "user" },
                    { "9eb31532-e2d8-40d8-879e-f61f50068c54", null, "admin", "admin" }
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
