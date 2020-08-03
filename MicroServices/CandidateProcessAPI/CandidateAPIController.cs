using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DotnetCore_TAS_CandidateAPI.Models;
using Microsoft.AspNetCore.Cors;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;

namespace DotnetCore_TAS_CandidateAPI.MicroServices.CandidateProcessAPI
{
    [EnableCors("CandCorsPolicy"), Route("api/[controller]")]
    [ApiController]
    public class CandidateAPIController : ControllerBase
    {
        private readonly CandidateProcessDBContext _context;
        private IWebHostEnvironment _hostingEnvironment;

        public CandidateAPIController(CandidateProcessDBContext context, IWebHostEnvironment hostingenvt)
        {
            _context = context;
            _hostingEnvironment = hostingenvt;
        }

        // logout from the application
        [Route("/api/Call_Logout/{ActionName}/{LogoutUser}")]
        [HttpPost]
        public async Task<ActionResult<TrackUserLogin>> Call_Logout(string ActionName, string LogoutUser)
        {
            // User Logout History

            TrackUserLogin trackuser = new TrackUserLogin();
            trackuser.UserName = LogoutUser;
            trackuser.LoginDate = DateTime.Now;
            trackuser.LoginStartTime = DateTime.Now;
            trackuser.LoginEndTime = DateTime.Now;
            trackuser.IsActive = true;
            trackuser.ActionName = ActionName;

            _context.TrackUserLogins.Add(trackuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Route("/api/populate_CurrentOpenings")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentOpenings>>> populate_CurrentOpenings()
        {
            var syncdata = await (from talent in _context.TalentRequests
                                  join jb in _context.JobTitles on Convert.ToInt32(talent.JobTitleFKID) equals jb.JobTitlePKID
                                  join city in _context.Cities on talent.CityFKID equals city.CityPKID
                                  //  join emptype in _context.EmploymentTypes on talent.EmploymentTypeFKID equals emptype.EmploymentTypePKID
                                  where talent.IsActive == true && talent.IsApprove == true
                                  select new CurrentOpenings()
                                  {
                                      JobRequisitionPKID = talent.JobRequisitionPKID,
                                      JobTitle = jb.JobTitleName,
                                      JobNature = talent.EmpcumDurationtext,
                                      Location = city.CityName,
                                      OverallExp = Convert.ToString(talent.OverallExperience),
                                      PostedDate = talent.StartDate

                                  }).ToListAsync();

            return syncdata;
        }

        [Route("/api/populate_ReqDetails_CurrentOpenings/{jobrequisitionpkid}")]
        [HttpGet("{jobrequisitionpkid}")]
        public async Task<ActionResult<IEnumerable<CurrentOpenings>>> populate_ReqDetails_CurrentOpenings(int jobrequisitionpkid)
        {
            var talentrequest = _context.TalentRequests.Where(s => s.IsActive == true && s.JobRequisitionPKID == jobrequisitionpkid).FirstOrDefault();
            // get the Mandatory skills list

            StringBuilder sbmandskills = new StringBuilder();
            string strmandskills = string.Empty;

            string[] mandskillsplit = talentrequest.MandSkillsFKID.Split(',').ToArray();

            foreach (var chkmskill in mandskillsplit)
            {
                var approvecheck = _context.Skills.FirstOrDefault(x => x.SkillsPKID == Convert.ToInt32(chkmskill));
                if (approvecheck.SkillsPKID != 0)
                {
                    sbmandskills.Append(approvecheck.SkillsName);
                    sbmandskills.Append(",");
                }
            }

            strmandskills = sbmandskills.ToString().TrimEnd(',');

            // get the Good skills list

            StringBuilder sbgoodskills = new StringBuilder();
            string strgoodskills = string.Empty;

            string[] goodskillsplit = talentrequest.GoodSkillsFKID.Split(',').ToArray();

            foreach (var chkgskill in goodskillsplit)
            {
                var approvecheck = _context.Skills.FirstOrDefault(x => x.SkillsPKID == Convert.ToInt32(chkgskill));
                if (approvecheck.SkillsPKID != 0)
                {
                    sbgoodskills.Append(approvecheck.SkillsName);
                    sbgoodskills.Append(",");
                }
            }
            strgoodskills = sbgoodskills.ToString().TrimEnd(',');

            var syncdata = await (from talent in _context.TalentRequests
                                  join jb in _context.JobTitles on Convert.ToInt32(talent.JobTitleFKID) equals jb.JobTitlePKID
                                  join city in _context.Cities on talent.CityFKID equals city.CityPKID
                                  join depart in _context.Departments on Convert.ToInt32(talent.DepartmentFKID) equals depart.DepartmentPKID
                                  join joblevel in _context.JobLevels on Convert.ToInt32(talent.JobLevelFKID) equals joblevel.JobLevelPKID
                                  join shift in _context.Shifts on Convert.ToInt32(talent.ShiftFKID) equals shift.ShiftPKID
                                  join travel in _context.Travels on Convert.ToInt32(talent.TravelFKID) equals travel.TravelPKID
                                  //  join emptype in _context.EmploymentTypes on talent.EmploymentTypeFKID equals emptype.EmploymentTypePKID
                                  where talent.IsActive == true && talent.JobRequisitionPKID == jobrequisitionpkid
                                  select new CurrentOpenings()
                                  {
                                      JobRequisitionPKID = talent.JobRequisitionPKID,
                                      JobTitle = jb.JobTitleName,
                                      JobNature = talent.EmpcumDurationtext,
                                      Location = city.CityName,
                                      OverallExp = Convert.ToString(talent.OverallExperience),
                                      PostedDate = talent.StartDate,
                                      Department = depart.DepartmentName,
                                      Joblevel = joblevel.JobLevelName,
                                      Shift = shift.ShiftType,
                                      Traveltype = travel.TravelType,
                                      Description = talent.Description,
                                      Mandskills = strmandskills,
                                      Goodskills = strgoodskills

                                  }).ToListAsync();

            return syncdata;
        }

        [Route("/api/call_insertcurrentopenings")]
        [HttpPost]
        public async Task<ActionResult<TalentCareerUpload>> PostCurrentOpenings([FromForm] FileUploadApis files)
        {
            //  var folderName = Path.Combine("FileUpload", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "FileUploads");

            var fileName = files.Resume.FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine("FileUploads", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                files.Resume.CopyTo(stream);
            }

            var jobposterid = _context.TalentRequests.Where(t => t.JobRequisitionPKID == files.JobRequisitionPKID).FirstOrDefault();
            int int_jobrefnumber = await get_JobReferenceNumber_LastInserted();

            var jobtitle = await _context.JobTitles.Where(j => j.JobTitlePKID == Convert.ToInt32(jobposterid.JobTitleFKID)).FirstOrDefaultAsync();
            var findrole = await _context.UserRoles.Where(u => u.RoleTitle == "Full Stack").FirstOrDefaultAsync();
            // var findrole = await _context.UserRoles.Where(u => u.RoleTitle == "HR Manager").FirstOrDefaultAsync();
            var getusername = await _context.Users.Where(g => g.RoleFKID == findrole.RolePKID).FirstOrDefaultAsync();
            var getstage = await _context.Statuses.Where(s => s.IsActive == true && s.StatusName == "Applied" && s.FlagStatus == "stage").FirstOrDefaultAsync();

            var values = new TalentCareerUpload
            {
                MobileNumber = files.MobileNumber,
                CandidateName = files.CandidateName,
                EmailID = files.EmailID,
                Resume = fileName,
                CurrentLocation = files.CurrentLocation,
                CurrentCompany = files.CurrentCompany,
                Designation = files.Designation,
                TotalExperience = files.TotalExperience,
                EducQualifyFKID = files.EducQualifyFKID,
                FuncSkillsFKID = files.FuncSkillsFKID,
                CreatedBy = files.CandidateName,
                CreatedDate = DateTime.Now,
                UpdatedBy = files.CandidateName,
                UploadedDate = DateTime.Now,
                IsActive = true,
                IsApprove = false,
                IsReject = false,
                JobReferenceNumber = Convert.ToString("JOBREF - " + int_jobrefnumber),
                JobPosterID = Convert.ToString(jobposterid.JobPosterID),
                RequisitionName = jobtitle.JobTitleName + " - " + Convert.ToString("JOBREF - " + int_jobrefnumber),
                StageFKID = Convert.ToInt32(getstage.StatusPKID),
                StatusFKID = Convert.ToInt32(jobposterid.StatusFKID)
            };

            _context.TalentCareerUploads.Add(values);
            await _context.SaveChangesAsync();

            //  var getjobreqid = await _context.TalentRequests.Where(x => x.JobRequisitionPKID == files.JobRequisitionPKID).FirstOrDefaultAsync();



            Task tasks = new Task();
            tasks.TasksActivity = "New Candidate Resume - " + Convert.ToString("JOBREF - " + int_jobrefnumber);
            tasks.Description = "A new resume uploaded for <" + files.JobRequisitionPKID + " + " + jobtitle.JobTitleName + ">" + ".The resume must be approved if suitable";
            tasks.ActionUserID = getusername.UserPKID;
            tasks.JobPosterID = jobposterid.JobPosterID;
            tasks.IsCompleted = false;
            tasks.IsDeleted = false;
            tasks.IsActive = true;
            tasks.IsApproved = false;
            tasks.IsRejected = false;
            tasks.CreatedDate = DateTime.Now;
            tasks.UpdatedDate = DateTime.Now;
            tasks.Moduletype = "CandidateModule";

            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            var credentials = new NetworkCredential("connectmuthu28@gmail.com", "ForverJoya$2019");

            var mail = new MailMessage()
            {
                From = new MailAddress("connectmuthu28@gmail.com"),
                Subject = "New Candidate Resume",
                Body = "New Candidate Resume - " + Convert.ToString("JOBREF - " + int_jobrefnumber)
            };

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(getusername.UserEmail));

            if (files.Resume.Length > 0)
            {
                string filename = Path.GetFileName(files.Resume.FileName);
                mail.Attachments.Add(new Attachment(files.Resume.OpenReadStream(), filename));
            }

            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            // client.Send(mail);

            EmailNotification email = new EmailNotification();
            email.MailingDate = DateTime.Now;
            email.SenderEmail = "connectmuthu28@gmail.com";
            email.Recepients = files.EmailID; // "rameshp48@gmail.com";
            email.Subject = mail.Subject;
            email.MessageBody = mail.Body;
            email.CreatedDate = DateTime.Now;

            _context.EmailNotifications.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareerUpload",
            new { id = values.CandidatePKID }, values);
        }

        public async Task<int> get_JobReferenceNumber_LastInserted()
        {
            int manualincrement = 1;
            int incrementjobrefnumber = 0;
            string jobrefnumcount = await _context.TalentCareerUploads.Select(u => u.JobReferenceNumber).MaxAsync();

            if (jobrefnumcount == null)
            {
                incrementjobrefnumber = Convert.ToInt32(jobrefnumcount) + manualincrement;
            }
            else
            {
                incrementjobrefnumber = Convert.ToInt32(jobrefnumcount.Split('-')[1].Trim()) + manualincrement;
            }

            return incrementjobrefnumber;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TalentCareerUpload>> GetCareerUpload(int id)
        {
            var careerupload = await _context.TalentCareerUploads.FindAsync(id);

            if (careerupload == null)
            {
                return NotFound();
            }

            return careerupload;
        }


        [Route("/api/call_insertpostresume")]
        [HttpPost]
        public async Task<ActionResult<TalentCareerUpload>> PostResume([FromForm] FileUploadApis files)
        {
            //  var folderName = Path.Combine("FileUpload", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "FileUploads");

            var fileName = files.Resume.FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine("FileUploads", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                files.Resume.CopyTo(stream);
            }

            // var jobposterid = _context.TalentRequests.Where(t => t.JobRequisitionPKID == files.JobRequisitionPKID).FirstOrDefault();
            int int_jobrefnumber = await get_PostResumeJobRef_LastInserted();
            var getstage = await _context.Statuses.Where(s => s.IsActive == true && s.StatusName == "Applied" && s.FlagStatus == "stage").FirstOrDefaultAsync();
            var getnewstatus = await _context.Statuses.Where(s => s.IsActive == true && s.StatusName == "New" && s.FlagStatus == "commonpoolstatus").FirstOrDefaultAsync();


            var values = new TalentCareerUpload
            {
                MobileNumber = files.MobileNumber,
                CandidateName = files.CandidateName,
                EmailID = files.EmailID,
                Resume = fileName,
                CurrentLocation = files.CurrentLocation,
                CurrentCompany = files.CurrentCompany,
                Designation = files.Designation,
                TotalExperience = files.TotalExperience,
                EducQualifyFKID = files.EducQualifyFKID,
                FuncSkillsFKID = files.FuncSkillsFKID,
                CreatedBy = files.CandidateName,
                CreatedDate = DateTime.Now,
                UpdatedBy = files.CandidateName,
                UploadedDate = DateTime.Now,
                IsActive = true,
                IsApprove = false,
                IsReject = false,
                PostResumeRefNumber = Convert.ToString("POSTRES - " + int_jobrefnumber),
                TechSkillsFKID = files.TechSkillsFKID,
                PreferredLocationFKID = files.PreferredLocationFKID,
                RequisitionName = "COMMON" + " - " + Convert.ToString("POSTRES - " + int_jobrefnumber),
                StageFKID = Convert.ToInt32(getstage.StatusPKID),
                StatusFKID = getnewstatus.StatusPKID
            };

            _context.TalentCareerUploads.Add(values);
            await _context.SaveChangesAsync();

            //  var getjobreqid = await _context.TalentRequests.Where(x => x.JobRequisitionPKID == files.JobRequisitionPKID).FirstOrDefaultAsync();

            // var jobtitle = await _context.JobTitles.Where(j => j.JobTitlePKID == Convert.ToInt32(jobposterid.JobTitleFKID)).FirstOrDefaultAsync();
            var findrole = await _context.UserRoles.Where(u => u.RoleTitle == "Full Stack").FirstOrDefaultAsync();
            var getusername = await _context.Users.Where(g => g.RoleFKID == findrole.RolePKID).FirstOrDefaultAsync();

            Task tasks = new Task();
            tasks.TasksActivity = "New Candidate Resume - " + Convert.ToString("POSTRES - " + int_jobrefnumber);
            tasks.Description = "A new resume uploaded for <" + values.PostResumeRefNumber + " + " + files.Designation + ">" + ".The resume must be approved if suitable";
            tasks.ActionUserID = getusername.UserPKID;
            //  tasks.JobPosterID = jobposterid.JobPosterID;
            tasks.IsCompleted = false;
            tasks.IsDeleted = false;
            tasks.IsActive = true;
            tasks.IsApproved = false;
            tasks.IsRejected = false;
            tasks.CreatedDate = DateTime.Now;
            tasks.UpdatedDate = DateTime.Now;
            tasks.Moduletype = "CandidateModule";


            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            var credentials = new NetworkCredential("connectmuthu28@gmail.com", "ForverJoya$2019");

            var mail = new MailMessage()
            {
                From = new MailAddress("connectmuthu28@gmail.com"),
                Subject = "New Candidate Resume",
                Body = "New Candidate Resume - " + Convert.ToString("POSTRES - " + int_jobrefnumber)
            };

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(getusername.UserEmail));

            if (files.Resume.Length > 0)
            {
                string filename = Path.GetFileName(files.Resume.FileName);
                mail.Attachments.Add(new Attachment(files.Resume.OpenReadStream(), filename));
            }

            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            // client.Send(mail);

            EmailNotification email = new EmailNotification();
            email.MailingDate = DateTime.Now;
            email.SenderEmail = "connectmuthu28@gmail.com";
            email.Recepients = files.EmailID;
            email.Subject = mail.Subject;
            email.MessageBody = mail.Body;
            email.CreatedDate = DateTime.Now;

            _context.EmailNotifications.Add(email);
            await _context.SaveChangesAsync();

            return NoContent();

            //return CreatedAtAction("GetPostResume",
            //new { id = values.CandidatePKID }, values);
        }

