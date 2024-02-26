using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcHamburgerProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class siparis2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "YanUrunler");

            migrationBuilder.DropColumn(
                name: "Resim",
                table: "YanUrunler");

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BuyukFiyat", "OrtaFiyat", "Resim" },
                values: new object[] { 195m, 190m, "1.jpg" });

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BuyukFiyat", "KucukFiyat", "Resim" },
                values: new object[] { 190m, 180m, "2.jpg" });

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ad",
                value: "Mayonez");

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Ketçap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "YanUrunler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "YanUrunler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BuyukFiyat", "OrtaFiyat", "Resim" },
                values: new object[] { 185m, 185m, "default.jpg" });

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BuyukFiyat", "KucukFiyat", "Resim" },
                values: new object[] { 185m, 185m, "default.jpg" });

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Ad", "Resim" },
                values: new object[] { "patates aciklama", "Patates", "default.jpg" });

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Ad", "Resim" },
                values: new object[] { "kola aciklama", "kola", "default.jpg" });
        }
    }
}
