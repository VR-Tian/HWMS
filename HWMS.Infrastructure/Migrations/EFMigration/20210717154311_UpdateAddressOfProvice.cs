using Microsoft.EntityFrameworkCore.Migrations;

namespace HWMS.Infrastructure.Migrations.EFMigration
{
    public partial class UpdateAddressOfProvice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Province1",
                table: "Orders",
                newName: "Province");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Orders",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Orders",
                newName: "Province1");

            migrationBuilder.AlterColumn<string>(
                name: "Province1",
                table: "Orders",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);
        }
    }
}
