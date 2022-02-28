using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class fixrotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DamageImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FullDamageImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Installed2ImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstalledImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InteriorImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SignedROImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TagImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VinImageId",
                table: "RepairOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageImageId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "FullDamageImageId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "Installed2ImageId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "InstalledImageId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "InteriorImageId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "SignedROImageId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "TagImageId",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "VinImageId",
                table: "RepairOrders");
        }
    }
}
