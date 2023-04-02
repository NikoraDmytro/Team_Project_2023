using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedJudgingStaffEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "judging_staff",
                columns: table => new
                {
                    application_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dayang_id = table.Column<int>(type: "int", nullable: false),
                    membership_card_num = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_judging_staff", x => x.application_num);
                    table.ForeignKey(
                        name: "FK_judging_staff_dayangs_dayang_id",
                        column: x => x.dayang_id,
                        principalTable: "dayangs",
                        principalColumn: "dayang_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_judging_staff_judge_roles_role",
                        column: x => x.role,
                        principalTable: "judge_roles",
                        principalColumn: "role_name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_judging_staff_judges_membership_card_num",
                        column: x => x.membership_card_num,
                        principalTable: "judges",
                        principalColumn: "membership_card_num",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_judging_staff_dayang_id",
                table: "judging_staff",
                column: "dayang_id");

            migrationBuilder.CreateIndex(
                name: "IX_judging_staff_membership_card_num",
                table: "judging_staff",
                column: "membership_card_num");

            migrationBuilder.CreateIndex(
                name: "IX_judging_staff_role",
                table: "judging_staff",
                column: "role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "judging_staff");
        }
    }
}
