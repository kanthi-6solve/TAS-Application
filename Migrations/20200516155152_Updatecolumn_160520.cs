using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class Updatecolumn_160520 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostResumeRefNumber",
                table: "TalentCareerUploads",
                type: "varchar(4000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostResumeRefNumber",
                table: "TalentCareerUploads");
        }
    }
}
