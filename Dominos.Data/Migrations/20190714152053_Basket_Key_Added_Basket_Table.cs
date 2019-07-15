using Microsoft.EntityFrameworkCore.Migrations;

namespace Dominos.Data.Migrations
{
    public partial class Basket_Key_Added_Basket_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Baskets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "BasketKey",
                table: "Baskets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasketKey",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Baskets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
