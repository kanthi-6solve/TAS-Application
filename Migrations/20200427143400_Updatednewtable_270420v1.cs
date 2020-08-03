using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class Updatednewtable_270420v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TalentRequest_SaveDrafts",
                columns: table => new
                {
                    JobRequisitionPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOpeningsCount = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OverallExperience = table.Column<int>(nullable: true),
                    RecruitReasonFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    Description = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Salary = table.Column<int>(nullable: true),
                    AdditionalNotes = table.Column<string>(type: "varchar(4000)", nullable: true),
                    JobPosterID = table.Column<string>(type: "varchar(4000)", nullable: true),
                    JobTitleFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    DepartmentFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    LocationFKID = table.Column<int>(nullable: true),
                    StateFKID = table.Column<int>(nullable: true),
                    CityFKID = table.Column<int>(nullable: true),
                    MandSkillsFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    GoodSkillsFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    EmploymentTypeFKID = table.Column<int>(nullable: true),
                    DurationFKID = table.Column<int>(nullable: true),
                    JobLevelFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    ShiftFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    TravelFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    ApproverFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    CollaboratorFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    StatusFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    QuestionnaireFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    InterviewRounds = table.Column<int>(nullable: true),
                    InterviewLevelFKID = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    TaskFKID = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsReject = table.Column<bool>(type: "bit", nullable: true),
                    IsApprove = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    ViewStatus = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentRequest_SaveDrafts", x => x.JobRequisitionPKID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalentRequest_SaveDrafts");
        }
    }
}
