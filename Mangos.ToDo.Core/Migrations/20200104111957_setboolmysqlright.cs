using Microsoft.EntityFrameworkCore.Migrations;

namespace Mangos.ToDo.Core.Migrations
{
    public partial class setboolmysqlright : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Done",
                table: "ToDoItems",
                type: "TINYINT(4)",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<byte>(
                name: "Deleted",
                table: "ToDoItems",
                type: "TINYINT(4)",
                nullable: false,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Done",
                table: "ToDoItems",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT(4)");

            migrationBuilder.AlterColumn<short>(
                name: "Deleted",
                table: "ToDoItems",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT(4)");
        }
    }
}
