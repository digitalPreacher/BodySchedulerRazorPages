using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
