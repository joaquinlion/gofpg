using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class checkROtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairOrders");

            migrationBuilder.AddColumn<bool>(
                name: "ArePartsAvailable",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillTo",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CalibrationDone",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasApproval",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasCalibration",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPictures",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasReferral",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasSignature",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallDate",
                table: "Quotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstallerName",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceImageId",
                table: "Quotes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInstalled",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsScheduled",
                table: "Quotes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartNumber",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PolicyNumber",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Procedure",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferralNumber",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "Quotes",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArePartsAvailable",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "BillTo",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "CalibrationDone",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "HasApproval",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "HasCalibration",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "HasPictures",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "HasReferral",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "HasSignature",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "InstallDate",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "InstallerName",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "InvoiceImageId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "IsInstalled",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "IsScheduled",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "PartNumber",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "PolicyNumber",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Procedure",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "ReferralNumber",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "Quotes");

            migrationBuilder.CreateTable(
                name: "RepairOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArePartsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    BillTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalibrationDone = table.Column<bool>(type: "bit", nullable: false),
                    DamageImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullDamageImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasApproval = table.Column<bool>(type: "bit", nullable: false),
                    HasCalibration = table.Column<bool>(type: "bit", nullable: false),
                    HasPictures = table.Column<bool>(type: "bit", nullable: false),
                    HasReferral = table.Column<bool>(type: "bit", nullable: false),
                    HasSignature = table.Column<bool>(type: "bit", nullable: false),
                    InstallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Installed2ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstalledImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstallerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteriorImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInstalled = table.Column<bool>(type: "bit", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferralNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TagImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VinImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
    }
}
