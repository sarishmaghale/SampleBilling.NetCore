using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBilling.Migrations
{
    public partial class UpdatedSalesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
;
            migrationBuilder.DropColumn(
               name: "BrandId",
               table: "Sale");
            migrationBuilder.AddColumn<int>(
                name: "LeftStocks",
                table: "Sale",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedDate",
                table: "Sale",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BrandId",
                table: "Sale",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Brand_BrandId",
                table: "Sale",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Brand_BrandId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_BrandId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "LeftStocks",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Sale");

            

        }
    }
}
