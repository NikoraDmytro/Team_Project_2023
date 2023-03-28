using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedClubsEntityConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "clubs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clubs",
                table: "clubs",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_clubs_name",
                table: "clubs",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_clubs",
                table: "clubs");

            migrationBuilder.DropIndex(
                name: "IX_clubs_name",
                table: "clubs");

            migrationBuilder.RenameTable(
                name: "clubs",
                newName: "Clubs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "club_id");
        }
    }
}
