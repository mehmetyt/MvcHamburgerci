using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcHamburgerProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menuler",
                columns: new[] { "Id", "Aciklama", "Ad", "Fiyat", "Resim" },
                values: new object[,]
                {
                    { 1, "big king aciklama", "Big King", 185m, "bigking.jpg" },
                    { 2, "double chicken aciklama", "Double Chicken", 190m, "dchicken.jpg" }
                });

            migrationBuilder.InsertData(
                table: "YanUrunler",
                columns: new[] { "Id", "Aciklama", "Ad", "Fiyat", "Resim" },
                values: new object[,]
                {
                    { 1, "patates aciklama", "Patates", 185m, "Patates.jpg" },
                    { 2, "kola aciklama", "kola", 190m, "kola.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
