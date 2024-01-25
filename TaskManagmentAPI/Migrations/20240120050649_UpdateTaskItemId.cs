using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentAPI.Migrations
{
    public partial class UpdateTaskItemId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskItemId",
                table: "TaskItems",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TaskItems",
                newName: "TaskItemId");
        }
    }
}
