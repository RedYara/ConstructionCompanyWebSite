using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diploma.Persistence.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Baths_BathId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Houses_HouseId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Baths");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BathId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_HouseId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BathId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Photos = table.Column<List<string>>(type: "text[]", nullable: false),
                    Preview = table.Column<string>(type: "text", nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: false),
                    Square = table.Column<string>(type: "text", nullable: false),
                    GroupTypeId = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Floors = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_GroupTypes_GroupTypeId",
                        column: x => x.GroupTypeId,
                        principalTable: "GroupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BuildingId",
                table: "Comments",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_GroupTypeId",
                table: "Buildings",
                column: "GroupTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Buildings_BuildingId",
                table: "Comments",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Buildings_BuildingId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BuildingId",
                table: "Comments");

            migrationBuilder.AddColumn<Guid>(
                name: "BathId",
                table: "Comments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "Comments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Baths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: false),
                    Floors = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Photos = table.Column<List<string>>(type: "text[]", nullable: false),
                    Preview = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Square = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: false),
                    Floors = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Photos = table.Column<List<string>>(type: "text[]", nullable: false),
                    Preview = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Square = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BathId",
                table: "Comments",
                column: "BathId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_HouseId",
                table: "Comments",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Baths_BathId",
                table: "Comments",
                column: "BathId",
                principalTable: "Baths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Houses_HouseId",
                table: "Comments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id");
        }
    }
}
