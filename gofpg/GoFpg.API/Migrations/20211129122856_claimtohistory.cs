using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GoFpg.API.Migrations
{
    public partial class claimtohistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                table: "Histories",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AltAddress",
                table: "Histories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltAddress2",
                table: "Histories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltCity",
                table: "Histories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltContactName",
                table: "Histories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltPhoneNumber",
                table: "Histories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltState",
                table: "Histories",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltZip",
                table: "Histories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Damage",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLoss",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCo",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PolicyNumber",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RODate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RONumber",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferralNumber",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Repair",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Histories",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltAddress",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "AltAddress2",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "AltCity",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "AltContactName",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "AltPhoneNumber",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "AltState",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "AltZip",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "DateOfLoss",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "InsuranceCo",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "PolicyNumber",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "RODate",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "RONumber",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "ReferralNumber",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Repair",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "ScheduleDate",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Histories");

            migrationBuilder.AlterColumn<int>(
                name: "Mileage",
                table: "Histories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);
        }
    }
}
