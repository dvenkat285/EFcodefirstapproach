using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcodefirstapproach.Migrations
{
    public partial class CodeFirstAddClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "voltage",
                table: "Dtrs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "voltage",
                table: "Dtrs");
        }
    }
}
