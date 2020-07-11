using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTest.Context.Migrations
{
    public partial class updatePriceRangeFieldType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PriceRange",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceRange",
                table: "Categories",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
