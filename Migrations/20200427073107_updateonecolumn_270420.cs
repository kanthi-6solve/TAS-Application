using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class updateonecolumn_270420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);
        }
    }
}
