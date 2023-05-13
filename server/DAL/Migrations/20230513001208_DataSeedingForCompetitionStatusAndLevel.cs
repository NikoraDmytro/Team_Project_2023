using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingForCompetitionStatusAndLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "competition_levels",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Чемпіонат області" },
                    { 2, "Кубок області" },
                    { 3, "Чемпіонат України" },
                    { 4, "Кубок України" },
                    { 5, "Інші всеукраїнські турніри" },
                    { 6, "Інші турніри" }
                });

            migrationBuilder.InsertData(
                table: "competition_statuses",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Очікується" },
                    { 2, "Прийом заявок" },
                    { 3, "Прийом заявок закінченно" },
                    { 4, "Проходить" },
                    { 5, "Завершено" },
                    { 6, "Скасовано" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "competition_levels",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "competition_levels",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "competition_levels",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "competition_levels",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "competition_levels",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "competition_levels",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "competition_statuses",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
