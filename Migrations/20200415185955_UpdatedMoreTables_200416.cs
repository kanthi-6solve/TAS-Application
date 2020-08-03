using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class UpdatedMoreTables_200416 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "AssessmentQuestions",
                columns: table => new
                {
                    AssessmentQuesPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Questions = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentQuestions", x => x.AssessmentQuesPKID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentPKID);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationPKID);
                });

            migrationBuilder.CreateTable(
                name: "EducQualifications",
                columns: table => new
                {
                    QualificationPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qualification = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducQualifications", x => x.QualificationPKID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    EmployeeTypePKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.EmployeeTypePKID);
                });

            migrationBuilder.CreateTable(
                name: "InterviewAssessments",
                columns: table => new
                {
                    InterviewAssessPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessedBy = table.Column<int>(nullable: false),
                    CandidateFKID = table.Column<int>(nullable: false),
                    InterviewFKID = table.Column<int>(nullable: false),
                    InterviewLevelFKID = table.Column<int>(nullable: false),
                    AssessmentQuesFKID = table.Column<int>(nullable: false),
                    Ratings = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewAssessments", x => x.InterviewAssessPKID);
                });

            migrationBuilder.CreateTable(
                name: "InterviewLevels",
                columns: table => new
                {
                    InterviewLevelPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewLevelType = table.Column<string>(type: "varchar(4000)", nullable: true),
                    LevelNumber = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewLevels", x => x.InterviewLevelPKID);
                });

            migrationBuilder.CreateTable(
                name: "InterviewResults",
                columns: table => new
                {
                    InterviewResultsPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewFKID = table.Column<int>(nullable: false),
                    CandidateFKID = table.Column<int>(nullable: false),
                    ApprovedBy = table.Column<int>(nullable: false),
                    StatusFKID = table.Column<int>(nullable: false),
                    JobPosterID = table.Column<string>(type: "varchar(4000)", nullable: true),
                    AttendedRounds = table.Column<int>(nullable: false),
                    TotalRatings = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewResults", x => x.InterviewResultsPKID);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    InterviewPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CandidateFKID = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Start_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    End_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    InterviewScheduledBy = table.Column<int>(nullable: false),
                    AssignedTo = table.Column<int>(nullable: false),
                    StatusFKID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.InterviewPKID);
                });

            migrationBuilder.CreateTable(
                name: "JobLevels",
                columns: table => new
                {
                    JobLevelPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobLevelName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevels", x => x.JobLevelPKID);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitlePKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitleName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitlePKID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationPKID);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogsPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogsName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UserFKID = table.Column<int>(nullable: false),
                    AccessType = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogsPKID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFKID = table.Column<int>(nullable: false),
                    Notification_Action = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationPKID);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    QuestionnairePKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.QuestionnairePKID);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftType = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftPKID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsPKID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    FlagStatus = table.Column<string>(type: "varchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusPKID);
                });

            migrationBuilder.CreateTable(
                name: "TalentCareerUploads",
                columns: table => new
                {
                    CandidatePKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    EmailID = table.Column<string>(type: "varchar(4000)", nullable: true),
                    MobileNumber = table.Column<int>(nullable: false),
                    CurrentLocationFKID = table.Column<int>(nullable: false),
                    PreferredLocationFKID = table.Column<int>(nullable: false),
                    TotalExperience = table.Column<int>(nullable: false),
                    CurrentCompany = table.Column<string>(type: "varchar(4000)", nullable: true),
                    DesignationFKID = table.Column<int>(nullable: false),
                    ExpertSkillsFKID = table.Column<int>(nullable: false),
                    TechSkillsFKID = table.Column<int>(nullable: false),
                    EducQualifyFKID = table.Column<int>(nullable: false),
                    JobTitleFKID = table.Column<int>(nullable: false),
                    Resume = table.Column<string>(type: "varchar(4000)", nullable: true),
                    JobPosterID = table.Column<string>(type: "varchar(4000)", nullable: true),
                    JobReferenceNumber = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UploadedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsReject = table.Column<bool>(type: "bit", nullable: false),
                    IsApprove = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentCareerUploads", x => x.CandidatePKID);
                });

            migrationBuilder.CreateTable(
                name: "TalentRequests",
                columns: table => new
                {
                    JobRequisitionPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOpeningsCount = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OverallExperience = table.Column<int>(nullable: false),
                    RecruitmentReason = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    AdditionalNotes = table.Column<string>(type: "varchar(4000)", nullable: true),
                    JobPosterID = table.Column<string>(type: "varchar(4000)", nullable: true),
                    JobTitleFKID = table.Column<int>(nullable: false),
                    DepartmentFKID = table.Column<int>(nullable: false),
                    LocationFKID = table.Column<int>(nullable: false),
                    MandSkillsFKID = table.Column<int>(nullable: false),
                    GoodSkillsFKID = table.Column<int>(nullable: false),
                    EmployeeTypeFKID = table.Column<int>(nullable: false),
                    JobLevelFKID = table.Column<int>(nullable: false),
                    ShiftFKID = table.Column<int>(nullable: false),
                    TravelFKID = table.Column<int>(nullable: false),
                    UserFKID = table.Column<int>(nullable: false),
                    StatusFKID = table.Column<int>(nullable: false),
                    QuestionnaireFKID = table.Column<int>(nullable: false),
                    InterviewRounds = table.Column<int>(nullable: false),
                    InterviewLevelFKID = table.Column<int>(nullable: false),
                    TaskFKID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsReject = table.Column<bool>(type: "bit", nullable: false),
                    IsApprove = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentRequests", x => x.JobRequisitionPKID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TasksPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasksActivity = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(4000)", nullable: true),
                    ActionUserID = table.Column<int>(nullable: false),
                    JobPosterID = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TasksPKID);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    TravelPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelType = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.TravelPKID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentQuestions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EducQualifications");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "InterviewAssessments");

            migrationBuilder.DropTable(
                name: "InterviewLevels");

            migrationBuilder.DropTable(
                name: "InterviewResults");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "JobLevels");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "TalentCareerUploads");

            migrationBuilder.DropTable(
                name: "TalentRequests");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Travels");

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
        }
    }
}
