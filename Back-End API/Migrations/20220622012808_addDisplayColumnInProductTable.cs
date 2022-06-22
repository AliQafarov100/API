using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_End_API.Migrations
{
    public partial class addDisplayColumnInProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisplayStatus",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayStatus",
                table: "Products");
        }
    }
}
