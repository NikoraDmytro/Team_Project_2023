using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SurrogateKeyForJudgeRoleEntityAndDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_judging_staff_judge_roles_role",
                table: "judging_staff");

            migrationBuilder.DropIndex(
                name: "IX_judging_staff_role",
                table: "judging_staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_judge_roles",
                table: "judge_roles");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyColumnType: "varchar(50)",
                keyValue: "chief_judge");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyColumnType: "varchar(50)",
                keyValue: "deputy_chief_judge");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyColumnType: "varchar(50)",
                keyValue: "referee");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyColumnType: "varchar(50)",
                keyValue: "reserve_judge");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyColumnType: "varchar(50)",
                keyValue: "side_judge");

            migrationBuilder.DropColumn(
                name: "role",
                table: "judging_staff");


            migrationBuilder.AddColumn<int>(
                name: "judge_role_id",
                table: "judging_staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "judge_roles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "judge_roles",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");
            
            migrationBuilder.DropColumn(
                name: "role_name",
                table: "judge_roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_judge_roles",
                table: "judge_roles",
                column: "id");

            migrationBuilder.InsertData(
                table: "belts",
                columns: new[] { "id", "rank" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "4" },
                    { 5, "5" },
                    { 6, "6" },
                    { 7, "7" },
                    { 8, "8" },
                    { 9, "9" },
                    { 10, "10" },
                    { 11, "I" },
                    { 12, "II" },
                    { 13, "III" },
                    { 14, "IV" },
                    { 15, "V" },
                    { 16, "VI" },
                    { 17, "VII" },
                    { 18, "VIII" },
                    { 19, "IX" }
                });

            migrationBuilder.InsertData(
                table: "judge_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "боковий суддя" },
                    { 2, "рефері" },
                    { 3, "головний суддя" },
                    { 4, "помічник головного судді" },
                    { 5, "запасний суддя" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_judging_staff_judge_role_id",
                table: "judging_staff",
                column: "judge_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_judge_roles_name",
                table: "judge_roles",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_judging_staff_judge_roles_judge_role_id",
                table: "judging_staff",
                column: "judge_role_id",
                principalTable: "judge_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_judging_staff_judge_roles_judge_role_id",
                table: "judging_staff");

            migrationBuilder.DropIndex(
                name: "IX_judging_staff_judge_role_id",
                table: "judging_staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_judge_roles",
                table: "judge_roles");

            migrationBuilder.DropIndex(
                name: "IX_judge_roles_name",
                table: "judge_roles");

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "belts",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "judge_role_id",
                table: "judging_staff");

            migrationBuilder.DropColumn(
                name: "id",
                table: "judge_roles");

            migrationBuilder.DropColumn(
                name: "name",
                table: "judge_roles");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "judging_staff",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "role_name",
                table: "judge_roles",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_judge_roles",
                table: "judge_roles",
                column: "role_name");

            migrationBuilder.InsertData(
                table: "judge_roles",
                column: "role_name",
                values: new object[]
                {
                    "chief_judge",
                    "deputy_chief_judge",
                    "referee",
                    "reserve_judge",
                    "side_judge"
                });

            migrationBuilder.CreateIndex(
                name: "IX_judging_staff_role",
                table: "judging_staff",
                column: "role");

            migrationBuilder.AddForeignKey(
                name: "FK_judging_staff_judge_roles_role",
                table: "judging_staff",
                column: "role",
                principalTable: "judge_roles",
                principalColumn: "role_name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