        public async Task<int> get_PostResumeJobRef_LastInserted()
        {
            int manualincrement = 1;
            int incrementjobrefnumber = 0;
            string jobrefnumcount = await _context.TalentCareerUploads.Select(u => u.PostResumeRefNumber).MaxAsync();

            if (jobrefnumcount == null)
            {
                incrementjobrefnumber = Convert.ToInt32(jobrefnumcount) + manualincrement;
            }
            else
            {
                incrementjobrefnumber = Convert.ToInt32(jobrefnumcount.Split('-')[1].Trim()) + manualincrement;
            }

            return incrementjobrefnumber;
        }

        [Route("/api/bind_candidateslist/{userparamvalue}/{roleuservalue}")]
        [HttpGet("{userparamvalue}/{roleuservalue}")]
        public async Task<ActionResult<IEnumerable<TalentCareer>>> bind_candidateslist(string userparamvalue, string roleuservalue)
        {
            var syncdata = (dynamic)null;
            if (roleuservalue == "HR Manager")
            {
                // var areaexpertise = await _context.Statuses.Where(a=>a.st)
                syncdata = await (from talentcareer in _context.TalentCareerUploads
                                      //join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                                      //join jobtitle in _context.JobTitles on Convert.ToInt32(talentreq.JobTitleFKID) equals jobtitle.JobTitlePKID
                                  join stat in _context.Statuses on talentcareer.StageFKID equals stat.StatusPKID
                                  join status in _context.Statuses on talentcareer.FuncSkillsFKID equals status.StatusPKID
                                  join stat1 in _context.Statuses on talentcareer.StatusFKID equals stat1.StatusPKID
                                  where talentcareer.IsActive == true
                                  select new TalentCareer()
                                  {
                                      candidatepkid = talentcareer.CandidatePKID,
                                      candidatename = talentcareer.CandidateName,
                                      requisition_name = talentcareer.RequisitionName,
                                      appliedate = talentcareer.CreatedDate,
                                      stage = stat.StatusName,
                                      areaexpertise = status.StatusName,
                                      status = stat1.StatusName,
                                      //strength = "Communication",
                                      //weakness = "weakness"
                                  }).ToListAsync();

            }
            else
            {
                syncdata = await (from talentcareer in _context.TalentCareerUploads
                                  join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                                  join inter in _context.Interviews on talentcareer.CandidatePKID equals inter.CandidateFKID
                                  join us in _context.Users on inter.AssignedTo equals us.UserPKID
                                  //join jobtitle in _context.JobTitles on Convert.ToInt32(talentreq.JobTitleFKID) equals jobtitle.JobTitlePKID
                                  join stat in _context.Statuses on talentcareer.StageFKID equals stat.StatusPKID
                                  join status in _context.Statuses on talentcareer.FuncSkillsFKID equals status.StatusPKID
                                  join stat1 in _context.Statuses on talentcareer.StatusFKID equals stat1.StatusPKID
                                  where talentcareer.IsActive == true && us.UserName == userparamvalue && inter.IsActive == true
                                  && talentreq.IsActive == true
                                  select new TalentCareer()
                                  {
                                      candidatepkid = talentcareer.CandidatePKID,
                                      candidatename = talentcareer.CandidateName,
                                      requisition_name = talentcareer.RequisitionName,
                                      appliedate = talentcareer.CreatedDate,
                                      stage = stat.StatusName,
                                      areaexpertise = status.StatusName,
                                      status = stat1.StatusName,
                                      //strength = "Communication",
                                      //weakness = "weakness"
                                  }).ToListAsync();
            }

            return syncdata;
        }

