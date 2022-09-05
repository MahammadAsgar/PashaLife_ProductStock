using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStockApi.Migrations
{
    public partial class productIdMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockProductId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockProductId",
                table: "Stocks");
        }
    }
}
