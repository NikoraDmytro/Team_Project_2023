using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguriedJudgeRoleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "judge_roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_judge_roles", x => x.role_id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "judge_roles");
        }
    }
}
