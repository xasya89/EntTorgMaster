using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class Alter_Specification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorSpecificationsWriteof_Goods_GoodId",
                table: "DoorSpecificationsWriteof");

            migrationBuilder.AlterColumn<int>(
                name: "GoodId",
                table: "DoorSpecificationsWriteof",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorSpecificationsWriteof_Goods_GoodId",
                table: "DoorSpecificationsWriteof",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorSpecificationsWriteof_Goods_GoodId",
                table: "DoorSpecificationsWriteof");

            migrationBuilder.AlterColumn<int>(
                name: "GoodId",
                table: "DoorSpecificationsWriteof",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorSpecificationsWriteof_Goods_GoodId",
                table: "DoorSpecificationsWriteof",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
