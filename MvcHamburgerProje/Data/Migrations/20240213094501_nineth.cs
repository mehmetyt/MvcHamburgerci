using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcHamburgerProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class nineth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuSiparis");

            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "Menuler",
                newName: "KucukFiyat");

            migrationBuilder.AddColumn<int>(
                name: "Adet",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyukFiyat",
                table: "Menuler",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OrtaFiyat",
                table: "Menuler",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BuyukFiyat", "OrtaFiyat" },
                values: new object[] { 185m, 185m });

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BuyukFiyat", "KucukFiyat", "OrtaFiyat" },
                values: new object[] { 185m, 185m, 185m });

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MenuId",
                table: "Siparisler",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Menuler_MenuId",
                table: "Siparisler",
                column: "MenuId",
                principalTable: "Menuler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Menuler_MenuId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_MenuId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "Adet",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "BuyukFiyat",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "OrtaFiyat",
                table: "Menuler");

            migrationBuilder.RenameColumn(
                name: "KucukFiyat",
                table: "Menuler",
                newName: "Fiyat");

            migrationBuilder.CreateTable(
                name: "MenuSiparis",
                columns: table => new
                {
                    MenulerId = table.Column<int>(type: "int", nullable: false),
                    SiparislerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSiparis", x => new { x.MenulerId, x.SiparislerId });
                    table.ForeignKey(
                        name: "FK_MenuSiparis_Menuler_MenulerId",
                        column: x => x.MenulerId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSiparis_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Menuler",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fiyat",
                value: 190m);

            migrationBuilder.CreateIndex(
                name: "IX_MenuSiparis_SiparislerId",
                table: "MenuSiparis",
                column: "SiparislerId");
        }
    }
}
