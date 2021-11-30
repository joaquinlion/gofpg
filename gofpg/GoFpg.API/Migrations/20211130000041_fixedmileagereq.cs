using Microsoft.EntityFrameworkCore.Migrations;

namespace GoFpg.API.Migrations
{
    public partial class fixedmileagereq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Histories");

            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                table: "Histories",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                table: "Histories",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Histories",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);
        }
    }
}
