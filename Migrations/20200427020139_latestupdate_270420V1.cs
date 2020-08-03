using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class latestupdate_270420V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MandSkillsFKID",
                table: "TalentRequests",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GoodSkillsFKID",
                table: "TalentRequests",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CollaboratorFKID",
                table: "TalentRequests",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApproverFKID",
                table: "TalentRequests",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MandSkillsFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<int>(
                name: "GoodSkillsFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollaboratorFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApproverFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);
        }
    }
}
