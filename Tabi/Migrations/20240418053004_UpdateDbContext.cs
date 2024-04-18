using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CropManagementType",
                columns: table => new
                {
                    CropManagementTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropManagementType", x => x.CropManagementTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CropManagement",
                columns: table => new
                {
                    CropManagementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropID = table.Column<int>(type: "int", nullable: false),
                    CropManagementTypeID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropManagement", x => x.CropManagementID);
                    table.ForeignKey(
                        name: "FK_CropManagement_CropManagementType_CropManagementTypeID",
                        column: x => x.CropManagementTypeID,
                        principalTable: "CropManagementType",
                        principalColumn: "CropManagementTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropManagement_Crop_CropID",
                        column: x => x.CropID,
                        principalTable: "Crop",
                        principalColumn: "CropID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropManagement_CropID",
                table: "CropManagement",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_CropManagement_CropManagementTypeID",
                table: "CropManagement",
                column: "CropManagementTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CropManagement");

            migrationBuilder.DropTable(
                name: "CropManagementType");
        }
    }
}
