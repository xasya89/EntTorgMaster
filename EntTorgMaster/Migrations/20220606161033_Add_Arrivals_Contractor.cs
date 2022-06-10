using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class Add_Arrivals_Contractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrgName = table.Column<string>(type: "text", nullable: false, collation: "utf8_unicode_ci"),
                    Inn = table.Column<string>(type: "text", nullable: false, collation: "utf8_unicode_ci"),
                    Kpp = table.Column<string>(type: "text", nullable: false, collation: "utf8_unicode_ci"),
                    Phone = table.Column<string>(type: "text", nullable: false, collation: "utf8_unicode_ci"),
                    Mail = table.Column<string>(type: "text", nullable: false, collation: "utf8_unicode_ci"),
                    Note = table.Column<string>(type: "text", nullable: false, collation: "utf8_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                })
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "Arrivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Num = table.Column<string>(type: "text", nullable: false, collation: "utf8_unicode_ci"),
                    DateArrival = table.Column<DateOnly>(type: "date", nullable: false),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    SumAll = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrivals_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "ArrivalGoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArrivalId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivalGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrivalGoods_Arrivals_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "Arrivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArrivalGoods_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalGoods_ArrivalId",
                table: "ArrivalGoods",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalGoods_GoodId",
                table: "ArrivalGoods",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrivals_ContractorId",
                table: "Arrivals",
                column: "ContractorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArrivalGoods");

            migrationBuilder.DropTable(
                name: "Arrivals");

            migrationBuilder.DropTable(
                name: "Contractors");
        }
    }
}
