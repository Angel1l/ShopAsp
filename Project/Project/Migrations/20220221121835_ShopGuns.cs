using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class ShopGuns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_ShopGunsItem_gunsid",
                table: "ShopGunsItem",
                column: "gunsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopGunsItem");
        }
    }
}
