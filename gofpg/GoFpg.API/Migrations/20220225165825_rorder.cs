using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class rorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasReferral = table.Column<bool>(type: "bit", nullable: false),
                    ReferralNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArePartsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    HasApproval = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    InstallerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DamageImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullDamageImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VinImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteriorImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasPictures = table.Column<bool>(type: "bit", nullable: false),
                    HasSignature = table.Column<bool>(type: "bit", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    InstallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstalledImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Installed2ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInstalled = table.Column<bool>(type: "bit", nullable: false),
                    HasCalibration = table.Column<bool>(type: "bit", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalibrationDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairOrders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_Id",
                table: "RepairOrders",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairOrders");
        }
    }
}
