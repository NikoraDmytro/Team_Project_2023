using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MadeRelationBetweenCoachAndSportsmenNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sportsmen_coaches_coach_membership_card_num",
                table: "sportsmen");

            migrationBuilder.AlterColumn<int>(
                name: "coach_membership_card_num",
                table: "sportsmen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_sportsmen_coaches_coach_membership_card_num",
                table: "sportsmen",
                column: "coach_membership_card_num",
                principalTable: "coaches",
                principalColumn: "membership_card_num");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sportsmen_coaches_coach_membership_card_num",
                table: "sportsmen");

            migrationBuilder.AlterColumn<int>(
                name: "coach_membership_card_num",
                table: "sportsmen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_sportsmen_coaches_coach_membership_card_num",
                table: "sportsmen",
                column: "coach_membership_card_num",
                principalTable: "coaches",
                principalColumn: "membership_card_num",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
