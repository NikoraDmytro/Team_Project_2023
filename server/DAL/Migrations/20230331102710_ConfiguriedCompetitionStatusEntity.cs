using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedCompetitionStatusEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_judges_sportsmen_membership_card_num",
                table: "judges");

            migrationBuilder.CreateTable(
                name: "competition_statuses",
                columns: table => new
                {
                    status_name = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_statuses", x => x.status_name);
                });

            migrationBuilder.InsertData(
                table: "competition_statuses",
                column: "status_name",
                values: new object[]
                {
                    "accepting_applications",
                    "accepting_applications_closed",
                    "canceled",
                    "finished",
                    "pending",
                    "started"
                });

            migrationBuilder.AddForeignKey(
                name: "FK_judges_sportsmen_membership_card_num",
                table: "judges",
                column: "membership_card_num",
                principalTable: "sportsmen",
                principalColumn: "membership_card_num",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_judges_sportsmen_membership_card_num",
                table: "judges");

            migrationBuilder.DropTable(
                name: "competition_statuses");

            migrationBuilder.AddForeignKey(
                name: "FK_judges_sportsmen_membership_card_num",
                table: "judges",
                column: "membership_card_num",
                principalTable: "sportsmen",
                principalColumn: "membership_card_num",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
