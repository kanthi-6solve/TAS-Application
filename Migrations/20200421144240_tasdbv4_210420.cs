using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class tasdbv4_210420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DepartmentFKID",
                table: "TalentRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeFKID",
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
                name: "ShiftFKID",
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
                name: "UserFKID",
                table: "TalentRequests");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DepartmentFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTypeFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoodSkillsFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewLevelFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobLevelFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTitleFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MandSkillsFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TravelFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserFKID",
                table: "TalentRequests",
                type: "int",
                nullable: true);

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
    }
}
