using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

#nullable disable

namespace EntTorgMaster.Migrations
{
    public partial class add_doorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.CreateTable(
                name: "DoorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci"),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorTypes", x => x.Id);
                })
                .Annotation("Relational:Collation", "utf8_unicode_ci");
            string typedoorstr="";
            using (StreamReader sr = new StreamReader("ImpoerTypeDoorFromDB.txt"))
                while ((typedoorstr = sr.ReadLine()) != null)
                    migrationBuilder.Sql($"INSERT INTO DoorTypes (Name) VALUES ('{typedoorstr}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoorTypes");
        }
    }
}
