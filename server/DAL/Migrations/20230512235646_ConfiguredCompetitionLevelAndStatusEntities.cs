using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredCompetitionLevelAndStatusEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_competitions_competition_statuses_current_status",
                table: "competitions");

            migrationBuilder.DropIndex(
                name: "IX_competitions_current_status",
                table: "competitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_competition_statuses",
                table: "competition_statuses");

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "status_name",
                keyColumnType: "char(30)",
                keyValue: "accepting_applications");

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "status_name",
                keyColumnType: "char(30)",
                keyValue: "accepting_applications_closed");

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "status_name",
                keyColumnType: "char(30)",
                keyValue: "canceled");

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "status_name",
                keyColumnType: "char(30)",
                keyValue: "finished");

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "status_name",
                keyColumnType: "char(30)",
                keyValue: "pending");

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "status_name",
                keyColumnType: "char(30)",
                keyValue: "started");

            migrationBuilder.DropColumn(
                name: "competition_level",
                table: "competitions");

            migrationBuilder.DropColumn(
                name: "current_status",
                table: "competitions");


            migrationBuilder.AddColumn<int>(
                name: "competition_level_id",
                table: "competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "competition_status_id",
                table: "competitions",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "competition_statuses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(
                name: "status_name",
                table: "competition_statuses");
            
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "competition_statuses",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_competition_statuses",
                table: "competition_statuses",
                column: "id");

            migrationBuilder.CreateTable(
                name: "competition_levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_levels", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitions_competition_level_id",
                table: "competitions",
                column: "competition_level_id");

            migrationBuilder.CreateIndex(
                name: "IX_competitions_competition_status_id",
                table: "competitions",
                column: "competition_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_statuses_name",
                table: "competition_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_competition_levels_name",
                table: "competition_levels",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_competitions_competition_levels_competition_level_id",
                table: "competitions",
                column: "competition_level_id",
                principalTable: "competition_levels",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_competitions_competition_statuses_competition_status_id",
                table: "competitions",
                column: "competition_status_id",
                principalTable: "competition_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_competitions_competition_levels_competition_level_id",
                table: "competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_competitions_competition_statuses_competition_status_id",
                table: "competitions");

            migrationBuilder.DropTable(
                name: "competition_levels");

            migrationBuilder.DropIndex(
                name: "IX_competitions_competition_level_id",
                table: "competitions");

            migrationBuilder.DropIndex(
                name: "IX_competitions_competition_status_id",
                table: "competitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_competition_statuses",
                table: "competition_statuses");

            migrationBuilder.DropIndex(
                name: "IX_competition_statuses_name",
                table: "competition_statuses");

            migrationBuilder.DropColumn(
                name: "competition_level_id",
                table: "competitions");

            migrationBuilder.DropColumn(
                name: "competition_status_id",
                table: "competitions");

            migrationBuilder.DropColumn(
                name: "id",
                table: "competition_statuses");

            migrationBuilder.DropColumn(
                name: "name",
                table: "competition_statuses");

            migrationBuilder.AddColumn<string>(
                name: "competition_level",
                table: "competitions",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "current_status",
                table: "competitions",
                type: "char(30)",
                nullable: true,
                defaultValue: "pending");

            migrationBuilder.AddColumn<string>(
                name: "status_name",
                table: "competition_statuses",
                type: "char(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_competition_statuses",
                table: "competition_statuses",
                column: "status_name");

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

            migrationBuilder.CreateIndex(
                name: "IX_competitions_current_status",
                table: "competitions",
                column: "current_status");

            migrationBuilder.AddForeignKey(
                name: "FK_competitions_competition_statuses_current_status",
                table: "competitions",
                column: "current_status",
                principalTable: "competition_statuses",
                principalColumn: "status_name");
        }
    }
}
