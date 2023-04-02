using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedCoachEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coaches",
                columns: table => new
                {
                    membership_card_num = table.Column<int>(type: "int", nullable: false),
                    InstructorCategory = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "char(16)", maxLength: 16, nullable: false),
                    club_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coaches", x => x.membership_card_num);
                    table.ForeignKey(
                        name: "FK_coaches_clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "clubs",
                        principalColumn: "club_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_coaches_sportsmen_membership_card_num",
                        column: x => x.membership_card_num,
                        principalTable: "sportsmen",
                        principalColumn: "membership_card_num",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coaches_club_id",
                table: "coaches",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_coaches_phone",
                table: "coaches",
                column: "phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coaches");
        }
    }
}
