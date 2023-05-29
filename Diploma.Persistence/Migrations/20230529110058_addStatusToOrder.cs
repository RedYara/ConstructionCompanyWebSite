using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.Persistence.Migrations
{
    public partial class addStatusToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stauts",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stauts",
                table: "Orders");
        }
    }
}
