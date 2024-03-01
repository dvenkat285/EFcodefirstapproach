using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcodefirstapproach.Migrations
{
    public partial class CodeFirstCreatdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dtrs",
                columns: table => new
                {
                    MtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MtrName = table.Column<string>(type: "varchar(100)", nullable: false),
                    PowerStatus = table.Column<string>(type: "varchar(20)", nullable: false),
                    current = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dtrs", x => x.MtId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dtrs");
        }
    }
}
