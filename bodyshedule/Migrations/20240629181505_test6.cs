using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test6 : Migration
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
                keyValue: "58f85ab9-1651-410d-89bd-378b62a8bcc8");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c53f66b2-0f4e-404b-8cf1-4f1f2065803d");

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
                    { "026000d5-9f20-4076-8e59-994ef6e43d5e", null, "user", "user" },
                    { "be6cfbb7-d6a2-4fb8-97bd-31b73fb9c7dd", null, "admin", "admin" }
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
                keyValue: "026000d5-9f20-4076-8e59-994ef6e43d5e");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "be6cfbb7-d6a2-4fb8-97bd-31b73fb9c7dd");

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
                    { "58f85ab9-1651-410d-89bd-378b62a8bcc8", null, "admin", "admin" },
                    { "c53f66b2-0f4e-404b-8cf1-4f1f2065803d", null, "user", "user" }
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
