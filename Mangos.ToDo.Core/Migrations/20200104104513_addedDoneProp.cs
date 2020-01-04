using Microsoft.EntityFrameworkCore.Migrations;

namespace Mangos.ToDo.Core.Migrations
{
    public partial class addedDoneProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Done",
                table: "ToDoItems",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "ToDoItems");
        }
    }
}
