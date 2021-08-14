using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KazanExpress.Parser.Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductAmount = table.Column<long>(type: "bigint", nullable: false),
                    Adult = table.Column<bool>(type: "boolean", nullable: false),
                    Eco = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ProductIds = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    SellPrice = table.Column<long>(type: "bigint", nullable: false),
                    FullPrice = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    OrdersQuantity = table.Column<long>(type: "bigint", nullable: false),
                    ROrdersQuantity = table.Column<long>(type: "bigint", nullable: false),
                    CharityCommission = table.Column<long>(type: "bigint", nullable: false),
                    IsEco = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductAmount",
                table: "Categories",
                column: "ProductAmount");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductIds",
                table: "Categories",
                column: "ProductIds");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Title",
                table: "Categories",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CharityCommission",
                table: "Products",
                column: "CharityCommission");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FullPrice",
                table: "Products",
                column: "FullPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrdersQuantity",
                table: "Products",
                column: "OrdersQuantity");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Rating",
                table: "Products",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ROrdersQuantity",
                table: "Products",
                column: "ROrdersQuantity");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellPrice",
                table: "Products",
                column: "SellPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Title",
                table: "Products",
                column: "Title");
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
