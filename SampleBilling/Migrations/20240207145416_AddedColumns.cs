using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBilling.Migrations
{
    public partial class AddedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__BillingDe__BillI__73BA3083",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__BillingDe__Brand__75A278F5",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__BillingDe__Categ__74AE54BC",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__Sales__ProductId__6C190EBB",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "Sale");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sale",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_ProductId",
                table: "Sale",
                newName: "IX_Sale_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "LeftStock",
                table: "Brand",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalStocks",
                table: "Brand",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BillingDate",
                table: "Billings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "BillingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BillingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "BillingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "BillingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__BillingDe__BillI__47DBAE45",
                table: "BillingDetails",
                column: "BillId",
                principalTable: "Billings",
                principalColumn: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK__BillingDe__Brand__49C3F6B7",
                table: "BillingDetails",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK__BillingDe__Categ__48CFD27E",
                table: "BillingDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK__Sale__ProductId__693CA210",
                table: "Sale",
                column: "ProductId",
                principalTable: "Brand",
                principalColumn: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__BillingDe__BillI__47DBAE45",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__BillingDe__Brand__49C3F6B7",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__BillingDe__Categ__48CFD27E",
                table: "BillingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__Sale__ProductId__693CA210",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "LeftStock",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "TotalStocks",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "BillingDate",
                table: "Billings");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sales");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sales",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_ProductId",
                table: "Sales",
                newName: "IX_Sales_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "BillingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BillingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "BillingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "BillingDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__BillingDe__BillI__73BA3083",
                table: "BillingDetails",
                column: "BillId",
                principalTable: "Billings",
                principalColumn: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK__BillingDe__Brand__75A278F5",
                table: "BillingDetails",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK__BillingDe__Categ__74AE54BC",
                table: "BillingDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK__Sales__ProductId__6C190EBB",
                table: "Sales",
                column: "ProductId",
                principalTable: "Brand",
                principalColumn: "BrandId");
        }
    }
}
