using Microsoft.EntityFrameworkCore.Migrations;

namespace Helthy_Shop.Migrations
{
    public partial class Cartdelamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShopCartItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
