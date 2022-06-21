using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class Alter_History_Add_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Histories",
                type: "json",
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "json")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Histories");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Histories",
                type: "jsonb",
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "json")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");
        }
    }
}
