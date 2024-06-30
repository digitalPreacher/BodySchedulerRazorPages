using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class ts1 : Migration
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
                keyValue: "51faf5c3-9e28-4f34-8f46-a738eba5bdc4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "94d7d1e0-938a-4f32-b2ee-183f2fd71c45");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ExerciseItems");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseItemsId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a740032-8dfb-4157-b056-0b1b123e5ef6", null, "user", "user" },
                    { "c7c0aab9-bf09-41fd-b486-70c4c8a18766", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ExerciseItemsId",
                table: "Events",
                column: "ExerciseItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ExerciseItems_ExerciseItemsId",
                table: "Events",
                column: "ExerciseItemsId",
                principalTable: "ExerciseItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ExerciseItems_ExerciseItemsId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ExerciseItemsId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8a740032-8dfb-4157-b056-0b1b123e5ef6");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c7c0aab9-bf09-41fd-b486-70c4c8a18766");

            migrationBuilder.DropColumn(
                name: "ExerciseItemsId",
                table: "Events");

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
                    { "51faf5c3-9e28-4f34-8f46-a738eba5bdc4", null, "admin", "admin" },
                    { "94d7d1e0-938a-4f32-b2ee-183f2fd71c45", null, "user", "user" }
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
