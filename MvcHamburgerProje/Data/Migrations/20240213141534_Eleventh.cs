using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcHamburgerProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class Eleventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Tutar",
                table: "Siparisler",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "Siparisler");
        }
    }
}
