using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class Add_order_orderdoors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreate = table.Column<DateOnly>(type: "date", nullable: false),
                    Shet = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    ShetDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomerName = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    CustomerPhone = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                })
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "OrderDoors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    DoorTypeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: true),
                    H = table.Column<int>(type: "int", nullable: false),
                    W = table.Column<int>(type: "int", nullable: false),
                    S = table.Column<int>(type: "int", nullable: true),
                    SEqual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Open = table.Column<int>(type: "int", nullable: false),
                    Ral = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    Nalichnik = table.Column<int>(type: "int", nullable: false),
                    Dovod = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    Marking = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    Shild = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    NavesCount = table.Column<int>(type: "int", nullable: true),
                    NavesStvorkaCount = table.Column<int>(type: "int", nullable: true),
                    WindowCount = table.Column<int>(type: "int", nullable: true),
                    WindowStvorkaCount = table.Column<int>(type: "int", nullable: true),
                    Framuga = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FramugaH = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDoors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDoors_DoorTypes_DoorTypeId",
                        column: x => x.DoorTypeId,
                        principalTable: "DoorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDoors_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDoors_DoorTypeId",
                table: "OrderDoors",
                column: "DoorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDoors_OrderId",
                table: "OrderDoors",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDoors");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
