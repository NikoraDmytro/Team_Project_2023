using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredJudgeCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches");

            migrationBuilder.DropColumn(
                name: "judge_category",
                table: "judges");

            migrationBuilder.AddColumn<int>(
                name: "judge_category_id",
                table: "judges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "instructor_category_id",
                table: "coaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "judge_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_judge_categories", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "judge_categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Суддя міжнародної категорії А" },
                    { 2, "Суддя міжнародної категорії В" },
                    { 3, "Суддя національної категорії" },
                    { 4, "Суддя 1-ї категорії" },
                    { 5, "Суддя 2-ї категорії" },
                    { 6, "Суддя 3-ї категорії" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_judges_judge_category_id",
                table: "judges",
                column: "judge_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_judge_categories_name",
                table: "judge_categories",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches",
                column: "instructor_category_id",
                principalTable: "instructor_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_judges_judge_categories_judge_category_id",
                table: "judges",
                column: "judge_category_id",
                principalTable: "judge_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_judges_judge_categories_judge_category_id",
                table: "judges");

            migrationBuilder.DropTable(
                name: "judge_categories");

            migrationBuilder.DropIndex(
                name: "IX_judges_judge_category_id",
                table: "judges");

            migrationBuilder.DropColumn(
                name: "judge_category_id",
                table: "judges");

            migrationBuilder.AddColumn<string>(
                name: "judge_category",
                table: "judges",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "instructor_category_id",
                table: "coaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches",
                column: "instructor_category_id",
                principalTable: "instructor_categories",
                principalColumn: "id");
        }
    }
}
