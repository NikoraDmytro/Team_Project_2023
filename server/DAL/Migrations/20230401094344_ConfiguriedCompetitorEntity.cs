using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedCompetitorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competitors",
                columns: table => new
                {
                    application_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weighting_result = table.Column<int>(type: "int", nullable: true),
                    membership_card_num = table.Column<int>(type: "int", nullable: false),
                    belt_rank = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    competition_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitors", x => x.application_num);
                    table.ForeignKey(
                        name: "FK_competitors_belts_belt_rank",
                        column: x => x.belt_rank,
                        principalTable: "belts",
                        principalColumn: "rank",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_competitors_competitions_competition_id",
                        column: x => x.competition_id,
                        principalTable: "competitions",
                        principalColumn: "competition_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_competitors_sportsmen_membership_card_num",
                        column: x => x.membership_card_num,
                        principalTable: "sportsmen",
                        principalColumn: "membership_card_num",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitors_belt_rank",
                table: "competitors",
                column: "belt_rank");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_competition_id",
                table: "competitors",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_membership_card_num",
                table: "competitors",
                column: "membership_card_num",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "competitors");
        }
    }
}
