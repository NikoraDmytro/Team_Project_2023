using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedSportsmanEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "belts",
                columns: table => new
                {
                    rank = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_belts", x => x.rank);
                });

            migrationBuilder.CreateTable(
                name: "sportsmen",
                columns: table => new
                {
                    membership_card_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sports_category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sex = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    belt_rank = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true, defaultValue: "10")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sportsmen", x => x.membership_card_num);
                    table.CheckConstraint("CHK_sportsmen_user_id", "sex IN ('M', 'F')");
                    table.ForeignKey(
                        name: "FK_sportsmen_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sportsmen_belts_belt_rank",
                        column: x => x.belt_rank,
                        principalTable: "belts",
                        principalColumn: "rank");
                });

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
                name: "IX_sportsmen_user_id",
                table: "sportsmen",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sportsmen");

            migrationBuilder.DropTable(
                name: "belts");
        }
    }
}
