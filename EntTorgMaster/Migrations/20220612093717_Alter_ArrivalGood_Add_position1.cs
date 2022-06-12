using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class Alter_ArrivalGood_Add_position1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ArrivalGoods",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "ArrivalGoods");
        }
    }
}