        [Route("/api/bind_requisition_name/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> bind_requisition_name(int candidatepkid)
        {
            //var getcand = await _context.TalentCareerUploads.Where(a => a.CandidatePKID == candidatepkid).FirstOrDefaultAsync();
            var getcandidate = await (from cand in _context.TalentCareerUploads
                                      where cand.CandidatePKID == candidatepkid && cand.IsActive == true
                                      select new TalentCareerUpload()
                                      {
                                          CandidateName = cand.CandidateName,
                                          EmailID = cand.EmailID
                                      }).FirstOrDefaultAsync();
            var syncdata = await (from talentcareer in _context.TalentCareerUploads
                                  where talentcareer.IsActive == true && talentcareer.CandidateName == getcandidate.CandidateName &&
                                  talentcareer.EmailID == getcandidate.EmailID
                                  select new TalentCareerUpload()
                                  {
                                      RequisitionName = talentcareer.RequisitionName,
                                      CandidatePKID = talentcareer.CandidatePKID,
                                      JobPosterID = talentcareer.JobPosterID
                                  }).ToListAsync();

            return syncdata;
        }

        [Route("/api/bind_Resume/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> bind_Resume(int candidatepkid)
        {
            var syncdata = await (from talentcareer in _context.TalentCareerUploads
                                  where talentcareer.IsActive == true && talentcareer.CandidatePKID == candidatepkid
                                  select new TalentCareerUpload()
                                  {
                                      Resume = talentcareer.Resume,
                                      CandidatePKID = talentcareer.CandidatePKID
                                  }).ToListAsync();

            return syncdata;
        }

        [Route("/api/bind_Interviewer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> bind_Interviewer()
        {
            var syncuser = await (from emp in _context.Users
                                  join ur in _context.UserRoles on emp.RoleFKID equals ur.RolePKID
                                  where emp.IsActive == true && ur.RoleTitle != "HR Manager"
                                  select new User()
                                  {
                                      UserPKID = emp.UserPKID,
                                      UserName = emp.UserName
                                  }).ToListAsync();

            return syncuser;
        }

        [Route("/api/bind_InterviewLevelRounds")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterviewLevel>>> bind_InterviewLevelRounds()
        {
            var synclevel = await (from level in _context.InterviewLevels
                                   where level.IsActive == true
                                   select new InterviewLevel()
                                   {
                                       InterviewLevelPKID = level.InterviewLevelPKID,
                                       InterviewLevelType = level.InterviewLevelType,
                                       LevelNumber = level.LevelNumber
                                   }).ToListAsync();

            return synclevel;
        }

        [Route("/api/bind_single_InterviewLevel/{interviewlevelpkid}")]
        [HttpGet("{interviewlevelpkid}")]
        public async Task<ActionResult<IEnumerable<InterviewLevel>>> bind_single_InterviewLevel(string interviewlevelpkid)
        {
            var interviewfkids = interviewlevelpkid.Split(',');
            var synconelevel = await (from level in _context.InterviewLevels.Where(i => interviewfkids.Contains(i.InterviewLevelPKID.ToString()))
                                      where level.IsActive == true // && level.InterviewLevelPKID == interviewlevelpkid
                                      select new InterviewLevel()
                                      {
                                          InterviewLevelPKID = level.InterviewLevelPKID,
                                          InterviewLevelType = level.InterviewLevelType
                                      }).ToListAsync();

            return synconelevel;
        }

        [Route("/api/bind_InterviewLevel/{candidatepkid}/{statustext}")]
        [HttpGet("{candidatepkid}/{statustext}")]
        public async Task<JsonResult> bind_InterviewLevel(int candidatepkid, string statustext)
        {
            var findstatus = await _context.Statuses.Where(s => s.StatusName == statustext).FirstOrDefaultAsync();
            var interviewfkids = (string[])null;
            var interleveltype = (dynamic)null;
            if (findstatus.StatusName == "Open")
            {
                var syncdata = await (from talentcareer in _context.TalentCareerUploads
                                      join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                                      where talentcareer.IsActive == true && talentcareer.CandidatePKID == candidatepkid
                                      && talentcareer.IsFirstLevelApprove == true && talentcareer.IsSecondLevelApprove == true
                                      select new TalentRequest()
                                      {
                                          InterviewLevelFKID = talentreq.InterviewLevelFKID
                                      }).FirstOrDefaultAsync();
                if (syncdata != null)
                {
                    interviewfkids = syncdata.InterviewLevelFKID.Split(',');

                    interleveltype = await (from tc in _context.InterviewLevels.Where(i => interviewfkids.Contains(i.InterviewLevelPKID.ToString()))
                                            select new InterviewLevel()
                                            {
                                                InterviewLevelType = tc.InterviewLevelType
                                            }).ToListAsync();
                }
                else
                {
                    interleveltype = 0;
                }

            }
            else
            {
                var syncdata = await (from talentcareer in _context.TalentCareerUploads
                                      where talentcareer.IsActive == true && talentcareer.CandidatePKID == candidatepkid
                                      && talentcareer.IsFirstLevelApprove == true && talentcareer.IsSecondLevelApprove == true
                                      select new TalentCareerUpload()
                                      {
                                          InterviewLevelFKID = talentcareer.InterviewLevelFKID
                                      }).FirstOrDefaultAsync();



                if (syncdata != null)
                {
                    if (syncdata.InterviewLevelFKID == null)
                    {
                        interleveltype = 0;
                    }
                    else
                    {
                        interviewfkids = syncdata.InterviewLevelFKID.Split(',');

                        interleveltype = await (from tc in _context.InterviewLevels.Where(i => interviewfkids.Contains(i.InterviewLevelPKID.ToString()))
                                                select new InterviewLevel()
                                                {
                                                    InterviewLevelType = tc.InterviewLevelType
                                                }).ToListAsync();
                    }

                }
                else
                {
                    interleveltype = 0;
                }


            }

            return new JsonResult(interleveltype);
        }

        public class InterviewRoundLevel
        {
            public string InterviewLevelType { get; set; }
            public string InterviewLevelPKID { get; set; }
        }



        [Route("/api/bind_CandidateStatus")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> bind_CandidateStatus()
        {
            var syncdata = await (from status in _context.Statuses
                                  where status.IsActive == true && status.FlagStatus == "commonpoolstatus" ||
                                 status.FlagStatus == "status" && status.StatusName == "Open" || status.StatusName == "New"
                                 || (status.StatusName == "Hired" && status.FlagStatus == "stage") || (status.StatusName == "Rejected" &&
                                 status.FlagStatus == "stage")
                                  select new Status()
                                  {
                                      StatusPKID = status.StatusPKID,
                                      StatusName = status.StatusName
                                  }).ToListAsync();

            return syncdata;
        }

        [Route("/api/bind_jobopening_totalexp")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> bind_jobopening_totalexp()
        {
            var synctotalexp = await (from status in _context.Statuses
                                      where status.IsActive == true && status.FlagStatus == "totalexperience"
                                      select new Status()
                                      {
                                          StatusPKID = status.StatusPKID,
                                          StatusName = status.StatusName
                                      }).ToListAsync();

            return synctotalexp;
        }

        [Route("/api/bind_jobopening_eduqualify")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> bind_jobopening_eduqualify()
        {
            var syncqualify = await (from status in _context.Statuses
                                     where status.IsActive == true && status.FlagStatus == "eduqualify"
                                     select new Status()
                                     {
                                         StatusPKID = status.StatusPKID,
                                         StatusName = status.StatusName
                                     }).ToListAsync();

            return syncqualify;
        }

        [Route("/api/bind_jobopening_funcexpert")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> bind_jobopening_funcexpert()
        {
            var syncexpert = await (from status in _context.Statuses
                                    where status.IsActive == true && status.FlagStatus == "areaexpertise"
                                    select new Status()
                                    {
                                        StatusPKID = status.StatusPKID,
                                        StatusName = status.StatusName
                                    }).ToListAsync();

            return syncexpert;
        }

        [Route("/api/bind_jobopening_prefloc")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> bind_jobopening_prefloc()
        {
            var synclocation = await (from status in _context.Statuses
                                      where status.IsActive == true && status.FlagStatus == "preflocation"
                                      select new Status()
                                      {
                                          StatusPKID = status.StatusPKID,
                                          StatusName = status.StatusName
                                      }).ToListAsync();

            return synclocation;
        }

        [Route("/api/bind_jobopening_techexpert")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> bind_jobopening_techexpert()
        {
            var synclocation = await (from status in _context.Statuses
                                      where status.IsActive == true && status.FlagStatus == "techexpertise"
                                      select new Status()
                                      {
                                          StatusPKID = status.StatusPKID,
                                          StatusName = status.StatusName
                                      }).ToListAsync();

            return synclocation;
        }

        [Route("/api/viewResume/{fileName}")]
        [HttpGet("{fileName}")]
        public async Task<FileStream> viewResume(string fileName)
        {
            var path = Path.Combine(
                           _hostingEnvironment.ContentRootPath,
                           "FileUploads", fileName);



            //   return new FileStream(filename, FileMode.Open, FileAccess.Read); 
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        [Route("/api/populate_CandidateDetails/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<CandidateDetails>>> populate_CandidateDetails(int candidatepkid)
        {
            //var getcand = await _context.TalentCareerUploads.Where(a => a.CandidatePKID == candidatepkid).FirstOrDefaultAsync();
            var getcandet = await (from cand in _context.TalentCareerUploads
                                   join stat in _context.Statuses on cand.EducQualifyFKID equals stat.StatusPKID
                                   join statusexp in _context.Statuses on cand.TotalExperience equals statusexp.StatusPKID
                                   join statexpert in _context.Statuses on cand.FuncSkillsFKID equals statexpert.StatusPKID
                                   join status in _context.Statuses on cand.StatusFKID equals status.StatusPKID
                                   where cand.CandidatePKID == candidatepkid && cand.IsActive == true
                                   //   && stat.FlagStatus == "eduqualify" && statusexp.FlagStatus == "totalexperience" && statexpert.FlagStatus == "areaexpertise"
                                   select new CandidateDetails()
                                   {
                                       EducationQualif = stat.StatusName,
                                       Experience = statusexp.StatusName,
                                       AreaExpertise = statexpert.StatusName,
                                       Uploaded_Date = cand.UploadedDate,
                                       Resume = cand.Resume,
                                       Statuspkid = status.StatusPKID,
                                       Candidatepkid = cand.CandidatePKID
                                   }).ToListAsync();

            //var totalexp = await (from cand in _context.TalentCareerUploads
            //                      join stat in _context.Statuses on cand.TotalExperience equals stat.StatusPKID
            //                      where cand.CandidatePKID == candidatepkid && cand.IsActive == true && stat.FlagStatus == "totalexperience"
            //                      select new CandidateDetails()
            //                      {
            //                          Experience = stat.StatusName
            //                      }).FirstOrDefaultAsync();
            //var syncdata = await (from talentcareer in _context.TalentCareerUploads
            //                      where talentcareer.IsActive == true
            //                      select new CandidateDetails()
            //                      {
            //                          RequisitionName = talentcareer.RequisitionName,
            //                          CandidatePKID = talentcareer.CandidatePKID
            //                      }).ToListAsync();

            return getcandet;
        }

        public class CandidateDetails
        {
            public string EducationQualif { get; set; }
            public string Experience { get; set; }
            public string AreaExpertise { get; set; }
            public string Resume { get; set; }
            public DateTime? Uploaded_Date { get; set; }
            public int Statuspkid { get; set; }
            public int Candidatepkid { get; set; }

        }

        [Route("/api/bind_UserDetails/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> bind_UserDetails(int candidatepkid)
        {
            // var areaexpertise = await _context.Statuses.Where(a=>a.st)
            var syncuserdet = await (from talentcareer in _context.TalentCareerUploads
                                     where talentcareer.IsActive == true && talentcareer.CandidatePKID == candidatepkid
                                     select new TalentCareerUpload()
                                     {
                                         CandidateName = talentcareer.CandidateName,
                                         EmailID = talentcareer.EmailID,
                                         MobileNumber = talentcareer.MobileNumber
                                     }).ToListAsync();

            return syncuserdet;
        }

        [Route("/api/updateCandComments/{candidatepkid}/{comments}/{commentsoptions}")]
        [HttpPut("{candidatepkid}/{comments}/{commentsoptions}")]
        public async Task<IActionResult> updateCandComments(int candidatepkid, string comments, string commentsoptions)
        {
            var candet = await _context.TalentCareerUploads.Where(t => t.CandidatePKID == candidatepkid).FirstOrDefaultAsync();

            if (candidatepkid == 0)
            {
                return BadRequest();
            }
            else
            {
                if (commentsoptions == "updateStrength")
                {
                    candet.Strengths += comments + ",";
                }
                else
                {
                    candet.Weaknesses += comments + ",";
                }

            }
            _context.Entry(candet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return NoContent();
        }

        //[Route("/api/GetCandInterviewDateandTime1/{userparamvalue}/{candidatepkid}")]
        //[HttpGet("{userparamvalue}/{candidatepkid}")]
        //public async Task<ActionResult<IEnumerable<Interview>>> GetCandInterviewDateandTime(string userparamvalue, int candidatepkid)
        //{
        //    // var areaexpertise = await _context.Statuses.Where(a=>a.st)
        //    var syncuserdet = await (from intview in _context.Interviews
        //                            join getuser in _context.Users on intview.AssignedTo equals getuser.UserPKID
        //                             where getuser.UserName == userparamvalue && intview.CandidateFKID == candidatepkid
        //                             select new Interview()
        //                             {
        //                              InterviewDate = intview.InterviewDate,
        //                              Start_Time = intview.Start_Time,
        //                              InterviewLevelType = intview.InterviewLevelType
        //                             }).ToListAsync();

        //    return syncuserdet;
        //}viewInterviewDetailsbyHR

        [Route("/api/GetCandInterviewDateandTime/{userparamvalue}/{candidatepkid}/{statuspkid}")]
        [HttpGet("{userparamvalue}/{candidatepkid}/{statuspkid}")]
        public async Task<ActionResult<IEnumerable<Interview>>> GetInterviewDetails(string userparamvalue, int candidatepkid, int statuspkid)
        {
            // var areaexpertise = await _context.Statuses.Where(a=>a.st)
            var syncuserdet = await (from intview in _context.Interviews
                                     join getuser in _context.Users on intview.AssignedTo equals getuser.UserPKID
                                     where getuser.UserName == userparamvalue && intview.CandidateFKID == candidatepkid
                                     && intview.IsActive == true // && intview.StatusFKID == statuspkid
                                     select new Interview()
                                     {
                                         InterviewPKID = intview.InterviewPKID,
                                         InterviewDate = intview.InterviewDate,
                                         Start_Time = intview.Start_Time,
                                         InterviewLevelType = intview.InterviewLevelType,
                                         AssignedTo = intview.AssignedTo,
                                         IsApproved = intview.IsApproved,
                                         IsRejected = intview.IsRejected,
                                         IsAddAnotherRound = intview.IsAddAnotherRound,
                                         IsOnhold = intview.IsOnhold,
                                         DelegatedTo = intview.DelegatedTo
                                     }).ToListAsync();

            return syncuserdet;
        }

        [Route("/api/viewInterviewDetailsbyHR/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<ViewStagesByHR>>> viewInterviewDetailsbyHR(int candidatepkid)
        {
            // var areaexpertise = await _context.Statuses.Where(a=>a.st)
            var syncuserdet = await (from intview in _context.Interviews
                                     join getuser in _context.Users on intview.AssignedTo equals getuser.UserPKID
                                     where intview.CandidateFKID == candidatepkid && intview.IsActive == true
                                     select new ViewStagesByHR()
                                     {
                                         InterviewPKID = intview.InterviewPKID,
                                         InterviewDate = intview.InterviewDate,
                                         Start_Time = intview.Start_Time,
                                         InterviewLevelType = intview.InterviewLevelType,
                                         AssignedTo = intview.AssignedTo,
                                         IsApproved = intview.IsApproved,
                                         IsRejected = intview.IsRejected,
                                         IsAddAnotherRound = intview.IsAddAnotherRound,
                                         IsOnhold = intview.IsOnhold,
                                         DelegatedTo = intview.DelegatedTo,
                                         Username = _context.Users.Where(i => i.UserPKID == intview.DelegatedTo).Select(x => x.UserName).FirstOrDefault()
                                     }).ToListAsync();

            return syncuserdet;
        }

        public class ViewStagesByHR
        {
            public int InterviewPKID { get; set; }
            public int? DelegatedTo { get; set; }
            public int? AssignedTo { get; set; }
            public DateTime? InterviewDate { get; set; }
            public DateTime Start_Time { get; set; }
            public int StatusFKID { get; set; }
            public string InterviewLevelType { get; set; }
            public bool? IsApproved { get; set; }
            public bool? IsRejected { get; set; }
            public bool? IsAddAnotherRound { get; set; }
            public bool? IsOnhold { get; set; }
            public string InterviewScheduledby { get; set; }
            public int CandidateFKID { get; set; }
            public int taskspkid { get; set; }
            public int interviewpkid { get; set; }
            public string Createdby { get; set; }
            public string Remarks { get; set; }
            public string Username { get; set; }

        }

        // Interview Assessment form

        [Route("/api/bind_CandidateName/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> bind_CandidateName(int candidatepkid)
        {
            // var areaexpertise = await _context.Statuses.Where(a=>a.st)
            var candname = await (from tc in _context.TalentCareerUploads
                                  where tc.CandidatePKID == candidatepkid
                                  select new TalentCareerUpload()
                                  {
                                      CandidatePKID = tc.CandidatePKID,
                                      CandidateName = tc.CandidateName
                                  }).ToListAsync();

            return candname;
        }

        [Route("/api/bind_Interviewer_InterviewAssessment/{candidatepkid}/{userparamvalue}/{interviewer}")]
        [HttpGet("{candidatepkid}/{userparamvalue}/{interviewer}")]
        public async Task<ActionResult<IEnumerable<User>>> bind_Interviewer_InterviewAssessment(int candidatepkid, string userparamvalue, int interviewer)
        {
            var interviewers = (dynamic)null;

            try
            {
                var chkassignedto = await _context.Users.Where(x => x.UserName == userparamvalue).FirstOrDefaultAsync();

                var roletitle = await _context.UserRoles.Where(a => a.RolePKID == chkassignedto.RoleFKID).FirstOrDefaultAsync();

                //   var schdatandtime = await _context.Interviews.Where(i => i.CandidateFKID == candidatepkid && i.IsActive == true).FirstOrDefaultAsync();


                if (roletitle.RoleTitle != "HR Manager")
                {
                    interviewers = await (from tc in _context.Interviews
                                          join assusers in _context.Users on tc.AssignedTo equals assusers.UserPKID
                                          where tc.IsActive == true && tc.AssignedTo == chkassignedto.UserPKID
                                          && tc.CandidateFKID == candidatepkid
                                          select new User()
                                          {
                                              UserPKID = assusers.UserPKID,
                                              UserName = assusers.UserName
                                          }).ToListAsync();
                }
                else
                {
                    interviewers = await (from tc in _context.Interviews
                                          join assusers in _context.Users on tc.AssignedTo equals interviewer
                                          where tc.IsActive == true && tc.AssignedTo == assusers.UserPKID
                                          && tc.CandidateFKID == candidatepkid
                                          select new User()
                                          {
                                              UserPKID = assusers.UserPKID,
                                              UserName = assusers.UserName
                                          }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //  var assignedto = await _context.Interviews.Where(x => x.CandidateFKID == candidatepkid).FirstOrDefaultAsync();



            return interviewers;
        }

        [Route("/api/bind_Reqname_InterviewAssessment/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> bind_Reqname_InterviewAssessment(int candidatepkid)
        {
            // var areaexpertise = await _context.Statuses.Where(a=>a.st)
            var reqname = await (from tc in _context.TalentCareerUploads
                                 where tc.CandidatePKID == candidatepkid
                                 select new TalentCareerUpload()
                                 {
                                     RequisitionName = tc.RequisitionName,
                                     CandidatePKID = tc.CandidatePKID
                                 }).ToListAsync();

            return reqname;
        }

        [Route("/api/bind_Designation_InterviewAssessment/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> bind_Designation_InterviewAssessment(int candidatepkid)
        {
            // var areaexpertise = await _context.Statuses.Where(a=>a.st)
            var designation = await (from tc in _context.TalentCareerUploads
                                     where tc.CandidatePKID == candidatepkid
                                     select new TalentCareerUpload()
                                     {
                                         Designation = tc.Designation,
                                         CandidatePKID = tc.CandidatePKID
                                     }).ToListAsync();

            return designation;
        }

        [Route("/api/bind_InterviewLevel_InterviewAssessment/{candidatepkid}/{userparamvalue}/{assigninterviewer}")]
        [HttpGet("{candidatepkid}/{userparamvalue}/{assigninterviewer}")]
        public async Task<ActionResult<IEnumerable<InterviewLevel>>> bind_InterviewLevel_InterviewAssessment(int candidatepkid, string userparamvalue, int assigninterviewer)
        {
            var chkassignedto = await _context.Users.Where(x => x.UserName == userparamvalue).FirstOrDefaultAsync();

            var roletitle = await _context.UserRoles.Where(a => a.RolePKID == chkassignedto.RoleFKID).FirstOrDefaultAsync();
            var appendtext = (dynamic)null;
            if (roletitle.RoleTitle != "HR Manager")
            {
                var interviewlevel = await (from tc in _context.Interviews
                                            join user in _context.Users on tc.AssignedTo equals user.UserPKID
                                            where tc.IsActive == true && tc.AssignedTo == chkassignedto.UserPKID && tc.CandidateFKID == candidatepkid
                                            select new Interview()
                                            {
                                                InterviewPKID = tc.InterviewPKID,
                                                InterviewLevelType = tc.InterviewLevelType
                                            }).FirstOrDefaultAsync();

                appendtext = await (from intlevel in _context.InterviewLevels
                                    where intlevel.InterviewLevelType == interviewlevel.InterviewLevelType && intlevel.IsActive == true
                                    select new InterviewLevel()
                                    {
                                        InterviewLevelPKID = intlevel.InterviewLevelPKID,
                                        InterviewLevelType = intlevel.InterviewLevelType
                                    }).ToListAsync();
            }
            else
            {
                var interviewlevel = await (from tc in _context.Interviews
                                                //join user in _context.Users on tc.AssignedTo equals user.UserPKID
                                            where tc.IsActive == true && tc.CandidateFKID == candidatepkid && tc.AssignedTo == assigninterviewer
                                            select new Interview()
                                            {
                                                InterviewPKID = tc.InterviewPKID,
                                                InterviewLevelType = tc.InterviewLevelType
                                            }).FirstOrDefaultAsync();

                appendtext = await (from intlevel in _context.InterviewLevels
                                    join inter in _context.Interviews on interviewlevel.InterviewPKID equals inter.InterviewPKID
                                    join user in _context.Users on inter.AssignedTo equals user.UserPKID
                                    where intlevel.InterviewLevelType == interviewlevel.InterviewLevelType
                                    select new InterviewLevel()
                                    {
                                        InterviewLevelPKID = intlevel.InterviewLevelPKID,
                                        InterviewLevelType = intlevel.InterviewLevelType
                                    }).ToListAsync();
            }


            return appendtext;
        }

        [Route("/api/populate_InterviewDetails_InterAssess/{candidatepkid}/{userparamvalue}/{interviewpkid}")]
        [HttpGet("{candidatepkid}/{userparamvalue}/{interviewpkid}")]
        public async Task<ActionResult<IEnumerable<Interview>>> populate_InterviewDetails_InterAssess(int candidatepkid, string userparamvalue, int interviewpkid)
        {
            var chkassignedto = await _context.Users.Where(x => x.UserName == userparamvalue).FirstOrDefaultAsync();

            var assignedto = await _context.Interviews.Where(x => x.AssignedTo == chkassignedto.UserPKID &&
            x.CandidateFKID == candidatepkid && x.IsActive == true && x.InterviewPKID == interviewpkid).FirstOrDefaultAsync();

            var interdateandtime = (dynamic)null;

            if (assignedto != null)
            {
                interdateandtime = await (from tc in _context.Interviews
                                          join user in _context.Users on tc.AssignedTo equals user.UserPKID
                                          where tc.IsActive == true && tc.AssignedTo == chkassignedto.UserPKID
                                          && tc.CandidateFKID == candidatepkid && tc.InterviewPKID == interviewpkid
                                          select new Interview()
                                          {
                                              InterviewPKID = tc.InterviewPKID,
                                              InterviewDate = tc.InterviewDate,
                                              Start_Time = tc.Start_Time,
                                              End_Time = tc.End_Time,
                                              InterviewLevelType = tc.InterviewLevelType
                                          }).ToListAsync();
            }



            return interdateandtime;
        }

        [Route("/api/verifyAssessmentForm/{candidatepkid}/{assigninterviewer}/{schedsdate}/{interviewpkid}")]
        [HttpGet("{candidatepkid}/{assigninterviewer}/{schedsdate}/{interviewpkid}")]
        public async Task<int> verifyAssessmentForm(int candidatepkid, int assigninterviewer, DateTime schedsdate, int interviewpkid)
        {
            var assesscount = (dynamic)null;
            try
            {
                var assessform = await (from intview in _context.Interviews
                                        where intview.CandidateFKID == candidatepkid && intview.InterviewPKID == interviewpkid
                                        && intview.IsActive == true
                                        select new Interview()
                                        {
                                            InterviewPKID = intview.InterviewPKID
                                        }).FirstOrDefaultAsync();

                if (assessform == null)
                {
                    assesscount = 0;
                }
                else
                {
                    var findhr = _context.Users.Where(i => i.UserPKID == assigninterviewer).FirstOrDefaultAsync().Result.RoleFKID.ToString()
                        .Split(',').Contains(_context.UserRoles.Where(i => i.RoleTitle == "HR Manager").FirstOrDefaultAsync().Result.RolePKID.ToString());
                    if (findhr == true)
                    {
                        assesscount = 1;
                    }
                    else
                    {
                        assesscount = await (from interass in _context.InterviewAssessments
                                             where interass.InterviewFKID == assessform.InterviewPKID && interass.IsActive == true
                                             && interass.CandidateFKID == candidatepkid
                                             select new InterviewAssessment()).CountAsync();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return assesscount;
        }

        [Route("/api/disableforOtherRoles/{candidatepkid}/{assigninterviewer}/{interviewpkid}")]
        [HttpGet("{candidatepkid}/{assigninterviewer}/{interviewpkid}")]
        public async Task<int> disableforOtherRoles(int candidatepkid, int assigninterviewer, int interviewpkid)
        {
            var assesscount = (dynamic)null;
            try
            {
                var assessform = await (from intview in _context.Interviews
                                        where intview.CandidateFKID == candidatepkid && intview.AssignedTo == assigninterviewer
                                        && intview.IsActive == true && intview.InterviewPKID == interviewpkid
                                        select new Interview()
                                        {
                                            InterviewPKID = intview.InterviewPKID
                                        }).FirstOrDefaultAsync();

                if (assessform == null)
                {
                    assesscount = 0;
                }
                else
                {
                    assesscount = await (from interass in _context.InterviewAssessments
                                         where interass.InterviewFKID == assessform.InterviewPKID && interass.IsActive == true
                                         && interass.CandidateFKID == candidatepkid
                                         select new InterviewAssessment()).CountAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return assesscount;
        }

        [Route("/api/disableforHR/{candidatepkid}/{assigninterviewer}/{statuspkid}/{interviewpkid}")]
        [HttpGet("{candidatepkid}/{assigninterviewer}/{statuspkid}/{interviewpkid}")]
        public async Task<int> disableforHR(int candidatepkid, int assigninterviewer, int statuspkid, int interviewpkid)
        {
            var assesscount = (dynamic)null;
            try
            {
                var assessform = await (from intview in _context.Interviews
                                        where intview.CandidateFKID == candidatepkid && intview.AssignedTo == assigninterviewer
                                        && intview.IsActive == true && intview.StatusFKID == statuspkid && intview.InterviewPKID == interviewpkid
                                        select new Interview()
                                        {
                                            InterviewPKID = intview.InterviewPKID
                                        }).FirstOrDefaultAsync();

                if (assessform == null)
                {
                    assesscount = 0;
                }
                else
                {
                    assesscount = await (from interass in _context.InterviewAssessments
                                         where interass.InterviewFKID == assessform.InterviewPKID && interass.IsActive == true
                                         && interass.CandidateFKID == candidatepkid
                                         select new InterviewAssessment()).CountAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return assesscount;
        }



        [Route("/api/DisableInterviewStages/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<int> DisableInterviewStages(int candidatepkid)
        {
            var disabcount = await _context.Interviews.Where(x => x.CandidateFKID == candidatepkid && x.IsActive == true
                                && x.IsRejected == true || x.IsOnhold == true).CountAsync();
            int disablecount = 0;
            disablecount = disabcount;
            return disablecount;
        }


        [Route("/api/populatealldet_InterviewAssess/{candidatepkid}/{assigninterviewer}/{interviewpkid}")]
        [HttpGet("{candidatepkid}/{assigninterviewer}/{interviewpkid}")]
        public async Task<PopulateInterviewAssessment> populatealldet_InterviewAssess(int candidatepkid, int assigninterviewer, int interviewpkid)
        {
            // var talentrequest = _context.TalentRequests.Where(s => s.IsActive == true && s.JobPosterID == talent.JobPosterID).FirstOrDefault();


            // var areaexpertise = await _context.Statuses.Where(a=>a.st)
            var assessform = await (from intview in _context.Interviews
                                    join viewass in _context.InterviewAssessments on intview.InterviewPKID equals viewass.InterviewFKID
                                    where intview.CandidateFKID == candidatepkid && intview.IsActive == true && viewass.IsActive == true
                                    && intview.AssignedTo == assigninterviewer && intview.InterviewPKID == interviewpkid
                                    select new Interview()
                                    {
                                        InterviewPKID = intview.InterviewPKID,
                                        InterviewDate = intview.InterviewDate,
                                        Start_Time = intview.Start_Time,
                                        InterviewLevelType = intview.InterviewLevelType,
                                        AssignedTo = intview.AssignedTo,
                                        End_Time = intview.End_Time
                                    }).FirstOrDefaultAsync();

            var interviewlevel = await (from intlevel in _context.InterviewLevels
                                        where intlevel.InterviewLevelType == assessform.InterviewLevelType
                                        select new InterviewLevel()
                                        {
                                            InterviewLevelPKID = intlevel.InterviewLevelPKID
                                        }).FirstOrDefaultAsync();

            var candidatename = await (from tc in _context.TalentCareerUploads
                                       where tc.CandidatePKID == candidatepkid
                                       select new TalentCareerUpload()
                                       {
                                           CandidatePKID = tc.CandidatePKID,
                                           Designation = tc.Designation,
                                           JobReferenceNumber = tc.JobReferenceNumber,
                                           RequisitionName = tc.RequisitionName
                                       }).FirstOrDefaultAsync();

            var interass = await (from interassess in _context.InterviewAssessments
                                  where interassess.CandidateFKID == candidatepkid && interassess.InterviewFKID == assessform.InterviewPKID && interassess.IsActive == true
                                  select new InterviewAssessment()
                                  {
                                      Strength = interassess.Strength,
                                      Comments = interassess.Comments,
                                      Weakness = interassess.Weakness,
                                      Ratings = interassess.Ratings,
                                      IsApproved = interassess.IsApproved,
                                      IsRejected = interassess.IsRejected,
                                      IsAddAnotherRound = interassess.IsAddAnotherRound,
                                      IsOnhold = interassess.IsOnhold
                                  }).FirstOrDefaultAsync();

            var flagstatus = await (from stat in _context.Statuses
                                    where stat.StatusPKID == interass.Ratings
                                    select new Status()
                                    {
                                        FlagStatus = stat.FlagStatus
                                    }).FirstOrDefaultAsync();

            var assquestions = _context.InterviewAssessments.Where(x => x.InterviewFKID == assessform.InterviewPKID).FirstOrDefault();

            StringBuilder questionsb = new StringBuilder();
            string strquestions = string.Empty;
            string[] strqueslist = assquestions.AssessmentQuesFKID.Split(',').ToArray();

            foreach (var chkapp in strqueslist)
            {
                var questioncheck = _context.AssessmentQuestions.FirstOrDefault(x => x.AssessmentQuesPKID == Convert.ToInt32(chkapp));
                if (questioncheck.AssessmentQuesPKID != 0)
                {
                    questionsb.Append(questioncheck.Answers);
                    questionsb.Append(",");
                }
            }
            strquestions = questionsb.ToString().TrimEnd(',');

            var popassform = await (from tc in _context.TalentCareerUploads
                                    select new PopulateInterviewAssessment()
                                    {
                                        InterviewDate = assessform.InterviewDate,
                                        Startime = assessform.Start_Time,
                                        EndTime = assessform.End_Time,
                                        Assessquesfkid = strquestions,
                                        Strength = interass.Strength,
                                        Weakness = interass.Weakness,
                                        Comments = interass.Comments,
                                        Candidatepkid = candidatepkid,
                                        AssignedTo = assessform.AssignedTo,
                                        InterviewLevelType = assessform.InterviewLevelType,
                                        Designation = candidatename.Designation,
                                        Flagstatus = flagstatus.FlagStatus,
                                        Interviewpkid = assessform.InterviewPKID,
                                        InterviewLevelPKID = interviewlevel.InterviewLevelPKID,
                                        IsApproved = interass.IsApproved,
                                        IsRejected = interass.IsRejected,
                                        IsAnotheround = interass.IsAddAnotherRound,
                                        IsOnhold = interass.IsOnhold
                                    }).FirstOrDefaultAsync();

            return popassform;
        }

        public class PopulateInterviewAssessment
        {
            public int? AssignedTo { get; set; }
            public DateTime? InterviewDate { get; set; }
            public DateTime Startime { get; set; }
            public DateTime EndTime { get; set; }
            public int Interviewpkid { get; set; }
            public string Assessquesfkid { get; set; }
            public string Strength { get; set; }
            public string Weakness { get; set; }
            public string Comments { get; set; }
            public int Candidatepkid { get; set; }
            public int InterviewLevelPKID { get; set; }
            public string InterviewLevelType { get; set; }
            public string Designation { get; set; }
            public string Flagstatus { get; set; }
            public bool? IsApproved { get; set; }
            public bool? IsRejected { get; set; }
            public bool? IsAnotheround { get; set; }
            public bool? IsOnhold { get; set; }



        }

        [Route("/api/postAssessFormValues")]
        [HttpPost]
        public async Task<ActionResult<InterviewAssessment>> postAssessFormValues([FromForm] InsertInterviewAssessment interassess)
        {
            try
            {

                //   await updateTasks(interassess.taskspkid);

                bool isonhold = false;

                string strassesspkids = await InsertAssessAnswers(interassess.AssessmentAnswers, interassess.CreatedBy);

                var ratingvalue = await _context.Statuses.Where(x => x.FlagStatus == interassess.Ratings).FirstOrDefaultAsync();

                //  bool isfilter = true;

                if (interassess.IsFilterCandidates == "accept")
                {
                    interassess.IsApproved = true;
                }
                else if (interassess.IsFilterCandidates == "reject")
                {
                    interassess.IsRejected = true;
                }
                else if (interassess.IsFilterCandidates == "takeanotheround")
                {
                    interassess.IsAnotheround = true;
                }
                else
                {
                    interassess.IsOnhold = true;
                    isonhold = true;
                }

                await updateInterviewTab(interassess.InterviewDate, interassess.Start_Time, interassess.End_Time, interassess.InterviewFKID, isonhold);


                var assessanswer = new InterviewAssessment
                {
                    AssessedBy = interassess.AssessedBy,
                    CandidateFKID = interassess.CandidateFKID,
                    InterviewFKID = interassess.InterviewFKID,
                    InterviewLevelFKID = interassess.InterviewLevelFKID,
                    AssessmentQuesFKID = strassesspkids,
                    Ratings = ratingvalue.StatusPKID,
                    Strength = interassess.Strength,
                    Weakness = interassess.Weakness,
                    Comments = interassess.Comments,
                    IsOnhold = interassess.IsOnhold,
                    IsApproved = interassess.IsApproved,
                    IsRejected = interassess.IsRejected,
                    IsAddAnotherRound = interassess.IsAnotheround,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = interassess.CreatedBy,
                    UpdatedBy = interassess.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                _context.InterviewAssessments.Add(assessanswer);
                await _context.SaveChangesAsync();

                var findcandidatepkid = await _context.InterviewResults.Where(i => i.CandidateFKID == interassess.CandidateFKID && i.IsActive == true).FirstOrDefaultAsync();

                StringBuilder sbuilder = new StringBuilder();

                var findusername = await _context.Users.Where(i => i.UserName == interassess.CreatedBy && i.IsActive == true).FirstOrDefaultAsync();

                var findstatus = await _context.Interviews.Where(x => x.InterviewPKID == interassess.InterviewFKID && x.IsActive == true).FirstOrDefaultAsync();

                var findjobposterid = await _context.TalentCareerUploads.Where(t => t.CandidatePKID == interassess.CandidateFKID && t.IsActive == true).FirstOrDefaultAsync();

                if (findjobposterid.JobPosterID == null)
                {
                    var fincandidatepkid = await _context.InterviewResults.Where(i => i.CandidateFKID == interassess.CandidateFKID && i.IsActive == true).CountAsync();

                    if (fincandidatepkid == 0)
                    {
                        var interesults = new InterviewResult
                        {
                            InterviewFKID = Convert.ToString(interassess.InterviewFKID),
                            CandidateFKID = interassess.CandidateFKID,
                            ApprovedBy = Convert.ToString(findusername.UserPKID),
                            StatusFKID = findstatus.StatusFKID,
                            AttendedRounds = 1,
                            TotalRatings = Convert.ToString(ratingvalue.StatusPKID),
                            IsActive = true,
                            IsDeleted = false,
                            IsApproved = false,
                            IsRejected = false,
                            CreatedBy = interassess.CreatedBy,
                            UpdatedBy = interassess.CreatedBy,
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            InterviewLevelFKID = Convert.ToString(interassess.InterviewLevelFKID)
                        };

                        _context.InterviewResults.Add(interesults);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var updatentity = await _context.InterviewResults.Where(x => x.CandidateFKID == interassess.CandidateFKID && x.IsActive == true).FirstOrDefaultAsync();

                        if (updatentity == null)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            int manualincrement = 1;
                            int increment = 0;
                            StringBuilder sbupdintfkid = new StringBuilder();

                            sbupdintfkid.Append(updatentity.InterviewFKID);
                            sbupdintfkid.Append(",");
                            sbupdintfkid.Append(interassess.InterviewFKID);

                            updatentity.InterviewFKID = sbupdintfkid.ToString().TrimEnd(',');

                            StringBuilder sbupdapproved = new StringBuilder();

                            sbupdapproved.Append(updatentity.ApprovedBy);
                            sbupdapproved.Append(",");
                            sbupdapproved.Append(findusername.UserPKID);

                            updatentity.ApprovedBy = sbupdapproved.ToString().TrimEnd(',');

                            increment = Convert.ToInt32(updatentity.AttendedRounds);
                            updatentity.AttendedRounds = increment + manualincrement;

                            StringBuilder sbupdattrounds = new StringBuilder();

                            sbupdattrounds.Append(updatentity.TotalRatings);
                            sbupdattrounds.Append(",");
                            sbupdattrounds.Append(ratingvalue.StatusPKID);

                            updatentity.TotalRatings = sbupdattrounds.ToString().TrimEnd(',');

                            StringBuilder sbinterlevelfkid = new StringBuilder();

                            sbinterlevelfkid.Append(updatentity.InterviewLevelFKID);
                            sbinterlevelfkid.Append(",");
                            sbinterlevelfkid.Append(interassess.InterviewLevelFKID);

                            updatentity.InterviewLevelFKID = sbinterlevelfkid.ToString().TrimEnd(',');

                            updatentity.UpdatedBy = interassess.CreatedBy;
                            updatentity.UpdatedDate = DateTime.Now;
                            await _context.SaveChangesAsync();

                        }
                    }
                }
                else if (findjobposterid.JobPosterID != null || findjobposterid.JobPosterID != "")
                {
                    var findcandidateid = await _context.InterviewResults.Where(i => i.CandidateFKID == interassess.CandidateFKID && i.IsActive == true).CountAsync();

                    if (findcandidateid == 0)
                    {
                        var interesults = new InterviewResult
                        {
                            InterviewFKID = Convert.ToString(interassess.InterviewFKID),
                            CandidateFKID = interassess.CandidateFKID,
                            ApprovedBy = Convert.ToString(findusername.UserPKID),
                            StatusFKID = findstatus.StatusFKID,
                            JobPosterID = findjobposterid.JobPosterID,
                            AttendedRounds = 1,
                            TotalRatings = Convert.ToString(ratingvalue.StatusPKID),
                            IsActive = true,
                            IsDeleted = false,
                            IsApproved = false,
                            IsRejected = false,
                            CreatedBy = interassess.CreatedBy,
                            UpdatedBy = interassess.CreatedBy,
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            InterviewLevelFKID = Convert.ToString(interassess.InterviewLevelFKID)
                        };

                        _context.InterviewResults.Add(interesults);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var updatentity = await _context.InterviewResults.Where(x => x.CandidateFKID == interassess.CandidateFKID && x.IsActive == true).FirstOrDefaultAsync();

                        if (updatentity == null)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            int manualincrement = 1;
                            int increment = 0;
                            StringBuilder sbupdintfkid = new StringBuilder();

                            sbupdintfkid.Append(updatentity.InterviewFKID);
                            sbupdintfkid.Append(",");
                            sbupdintfkid.Append(interassess.InterviewFKID);

                            updatentity.InterviewFKID = sbupdintfkid.ToString().TrimEnd(',');

                            StringBuilder sbupdapproved = new StringBuilder();

                            sbupdapproved.Append(updatentity.ApprovedBy);
                            sbupdapproved.Append(",");
                            sbupdapproved.Append(findusername.UserPKID);

                            updatentity.ApprovedBy = sbupdapproved.ToString().TrimEnd(',');

                            increment = Convert.ToInt32(updatentity.AttendedRounds);
                            updatentity.AttendedRounds = increment + manualincrement;

                            StringBuilder sbupdattrounds = new StringBuilder();

                            sbupdattrounds.Append(updatentity.TotalRatings);
                            sbupdattrounds.Append(",");
                            sbupdattrounds.Append(ratingvalue.StatusPKID);

                            updatentity.TotalRatings = sbupdattrounds.ToString().TrimEnd(',');

                            StringBuilder sbinterlevelfkid = new StringBuilder();

                            sbinterlevelfkid.Append(updatentity.InterviewLevelFKID);
                            sbinterlevelfkid.Append(",");
                            sbinterlevelfkid.Append(interassess.InterviewLevelFKID);

                            updatentity.InterviewLevelFKID = sbinterlevelfkid.ToString().TrimEnd(',');

                            updatentity.UpdatedBy = interassess.CreatedBy;
                            updatentity.UpdatedDate = DateTime.Now;
                            await _context.SaveChangesAsync();

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return NoContent();

        }

        public async Task<string> InsertAssessAnswers(string strassessanswers, string strcreatedby)
        {
            StringBuilder sbassessanswers = new StringBuilder();
            string assessanswers = string.Empty;
            string[] splitassessanswers = strassessanswers.Split(',').ToArray();
            foreach (var chkassanswers in splitassessanswers)
            {
                //var assessans = await _context.AssessmentQuestions.FirstOrDefaultAsync(x => x.Answers == chkassanswers);
                //if (assessans != null)
                //{
                //    sbassessanswers.Append(assessans.AssessmentQuesPKID);
                //    sbassessanswers.Append(",");
                // }
                //  else
                //   {
                AssessmentQuestion addassquestion = new AssessmentQuestion();

                addassquestion.Answers = chkassanswers;
                addassquestion.IsActive = true;
                addassquestion.IsDeleted = false;
                addassquestion.CreatedBy = strcreatedby;
                addassquestion.UpdatedBy = strcreatedby;
                addassquestion.CreatedDate = DateTime.Now;
                addassquestion.UpdatedDate = DateTime.Now;

                await LastInsertedAssessAnswers(addassquestion);

                var lastinserted = await _context.AssessmentQuestions.Select(x => x.AssessmentQuesPKID).MaxAsync();
                sbassessanswers.Append(lastinserted);
                sbassessanswers.Append(",");

                //  }
            }
            assessanswers = sbassessanswers.ToString().TrimEnd(',');
            return assessanswers;

        }

        public async Task<ActionResult<AssessmentQuestion>> LastInsertedAssessAnswers(AssessmentQuestion assessanswers)
        {
            _context.AssessmentQuestions.Add(assessanswers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssessmentQues", new { id = assessanswers.AssessmentQuesPKID }, assessanswers);
        }

        public async Task<ActionResult<AssessmentQuestion>> GetAssessmentQues(int id)
        {
            var awaitassessanswers = await _context.AssessmentQuestions.FindAsync(id);

            if (awaitassessanswers == null)
            {
                return NotFound();
            }

            return awaitassessanswers;
        }

        public async Task<IActionResult> updateInterviewTab(DateTime interviewdate, DateTime startime, DateTime endtime, int interviewfkid, bool isonhold)
        {
            var updatentity = await _context.Interviews.Where(x => x.InterviewPKID == interviewfkid).FirstOrDefaultAsync();

            if (updatentity == null)
            {
                return BadRequest();
            }
            else
            {
                updatentity.InterviewDate = interviewdate;
                updatentity.Start_Time = startime;
                updatentity.End_Time = endtime;
                if (isonhold == true)
                {
                    updatentity.IsOnhold = true;
                }
                //  updatentity.IsOnhold = true;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public async Task<IActionResult> updateTasks(int taskspkid)
        {
            var updatetaskentity = await _context.Tasks.Where(x => x.TasksPKID == taskspkid).FirstOrDefaultAsync();

            if (updatetaskentity == null)
            {
                return BadRequest();
            }
            else
            {
                updatetaskentity.IsCompleted = true;
                updatetaskentity.UpdatedDate = DateTime.Now;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //public DateTime GetTime(DateTime start_time)
        //{
        //    TimeSpan ts = new TimeSpan();
        //    ts.Subtract(start_time);
        //    return ts;
        //}


        public class TalentCareer
        {
            public int candidatepkid { get; set; }
            public string candidatename { get; set; }
            public string requisition_name { get; set; }
            public DateTime? appliedate { get; set; }
            public string areaexpertise { get; set; }
            public string stage { get; set; }
            public string status { get; set; }
            public string strength { get; set; }
            public string weakness { get; set; }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TalentCareerUpload>> GetPostResume(int id)
        {
            var careerupload = await _context.TalentCareerUploads.FindAsync(id);

            if (careerupload == null)
            {
                return NotFound();
            }

            return careerupload;
        }

        [Route("/api/AddAnotherInterviewStage")]
        [HttpPost]
        public async Task<ActionResult<Interview>> AddAnotherInterviewStage([FromForm] InsertStages instages)
        {
            var interviewentity = await _context.Interviews.Where(x => x.InterviewPKID == instages.interviewpkid).FirstOrDefaultAsync();
            var status = await _context.Statuses.Where(i => i.FlagStatus == "candidatestatus" && i.StatusName == "Waiting for another round").FirstOrDefaultAsync();

            var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                       join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                       where interviewentity.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                       && tas.IsCompleted == false && interviewentity.CandidateFKID == tc.CandidatePKID
                                       select new Task()
                                       {
                                           TasksPKID = tas.TasksPKID
                                       }).FirstOrDefaultAsync();

            if (interviewentity == null)
            {
                return BadRequest();
            }
            else
            {
                interviewentity.StatusFKID = status.StatusPKID;
                interviewentity.IsAddAnotherRound = true;
                interviewentity.UpdatedDate = DateTime.Now;
                interviewentity.UpdatedBy = instages.Createdby;
                interviewentity.Remarks = instages.Remarks;
                interviewentity.IsApproved = true;
            }

            var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

            if (taskentity == null)
            {
                return BadRequest();
            }
            else
            {
                taskentity.IsCompleted = true;
                taskentity.UpdatedDate = DateTime.Now;
                taskentity.UpdatedBy = instages.Createdby;
            }

            await _context.SaveChangesAsync();

            var chkrole = await (from role in _context.UserRoles
                                 join tuser in _context.Users on role.RolePKID equals tuser.RoleFKID
                                 where role.RoleTitle == "HR Manager"
                                 select new User()
                                 {
                                     UserPKID = tuser.UserPKID
                                 }).FirstOrDefaultAsync();

            var getjobposterid = await _context.TalentCareerUploads.Where(x => x.CandidatePKID == instages.CandidateFKID).FirstOrDefaultAsync();

            Task tasks = new Task();
            tasks.TasksActivity = "Interviewer asked for another round";
            tasks.Description = instages.Remarks;
            tasks.ActionUserID = chkrole.UserPKID;
            tasks.JobPosterID = getjobposterid.JobPosterID;
            tasks.IsCompleted = false;
            tasks.IsDeleted = false;
            tasks.IsActive = true;
            tasks.CreatedBy = instages.Createdby;
            tasks.UpdatedBy = instages.Createdby;
            tasks.IsApproved = false;
            tasks.IsRejected = false;
            tasks.Remarks = null;
            tasks.CreatedDate = DateTime.Now;
            tasks.UpdatedDate = DateTime.Now;
            tasks.Moduletype = "CandidateModule";

            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            var finduser = await _context.Users.Where(i => i.UserPKID == instages.AssignedTo).FirstOrDefaultAsync();

            // send html page to gmail

            var tempath = Path.Combine(
                          _hostingEnvironment.ContentRootPath,
                          "EmailTemplates", "EmailTemplate.html");

            StreamReader reader = new StreamReader(tempath);

            string readFile = reader.ReadToEnd();

            string myString = "";
            myString = readFile;
            myString = myString.Replace("$$username$$", chkrole.UserName);
            myString = myString.Replace("$$taskactivity$$", finduser.UserName + " has asked for another round");
            //  myString = myString.Replace("$$roletitle$$", Convert.ToString(getroletitle.RoleTitle));
            // myString = 

            //myString = myString.Replace("$$CompanyName$$", "6Solve");
            //myString = myString.Replace("$$Email$$", "connectmuthu28@gmail.com");
            //myString = myString.Replace("$$Website$$", "http://6solve.com/");


            var credentials = new NetworkCredential("connectmuthu28@gmail.com", "ForverJoya$2019");

            var mail = new MailMessage()
            {
                From = new MailAddress("connectmuthu28@gmail.com"),
                Subject = finduser.UserName + " has asked for another round",
                Body = myString.ToString()
            };

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(chkrole.UserEmail));

            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            //  client.Send(mail);

            return NoContent();
            //return CreatedAtAction("GetCareerTab",
            //new { id = values.InterviewPKID }, values);
        }

        [Route("/api/RejectInterviewStage")]
        [HttpPost]
        public async Task<ActionResult<Interview>> RejectInterviewStage([FromForm] InsertStages instages)
        {
            var interviewentity = await _context.Interviews.Where(x => x.InterviewPKID == instages.interviewpkid && x.IsActive == true).FirstOrDefaultAsync();
            var status = await _context.Statuses.Where(i => i.FlagStatus == "candidatestatus" && i.StatusName == "Selected").FirstOrDefaultAsync();

            var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                       join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                       where interviewentity.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                       && tas.IsCompleted == false && interviewentity.CandidateFKID == tc.CandidatePKID
                                       select new Task()
                                       {
                                           TasksPKID = tas.TasksPKID
                                       }).FirstOrDefaultAsync();

            if (interviewentity == null)
            {
                return BadRequest();
            }
            else
            {
                interviewentity.StatusFKID = status.StatusPKID;
                interviewentity.IsRejected = true;
                interviewentity.UpdatedDate = DateTime.Now;
                interviewentity.UpdatedBy = instages.Createdby;
            }

            var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

            if (taskentity == null)
            {
                return BadRequest();
            }
            else
            {
                taskentity.IsCompleted = true;
                taskentity.UpdatedDate = DateTime.Now;
                taskentity.UpdatedBy = instages.Createdby;
            }

            await _context.SaveChangesAsync();

            return NoContent();
            //return CreatedAtAction("GetCareerTab",
            //new { id = values.InterviewPKID }, values);
        }

        [Route("/api/ApproveInterviewStage")]
        [HttpPost]
        public async Task<ActionResult<Interview>> ApproveInterviewStage([FromForm] InsertStages instages)
        {
            var interviewentity = await _context.Interviews.Where(x => x.InterviewPKID == instages.interviewpkid).FirstOrDefaultAsync();
            var status = await _context.Statuses.Where(i => i.FlagStatus == "candidatestatus" && i.StatusName == "Rejected").FirstOrDefaultAsync();

            var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                       join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                       where interviewentity.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                       && tas.IsCompleted == false && interviewentity.CandidateFKID == tc.CandidatePKID
                                       select new Task()
                                       {
                                           TasksPKID = tas.TasksPKID
                                       }).FirstOrDefaultAsync();

            if (interviewentity == null)
            {
                return BadRequest();
            }
            else
            {
                interviewentity.StatusFKID = status.StatusPKID;
                interviewentity.IsApproved = true;
                interviewentity.UpdatedDate = DateTime.Now;
                interviewentity.UpdatedBy = instages.Createdby;
            }

            var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

            if (taskentity == null)
            {
                return BadRequest();
            }
            else
            {
                taskentity.IsCompleted = true;
                taskentity.UpdatedDate = DateTime.Now;
                taskentity.UpdatedBy = instages.Createdby;
            }

            await _context.SaveChangesAsync();

            return NoContent();
            //return CreatedAtAction("GetCareerTab",
            //new { id = values.InterviewPKID }, values);
        }

        //[Route("/api/addInterviewStage")]
        //[HttpPost]
        //public async Task<ActionResult<Interview>> addInterviewStage([FromForm] InsertStages instages)
        //{
        //    var interviewentity = await _context.Interviews.Where(x => x.InterviewPKID == instages.interviewpkid).FirstOrDefaultAsync();

        //    var findtaskspkid = await (from tc in _context.TalentCareerUploads
        //                               join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
        //                               where interviewentity.AssignedTo == tas.ActionUserID && tas.IsActive == true
        //                               && tas.IsCompleted == false && interviewentity.CandidateFKID == tc.CandidatePKID
        //                               select new Task()
        //                               {
        //                                   TasksPKID = tas.TasksPKID,
        //                                   JobPosterID = tc.JobPosterID
        //                               }).FirstOrDefaultAsync();

        //    if (interviewentity == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        interviewentity.IsApproved = true;
        //        interviewentity.UpdatedDate = DateTime.Now;
        //        interviewentity.UpdatedBy = instages.Createdby;
        //    }

        //    var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

        //    if (taskentity == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        taskentity.IsCompleted = true;
        //        taskentity.UpdatedDate = DateTime.Now;
        //        taskentity.UpdatedBy = instages.Createdby;
        //    }

        //    await _context.SaveChangesAsync();

        //    var findrole = await _context.UserRoles.Where(u => u.RoleTitle == "HR Manager").FirstOrDefaultAsync();
        //    var getusername = await _context.Users.Where(g => g.RoleFKID == findrole.RolePKID).FirstOrDefaultAsync();

        //    Task tasks = new Task();
        //    tasks.TasksActivity = "Add another round";
        //    tasks.Description = "Approve a New Candidate";
        //    tasks.ActionUserID = getusername.UserPKID;
        //    tasks.JobPosterID = findtaskspkid.JobPosterID;
        //    tasks.IsCompleted = false;
        //    tasks.IsDeleted = false;
        //    tasks.IsActive = true;
        //    tasks.CreatedBy = instages.Createdby;
        //    tasks.UpdatedBy = instages.Createdby;
        //    tasks.IsApproved = false;
        //    tasks.IsRejected = false;
        //    tasks.Remarks = null;
        //    tasks.CreatedDate = DateTime.Now;
        //    tasks.UpdatedDate = DateTime.Now;
        //    tasks.Moduletype = "CandidateModule";

        //    _context.Tasks.Add(tasks);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //    //return CreatedAtAction("GetCareerTab",
        //    //new { id = values.InterviewPKID }, values);
        //}



        [Route("/api/InsertInterviewStage")]
        [HttpPost]
        public async Task<ActionResult<Interview>> InsertInterviewStage([FromForm] InsertStages instages)
        {
            try
            {
                var chkrole = await (from role in _context.UserRoles
                                     join tuser in _context.Users on role.RolePKID equals tuser.RoleFKID
                                     where instages.InterviewScheduledby == "HR Manager"
                                     select new User()
                                     {
                                         UserPKID = tuser.UserPKID
                                     }).FirstOrDefaultAsync();

                var getjobposterid = await _context.TalentCareerUploads.Where(x => x.CandidatePKID == instages.CandidateFKID && x.StatusFKID == instages.StatusFKID).FirstOrDefaultAsync();

                var talentrequest = await _context.TalentRequests.Where(t => t.JobPosterID == getjobposterid.JobPosterID).FirstOrDefaultAsync();

                var findstatus = await _context.Statuses.Where(s => s.StatusPKID == instages.StatusFKID).FirstOrDefaultAsync();

                var findhrid = await _context.Interviews.Where(i => i.CandidateFKID == instages.CandidateFKID && i.StatusFKID == instages.StatusFKID
                && i.IsAddAnotherRound == true && i.IsApproved == true && i.IsActive == true).FirstOrDefaultAsync();

                if (findstatus.StatusName == "New")
                {
                    var interviewlevel = await _context.InterviewLevels.Where(i => i.InterviewLevelType == instages.InterviewLevelType).FirstOrDefaultAsync();
                    //  var taskentity = await _context.Tasks.Where(x => x.TasksPKID == instages.taskspkid).FirstOrDefaultAsync();
                    StringBuilder sb = new StringBuilder();
                    if (interviewlevel == null)
                    {
                        InterviewLevel addinterlevel = new InterviewLevel();
                        addinterlevel.InterviewLevelType = instages.InterviewLevelType;
                        // addinterlevel.LevelNumber = "Level1";
                        addinterlevel.IsActive = true;
                        addinterlevel.IsDeleted = false;
                        addinterlevel.CreatedDate = DateTime.Now;
                        addinterlevel.UpdatedDate = DateTime.Now;
                        addinterlevel.CreatedBy = instages.Createdby;
                        addinterlevel.UpdatedBy = instages.Createdby;
                        await PostInterviewLevel(addinterlevel);
                        var lastinserted = await _context.InterviewLevels.Select(x => x.InterviewLevelPKID).MaxAsync();



                        sb.Append(getjobposterid.InterviewLevelFKID);
                        sb.Append(",");
                        sb.Append(lastinserted);
                        getjobposterid.InterviewLevelFKID = sb.ToString().TrimEnd(',');
                        //  getjobposterid.UpdatedDate = DateTime.Now;
                        getjobposterid.UpdatedBy = instages.Createdby;
                    }
                    else
                    {
                        sb.Append(getjobposterid.InterviewLevelFKID);
                        sb.Append(",");
                        //   sb.Append(interviewlevel.InterviewLevelPKID);


                        getjobposterid.InterviewLevelFKID = sb.ToString().TrimEnd(',');
                        //  getjobposterid.UpdatedDate = DateTime.Now;
                        getjobposterid.UpdatedBy = instages.Createdby;
                    }
                    if (instages.InterviewScheduledby == "HR Manager")
                    {
                        if (instages.interviewpkid == 0)
                        {
                            if (findhrid != null)
                            {
                                var taskcount = await (from tc in _context.TalentCareerUploads
                                                       join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                       where findhrid.InterviewScheduledBy == tas.ActionUserID && tas.IsActive == true
                                                       && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                       select new Task()).CountAsync();
                                if (taskcount >= 1)
                                {
                                    var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                                               join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                               where findhrid.InterviewScheduledBy == tas.ActionUserID && tas.IsActive == true
                                                               && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                               select new Task()
                                                               {
                                                                   TasksPKID = tas.TasksPKID
                                                               }).FirstOrDefaultAsync();
                                    var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

                                    if (taskentity == null)
                                    {
                                        return BadRequest();
                                    }
                                    else
                                    {
                                        taskentity.IsCompleted = true;
                                        taskentity.UpdatedDate = DateTime.Now;
                                        taskentity.UpdatedBy = instages.Createdby;
                                    }
                                    await _context.SaveChangesAsync();
                                }
                            }

                        }
                        else
                        {
                            if (instages.interviewpkid == 0)
                            {
                                if (findhrid != null)
                                {
                                    var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                                               join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                               where findhrid.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                                               && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                               select new Task()
                                                               {
                                                                   TasksPKID = tas.TasksPKID
                                                               }).FirstOrDefaultAsync();
                                    var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

                                    if (taskentity == null)
                                    {
                                        return BadRequest();
                                    }
                                    else
                                    {
                                        taskentity.IsCompleted = true;
                                        taskentity.UpdatedDate = DateTime.Now;
                                        taskentity.UpdatedBy = instages.Createdby;
                                    }
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
                else
                {
                    var interviewlevel = await _context.InterviewLevels.Where(i => i.InterviewLevelType == instages.InterviewLevelType).FirstOrDefaultAsync();
                    //  var taskentity = await _context.Tasks.Where(x => x.TasksPKID == instages.taskspkid).FirstOrDefaultAsync();
                    StringBuilder sb = new StringBuilder();
                    if (interviewlevel == null)
                    {
                        InterviewLevel addinterlevel = new InterviewLevel();
                        addinterlevel.InterviewLevelType = instages.InterviewLevelType;
                        // addinterlevel.LevelNumber = "Level1";
                        addinterlevel.IsActive = true;
                        addinterlevel.IsDeleted = false;
                        addinterlevel.CreatedDate = DateTime.Now;
                        addinterlevel.UpdatedDate = DateTime.Now;
                        addinterlevel.CreatedBy = instages.Createdby;
                        addinterlevel.UpdatedBy = instages.Createdby;
                        await PostInterviewLevel(addinterlevel);
                        var lastinserted = await _context.InterviewLevels.Select(x => x.InterviewLevelPKID).MaxAsync();



                        sb.Append(talentrequest.InterviewLevelFKID);
                        sb.Append(",");
                        sb.Append(lastinserted);
                        talentrequest.InterviewLevelFKID = sb.ToString().TrimEnd(',');
                        talentrequest.UpdatedDate = DateTime.Now;
                        talentrequest.UpdatedBy = instages.Createdby;
                    }
                    else
                    {
                        sb.Append(talentrequest.InterviewLevelFKID);
                        sb.Append(",");
                        //    sb.Append(interviewlevel.InterviewLevelPKID);


                        talentrequest.InterviewLevelFKID = sb.ToString().TrimEnd(',');
                        talentrequest.UpdatedDate = DateTime.Now;
                        talentrequest.UpdatedBy = instages.Createdby;
                    }
                    await _context.SaveChangesAsync();

                    if (instages.InterviewScheduledby == "HR Manager")
                    {
                        if (instages.interviewpkid == 0)
                        {
                            if (findhrid != null)
                            {
                                var taskcount = await (from tc in _context.TalentCareerUploads
                                                       join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                       where findhrid.InterviewScheduledBy == tas.ActionUserID && tas.IsActive == true
                                                       && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                       select new Task()).CountAsync();
                                if (taskcount >= 1)
                                {
                                    var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                                               join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                               where findhrid.InterviewScheduledBy == tas.ActionUserID && tas.IsActive == true
                                                               && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                               select new Task()
                                                               {
                                                                   TasksPKID = tas.TasksPKID
                                                               }).FirstOrDefaultAsync();
                                    var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

                                    if (taskentity == null)
                                    {
                                        return BadRequest();
                                    }
                                    else
                                    {
                                        taskentity.IsCompleted = true;
                                        taskentity.UpdatedDate = DateTime.Now;
                                        taskentity.UpdatedBy = instages.Createdby;
                                    }
                                    await _context.SaveChangesAsync();
                                }

                            }
                        }
                        else
                        {
                            if (instages.interviewpkid == 0)
                            {
                                if (findhrid != null)
                                {
                                    var taskcounts = await (from tc in _context.TalentCareerUploads
                                                            join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                            where findhrid.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                                            && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                            select new Task()).CountAsync();

                                    if (taskcounts >= 1)
                                    {
                                        var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                                                   join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                                   where findhrid.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                                                   && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                                   select new Task()
                                                                   {
                                                                       TasksPKID = tas.TasksPKID
                                                                   }).FirstOrDefaultAsync();
                                        var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

                                        if (taskentity == null)
                                        {
                                            return BadRequest();
                                        }
                                        else
                                        {
                                            taskentity.IsCompleted = true;
                                            taskentity.UpdatedDate = DateTime.Now;
                                            taskentity.UpdatedBy = instages.Createdby;
                                        }
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        if (findhrid != null)
                        {
                            var taskscount = await (from tc in _context.TalentCareerUploads
                                                    join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                    where findhrid.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                                    && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                    select new Task()).CountAsync();

                            if (taskscount >= 1)
                            {
                                var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                                           join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                                           where findhrid.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                                           && tas.IsCompleted == false && findhrid.CandidateFKID == tc.CandidatePKID
                                                           select new Task()
                                                           {
                                                               TasksPKID = tas.TasksPKID
                                                           }).FirstOrDefaultAsync();
                                var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

                                if (taskentity == null)
                                {
                                    return BadRequest();
                                }
                                else
                                {
                                    taskentity.IsCompleted = true;
                                    taskentity.UpdatedDate = DateTime.Now;
                                    taskentity.UpdatedBy = instages.Createdby;
                                }
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                }

                await _context.SaveChangesAsync();

                if (instages.interviewpkid == 0)
                {
                    var status = await _context.Statuses.Where(i => i.FlagStatus == "candidatestatus" && i.StatusName == "Waiting for approval").FirstOrDefaultAsync();
                    var values = new Interview
                    {
                        InterviewDate = instages.InterviewDate,
                        CandidateFKID = instages.CandidateFKID,
                        Start_Time = instages.Startime,
                        End_Time = DateTime.Now,
                        InterviewScheduledBy = chkrole.UserPKID,
                        AssignedTo = instages.AssignedTo,
                        StatusFKID = status.StatusPKID,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = instages.Createdby,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = instages.Createdby,
                        UpdatedDate = DateTime.Now,
                        InterviewLevelType = instages.InterviewLevelType,

                        //  InterviewLevelFKID = instages.InterviewLevelFKID                
                    };

                    _context.Interviews.Add(values);
                    await _context.SaveChangesAsync();

                    Task tasks = new Task();
                    tasks.TasksActivity = "Approve a New Candidate";
                    tasks.Description = "Approve a New Candidate";
                    tasks.ActionUserID = instages.AssignedTo;
                    tasks.JobPosterID = getjobposterid.JobPosterID;
                    tasks.IsCompleted = false;
                    tasks.IsDeleted = false;
                    tasks.IsActive = true;
                    tasks.CreatedBy = instages.Createdby;
                    tasks.UpdatedBy = instages.Createdby;
                    tasks.IsApproved = false;
                    tasks.IsRejected = false;
                    tasks.Remarks = null;
                    tasks.CreatedDate = DateTime.Now;
                    tasks.UpdatedDate = DateTime.Now;
                    tasks.Moduletype = "CandidateModule";

                    _context.Tasks.Add(tasks);
                    await _context.SaveChangesAsync();

                    var finduser = await _context.Users.Where(i => i.UserPKID == instages.AssignedTo).FirstOrDefaultAsync();

                    // send html page to gmail

                    var tempath = Path.Combine(
                                  _hostingEnvironment.ContentRootPath,
                                  "EmailTemplates", "EmailTemplate.html");

                    StreamReader reader = new StreamReader(tempath);

                    string readFile = reader.ReadToEnd();

                    string myString = "";
                    myString = readFile;
                    myString = myString.Replace("$$username$$", finduser.UserName);
                    myString = myString.Replace("$$taskactivity$$", "Approve a New Candidate");
                    //  myString = myString.Replace("$$roletitle$$", Convert.ToString(getroletitle.RoleTitle));
                    // myString = 

                    //myString = myString.Replace("$$CompanyName$$", "6Solve");
                    //myString = myString.Replace("$$Email$$", "connectmuthu28@gmail.com");
                    //myString = myString.Replace("$$Website$$", "http://6solve.com/");


                    var credentials = new NetworkCredential("connectmuthu28@gmail.com", "ForverJoya$2019");

                    var mail = new MailMessage()
                    {
                        From = new MailAddress("connectmuthu28@gmail.com"),
                        Subject = "Approve a New Candidate",
                        Body = myString.ToString()
                    };

                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(finduser.UserEmail));

                    var client = new SmtpClient()
                    {
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Host = "smtp.gmail.com",
                        EnableSsl = true,
                        Credentials = credentials
                    };

                    // client.Send(mail);
                }
                else
                {
                    var interviewentity = await _context.Interviews.Where(i => i.InterviewPKID == instages.interviewpkid).FirstOrDefaultAsync();

                    if (interviewentity == null)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        interviewentity.InterviewDate = instages.InterviewDate;
                        interviewentity.Start_Time = instages.Startime;
                        interviewentity.UpdatedBy = instages.Createdby;
                        interviewentity.UpdatedDate = DateTime.Now;
                    }

                    await _context.SaveChangesAsync();

                    var finduser = await _context.Users.Where(i => i.UserPKID == interviewentity.AssignedTo).FirstOrDefaultAsync();

                    Task tasks = new Task();
                    tasks.TasksActivity = "Interview delegation";
                    tasks.Description = "Delegate the " + interviewentity.InterviewLevelType + " to another interviewer";
                    tasks.ActionUserID = Convert.ToInt32(interviewentity.AssignedTo);
                    tasks.JobPosterID = getjobposterid.JobPosterID;
                    tasks.IsCompleted = false;
                    tasks.IsDeleted = false;
                    tasks.IsActive = true;
                    tasks.CreatedBy = instages.Createdby;
                    tasks.UpdatedBy = instages.Createdby;
                    tasks.IsApproved = false;
                    tasks.IsRejected = false;
                    tasks.Remarks = null;
                    tasks.CreatedDate = DateTime.Now;
                    tasks.UpdatedDate = DateTime.Now;
                    tasks.Moduletype = "CandidateModule";

                    _context.Tasks.Add(tasks);
                    await _context.SaveChangesAsync();

                    // send html page to gmail

                    var tempath = Path.Combine(
                                  _hostingEnvironment.ContentRootPath,
                                  "EmailTemplates", "EmailTemplate.html");

                    StreamReader reader = new StreamReader(tempath);

                    string readFile = reader.ReadToEnd();

                    string myString = "";
                    myString = readFile;
                    myString = myString.Replace("$$username$$", finduser.UserName);
                    myString = myString.Replace("$$taskactivity$$", "New Requisition created");
                    //  myString = myString.Replace("$$roletitle$$", Convert.ToString(getroletitle.RoleTitle));
                    // myString = 

                    //myString = myString.Replace("$$CompanyName$$", "6Solve");
                    //myString = myString.Replace("$$Email$$", "connectmuthu28@gmail.com");
                    //myString = myString.Replace("$$Website$$", "http://6solve.com/");


                    var credentials = new NetworkCredential("connectmuthu28@gmail.com", "ForverJoya$2019");

                    var mail = new MailMessage()
                    {
                        From = new MailAddress("connectmuthu28@gmail.com"),
                        Subject = "New Requisition created",
                        Body = myString.ToString()
                    };

                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(finduser.UserEmail));

                    var client = new SmtpClient()
                    {
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Host = "smtp.gmail.com",
                        EnableSsl = true,
                        Credentials = credentials
                    };

                    // client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NoContent();
        }

        [Route("/api/onDelegateto")]
        [HttpPost]
        public async Task<ActionResult<Interview>> onDelegateto([FromForm] InsertStages instages)
        {
            try
            {
                var chkrole = await (from role in _context.UserRoles
                                     join tuser in _context.Users on role.RolePKID equals tuser.RoleFKID
                                     where role.RoleTitle == instages.InterviewScheduledby
                                     select new User()
                                     {
                                         UserPKID = tuser.UserPKID
                                     }).FirstOrDefaultAsync();

                var getjobposterid = await _context.TalentCareerUploads.Where(x => x.CandidatePKID == instages.CandidateFKID && x.StatusFKID == instages.StatusFKID).FirstOrDefaultAsync();

                var talentrequest = await _context.TalentRequests.Where(t => t.JobPosterID == getjobposterid.JobPosterID).FirstOrDefaultAsync();

                var findstatus = await _context.Statuses.Where(s => s.StatusPKID == instages.StatusFKID).FirstOrDefaultAsync();

                var findinterviewpkid = await _context.Interviews.Where(i => i.CandidateFKID == instages.CandidateFKID // && i.StatusFKID == instages.StatusFKID
                 && i.InterviewPKID == instages.interviewpkid && i.IsActive == true).FirstOrDefaultAsync();



                if (findstatus.StatusName == "New")
                {

                    var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                               join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                               where findinterviewpkid.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                               && tas.IsCompleted == false && findinterviewpkid.CandidateFKID == tc.CandidatePKID
                                               select new Task()
                                               {
                                                   TasksPKID = tas.TasksPKID
                                               }).FirstOrDefaultAsync();

                    var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

                    if (taskentity == null)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        taskentity.IsCompleted = true;
                        taskentity.UpdatedDate = DateTime.Now;
                        taskentity.UpdatedBy = instages.Createdby;
                    }

                    await _context.SaveChangesAsync();


                    var interentity = await _context.Interviews.Where(x => x.InterviewPKID == findinterviewpkid.InterviewPKID).FirstOrDefaultAsync();

                    if (interentity == null)
                    {

                    }
                    else
                    {
                        interentity.DelegatedTo = instages.Delegateto;
                        interentity.UpdatedDate = DateTime.Now;
                        interentity.UpdatedBy = instages.Createdby;
                    }

                    await _context.SaveChangesAsync();


                    var newvalues = new Interview
                    {
                        InterviewDate = instages.InterviewDate,
                        CandidateFKID = instages.CandidateFKID,
                        Start_Time = instages.Startime,
                        End_Time = DateTime.Now,
                        InterviewScheduledBy = chkrole.UserPKID,
                        AssignedTo = instages.Delegateto,
                        StatusFKID = instages.StatusFKID,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = instages.Createdby,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = instages.Createdby,
                        UpdatedDate = DateTime.Now,
                        InterviewLevelType = instages.InterviewLevelType
                        //  InterviewLevelFKID = instages.InterviewLevelFKID                
                    };

                    _context.Interviews.Add(newvalues);
                    await _context.SaveChangesAsync();

                    var usercheck = await _context.Users.Where(x => x.UserPKID == instages.Delegateto).FirstOrDefaultAsync();


                    Task newtasks = new Task();
                    newtasks.TasksActivity = "Interview delegation";
                    newtasks.Description = "Delegate the " + instages.InterviewLevelType + " to " + usercheck.UserName;
                    newtasks.ActionUserID = instages.Delegateto;
                    newtasks.JobPosterID = getjobposterid.JobPosterID;
                    newtasks.IsCompleted = false;
                    newtasks.IsDeleted = false;
                    newtasks.IsActive = true;
                    newtasks.CreatedBy = instages.Createdby;
                    newtasks.UpdatedBy = instages.Createdby;
                    newtasks.IsApproved = false;
                    newtasks.IsRejected = false;
                    newtasks.Remarks = null;
                    newtasks.CreatedDate = DateTime.Now;
                    newtasks.UpdatedDate = DateTime.Now;
                    newtasks.Moduletype = "CandidateModule";

                    _context.Tasks.Add(newtasks);
                    await _context.SaveChangesAsync();



                    // send html page to gmail

                    var tempath = Path.Combine(
                                  _hostingEnvironment.ContentRootPath,
                                  "EmailTemplates", "EmailTemplate.html");

                    StreamReader reader = new StreamReader(tempath);

                    string readFile = reader.ReadToEnd();

                    string myString = "";
                    myString = readFile;
                    myString = myString.Replace("$$username$$", usercheck.UserName);
                    myString = myString.Replace("$$taskactivity$$", "Approve a New Requisition");
                    //  myString = myString.Replace("$$roletitle$$", Convert.ToString(getroletitle.RoleTitle));
                    // myString = 

                    //myString = myString.Replace("$$CompanyName$$", "6Solve");
                    //myString = myString.Replace("$$Email$$", "connectmuthu28@gmail.com");
                    //myString = myString.Replace("$$Website$$", "http://6solve.com/");


                    var credentials = new NetworkCredential("connectmuthu28@gmail.com", "ForverJoya$2019");

                    var mail = new MailMessage()
                    {
                        From = new MailAddress("connectmuthu28@gmail.com"),
                        Subject = "Approve a New Requisition",
                        Body = myString.ToString()
                    };

                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(usercheck.UserEmail));

                    var client = new SmtpClient()
                    {
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Host = "smtp.gmail.com",
                        EnableSsl = true,
                        Credentials = credentials
                    };

                    // client.Send(mail);
                }
                else
                {

                    var findtaskspkid = await (from tc in _context.TalentCareerUploads
                                               join tas in _context.Tasks on tc.JobPosterID equals tas.JobPosterID
                                               where findinterviewpkid.AssignedTo == tas.ActionUserID && tas.IsActive == true
                                               && tas.IsCompleted == false && findinterviewpkid.CandidateFKID == tc.CandidatePKID
                                               select new Task()
                                               {
                                                   TasksPKID = tas.TasksPKID
                                               }).FirstOrDefaultAsync();

                    var taskentity = await _context.Tasks.Where(x => x.TasksPKID == findtaskspkid.TasksPKID).FirstOrDefaultAsync();

                    if (taskentity == null)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        taskentity.IsCompleted = true;
                        taskentity.UpdatedDate = DateTime.Now;
                        taskentity.UpdatedBy = instages.Createdby;
                    }

                    await _context.SaveChangesAsync();


                    var interentity = await _context.Interviews.Where(x => x.InterviewPKID == findinterviewpkid.InterviewPKID).FirstOrDefaultAsync();

                    if (interentity == null)
                    {

                    }
                    else
                    {
                        interentity.DelegatedTo = instages.Delegateto;
                        interentity.UpdatedDate = DateTime.Now;
                        interentity.UpdatedBy = instages.Createdby;
                    }

                    await _context.SaveChangesAsync();


                    var newvalues = new Interview
                    {
                        InterviewDate = instages.InterviewDate,
                        CandidateFKID = instages.CandidateFKID,
                        Start_Time = instages.Startime,
                        End_Time = DateTime.Now,
                        InterviewScheduledBy = chkrole.UserPKID,
                        AssignedTo = instages.Delegateto,
                        StatusFKID = instages.StatusFKID,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = instages.Createdby,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = instages.Createdby,
                        UpdatedDate = DateTime.Now,
                        InterviewLevelType = instages.InterviewLevelType
                        //  InterviewLevelFKID = instages.InterviewLevelFKID                
                    };

                    _context.Interviews.Add(newvalues);
                    await _context.SaveChangesAsync();

                    var usercheck = await _context.Users.Where(x => x.UserPKID == instages.Delegateto).FirstOrDefaultAsync();

                    Task newtasks = new Task();
                    newtasks.TasksActivity = "Interview delegation";
                    newtasks.Description = "Delegate the " + instages.InterviewLevelType + " to " + usercheck.UserName;
                    newtasks.ActionUserID = instages.Delegateto;
                    newtasks.JobPosterID = getjobposterid.JobPosterID;
                    newtasks.IsCompleted = false;
                    newtasks.IsDeleted = false;
                    newtasks.IsActive = true;
                    newtasks.CreatedBy = instages.Createdby;
                    newtasks.UpdatedBy = instages.Createdby;
                    newtasks.IsApproved = false;
                    newtasks.IsRejected = false;
                    newtasks.Remarks = null;
                    newtasks.CreatedDate = DateTime.Now;
                    newtasks.UpdatedDate = DateTime.Now;
                    newtasks.Moduletype = "CandidateModule";

                    _context.Tasks.Add(newtasks);
                    await _context.SaveChangesAsync();

                    // send html page to gmail

                    var tempath = Path.Combine(
                                  _hostingEnvironment.ContentRootPath,
                                  "EmailTemplates", "EmailTemplate.html");

                    StreamReader reader = new StreamReader(tempath);

                    string readFile = reader.ReadToEnd();

                    string myString = "";
                    myString = readFile;
                    myString = myString.Replace("$$username$$", usercheck.UserName);
                    myString = myString.Replace("$$taskactivity$$", "Approve a New Requisition");
                    //  myString = myString.Replace("$$roletitle$$", Convert.ToString(getroletitle.RoleTitle));
                    // myString = 

                    //myString = myString.Replace("$$CompanyName$$", "6Solve");
                    //myString = myString.Replace("$$Email$$", "connectmuthu28@gmail.com");
                    //myString = myString.Replace("$$Website$$", "http://6solve.com/");


                    var credentials = new NetworkCredential("connectmuthu28@gmail.com", "ForverJoya$2019");

                    var mail = new MailMessage()
                    {
                        From = new MailAddress("connectmuthu28@gmail.com"),
                        Subject = "Approve a New Requisition",
                        Body = myString.ToString()
                    };

                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(usercheck.UserEmail));

                    var client = new SmtpClient()
                    {
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Host = "smtp.gmail.com",
                        EnableSsl = true,
                        Credentials = credentials
                    };

                    // client.Send(mail);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<InterviewLevel>> PostInterviewLevel(InterviewLevel interLevel)
        {
            _context.InterviewLevels.Add(interLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewLevels", new { id = interLevel.InterviewLevelPKID }, interLevel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewLevel>> GetInterviewLevels(int id)
        {
            var awaitinterlevel = await _context.InterviewLevels.FindAsync(id);

            if (awaitinterlevel == null)
            {
                return NotFound();
            }

            return awaitinterlevel;
        }


        public class InsertStages
        {
            public int AssignedTo { get; set; }
            public int Delegateto { get; set; }
            public DateTime InterviewDate { get; set; }
            public DateTime Startime { get; set; }
            public int StatusFKID { get; set; }
            public string InterviewLevelType { get; set; }
            public string InterviewScheduledby { get; set; }
            public int CandidateFKID { get; set; }
            public int taskspkid { get; set; }
            public int interviewpkid { get; set; }
            public string Createdby { get; set; }
            public string Remarks { get; set; }
        }


        public class CurrentOpenings
        {
            public int JobRequisitionPKID { get; set; }
            public string JobTitle { get; set; }
            public string JobNature { get; set; }
            public string Location { get; set; }
            public string Department { get; set; }
            public string Joblevel { get; set; }
            public string Shift { get; set; }
            public string Traveltype { get; set; }
            public string Description { get; set; }
            public string Mandskills { get; set; }
            public string Goodskills { get; set; }
            public string OverallExp { get; set; }
            public DateTime? PostedDate { get; set; }
        }

        public class FileUploadApis
        {
            public IFormFile Resume { get; set; }
            public string CandidateName { get; set; }
            public string EmailID { get; set; }
            public string MobileNumber { get; set; }
            public string CurrentCompany { get; set; }
            public string CurrentLocation { get; set; }
            public string Designation { get; set; }
            public int EducQualifyFKID { get; set; }
            public int FuncSkillsFKID { get; set; }
            public int TotalExperience { get; set; }
            public int JobRequisitionPKID { get; set; }
            public int TechSkillsFKID { get; set; }
            public int PreferredLocationFKID { get; set; }

        }



        [Route("/api/updApproveRejectResume/{candidatepkid}/{user_rolevalue}/{approveorreject}")]
        [HttpPut("{candidatepkid}/{user_rolevalue}/{approveorreject}")]
        public async Task<JsonResult> updApproveRejectResume(int candidatepkid, string user_rolevalue, string approveorreject)
        {
            int chkhr_approved = 0;
            int chkhr_rejected = 0;
            var strhr_appreject = (dynamic)null;
            // string strhr_rejected = string.Empty;
            var jointables = await (from roles in _context.UserRoles
                                    join user in _context.Users on roles.RolePKID equals user.RoleFKID
                                    where roles.RoleTitle == user_rolevalue || roles.RoleTitle == user_rolevalue
                                    select new User()
                                    {
                                        UserPKID = user.UserPKID
                                    }).FirstOrDefaultAsync();

            var candet = await _context.TalentCareerUploads.Where(t => t.CandidatePKID == candidatepkid).FirstOrDefaultAsync();

            if (candidatepkid == 0)
            {
                // return BadRequest();
            }
            else
            {
                if (user_rolevalue == "HR Manager")
                {
                    //   var chkalreadyexists = await _context.TalentCareerUploads.Where(t => t.IsActive == true && t.IsFirstLevelApprove == true
                    //   || t.IsFirstLevelReject == true && t.CandidatePKID == candidatepkid).CountAsync();

                    //   if(chkalreadyexists == 0)
                    //   {
                    candet.FirstLevelApprover = jointables.UserPKID;
                    if (approveorreject == "ApproveResume")
                    {
                        candet.IsFirstLevelApprove = true;
                        strhr_appreject = "Approved";
                    }
                    else
                    {
                        candet.IsFirstLevelReject = true;
                        strhr_appreject = "Rejected";

                    }
                    _context.Entry(candet).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    //   }                   
                }
                else
                {
                    if (user_rolevalue == "Project Manager")
                    {
                        chkhr_approved = await _context.TalentCareerUploads.Where(t => t.IsActive == true && t.IsFirstLevelApprove == true
                        && t.CandidatePKID == candidatepkid).CountAsync();
                        if (chkhr_approved == 1)
                        {
                            strhr_appreject = "Approved";
                        }
                        else
                        {
                            chkhr_rejected = await _context.TalentCareerUploads.Where(t => t.IsActive == true && t.IsFirstLevelReject == true
                            && t.CandidatePKID == candidatepkid).CountAsync();

                            if (chkhr_rejected == 1)
                            {
                                strhr_appreject = "Rejected";
                            }
                        }



                        if (strhr_appreject == "Approved")
                        {
                            candet.SecondLevelApprover = jointables.UserPKID;
                            if (approveorreject == "ApproveResume")
                            {
                                candet.IsSecondLevelApprove = true;
                            }
                            else
                            {
                                candet.IsSecondLevelReject = true;
                            }
                            _context.Entry(candet).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            if (strhr_appreject == "Rejected")
                            {
                                strhr_appreject = "Rejected";
                            }
                            else
                            {
                                strhr_appreject = "Not Approved";
                            }
                        }
                    }
                }
            }

            //try
            //{

            //}
            //catch (DbUpdateConcurrencyException)
            //{

            //}
            return new JsonResult(strhr_appreject);
        }

        // From Tasks to Candidate Profile Page

        [Route("/api/get_CandidateID/{jobposterid}")]
        [HttpGet("{jobposterid}")]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> get_CandidateID(int jobposterid)
        {
            var candidateid = await (from talentcareer in _context.TalentCareerUploads
                                     join tas in _context.Tasks on talentcareer.JobPosterID equals tas.JobPosterID
                                     where talentcareer.IsActive == true && tas.TasksPKID == jobposterid
                                     select new TalentCareerUpload()
                                     {
                                         CandidatePKID = talentcareer.CandidatePKID
                                     }).ToListAsync();

            return candidateid;
        }

        // bind Requistion name
        [Route("/api/Call_jobrequisition")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalentCareerUpload>>> bindRequisition()
        {
            return await _context.TalentCareerUploads.Where(x => x.IsActive == true && x.JobPosterID != null).ToListAsync();
        }

        //// bind Requistion name
        //[Route("/api/EnableOfferMgmt/{enableoffermgt}")]
        //[HttpGet("{enableoffermgt}")]
        //public async Task<Interview> EnableOfferMgmt(string enableoffermgt)
        //{
        //    return await _context.Interviews.Where(x => x.IsActive == true && x.InterviewLevelType == enableoffermgt).FirstOrDefaultAsync();
        //}

        // map job Requistion
        [Route("/api/mapJobRequisition/{canidatepkid}")]
        [HttpGet("{canidatepkid}")]
        public async Task<ActionResult<MapJobPosterID>> mapJobRequisition(int canidatepkid)
        {
            var getposterid = await (from tc in _context.TalentCareerUploads
                                     join talreq in _context.TalentRequests on tc.JobPosterID equals talreq.JobPosterID
                                     join jobtit in _context.JobTitles on Convert.ToInt32(talreq.JobTitleFKID) equals jobtit.JobTitlePKID
                                     where tc.CandidatePKID == canidatepkid && tc.Designation == jobtit.JobTitleName
                                     select new MapJobPosterID()
                                     {
                                         JobPosterID = talreq.JobPosterID
                                     }).FirstOrDefaultAsync();

            return getposterid;
        }

        [Route("/api/checkResume/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<int> checkResume(int candidatepkid)
        {
            int chkresume = 0;
            chkresume = await (from talentcareer in _context.TalentCareerUploads
                               join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                               where talentcareer.IsActive == true && talentcareer.CandidatePKID == candidatepkid
                               && talentcareer.IsFirstLevelApprove == true && talentcareer.IsSecondLevelApprove == true
                               select new TalentCareerUpload()).CountAsync();
            return chkresume;
        }

        public class MapJobPosterID
        {
            public string JobPosterID { get; set; }
        }

        [Route("/api/update_JobPosterID_InterviewLevel/{candidatepkid}/{jobposterid}/{userparamvalue}")]
        [HttpPut("{candidatepkid}/{jobposterid}/{userparamvalue}")]
        public async Task<ActionResult<TalentCareerUpload>> update_JobPosterID_InterviewLevel(int candidatepkid, string jobposterid, string userparamvalue)
        {
            var talententity = await _context.TalentCareerUploads.Where(x => x.CandidatePKID == candidatepkid).FirstOrDefaultAsync();

            var interviewlevelfkid = await _context.TalentRequests.Where(t => t.JobPosterID == jobposterid).FirstOrDefaultAsync();

            if (talententity == null)
            {
                return BadRequest();
            }
            else
            {
                talententity.JobPosterID = jobposterid;
                talententity.InterviewLevelFKID = interviewlevelfkid.InterviewLevelFKID;
                talententity.UpdatedBy = userparamvalue;
            }

            await _context.SaveChangesAsync();

            return NoContent();
            //return CreatedAtAction("GetCareerTab",
            //new { id = values.InterviewPKID }, values);
        }


        [Route("/api/remaindertoHR/{candidatepkid}")]
        [HttpGet("{candidatepkid}")]
        public async Task<int> remaindertoHR(int candidatepkid)
        {
            var roundcount = await _context.Interviews.Where(x => x.CandidateFKID == candidatepkid && x.IsActive == true
                                && x.IsApproved == true && x.IsAddAnotherRound == true).CountAsync();
            int count = 0;
            count = roundcount;
            return count;
        }

        public class InsertInterviewAssessment
        {
            public DateTime InterviewDate { get; set; }
            public DateTime Start_Time { get; set; }
            public DateTime End_Time { get; set; }
            //  public string AssessmentQuestions { get; set; }
            public string AssessmentAnswers { get; set; }
            public int AssessedBy { get; set; }
            public int CandidateFKID { get; set; }
            public int InterviewFKID { get; set; }
            public int InterviewLevelFKID { get; set; }
            public int taskspkid { get; set; }
            public string Ratings { get; set; }
            public string IsFilterCandidates { get; set; }
            public bool IsOnhold { get; set; }
            public bool IsApproved { get; set; }
            public bool IsRejected { get; set; }
            public bool IsAnotheround { get; set; }
            public string Strength { get; set; }
            public string Weakness { get; set; }
            public string Comments { get; set; }
            public string CreatedBy { get; set; }

        }

        public class Progressbar_candidates
        {
            public int TotalRecordCount { get; set; }
            public int TotalAssignCount { get; set; }
            public double CandPercentage { get; set; }

        }

        // dashboard - under candidate section - sub heading - candidate assigned 

        [Route("/api/ProgressValue_CandidateAssigned/{userparamvalue}/{roleuservalue}")]
        [HttpGet("{userparamvalue}/{roleuservalue}")]
        public async Task<JsonResult> ProgressValue_CandidateAssigned(string userparamvalue, string roleuservalue)
        {
            //  var assignedusercount = (dynamic)null;
            int totalcandcount_hr = 0;
            int totalcandcount_others = 0;
            // decimal candpercentage = 0;
            var candidateassigned = (dynamic)null;

            totalcandcount_hr = await (from talentcareer in _context.TalentCareerUploads
                                           //join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                                           //join jobtitle in _context.JobTitles on Convert.ToInt32(talentreq.JobTitleFKID) equals jobtitle.JobTitlePKID
                                       join stat in _context.Statuses on talentcareer.StageFKID equals stat.StatusPKID
                                       join status in _context.Statuses on talentcareer.FuncSkillsFKID equals status.StatusPKID
                                       join stat1 in _context.Statuses on talentcareer.StatusFKID equals stat1.StatusPKID
                                       where talentcareer.IsActive == true
                                       select new TalentCareerUpload()).CountAsync();


            if (roleuservalue == "HR Manager")
            {

                candidateassigned = await (from tc in _context.TalentCareerUploads
                                           where tc.IsActive == true
                                           select new Progressbar_candidates()
                                           {
                                               TotalRecordCount = 100,
                                               TotalAssignCount = totalcandcount_hr,
                                               CandPercentage = 100
                                               // CandPercentage = 100 / totalcandcount_hr * totalcandcount_hr
                                           }).FirstOrDefaultAsync();


            }
            else
            {
                totalcandcount_others = await (from talentcareer in _context.TalentCareerUploads
                                               join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                                               join inter in _context.Interviews on talentcareer.CandidatePKID equals inter.CandidateFKID
                                               join us in _context.Users on inter.AssignedTo equals us.UserPKID
                                               //join jobtitle in _context.JobTitles on Convert.ToInt32(talentreq.JobTitleFKID) equals jobtitle.JobTitlePKID
                                               join stat in _context.Statuses on talentcareer.StageFKID equals stat.StatusPKID
                                               join status in _context.Statuses on talentcareer.FuncSkillsFKID equals status.StatusPKID
                                               join stat1 in _context.Statuses on talentcareer.StatusFKID equals stat1.StatusPKID
                                               where talentcareer.IsActive == true && us.UserName == userparamvalue && inter.IsActive == true
                                               && talentreq.IsActive == true
                                               select new TalentCareerUpload()).CountAsync();

                // var findvalue = 100 / totalcandcount_hr;

                candidateassigned = await (from tc in _context.TalentCareerUploads
                                           where tc.IsActive == true
                                           select new Progressbar_candidates()
                                           {
                                               TotalRecordCount = totalcandcount_hr,
                                               TotalAssignCount = totalcandcount_others,
                                               CandPercentage = 100
                                           }).FirstOrDefaultAsync();
            }


            return new JsonResult(candidateassigned);
        }

        // dashboard - under candidate section - sub heading - designation

        [Route("/api/ProgressValue_Designation/{userparamvalue}/{roleuservalue}")]
        [HttpGet("{userparamvalue}/{roleuservalue}")]
        public async Task<JsonResult> ProgressValue_Designation(string userparamvalue, string roleuservalue)
        {
            int total_designcount = 0;
            int total_designcount_others = 0;

            var result_designation = (dynamic)null;

            total_designcount = await (from tc in _context.TalentCareerUploads
                                       join tr in _context.TalentRequests on tc.JobPosterID equals tr.JobPosterID
                                       join job in _context.JobTitles on Convert.ToInt32(tr.JobTitleFKID) equals job.JobTitlePKID
                                       where tc.IsActive == true && tr.IsActive == true && job.IsActive == true
                                       && tc.Designation == "Software Developer"
                                       select new TalentCareerUpload()).CountAsync();

            if (roleuservalue == "HR Manager")
            {
                result_designation = await (from tc in _context.TalentCareerUploads
                                            where tc.IsActive == true
                                            select new Progressbar_candidates()
                                            {
                                                TotalRecordCount = 100,
                                                TotalAssignCount = total_designcount,
                                                CandPercentage = 100
                                            }).FirstOrDefaultAsync();
            }
            else
            {
                total_designcount_others = await (from talentcareer in _context.TalentCareerUploads
                                                  join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                                                  join inter in _context.Interviews on talentcareer.CandidatePKID equals inter.CandidateFKID
                                                  join jobtitle in _context.JobTitles on Convert.ToInt32(talentreq.JobTitleFKID) equals jobtitle.JobTitlePKID
                                                  join us in _context.Users on inter.AssignedTo equals us.UserPKID
                                                  //join jobtitle in _context.JobTitles on Convert.ToInt32(talentreq.JobTitleFKID) equals jobtitle.JobTitlePKID
                                                  join stat in _context.Statuses on talentcareer.StageFKID equals stat.StatusPKID
                                                  join status in _context.Statuses on talentcareer.FuncSkillsFKID equals status.StatusPKID
                                                  join stat1 in _context.Statuses on talentcareer.StatusFKID equals stat1.StatusPKID
                                                  where talentcareer.IsActive == true && us.UserName == userparamvalue && inter.IsActive == true
                                                  && talentreq.IsActive == true && talentcareer.Designation == "Software Developer" && jobtitle.IsActive == true
                                                  select new TalentCareerUpload()).CountAsync();

                result_designation = await (from tc in _context.TalentCareerUploads
                                            where tc.IsActive == true
                                            select new Progressbar_candidates()
                                            {
                                                TotalRecordCount = total_designcount,
                                                TotalAssignCount = total_designcount_others,
                                                CandPercentage = 100
                                            }).FirstOrDefaultAsync();
            }
            return new JsonResult(result_designation);
        }

        // dashboard - under candidate section - sub heading - recruitment process

        [Route("/api/ProgressValue_RecProcess/{userparamvalue}/{roleuservalue}")]
        [HttpGet("{userparamvalue}/{roleuservalue}")]
        public async Task<JsonResult> ProgressValue_RecProcess(string userparamvalue, string roleuservalue)
        {
            int total_recprocess = 0;
            int total_recprocess_others = 0;

            var result_recprocess = (dynamic)null;

            total_recprocess = await (from tc in _context.TalentCareerUploads
                                      join tr in _context.TalentRequests on tc.JobPosterID equals tr.JobPosterID
                                      // join job in _context.JobTitles on Convert.ToInt32(tr.JobTitleFKID) equals job.JobTitlePKID
                                      where tc.IsActive == true && tr.IsActive == true
                                      select new TalentCareerUpload()).CountAsync();

            if (roleuservalue == "HR Manager")
            {
                result_recprocess = await (from tc in _context.TalentCareerUploads
                                           where tc.IsActive == true
                                           select new Progressbar_candidates()
                                           {
                                               TotalRecordCount = 100,
                                               TotalAssignCount = total_recprocess,
                                               CandPercentage = 100
                                           }).FirstOrDefaultAsync();
            }
            else
            {
                total_recprocess_others = await (from talentcareer in _context.TalentCareerUploads
                                                 join talentreq in _context.TalentRequests on talentcareer.JobPosterID equals talentreq.JobPosterID
                                                 join inter in _context.Interviews on talentcareer.CandidatePKID equals inter.CandidateFKID
                                                 join us in _context.Users on inter.AssignedTo equals us.UserPKID
                                                 where talentcareer.IsActive == true && us.UserName == userparamvalue && inter.IsActive == true
                                                 && talentreq.IsActive == true
                                                 select new TalentCareerUpload()).CountAsync();

                result_recprocess = await (from tc in _context.TalentCareerUploads
                                           where tc.IsActive == true
                                           select new Progressbar_candidates()
                                           {
                                               TotalRecordCount = total_recprocess,
                                               TotalAssignCount = total_recprocess_others,
                                               CandPercentage = 100
                                           }).FirstOrDefaultAsync();
            }
            return new JsonResult(result_recprocess);
        }

    }
}