using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class latestupdate_260420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Departments_DepartmentPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_EmploymentTypes_EmploymentTypePKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_GoodSkills_GoodSkillsPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_InterviewLevels_InterviewLevelPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_JobLevels_JobLevelPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_JobTitles_JobTitlePKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Locations_LocationPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Questionnaires_QuestionnairePKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Shifts_ShiftPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Skills_SkillsPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Statuses_StatusPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Tasks_TasksPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Travels_TravelPKID",
                table: "TalentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentRequests_Users_UserPKID",
                table: "TalentRequests");

            migrationBuilder.DropTable(
                name: "GoodSkills");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_DepartmentPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_EmploymentTypePKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_GoodSkillsPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_InterviewLevelPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_JobLevelPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_JobTitlePKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_LocationPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_QuestionnairePKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_ShiftPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_SkillsPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_StatusPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_TasksPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_TravelPKID",
                table: "TalentRequests");

            migrationBuilder.DropIndex(
                name: "IX_TalentRequests_UserPKID",
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
                name: "RecruitmentReason",
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserRoles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserRoles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserPermissions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserPermissions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Travels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Travels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Tasks",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsReject",
                table: "TalentRequests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsApprove",
                table: "TalentRequests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApproverFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CollaboratorFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoodSkillsFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobLevelFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobTitleFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MandSkillsFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecruitReasonFKID",
                table: "TalentRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TravelFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TalentCareerUploads",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Statuses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Statuses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "States",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "States",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Skills",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Skills",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Shifts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Shifts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Role_Permissions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Role_Permissions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RecruitmentReasons",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecruitmentReasons",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Questionnaires",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Questionnaires",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Notifications",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Notifications",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Logs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Logs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Locations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Locations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "JobTitles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "JobLevels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "JobLevels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Interviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Interviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "InterviewResults",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "InterviewResults",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "InterviewLevels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "InterviewLevels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "InterviewAssessments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "InterviewAssessments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "EmploymentTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "EmploymentTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "EmploymentTypes",
                type: "varchar(4000)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "EducQualifications",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "EducQualifications",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Designations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Designations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cities",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentQuestions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AssessmentQuestions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproverFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "CityFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "CollaboratorFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "DepartmentFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "GoodSkillsFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "InterviewLevelFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "JobLevelFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "JobTitleFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "LocationFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "MandSkillsFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "QuestionnaireFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "RecruitReasonFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "ShiftFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "StateFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "StatusFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "TaskFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "TravelFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EmploymentTypes");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserPermissions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserPermissions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Travels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Travels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsReject",
                table: "TalentRequests",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApprove",
                table: "TalentRequests",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypePKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoodSkillsPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewLevelPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobLevelPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobTitlePKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionnairePKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecruitmentReason",
                table: "TalentRequests",
                type: "varchar(4000)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillsPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TasksPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TravelPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserPKID",
                table: "TalentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TalentCareerUploads",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Statuses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Statuses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "States",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "States",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Skills",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Skills",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Shifts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Shifts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Role_Permissions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Role_Permissions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RecruitmentReasons",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecruitmentReasons",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Questionnaires",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Questionnaires",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Notifications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Notifications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Logs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Logs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Locations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Locations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "JobTitles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "JobLevels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "JobLevels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Interviews",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Interviews",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "InterviewResults",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "InterviewResults",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "InterviewLevels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "InterviewLevels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "InterviewAssessments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "InterviewAssessments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "EmploymentTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "EmploymentTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "EducQualifications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "EducQualifications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Designations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Designations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cities",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentQuestions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AssessmentQuestions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GoodSkills",
                columns: table => new
                {
                    GoodSkillsPKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    GoodSkillsName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodSkills", x => x.GoodSkillsPKID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_DepartmentPKID",
                table: "TalentRequests",
                column: "DepartmentPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_EmploymentTypePKID",
                table: "TalentRequests",
                column: "EmploymentTypePKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_GoodSkillsPKID",
                table: "TalentRequests",
                column: "GoodSkillsPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_InterviewLevelPKID",
                table: "TalentRequests",
                column: "InterviewLevelPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_JobLevelPKID",
                table: "TalentRequests",
                column: "JobLevelPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_JobTitlePKID",
                table: "TalentRequests",
                column: "JobTitlePKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_LocationPKID",
                table: "TalentRequests",
                column: "LocationPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_QuestionnairePKID",
                table: "TalentRequests",
                column: "QuestionnairePKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_ShiftPKID",
                table: "TalentRequests",
                column: "ShiftPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_SkillsPKID",
                table: "TalentRequests",
                column: "SkillsPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_StatusPKID",
                table: "TalentRequests",
                column: "StatusPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_TasksPKID",
                table: "TalentRequests",
                column: "TasksPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_TravelPKID",
                table: "TalentRequests",
                column: "TravelPKID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRequests_UserPKID",
                table: "TalentRequests",
                column: "UserPKID");

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Departments_DepartmentPKID",
                table: "TalentRequests",
                column: "DepartmentPKID",
                principalTable: "Departments",
                principalColumn: "DepartmentPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_EmploymentTypes_EmploymentTypePKID",
                table: "TalentRequests",
                column: "EmploymentTypePKID",
                principalTable: "EmploymentTypes",
                principalColumn: "EmploymentTypePKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_GoodSkills_GoodSkillsPKID",
                table: "TalentRequests",
                column: "GoodSkillsPKID",
                principalTable: "GoodSkills",
                principalColumn: "GoodSkillsPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_InterviewLevels_InterviewLevelPKID",
                table: "TalentRequests",
                column: "InterviewLevelPKID",
                principalTable: "InterviewLevels",
                principalColumn: "InterviewLevelPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_JobLevels_JobLevelPKID",
                table: "TalentRequests",
                column: "JobLevelPKID",
                principalTable: "JobLevels",
                principalColumn: "JobLevelPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_JobTitles_JobTitlePKID",
                table: "TalentRequests",
                column: "JobTitlePKID",
                principalTable: "JobTitles",
                principalColumn: "JobTitlePKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Locations_LocationPKID",
                table: "TalentRequests",
                column: "LocationPKID",
                principalTable: "Locations",
                principalColumn: "LocationPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Questionnaires_QuestionnairePKID",
                table: "TalentRequests",
                column: "QuestionnairePKID",
                principalTable: "Questionnaires",
                principalColumn: "QuestionnairePKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Shifts_ShiftPKID",
                table: "TalentRequests",
                column: "ShiftPKID",
                principalTable: "Shifts",
                principalColumn: "ShiftPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Skills_SkillsPKID",
                table: "TalentRequests",
                column: "SkillsPKID",
                principalTable: "Skills",
                principalColumn: "SkillsPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Statuses_StatusPKID",
                table: "TalentRequests",
                column: "StatusPKID",
                principalTable: "Statuses",
                principalColumn: "StatusPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Tasks_TasksPKID",
                table: "TalentRequests",
                column: "TasksPKID",
                principalTable: "Tasks",
                principalColumn: "TasksPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Travels_TravelPKID",
                table: "TalentRequests",
                column: "TravelPKID",
                principalTable: "Travels",
                principalColumn: "TravelPKID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentRequests_Users_UserPKID",
                table: "TalentRequests",
                column: "UserPKID",
                principalTable: "Users",
                principalColumn: "UserPKID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
