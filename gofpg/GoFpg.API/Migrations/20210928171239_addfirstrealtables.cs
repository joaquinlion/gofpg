using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class addfirstrealtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Dealerships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dealer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServicePhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PartsPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealerships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfLoss = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Damage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    VINImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DLImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsCardImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceClaims_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsCoPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_Dealer",
                table: "Dealerships",
                column: "Dealer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaims_Id",
                table: "InsuranceClaims",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaims_VehicleId",
                table: "InsuranceClaims",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCompanies_InsCompany",
                table: "InsuranceCompanies",
                column: "InsCompany",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                table: "AspNetUsers",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Dealerships");

            migrationBuilder.DropTable(
                name: "InsuranceClaims");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                table: "AspNetUsers",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
