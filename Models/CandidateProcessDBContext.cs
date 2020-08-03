using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore_TAS_CandidateAPI.Models
{
    public class CandidateProcessDBContext : DbContext
    {
        public CandidateProcessDBContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<JobTitle> JobTitles { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }

        public virtual DbSet<JobLevel> JobLevels { get; set; }

        public virtual DbSet<Shift> Shifts { get; set; }

        public virtual DbSet<Travel> Travels { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Role_Permission> Role_Permissions { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<EducQualification> EducQualifications { get; set; }

        public virtual DbSet<Questionnaire> Questionnaires { get; set; }

        public virtual DbSet<InterviewLevel> InterviewLevels { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Interview> Interviews { get; set; }

        public virtual DbSet<InterviewResult> InterviewResults { get; set; }

        public virtual DbSet<Designation> Designations { get; set; }

        public virtual DbSet<InterviewAssessment> InterviewAssessments { get; set; }

        public virtual DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }

        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<State> States { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<EmailNotification> EmailNotifications { get; set; }

        public virtual DbSet<TalentRequest> TalentRequests { get; set; }

        public virtual DbSet<TalentCareerUpload> TalentCareerUploads { get; set; }

        public virtual DbSet<RecruitmentReason> RecruitmentReasons { get; set; }

        public virtual DbSet<TalentRequest_SaveDraft> TalentRequest_SaveDrafts { get; set; }

        public virtual DbSet<ApprovalLevel> ApprovalLevels { get; set; }

        public virtual DbSet<TrackUserLogin> TrackUserLogins { get; set; }

        //public virtual DbSet<OfferLetterMgmt> OfferLetterMgmts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Users>().MapToStoredProcedures();
            // base.OnModelCreating(modelBuilder);


        }
    }
}

