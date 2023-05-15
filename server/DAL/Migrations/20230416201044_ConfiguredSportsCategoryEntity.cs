using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredSportsCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches");

            migrationBuilder.DropColumn(
                name: "sports_category",
                table: "sportsmen");

            migrationBuilder.AddColumn<int>(
                name: "sports_category_id",
                table: "sportsmen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sports_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sports_categories", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "sports_categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Майстер спорту України міжнародного класу" },
                    { 2, "Майстер спорту України" },
                    { 3, "Кандидат у майстри спорту" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_sportsmen_sports_category_id",
                table: "sportsmen",
                column: "sports_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_sports_categories_name",
                table: "sports_categories",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches",
                column: "instructor_category_id",
                principalTable: "instructor_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sportsmen_sports_categories_sports_category_id",
                table: "sportsmen",
                column: "sports_category_id",
                principalTable: "sports_categories",
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
                name: "FK_sportsmen_sports_categories_sports_category_id",
                table: "sportsmen");

            migrationBuilder.DropTable(
                name: "sports_categories");

            migrationBuilder.DropIndex(
                name: "IX_sportsmen_sports_category_id",
                table: "sportsmen");

            migrationBuilder.DropColumn(
                name: "sports_category_id",
                table: "sportsmen");

            migrationBuilder.AddColumn<string>(
                name: "sports_category",
                table: "sportsmen",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_coaches_instructor_categories_instructor_category_id",
                table: "coaches",
                column: "instructor_category_id",
                principalTable: "instructor_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
