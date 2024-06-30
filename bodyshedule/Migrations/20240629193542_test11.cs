using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bodyshedule.Migrations
{
    /// <inheritdoc />
    public partial class test11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "ExerciseItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51faf5c3-9e28-4f34-8f46-a738eba5bdc4", null, "admin", "admin" },
                    { "94d7d1e0-938a-4f32-b2ee-183f2fd71c45", null, "user", "user" }
                });

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

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "51faf5c3-9e28-4f34-8f46-a738eba5bdc4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "94d7d1e0-938a-4f32-b2ee-183f2fd71c45");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "ExerciseItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
