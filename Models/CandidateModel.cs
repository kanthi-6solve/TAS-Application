using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//    JobTitle
public class JobTitle
{
    [Key]
    public int JobTitlePKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string JobTitleName { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Department
public class Department
{
    [Key]
    public int DepartmentPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string DepartmentName { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Location

public class Location
{
    [Key]
    public int LocationPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string LocationName { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Skill
public class Skill
{
    [Key]
    public int SkillsPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string SkillsName { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// EmployeeType

public class EmploymentType
{
    [Key]
    public int EmploymentTypePKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string EmploymentTypeName { get; set; }

    //[Column(TypeName = "varchar(4000)")]
    //public string Duration { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  JobLevel

public class JobLevel
{
    [Key]
    public int JobLevelPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string JobLevelName { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  Shift

public class Shift
{
    [Key]
    public int ShiftPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string ShiftType { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Travel

public class Travel
{
    [Key]
    public int TravelPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string TravelType { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// City

public class City
{
    [Key]
    public int CityPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CityName { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  State

public class State
{
    [Key]
    public int StatePKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string StateName { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  User

public class User
{
    [Key]
    public int UserPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string EmployeeID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UserName { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UserEmail { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string OldPassword { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string NewPassword { get; set; }

    [Column("IsRemember", TypeName = "bit")]
    public bool? IsRemember { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Mobile { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DOJ { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Address { get; set; }

    public int? PinCode { get; set; }

    [ForeignKey("CityFKID")]
    public int? CityFKID { get; set; }

    [ForeignKey("StateFKID")]
    public int? StateFKID { get; set; }

    [ForeignKey("RoleFKID")]
    public int? RoleFKID { get; set; }
    public int? DesignationFKID { get; set; }
    public int? DepartmentFKID { get; set; }
    public int? StatusFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string ProfileImage { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  UserPermissions

public class UserPermission
{
    [Key]
    public int PermissionPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string PermissionTitle { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Description { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// UserRole

public class UserRole
{
    [Key]
    public int RolePKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string RoleTitle { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Role_Permission

public class Role_Permission
{
    [Key]
    public int RolePermissionPKID { get; set; }

    [ForeignKey("RoleFKID")]
    public int? RoleFKID { get; set; }

    [ForeignKey("PermissionFKID")]
    public int PermissionFKID { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  Status

public class Status
{
    [Key]
    public int StatusPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string StatusName { get; set; }

    [Column(TypeName = "varchar(1000)")]
    public string FlagStatus { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  Questionnaire

public class Questionnaire
{
    [Key]
    public int QuestionnairePKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string QuestionnaireName { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//    EducationalQualification

public class EducQualification
{
    [Key]
    public int QualificationPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Qualification { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Logs

public class Log
{
    [Key]
    public int LogsPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string LogsName { get; set; }

    [ForeignKey("UserFKID")]
    public int? UserFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string AccessType { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Description { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  InterviewLevel

public class InterviewLevel
{
    [Key]
    public int InterviewLevelPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string InterviewLevelType { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string LevelNumber { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Interview

public class Interview
{
    [Key]
    public int InterviewPKID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InterviewDate { get; set; }

    [ForeignKey("CandidateFKID")]
    public int? CandidateFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Remarks { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Start_Time { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime End_Time { get; set; }

    public int? InterviewScheduledBy { get; set; }

    [ForeignKey("AssignedTo")]
    public int? AssignedTo { get; set; }
    public int? DelegatedTo { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string InterviewLevelType { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Strength { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Weakness { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Comments { get; set; }

    [Column("IsAddAnotherRound", TypeName = "bit")]
    public bool? IsAddAnotherRound { get; set; }

    [Column("IsOnhold", TypeName = "bit")]
    public bool? IsOnhold { get; set; }

    [ForeignKey("StatusFKID")]
    public int? StatusFKID { get; set; }
    //  public int? StageFKID { get; set; }

    [Column("IsApproved", TypeName = "bit")]
    public bool? IsApproved { get; set; }

    [Column("IsRejected", TypeName = "bit")]
    public bool? IsRejected { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  InterviewResults
public class InterviewResult
{
    [Key]
    public int InterviewResultsPKID { get; set; }

    [Column(TypeName = "varchar(1000)")]
    public string InterviewFKID { get; set; }

    [Column(TypeName = "varchar(1000)")]
    public string InterviewLevelFKID { get; set; }

    [ForeignKey("CandidateFKID")]
    public int? CandidateFKID { get; set; }

    [Column(TypeName = "varchar(1000)")]
    public string ApprovedBy { get; set; }

    [ForeignKey("StatusFKID")]
    public int? StatusFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string JobPosterID { get; set; }

    public int? AttendedRounds { get; set; }

    [Column(TypeName = "varchar(1000)")]
    public string TotalRatings { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Remarks { get; set; }

    [Column("IsApproved", TypeName = "bit")]
    public bool? IsApproved { get; set; }

    [Column("IsRejected", TypeName = "bit")]
    public bool? IsRejected { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Designation

public class Designation
{
    [Key]
    public int DesignationPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string DesignationName { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  Interview Assessment

public class InterviewAssessment
{
    [Key]
    public int InterviewAssessPKID { get; set; }

    [ForeignKey("AssessedBy")]
    public int? AssessedBy { get; set; }

    [ForeignKey("CandidateFKID")]
    public int? CandidateFKID { get; set; }

    [ForeignKey("InterviewFKID")]
    public int? InterviewFKID { get; set; }

    [ForeignKey("InterviewLevelFKID")]
    public int? InterviewLevelFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string AssessmentQuesFKID { get; set; }
    public int? Ratings { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Strength { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Weakness { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Comments { get; set; }

    [Column("IsAddAnotherRound", TypeName = "bit")]
    public bool? IsAddAnotherRound { get; set; }

    [Column("IsOnhold", TypeName = "bit")]
    public bool? IsOnhold { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Remarks { get; set; }

    [Column("IsApproved", TypeName = "bit")]
    public bool? IsApproved { get; set; }

    [Column("IsRejected", TypeName = "bit")]
    public bool? IsRejected { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//  Assessment Question

public class AssessmentQuestion
{
    [Key]
    public int AssessmentQuesPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Questions { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Answers { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// Task

public class Task
{
    [Key]
    public int TasksPKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string TasksActivity { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Description { get; set; }

    [Column(TypeName = "varchar(500)")]
    public string Moduletype { get; set; }

    [ForeignKey("ActionUserID")]
    public int ActionUserID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string JobPosterID { get; set; }

    [Column("IsCompleted", TypeName = "bit")]
    public bool? IsCompleted { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column("IsApproved", TypeName = "bit")]
    public bool? IsApproved { get; set; }

    [Column("IsRejected", TypeName = "bit")]
    public bool? IsRejected { get; set; }

    [Column("IsOnhold", TypeName = "bit")]
    public bool? IsOnhold { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string Remarks { get; set; }


}

//  EmailNotification
public class EmailNotification
{
    [Key]
    public int EmailPKID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime MailingDate { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string SenderEmail { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Recepients { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Subject { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string MessageBody { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }
}

// Notifications

public class Notification
{
    [Key]
    public int NotificationPKID { get; set; }

    [ForeignKey("UserFKID")]
    public int UserFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Notification_Action { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Description { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }
}

// TalentRequest

public class TalentRequest
{
    [Key]
    public int JobRequisitionPKID { get; set; }

    public int? JobOpeningsCount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column(TypeName = "nvarchar(2000)")]
    public string OverallExperience { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string RecruitReasonFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Description { get; set; }

    public int? Salary { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string AdditionalNotes { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string JobPosterID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string JobTitleFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string DepartmentFKID { get; set; }

    // [ForeignKey("LocationFKID")]
    public int? LocationFKID { get; set; }

    //  [ForeignKey("StateFKID")]
    public int? StateFKID { get; set; }

    //  [ForeignKey("CityFKID")]
    public int? CityFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string MandSkillsFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string GoodSkillsFKID { get; set; }

    //  [ForeignKey("EmploymentTypeFKID")]
    public int? EmploymentTypeFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string EmpcumDurationtext { get; set; }

    //  [Column(TypeName = "varchar(4000)")]
    public int? DurationFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string JobLevelFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string ShiftFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string TravelFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string ApproverFKID { get; set; }

    [Column(TypeName = "nvarchar(250)")]
    public string NextApproverLevel { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string CollaboratorFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string StatusFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string QuestionnaireFKID { get; set; }

    public int? InterviewRounds { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string InterviewLevelFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string TaskFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string ApprovedBy { get; set; }

    [Column("IsReject", TypeName = "bit")]
    public bool? IsReject { get; set; }

    [Column("IsApprove", TypeName = "bit")]
    public bool? IsApprove { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

}

//  TalentCareerUpload

public class TalentCareerUpload
{
    [Key]
    public int CandidatePKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CandidateName { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string EmailID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string MobileNumber { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CurrentLocation { get; set; }

    // [ForeignKey("PreferredLocationFKID")]
    public int? PreferredLocationFKID { get; set; }

    public int? TotalExperience { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CurrentCompany { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Designation { get; set; }

    // [ForeignKey("ExpertSkillsFKID")]
    public int? FuncSkillsFKID { get; set; }

    // [ForeignKey("TechSkillsFKID")]
    public int? TechSkillsFKID { get; set; }

    // [ForeignKey("EducQualifyFKID")]
    public int? EducQualifyFKID { get; set; }

    // [ForeignKey("JobTitleFKID")]
    //public int? JobTitleFKID { get; set; }    

    [Column(TypeName = "varchar(4000)")]
    public string Resume { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string JobPosterID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string RequisitionName { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string JobReferenceNumber { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Strengths { get; set; }

    [Column(TypeName = "varchar(2000)")]
    public string Weaknesses { get; set; }
    public int? StageFKID { get; set; }
    public int? StatusFKID { get; set; }

    [Column(TypeName = "varchar(1000)")]
    public string InterviewLevelFKID { get; set; }

    public int? FirstLevelApprover { get; set; }
    public int? SecondLevelApprover { get; set; }

    [Column("IsFirstLevelApprove", TypeName = "bit")]
    public bool? IsFirstLevelApprove { get; set; }

    [Column("IsFirstLevelReject", TypeName = "bit")]
    public bool? IsFirstLevelReject { get; set; }

    [Column("IsSecondLevelApprove", TypeName = "bit")]
    public bool? IsSecondLevelApprove { get; set; }

    [Column("IsSecondLevelReject", TypeName = "bit")]
    public bool? IsSecondLevelReject { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string PostResumeRefNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UploadedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("IsReject", TypeName = "bit")]
    public bool? IsReject { get; set; }

    [Column("IsApprove", TypeName = "bit")]
    public bool? IsApprove { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

}

// RecruitmentReasons

public class RecruitmentReason
{
    [Key]
    public int RecruitReasonPKID { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string RecruitReason { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

// SaveasDraft

public class TalentRequest_SaveDraft
{
    [Key]
    public int JobRequisitionPKID { get; set; }

    public int? JobOpeningsCount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column(TypeName = "nvarchar(2000)")]
    public string OverallExperience { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string RecruitReasonFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string Description { get; set; }

    public int? Salary { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string AdditionalNotes { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string JobPosterID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string JobTitleFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string DepartmentFKID { get; set; }

    [ForeignKey("LocationFKID")]
    public int? LocationFKID { get; set; }

    [ForeignKey("StateFKID")]
    public int? StateFKID { get; set; }

    [ForeignKey("CityFKID")]
    public int? CityFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string MandSkillsFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string GoodSkillsFKID { get; set; }

    [ForeignKey("EmploymentTypeFKID")]
    public int? EmploymentTypeFKID { get; set; }

    //  [Column(TypeName = "varchar(4000)")]
    public int? DurationFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string JobLevelFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string ShiftFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string TravelFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string ApproverFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string CollaboratorFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string StatusFKID { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string QuestionnaireFKID { get; set; }

    public int? InterviewRounds { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string InterviewLevelFKID { get; set; }

    [ForeignKey("TaskFKID")]
    public int? TaskFKID { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string ApprovedBy { get; set; }

    [Column("IsReject", TypeName = "bit")]
    public bool? IsReject { get; set; }

    [Column("IsApprove", TypeName = "bit")]
    public bool? IsApprove { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string ViewStatus { get; set; }

}

public class ApprovalLevel
{
    [Key]
    public int ApprovalLevelPKID { get; set; }


    [Column(TypeName = "nvarchar(4000)")]
    public string ApprovalLevels { get; set; }

    // [Column(TypeName = "varchar(4000)")]
    public int? RoleFKID { get; set; }


    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }


    [Column("IsDeleted", TypeName = "bit")]
    public bool? IsDeleted { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string CreatedBy { get; set; }


    [Column(TypeName = "varchar(4000)")]
    public string UpdatedBy { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }


    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}

//public class OfferLetterMgmt
//{
//    [Key]
//    public int ContentID { get; set; }

//    [Column(TypeName = "varchar(4000)")]
//    public string ContentTitle { get; set; }

//    [Column(TypeName = "varchar(max)")]
//    public string Content { get; set; }
//    public int? UserID { get; set; }

//    [Column(TypeName = "varchar(4000)")]
//    public string FilePath { get; set; }

//    [Column(TypeName = "varchar(500)")]
//    public string Moduletype { get; set; }

//    [Column("IsActive", TypeName = "bit")]
//    public bool? IsActive { get; set; }

//    [Column(TypeName = "varchar(4000)")]
//    public string CreatedBy { get; set; }

//    [Column(TypeName = "varchar(4000)")]
//    public string UpdatedBy { get; set; }

//    [Column(TypeName = "datetime")]
//    public DateTime? CreatedDate { get; set; }

//    [Column(TypeName = "datetime")]
//    public DateTime? UpdatedDate { get; set; }
//}

public class TrackUserLogin
{
    [Key]
    public int LoginID { get; set; }
    public DateTime? LoginDate { get; set; }
    public DateTime? LoginStartTime { get; set; }
    public DateTime? LoginEndTime { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string ActionName { get; set; }

    [Column(TypeName = "varchar(4000)")]
    public string UserName { get; set; }

    [Column("IsActive", TypeName = "bit")]
    public bool? IsActive { get; set; }
}





