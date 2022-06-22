using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_End_API.Migrations
{
    public partial class addSoldAndCostPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "SoldPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "Products",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SoldPrice",
                table: "Products",
                newName: "Price");
        }
    }
}
