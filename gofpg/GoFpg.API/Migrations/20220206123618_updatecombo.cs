using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class updatecombo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Glasstypes",
                table: "Glasstypes");

            migrationBuilder.DropColumn(
                name: "GlassType",
                table: "Quotes");

            migrationBuilder.RenameTable(
                name: "Glasstypes",
                newName: "GlassTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Glasstypes_Description",
                table: "GlassTypes",
                newName: "IX_GlassTypes_Description");

            migrationBuilder.AddColumn<int>(
                name: "GlassTypeId",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassTypes",
                table: "GlassTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_GlassTypeId",
                table: "Quotes",
                column: "GlassTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_GlassTypes_GlassTypeId",
                table: "Quotes",
                column: "GlassTypeId",
                principalTable: "GlassTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_GlassTypes_GlassTypeId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_GlassTypeId",
                table: "Quotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassTypes",
                table: "GlassTypes");

            migrationBuilder.DropColumn(
                name: "GlassTypeId",
                table: "Quotes");

            migrationBuilder.RenameTable(
                name: "GlassTypes",
                newName: "Glasstypes");

            migrationBuilder.RenameIndex(
                name: "IX_GlassTypes_Description",
                table: "Glasstypes",
                newName: "IX_Glasstypes_Description");

            migrationBuilder.AddColumn<string>(
                name: "GlassType",
                table: "Quotes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Glasstypes",
                table: "Glasstypes",
                column: "Id");
        }
    }
}
