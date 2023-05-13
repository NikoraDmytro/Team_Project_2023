using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SurrogateKeyForBeltEntityAndDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_competitors_belts_belt_rank",
                table: "competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_competitors_competitions_competition_id",
                table: "competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_divisions_belts_max_rank",
                table: "divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_divisions_belts_min_rank",
                table: "divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_sportsmen_belts_belt_rank",
                table: "sportsmen");

            migrationBuilder.DropIndex(
                name: "IX_sportsmen_belt_rank",
                table: "sportsmen");

            migrationBuilder.DropIndex(
                name: "IX_divisions_max_rank",
                table: "divisions");

            migrationBuilder.DropIndex(
                name: "IX_divisions_min_rank",
                table: "divisions");

            migrationBuilder.DropIndex(
                name: "IX_competitors_belt_rank",
                table: "competitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_belts",
                table: "belts");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "I");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "II");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "III");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "IV");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "IX");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "V");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "VI");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "VII");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "rank",
                keyValue: "VIII");

            migrationBuilder.DropColumn(
                name: "belt_rank",
                table: "sportsmen");

            migrationBuilder.DropColumn(
                name: "max_rank",
                table: "divisions");

            migrationBuilder.DropColumn(
                name: "min_rank",
                table: "divisions");

            migrationBuilder.DropColumn(
                name: "belt_rank",
                table: "competitors");

            migrationBuilder.AddColumn<int>(
                name: "belt_id",
                table: "sportsmen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "max_belt_id",
                table: "divisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "min_belt_id",
                table: "divisions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "belt_id",
                table: "competitors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "belts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_belts",
                table: "belts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_sportsmen_belt_id",
                table: "sportsmen",
                column: "belt_id");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_max_belt_id",
                table: "divisions",
                column: "max_belt_id");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_min_belt_id",
                table: "divisions",
                column: "min_belt_id");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_belt_id",
                table: "competitors",
                column: "belt_id");

            migrationBuilder.CreateIndex(
                name: "IX_belts_rank",
                table: "belts",
                column: "rank",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_competitors_belts_belt_id",
                table: "competitors",
                column: "belt_id",
                principalTable: "belts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_competitors_competitions_competition_id",
                table: "competitors",
                column: "competition_id",
                principalTable: "competitions",
                principalColumn: "competition_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_belts_max_belt_id",
                table: "divisions",
                column: "max_belt_id",
                principalTable: "belts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_belts_min_belt_id",
                table: "divisions",
                column: "min_belt_id",
                principalTable: "belts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sportsmen_belts_belt_id",
                table: "sportsmen",
                column: "belt_id",
                principalTable: "belts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_competitors_belts_belt_id",
                table: "competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_competitors_competitions_competition_id",
                table: "competitors");

            migrationBuilder.DropForeignKey(
                name: "FK_divisions_belts_max_belt_id",
                table: "divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_divisions_belts_min_belt_id",
                table: "divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_sportsmen_belts_belt_id",
                table: "sportsmen");

            migrationBuilder.DropIndex(
                name: "IX_sportsmen_belt_id",
                table: "sportsmen");

            migrationBuilder.DropIndex(
                name: "IX_divisions_max_belt_id",
                table: "divisions");

            migrationBuilder.DropIndex(
                name: "IX_divisions_min_belt_id",
                table: "divisions");

            migrationBuilder.DropIndex(
                name: "IX_competitors_belt_id",
                table: "competitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_belts",
                table: "belts");

            migrationBuilder.DropIndex(
                name: "IX_belts_rank",
                table: "belts");

            migrationBuilder.DropColumn(
                name: "belt_id",
                table: "sportsmen");

            migrationBuilder.DropColumn(
                name: "max_belt_id",
                table: "divisions");

            migrationBuilder.DropColumn(
                name: "min_belt_id",
                table: "divisions");

            migrationBuilder.DropColumn(
                name: "belt_id",
                table: "competitors");

            migrationBuilder.DropColumn(
                name: "id",
                table: "belts");

            migrationBuilder.AddColumn<string>(
                name: "belt_rank",
                table: "sportsmen",
                type: "varchar(4)",
                maxLength: 4,
                nullable: true,
                defaultValue: "10");

            migrationBuilder.AddColumn<string>(
                name: "max_rank",
                table: "divisions",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "min_rank",
                table: "divisions",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "belt_rank",
                table: "competitors",
                type: "varchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_belts",
                table: "belts",
                column: "rank");

            migrationBuilder.InsertData(
                table: "belts",
                column: "rank",
                values: new object[]
                {
                    "1",
                    "10",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "I",
                    "II",
                    "III",
                    "IV",
                    "IX",
                    "V",
                    "VI",
                    "VII",
                    "VIII"
                });

            migrationBuilder.CreateIndex(
                name: "IX_sportsmen_belt_rank",
                table: "sportsmen",
                column: "belt_rank");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_max_rank",
                table: "divisions",
                column: "max_rank");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_min_rank",
                table: "divisions",
                column: "min_rank");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_belt_rank",
                table: "competitors",
                column: "belt_rank");

            migrationBuilder.AddForeignKey(
                name: "FK_competitors_belts_belt_rank",
                table: "competitors",
                column: "belt_rank",
                principalTable: "belts",
                principalColumn: "rank",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_competitors_competitions_competition_id",
                table: "competitors",
                column: "competition_id",
                principalTable: "competitions",
                principalColumn: "competition_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_belts_max_rank",
                table: "divisions",
                column: "max_rank",
                principalTable: "belts",
                principalColumn: "rank",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_belts_min_rank",
                table: "divisions",
                column: "min_rank",
                principalTable: "belts",
                principalColumn: "rank",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sportsmen_belts_belt_rank",
                table: "sportsmen",
                column: "belt_rank",
                principalTable: "belts",
                principalColumn: "rank");
        }
    }
}
