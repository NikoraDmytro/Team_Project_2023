using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationBetweenCoachAndSportsmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "coach_membership_card_num",
                table: "sportsmen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_sportsmen_coach_membership_card_num",
                table: "sportsmen",
                column: "coach_membership_card_num");

            migrationBuilder.AddForeignKey(
                name: "FK_sportsmen_coaches_coach_membership_card_num",
                table: "sportsmen",
                column: "coach_membership_card_num",
                principalTable: "coaches",
                principalColumn: "membership_card_num",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sportsmen_coaches_coach_membership_card_num",
                table: "sportsmen");

            migrationBuilder.DropIndex(
                name: "IX_sportsmen_coach_membership_card_num",
                table: "sportsmen");

            migrationBuilder.DropColumn(
                name: "coach_membership_card_num",
                table: "sportsmen");
        }
    }
}
