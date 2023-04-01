using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSportsmanCheckConstraintName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_sportsmen_user_id",
                table: "sportsmen");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_sportsmen_sex",
                table: "sportsmen",
                sql: "sex IN ('M', 'F')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_sportsmen_sex",
                table: "sportsmen");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_sportsmen_user_id",
                table: "sportsmen",
                sql: "sex IN ('M', 'F')");
        }
    }
}
