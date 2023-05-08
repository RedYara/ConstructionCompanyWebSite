using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.Persistence.Migrations
{
    public partial class ChangeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Orders",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Orders",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Orders",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
