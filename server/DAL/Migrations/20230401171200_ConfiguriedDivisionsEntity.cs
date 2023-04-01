using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedDivisionsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    division_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    division_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    min_weight = table.Column<int>(type: "int", nullable: true),
                    max_weight = table.Column<int>(type: "int", nullable: true),
                    min_age = table.Column<int>(type: "int", nullable: false),
                    max_age = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    min_rank = table.Column<string>(type: "varchar(4)", nullable: false),
                    max_rank = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisions", x => x.division_id);
                    table.CheckConstraint("CHK_divisions_sex", "sex IN ('M', 'F')");
                    table.CheckConstraint("CHK_divisions_weight", "min_weight IS NOT NULL OR  max_weight IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_divisions_belts_max_rank",
                        column: x => x.max_rank,
                        principalTable: "belts",
                        principalColumn: "rank",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_divisions_belts_min_rank",
                        column: x => x.min_rank,
                        principalTable: "belts",
                        principalColumn: "rank",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_divisions_division_name",
                table: "divisions",
                column: "division_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_divisions_max_rank",
                table: "divisions",
                column: "max_rank");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_min_rank",
                table: "divisions",
                column: "min_rank");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "divisions");
        }
    }
}
