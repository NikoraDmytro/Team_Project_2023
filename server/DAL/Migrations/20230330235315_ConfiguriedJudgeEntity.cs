using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedJudgeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "judges",
                columns: table => new
                {
                    membership_card_num = table.Column<int>(type: "int", nullable: false),
                    judge_category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_judges", x => x.membership_card_num);
                    table.ForeignKey(
                        name: "FK_judges_sportsmen_membership_card_num",
                        column: x => x.membership_card_num,
                        principalTable: "sportsmen",
                        principalColumn: "membership_card_num",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "judges");
        }
    }
}
