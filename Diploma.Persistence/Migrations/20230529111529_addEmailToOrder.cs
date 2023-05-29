using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.Persistence.Migrations
{
    public partial class addEmailToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stauts",
                table: "Orders",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "Stauts");
        }
    }
}
