using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.Persistence.Migrations
{
    public partial class OrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Orders",
                newName: "RowId");

            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "Orders",
                newName: "BuildingId");
        }
    }
}
