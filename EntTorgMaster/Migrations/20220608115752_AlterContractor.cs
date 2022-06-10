using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class AlterContractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Contractors",
                type: "text",
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Contractors",
                type: "text",
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Contractors",
                type: "text",
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Kpp",
                table: "Contractors",
                type: "text",
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Inn",
                table: "Contractors",
                type: "text",
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Phone",
                keyValue: null,
                column: "Phone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Contractors",
                type: "longtext",
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Note",
                keyValue: null,
                column: "Note",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Contractors",
                type: "longtext",
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Mail",
                keyValue: null,
                column: "Mail",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Contractors",
                type: "longtext",
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Kpp",
                keyValue: null,
                column: "Kpp",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Kpp",
                table: "Contractors",
                type: "longtext",
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Inn",
                keyValue: null,
                column: "Inn",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Inn",
                table: "Contractors",
                type: "longtext",
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");
        }
    }
}
