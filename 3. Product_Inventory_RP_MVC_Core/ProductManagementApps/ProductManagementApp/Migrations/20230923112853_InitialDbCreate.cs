using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    SellUnit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventories",
                columns: table => new
                {
                    ProductInventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventories", x => x.ProductInventoryId);
                    table.ForeignKey(
                        name: "FK_ProductInventories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "CompanyName" },
                values: new object[,]
                {
                    { 1, "Addres 1", "Company 1" },
                    { 2, "Addres 2", "Company 2" },
                    { 3, "Addres 3", "Company 3" },
                    { 4, "Addres 4", "Company 4" },
                    { 5, "Addres 5", "Company 5" },
                    { 6, "Addres 6", "Company 6" },
                    { 7, "Addres 7", "Company 7" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Picture", "SellUnit", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "P01", "1.jpg", 1, 950.00m },
                    { 2, "P02", "2.jpg", 1, 1900.00m },
                    { 3, "P03", "3.jpg", 1, 2850.00m },
                    { 4, "P04", "4.jpg", 1, 3800.00m },
                    { 5, "P05", "5.jpg", 1, 4750.00m },
                    { 6, "P06", "6.jpg", 1, 5700.00m },
                    { 7, "P07", "7.jpg", 1, 6650.00m }
                });

            migrationBuilder.InsertData(
                table: "ProductInventories",
                columns: new[] { "ProductInventoryId", "CompanyId", "Date", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 31, 17, 28, 53, 195, DateTimeKind.Local).AddTicks(6898), 1, 50 },
                    { 2, 2, new DateTime(2023, 8, 8, 17, 28, 53, 195, DateTimeKind.Local).AddTicks(6935), 2, 100 },
                    { 3, 3, new DateTime(2023, 7, 16, 17, 28, 53, 195, DateTimeKind.Local).AddTicks(6944), 3, 150 },
                    { 4, 4, new DateTime(2023, 6, 23, 17, 28, 53, 195, DateTimeKind.Local).AddTicks(6951), 4, 200 },
                    { 5, 5, new DateTime(2023, 5, 31, 17, 28, 53, 195, DateTimeKind.Local).AddTicks(6958), 5, 250 },
                    { 6, 6, new DateTime(2023, 5, 8, 17, 28, 53, 195, DateTimeKind.Local).AddTicks(6967), 6, 300 },
                    { 7, 7, new DateTime(2023, 4, 15, 17, 28, 53, 195, DateTimeKind.Local).AddTicks(6975), 7, 350 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_CompanyId",
                table: "ProductInventories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_ProductId",
                table: "ProductInventories",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInventories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
