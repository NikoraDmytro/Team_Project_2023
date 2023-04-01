using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedOneToManyRelationForSportsmanAndCompetitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_competitors_membership_card_num",
                table: "competitors");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_membership_card_num",
                table: "competitors",
                column: "membership_card_num");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_competitors_membership_card_num",
                table: "competitors");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_membership_card_num",
                table: "competitors",
                column: "membership_card_num",
                unique: true);
        }
    }
}
