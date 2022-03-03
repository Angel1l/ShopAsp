using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Fauna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    adress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Guns",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    isFavorite = table.Column<bool>(type: "bit", nullable: false),
                    available = table.Column<bool>(type: "bit", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guns", x => x.id);
                    table.ForeignKey(
                        name: "FK_Guns_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    GunsID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Guns_GunsID",
                        column: x => x.GunsID,
                        principalTable: "Guns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_orderID",
                        column: x => x.orderID,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopGunsItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gunsid = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    ShopGunsId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopGunsItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopGunsItem_Guns_gunsid",
                        column: x => x.gunsid,
                        principalTable: "Guns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guns_categoryid",
                table: "Guns",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_GunsID",
                table: "OrderDetail",
                column: "GunsID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_orderID",
                table: "OrderDetail",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopGunsItem_gunsid",
                table: "ShopGunsItem",
                column: "gunsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ShopGunsItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Guns");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
