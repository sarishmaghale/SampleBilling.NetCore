using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBilling.Migrations
{
    public partial class AddColumnToSaleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "ImportedStock",
                table: "Sale",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportedStock",
                table: "Sale");

            migrationBuilder.AddColumn<int>(
                name: "LeftStock",
                table: "Brand",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
