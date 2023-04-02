using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIdFromJudgeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_judge_roles",
                table: "judge_roles");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "judge_roles");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_judge_roles",
                table: "judge_roles");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyValue: "chief_judge");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyValue: "deputy_chief_judge");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyValue: "referee");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyValue: "reserve_judge");

            migrationBuilder.DeleteData(
                table: "judge_roles",
                keyColumn: "role_name",
                keyValue: "side_judge");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "judge_roles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_judge_roles",
                table: "judge_roles",
                column: "role_id");

            migrationBuilder.InsertData(
                table: "judge_roles",
                columns: new[] { "role_id", "role_name" },
                values: new object[,]
                {
                    { 1, "side_judge" },
                    { 2, "referee" },
                    { 3, "chief_judge" },
                    { 4, "deputy_chief_judge" },
                    { 5, "reserve_judge" }
                });
        }
    }
}
