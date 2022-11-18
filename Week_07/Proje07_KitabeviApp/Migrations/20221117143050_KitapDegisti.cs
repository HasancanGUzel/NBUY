using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitabeviApp.Migrations
{
    public partial class KitapDegisti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anasayfa",
                table: "Kitaplar",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Ozet",
                table: "Kitaplar",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Anasayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!" });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Anasayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!" });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Anasayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!" });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Anasayfa", "Ozet" },
                values: new object[] { true, "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!" });

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 5,
                column: "Ozet",
                value: "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 6,
                column: "Ozet",
                value: "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 7,
                column: "Ozet",
                value: "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 8,
                column: "Ozet",
                value: "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!");

            migrationBuilder.UpdateData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 9,
                column: "Ozet",
                value: "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Optio quo iusto fugit saepe enim eum dolor ducimus a harum assumenda, praesentium neque odit numquam quia molestias dolorum quaerat, eaque ab!");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anasayfa",
                table: "Kitaplar");

            migrationBuilder.DropColumn(
                name: "Ozet",
                table: "Kitaplar");
        }
    }
}
