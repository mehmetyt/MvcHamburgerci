using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcHamburgerProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: null);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Resim",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resim",
                table: "Menuler");
        }
    }
}
