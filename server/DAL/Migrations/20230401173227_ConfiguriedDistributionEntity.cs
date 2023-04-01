using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedDistributionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "distributions",
                columns: table => new
                {
                    distribution_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serial_num = table.Column<int>(type: "int", nullable: false),
                    dayang_id = table.Column<int>(type: "int", nullable: false),
                    division_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distributions", x => x.distribution_id);
                    table.ForeignKey(
                        name: "FK_distributions_dayangs_dayang_id",
                        column: x => x.dayang_id,
                        principalTable: "dayangs",
                        principalColumn: "dayang_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_distributions_divisions_division_id",
                        column: x => x.division_id,
                        principalTable: "divisions",
                        principalColumn: "division_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_distributions_dayang_id_serial_num",
                table: "distributions",
                columns: new[] { "dayang_id", "serial_num" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_distributions_division_id",
                table: "distributions",
                column: "division_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "distributions");
        }
    }
}
