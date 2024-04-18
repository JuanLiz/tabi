using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CropStatus",
                columns: table => new
                {
                    CropStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropStatus", x => x.CropStatusID);
                });

            migrationBuilder.CreateTable(
                name: "CropType",
                columns: table => new
                {
                    CropTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExpectedYield = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropType", x => x.CropTypeID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    DocumentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.DocumentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "HarvestStatus",
                columns: table => new
                {
                    HarvestStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestStatus", x => x.HarvestStatusID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    PaymentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.PaymentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SlopeType",
                columns: table => new
                {
                    SlopeTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlopeType", x => x.SlopeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DocumentTypeID = table.Column<int>(type: "int", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_DocumentType_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeID");
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farm",
                columns: table => new
                {
                    FarmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hectares = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farm", x => x.FarmID);
                    table.ForeignKey(
                        name: "FK_Farm_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    LotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Hectares = table.Column<float>(type: "real", nullable: false),
                    SlopeTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.LotID);
                    table.ForeignKey(
                        name: "FK_Lot_Farm_FarmID",
                        column: x => x.FarmID,
                        principalTable: "Farm",
                        principalColumn: "FarmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lot_SlopeType_SlopeTypeID",
                        column: x => x.SlopeTypeID,
                        principalTable: "SlopeType",
                        principalColumn: "SlopeTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    CropID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotID = table.Column<int>(type: "int", nullable: false),
                    Hectares = table.Column<float>(type: "real", nullable: false),
                    CropTypeID = table.Column<int>(type: "int", nullable: false),
                    CropStatusID = table.Column<int>(type: "int", nullable: false),
                    PlantingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HarvestDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.CropID);
                    table.ForeignKey(
                        name: "FK_Crop_CropStatus_CropStatusID",
                        column: x => x.CropStatusID,
                        principalTable: "CropStatus",
                        principalColumn: "CropStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crop_CropType_CropTypeID",
                        column: x => x.CropTypeID,
                        principalTable: "CropType",
                        principalColumn: "CropTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crop_Lot_LotID",
                        column: x => x.LotID,
                        principalTable: "Lot",
                        principalColumn: "LotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harvest",
                columns: table => new
                {
                    HarvestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropID = table.Column<int>(type: "int", nullable: false),
                    HarvestStatusID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvest", x => x.HarvestID);
                    table.ForeignKey(
                        name: "FK_Harvest_Crop_CropID",
                        column: x => x.CropID,
                        principalTable: "Crop",
                        principalColumn: "CropID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Harvest_HarvestStatus_HarvestStatusID",
                        column: x => x.HarvestStatusID,
                        principalTable: "HarvestStatus",
                        principalColumn: "HarvestStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HarvestPayment",
                columns: table => new
                {
                    HarvestPaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarvestID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    HarvestedAmount = table.Column<float>(type: "real", nullable: false),
                    PaymentTypeID = table.Column<int>(type: "int", nullable: false),
                    PaymentAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestPayment", x => x.HarvestPaymentID);
                    table.ForeignKey(
                        name: "FK_HarvestPayment_Harvest_HarvestID",
                        column: x => x.HarvestID,
                        principalTable: "Harvest",
                        principalColumn: "HarvestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarvestPayment_PaymentType_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalTable: "PaymentType",
                        principalColumn: "PaymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarvestPayment_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crop_CropStatusID",
                table: "Crop",
                column: "CropStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Crop_CropTypeID",
                table: "Crop",
                column: "CropTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Crop_LotID",
                table: "Crop",
                column: "LotID");

            migrationBuilder.CreateIndex(
                name: "IX_Farm_UserID",
                table: "Farm",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Harvest_CropID",
                table: "Harvest",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_Harvest_HarvestStatusID",
                table: "Harvest",
                column: "HarvestStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPayment_HarvestID",
                table: "HarvestPayment",
                column: "HarvestID");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPayment_PaymentTypeID",
                table: "HarvestPayment",
                column: "PaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestPayment_UserID",
                table: "HarvestPayment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_FarmID",
                table: "Lot",
                column: "FarmID");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_SlopeTypeID",
                table: "Lot",
                column: "SlopeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_DocumentTypeID",
                table: "User",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HarvestPayment");

            migrationBuilder.DropTable(
                name: "Harvest");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Crop");

            migrationBuilder.DropTable(
                name: "HarvestStatus");

            migrationBuilder.DropTable(
                name: "CropStatus");

            migrationBuilder.DropTable(
                name: "CropType");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "Farm");

            migrationBuilder.DropTable(
                name: "SlopeType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
