using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class UpdatedTableName_210420v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TravelFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TaskFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionnaireFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MandSkillsFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobLevelFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GoodSkillsFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeTypeFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentFKID",
                table: "TalentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypePKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoodSkillsPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewLevelPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobLevelPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobTitlePKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionnairePKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShiftPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillsPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TasksPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TravelPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserPKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GoodSkills",
                columns: table => new
                {
                    GoodSkillsPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodSkillsName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodSkills", x => x.GoodSkillsPKID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_DepartmentFKID",
                table: "TalentRequests",
                column: "DepartmentFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_EmployeeTypeFKID",
                table: "TalentRequests",
                column: "EmployeeTypeFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_GoodSkillsFKID",
                table: "TalentRequests",
                column: "GoodSkillsFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_InterviewLevelFKID",
                table: "TalentRequests",
                column: "InterviewLevelFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_JobLevelFKID",
                table: "TalentRequests",
                column: "JobLevelFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_JobTitleFKID",
                table: "TalentRequests",
                column: "JobTitleFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_LocationFKID",
                table: "TalentRequests",
                column: "LocationFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_MandSkillsFKID",
                table: "TalentRequests",
                column: "MandSkillsFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_QuestionnaireFKID",
                table: "TalentRequests",
                column: "QuestionnaireFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_ShiftFKID",
                table: "TalentRequests",
                column: "ShiftFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_StatusFKID",
                table: "TalentRequests",
                column: "StatusFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_TaskFKID",
                table: "TalentRequests",
                column: "TaskFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_TravelFKID",
                table: "TalentRequests",
                column: "TravelFKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_UserFKID",
                table: "TalentRequests",
                column: "UserFKID");

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Departments_DepartmentFKID",
                table: "TalentRequests",
                column: "DepartmentFKID",
                principalTable: "Departments",
                principalColumn: "DepartmentPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_EmploymentTypes_EmployeeTypeFKID",
                table: "TalentRequests",
                column: "EmployeeTypeFKID",
                principalTable: "EmploymentTypes",
                principalColumn: "EmploymentTypePKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_GoodSkills_GoodSkillsFKID",
                table: "TalentRequests",
                column: "GoodSkillsFKID",
                principalTable: "GoodSkills",
                principalColumn: "GoodSkillsPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_InterviewLevels_InterviewLevelFKID",
                table: "TalentRequests",
                column: "InterviewLevelFKID",
                principalTable: "InterviewLevels",
                principalColumn: "InterviewLevelPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_JobLevels_JobLevelFKID",
                table: "TalentRequests",
                column: "JobLevelFKID",
                principalTable: "JobLevels",
                principalColumn: "JobLevelPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_JobTitles_JobTitleFKID",
                table: "TalentRequests",
                column: "JobTitleFKID",
                principalTable: "JobTitles",
                principalColumn: "JobTitlePKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Locations_LocationFKID",
                table: "TalentRequests",
                column: "LocationFKID",
                principalTable: "Locations",
                principalColumn: "LocationPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Skills_MandSkillsFKID",
                table: "TalentRequests",
                column: "MandSkillsFKID",
                principalTable: "Skills",
                principalColumn: "SkillsPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Questionnaires_QuestionnaireFKID",
                table: "TalentRequests",
                column: "QuestionnaireFKID",
                principalTable: "Questionnaires",
                principalColumn: "QuestionnairePKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Shifts_ShiftFKID",
                table: "TalentRequests",
                column: "ShiftFKID",
                principalTable: "Shifts",
                principalColumn: "ShiftPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Statuses_StatusFKID",
                table: "TalentRequests",
                column: "StatusFKID",
                principalTable: "Statuses",
                principalColumn: "StatusPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Tasks_TaskFKID",
                table: "TalentRequests",
                column: "TaskFKID",
                principalTable: "Tasks",
                principalColumn: "TasksPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Travels_TravelFKID",
                table: "TalentRequests",
                column: "TravelFKID",
                principalTable: "Travels",
                principalColumn: "TravelPKID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Users_UserFKID",
                table: "TalentRequests",
                column: "UserFKID",
                principalTable: "Users",
                principalColumn: "UserPKID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Departments_DepartmentFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_EmploymentTypes_EmployeeTypeFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_GoodSkills_GoodSkillsFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_InterviewLevels_InterviewLevelFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_JobLevels_JobLevelFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_JobTitles_JobTitleFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Locations_LocationFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Skills_MandSkillsFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Questionnaires_QuestionnaireFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Shifts_ShiftFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Statuses_StatusFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Tasks_TaskFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Travels_TravelFKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Users_UserFKID",
                table: "TalentRequests");

            migrationBuilder.DropTable(
                name: "GoodSkills");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_DepartmentFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_EmployeeTypeFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_GoodSkillsFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_InterviewLevelFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_JobLevelFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_JobTitleFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_LocationFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_MandSkillsFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_QuestionnaireFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_ShiftFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_StatusFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_TaskFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_TravelFKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_UserFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "DepartmentPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "EmploymentTypePKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "GoodSkillsPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "InterviewLevelPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "JobLevelPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "JobTitlePKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "LocationPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "QuestionnairePKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "ShiftPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "SkillsPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "StatusPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "TasksPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "TravelPKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "UserPKID",
                table: "TalentRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UserFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TravelFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaskFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionnaireFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MandSkillsFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobLevelFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GoodSkillsFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeTypeFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentFKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
