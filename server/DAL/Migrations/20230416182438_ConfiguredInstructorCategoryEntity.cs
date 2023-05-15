using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredInstructorCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorCategory",
                table: "coaches");

            migrationBuilder.AddColumn<int>(
                name: "instructor_category_id",
                table: "coaches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "instructor_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructor_categories", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "instructor_categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Тренер початкової підготовки" },
                    { 2, "Тренер національного класу" },
                    { 3, "Інстуктор міжнародного класу" },
                    { 4, "Майстер-інструктор міжнародного класу" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_coaches_instructor_category_id",
                table: "coaches",
                column: "instructor_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_instructor_categories_name",
                table: "instructor_categories",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches",
                column: "instructor_category_id",
                principalTable: "instructor_categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches");

            migrationBuilder.DropTable(
                name: "instructor_categories");

            migrationBuilder.DropIndex(
                name: "IX_coaches_instructor_category_id",
                table: "coaches");

            migrationBuilder.DropColumn(
                name: "instructor_category_id",
                table: "coaches");

            migrationBuilder.AddColumn<string>(
                name: "InstructorCategory",
                table: "coaches",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
