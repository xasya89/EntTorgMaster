using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class Add_Specification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoorSpecificationsWriteof",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderDoorId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    GoodType = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<decimal>(type: "decimal(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorSpecificationsWriteof", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoorSpecificationsWriteof_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoorSpecificationsWriteof_OrderDoors_OrderDoorId",
                        column: x => x.OrderDoorId,
                        principalTable: "OrderDoors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "IX_DoorSpecificationsWriteof_GoodId",
                table: "DoorSpecificationsWriteof",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorSpecificationsWriteof_OrderDoorId",
                table: "DoorSpecificationsWriteof",
                column: "OrderDoorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoorSpecificationsWriteof");
        }
    }
}
