using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBU.DAL.Migrations
{
    public partial class AddDocumentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentInfoId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DocumentInfoId",
                table: "Employee",
                column: "DocumentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_DocumentInfo_DocumentInfoId",
                table: "Employee",
                column: "DocumentInfoId",
                principalTable: "DocumentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_DocumentInfo_DocumentInfoId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "DocumentInfo");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DocumentInfoId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DocumentInfoId",
                table: "Employee");
        }
    }
}
