using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBilling.Migrations
{
    public partial class AddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "Sale");



            migrationBuilder.CreateTable(
                name: "SalesAndStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    TotalSales = table.Column<int>(type: "int", nullable: true),
                    LeftStocks = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportedStock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesAndStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesAndStocks_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesAndStocks_BrandId",
                table: "SalesAndStocks",
                column: "BrandId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Sale__ProductId__693CA210",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Brand_BrandId",
                table: "Sale");

            migrationBuilder.DropTable(
                name: "SalesAndStocks");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Sale",
                newName: "BrandId1");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_ProductId",
                table: "Sale",
                newName: "IX_Sale_BrandId1");

            migrationBuilder.AddForeignKey(
                name: "FK__Sale__ProductId__693CA210",
                table: "Sale",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Brand_BrandId1",
                table: "Sale",
                column: "BrandId1",
                principalTable: "Brand",
                principalColumn: "BrandId");
        }
    }
}
