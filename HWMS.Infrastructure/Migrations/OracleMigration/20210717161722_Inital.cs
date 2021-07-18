using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HWMS.Infrastructure.Migrations.OracleMigration
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavigationMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    ParentMenuId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ControllerName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ActionName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Visible = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationMenus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavigationMenus");
        }
    }
}
