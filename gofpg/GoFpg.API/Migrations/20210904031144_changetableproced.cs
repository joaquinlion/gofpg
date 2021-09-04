using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class changetableproced : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleType",
                table: "VehicleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure");

            migrationBuilder.RenameTable(
                name: "VehicleType",
                newName: "VehicleTypes");

            migrationBuilder.RenameTable(
                name: "Procedure",
                newName: "Procedures");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleType_Description",
                table: "VehicleTypes",
                newName: "IX_VehicleTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_Procedure_Description",
                table: "Procedures",
                newName: "IX_Procedures_Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

            migrationBuilder.RenameTable(
                name: "VehicleTypes",
                newName: "VehicleType");

            migrationBuilder.RenameTable(
                name: "Procedures",
                newName: "Procedure");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleTypes_Description",
                table: "VehicleType",
                newName: "IX_VehicleType_Description");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_Description",
                table: "Procedure",
                newName: "IX_Procedure_Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleType",
                table: "VehicleType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure",
                column: "Id");
        }
    }
}
