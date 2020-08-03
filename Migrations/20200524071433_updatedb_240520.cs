using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class updatedb_240520 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OverallExperience",
                table: "TalentRequests",
                type: "nvarchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OverallExperience",
                table: "TalentRequest_SaveDrafts",
                type: "nvarchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OverallExperience",
                table: "TalentRequests",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OverallExperience",
                table: "TalentRequest_SaveDrafts",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldNullable: true);
        }
    }
}
