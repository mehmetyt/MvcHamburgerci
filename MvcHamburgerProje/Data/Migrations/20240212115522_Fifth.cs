using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcHamburgerProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resim",
                table: "Menuler");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "Menuler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: "bigking.jpg");

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: "dchicken.jpg");

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 1,
                column: "Resim",
                value: "Patates.jpg");

            migrationBuilder.UpdateData(
                table: "YanUrunler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: "kola.jpg");
        }
    }
}
