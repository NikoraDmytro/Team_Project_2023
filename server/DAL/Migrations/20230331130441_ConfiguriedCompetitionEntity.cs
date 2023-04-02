using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedCompetitionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competitions",
                columns: table => new
                {
                    competition_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    weighting_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    city = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    competition_level = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    current_status = table.Column<string>(type: "char(30)", nullable: true, defaultValue: "pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitions", x => x.competition_id);
                    table.ForeignKey(
                        name: "FK_competitions_competition_statuses_current_status",
                        column: x => x.current_status,
                        principalTable: "competition_statuses",
                        principalColumn: "status_name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitions_current_status",
                table: "competitions",
                column: "current_status");

            migrationBuilder.CreateIndex(
                name: "IX_competitions_name_start_date",
                table: "competitions",
                columns: new[] { "name", "start_date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "competitions");
        }
    }
}
