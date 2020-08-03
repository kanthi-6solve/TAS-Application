using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class tas_updateintasks_20042020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Tasks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Tasks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Tasks",
                type: "nvarchar(1000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Tasks");
        }
    }
}
