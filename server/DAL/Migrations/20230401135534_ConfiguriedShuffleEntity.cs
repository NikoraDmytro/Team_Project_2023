using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedShuffleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shuffles",
                columns: table => new
                {
                    shuffle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lap_num = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    pair_serial_num = table.Column<int>(type: "int", nullable: false),
                    competitor_in_blue_id = table.Column<int>(type: "int", nullable: false),
                    competitor_in_red_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shuffles", x => x.shuffle_id);
                    table.CheckConstraint("CHK_shuffles_competitor_in_blue_id", "competitor_in_blue_id != competitor_in_red_id");
                    table.ForeignKey(
                        name: "FK_shuffles_competitors_competitor_in_blue_id",
                        column: x => x.competitor_in_blue_id,
                        principalTable: "competitors",
                        principalColumn: "application_num",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shuffles_competitors_competitor_in_red_id",
                        column: x => x.competitor_in_red_id,
                        principalTable: "competitors",
                        principalColumn: "application_num",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shuffles_competitor_in_blue_id_competitor_in_red_id",
                table: "shuffles",
                columns: new[] { "competitor_in_blue_id", "competitor_in_red_id" },
                unique: true,
                filter: "[competitor_in_red_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_shuffles_competitor_in_blue_id_lap_num",
                table: "shuffles",
                columns: new[] { "competitor_in_blue_id", "lap_num" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shuffles_competitor_in_red_id_lap_num",
                table: "shuffles",
                columns: new[] { "competitor_in_red_id", "lap_num" },
                unique: true,
                filter: "[competitor_in_red_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shuffles");
        }
    }
}
