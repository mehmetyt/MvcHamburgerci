using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcHamburgerProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class eight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: "default.jpg");

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: "default.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: null);

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: null);
        }
    }
}
