using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class updatecolumns_160620 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InterviewLevelFKID",
                table: "TalentCareerUploads",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TotalRatings",
                table: "InterviewResults",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterviewFKID",
                table: "InterviewResults",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "InterviewResults",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterviewLevelFKID",
                table: "InterviewResults",
                type: "varchar(1000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterviewLevelFKID",
                table: "TalentCareerUploads");

            migrationBuilder.DropColumn(
                name: "InterviewLevelFKID",
                table: "InterviewResults");

            migrationBuilder.AlterColumn<int>(
                name: "TotalRatings",
                table: "InterviewResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InterviewFKID",
                table: "InterviewResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedBy",
                table: "InterviewResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);
        }
    }
}
