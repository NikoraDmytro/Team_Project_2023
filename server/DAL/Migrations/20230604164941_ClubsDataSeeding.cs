using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ClubsDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "rank",
                table: "belts",
                type: "varchar(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 1,
                column: "rank",
                value: "1 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 2,
                column: "rank",
                value: "2 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 3,
                column: "rank",
                value: "3 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 4,
                column: "rank",
                value: "4 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 5,
                column: "rank",
                value: "5 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 6,
                column: "rank",
                value: "6 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 7,
                column: "rank",
                value: "7 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 8,
                column: "rank",
                value: "8 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 9,
                column: "rank",
                value: "9 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 10,
                column: "rank",
                value: "10 куп");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 11,
                column: "rank",
                value: "1 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 12,
                column: "rank",
                value: "2 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 13,
                column: "rank",
                value: "3 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 14,
                column: "rank",
                value: "4 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 15,
                column: "rank",
                value: "5 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 16,
                column: "rank",
                value: "6 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 17,
                column: "rank",
                value: "7 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 18,
                column: "rank",
                value: "8 дан");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 19,
                column: "rank",
                value: "9 дан");

            migrationBuilder.InsertData(
                table: "clubs",
                columns: new[] { "club_id", "address", "city", "name" },
                values: new object[,]
                {
                    { 1, "Дитячий садок, проспект Перемоги, 76А, Харків, Харківська область, 61000", "Харків", "СК \"Білий Ведмідь\"" },
                    { 2, "вулиця Шолохова, 17, Дніпро, Дніпропетровська область, 49000", "Дніпро", "СК \"Кобра-Кван\"" },
                    { 3, "Артилерійський провулок, 7Б, Київ, 03113", "Київ", "КДЮСШ \"ТАЙФУН\"" },
                    { 4, "вулиця Миколи Оводова, 22, Вінниця, Вінницька область, 21000", "Вінниця", "СК \"МАКСИМУМ\"" },
                    { 5, "вулиця Садова, 94, Ірпінь, Київська область, 08200", "Київ", "СК \"Спарта\"" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "clubs",
                keyColumn: "club_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clubs",
                keyColumn: "club_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "clubs",
                keyColumn: "club_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "clubs",
                keyColumn: "club_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "clubs",
                keyColumn: "club_id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "rank",
                table: "belts",
                type: "varchar(4)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Regular", "REGULAR" },
                    { 2, null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 1,
                column: "rank",
                value: "1");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 2,
                column: "rank",
                value: "2");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 3,
                column: "rank",
                value: "3");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 4,
                column: "rank",
                value: "4");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 5,
                column: "rank",
                value: "5");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 6,
                column: "rank",
                value: "6");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 7,
                column: "rank",
                value: "7");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 8,
                column: "rank",
                value: "8");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 9,
                column: "rank",
                value: "9");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 10,
                column: "rank",
                value: "10");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 11,
                column: "rank",
                value: "I");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 12,
                column: "rank",
                value: "II");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 13,
                column: "rank",
                value: "III");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 14,
                column: "rank",
                value: "IV");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 15,
                column: "rank",
                value: "V");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 16,
                column: "rank",
                value: "VI");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 17,
                column: "rank",
                value: "VII");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 18,
                column: "rank",
                value: "VIII");

            migrationBuilder.UpdateData(
                table: "belts",
                keyColumn: "id",
                keyValue: 19,
                column: "rank",
                value: "IX");
        }
    }
}
