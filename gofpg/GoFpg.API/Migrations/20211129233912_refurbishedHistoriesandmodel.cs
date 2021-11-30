using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class refurbishedHistoriesandmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RONumber",
                table: "Histories");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleTime",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleTime",
                table: "Histories");

            migrationBuilder.AddColumn<string>(
                name: "RONumber",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
