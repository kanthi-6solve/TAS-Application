using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class updatecolv1_20_05_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StageFKID",
                table: "TalentCareerUploads",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusFKID",
                table: "TalentCareerUploads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StageFKID",
                table: "TalentCareerUploads");

            migrationBuilder.DropColumn(
                name: "StatusFKID",
                table: "TalentCareerUploads");
        }
    }
}
