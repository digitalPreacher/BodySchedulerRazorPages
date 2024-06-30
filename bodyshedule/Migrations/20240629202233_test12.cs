using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1becab83-1192-4d71-aa02-2b37869cf89d", null, "user", "user" },
                    { "bcab4201-8cbc-494d-85a7-bf282b6d775d", null, "admin", "admin" }
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
                keyValue: "1becab83-1192-4d71-aa02-2b37869cf89d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "bcab4201-8cbc-494d-85a7-bf282b6d775d");

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
    }
}
