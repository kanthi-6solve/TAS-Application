using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class updatecareer_150520 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLocationFKID",
                table: "TalentCareerUploads");

            migrationBuilder.DropColumn(
                name: "DesignationFKID",
                table: "TalentCareerUploads");

            migrationBuilder.DropColumn(
                name: "ExpertSkillsFKID",
                table: "TalentCareerUploads");

            migrationBuilder.DropColumn(
                name: "JobTitleFKID",
                table: "TalentCareerUploads");

            migrationBuilder.AlterColumn<int>(
                name: "TotalExperience",
                table: "TalentCareerUploads",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TechSkillsFKID",
                table: "TalentCareerUploads",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PreferredLocationFKID",
                table: "TalentCareerUploads",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "TalentCareerUploads",
                type: "varchar(4000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EducQualifyFKID",
                table: "TalentCareerUploads",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CurrentLocation",
                table: "TalentCareerUploads",
                type: "varchar(4000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "TalentCareerUploads",
                type: "varchar(4000)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncSkillsFKID",
                table: "TalentCareerUploads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLocation",
                table: "TalentCareerUploads");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "TalentCareerUploads");

            migrationBuilder.DropColumn(
                name: "FuncSkillsFKID",
                table: "TalentCareerUploads");

            migrationBuilder.AlterColumn<int>(
                name: "TotalExperience",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TechSkillsFKID",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PreferredLocationFKID",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EducQualifyFKID",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentLocationFKID",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesignationFKID",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpertSkillsFKID",
                table: "TalentCareerUploads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobTitleFKID",
                table: "TalentCareerUploads",
                type: "int",
                nullable: true);
        }
    }
}
