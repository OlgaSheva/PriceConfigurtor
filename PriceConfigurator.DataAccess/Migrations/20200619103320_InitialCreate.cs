using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceConfigurator.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsUpdated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Mark = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Provider = table.Column<string>(nullable: true),
                    PriceWithoutVAT_EUR = table.Column<decimal>(nullable: true),
                    PriceWithoutVAT_BYN = table.Column<decimal>(nullable: true),
                    IsPriceAutoUpdate = table.Column<bool>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    XPath = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    PriceLastUpdate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsUpdated = table.Column<bool>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
