using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventExerciseItem");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "026000d5-9f20-4076-8e59-994ef6e43d5e");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "be6cfbb7-d6a2-4fb8-97bd-31b73fb9c7dd");

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
                    { "9da68ce1-97c4-4890-8bcc-f1f64e2667fe", null, "admin", "admin" },
                    { "f787e32e-ca3d-4eb7-a247-1ae90e68ae97", null, "user", "user" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "9da68ce1-97c4-4890-8bcc-f1f64e2667fe");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f787e32e-ca3d-4eb7-a247-1ae90e68ae97");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ExerciseItems");

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
                    { "026000d5-9f20-4076-8e59-994ef6e43d5e", null, "user", "user" },
                    { "be6cfbb7-d6a2-4fb8-97bd-31b73fb9c7dd", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventExerciseItem_ItemsId",
                table: "EventExerciseItem",
                column: "ItemsId");
        }
    }
}
