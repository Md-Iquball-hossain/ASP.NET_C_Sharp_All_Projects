using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateBlazorApp.Shared.Models
{
    public enum Gender { Male, Female}
    public enum Religion { Islam, Christianity, Buddhism, Hinduism, Other}
    public enum MaritalStatus { Single, Married}
    public class Candidate
    {
        public int CandidateId { get; set; }
        [Required, StringLength(50)]
        public string CandidateName { get; set; } = default!;
        [Required, Column(TypeName ="date")]
        public DateTime DateOfBirth { get; set; }=DateTime.Now;
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        public string Phone { get; set; } = default!;
        [Required]
        public string Picture { get; set; } = default!;
        public virtual PersonalInfo? PersonalInfo { get; set; } =new PersonalInfo();
        public virtual List<Education>? Educations { get; set; }= new List<Education>();
        public virtual List<Experience>? Experiences { get; set; } = new List<Experience>();
        public virtual List<Skill>? Skills { get; set; } = new List<Skill>();
        public virtual List<Training>? Training { get; set; } = new List<Training>();
        public virtual List<Resume>? Resumes { get; set; } = new List<Resume>();
        public virtual List<Project>? Projects { get; set; } = new List<Project>();
        public virtual List<Reference>? References { get; set; } = new List<Reference>();
        public virtual JobDetail? JobDetail { get; set; } = new JobDetail();

    }
    public class PersonalInfo
    {
        public int PersonalInfoId { get; set; }
        [Required]
        public string FatherName { get; set; } = default!;
        [Required]
        public string MotherName { get; set; } = default!;
        [Required,EnumDataType(typeof( Gender))]
        public Gender Gender { get; set; }
        [Required, EnumDataType(typeof(Religion))]
        public Religion Religion { get;set; }
        [Required, EnumDataType(typeof(MaritalStatus))]
        public MaritalStatus MaritalStatus { get; set; }
        [Required]
        public string PresentAddress { get; set; } = default!;
        [Required]
        public string PermanentAddress { get; set; }= default!;
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class Education
    {
        public int EducationId { get; set; }
        [Required]
        public string Degree { get; set; }=default!;
        [Required]
        public string MajorSubject { get; set; } = default!;
        [Required]
        public string Institute { get; set; } = default!;
        [Required]
        public string CGPA { get; set; } = default!;
        [Required]
        public int PassingYear { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class Skill
    {
        public int SkillId { get; set; }
        [Required]
        public string SkillName { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!;
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class Experience
    {
        public int ExperienceId { get; set; }
        [Required]
        public string CompanyName { get; set; } =default!;
        [Required]
        public string Position { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required, Column(TypeName = "date")]
        public DateTime  EndDate { get; set; } = DateTime.Now;
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class Training
    {
        public int TrainingId { get; set; }
        [Required]
        public string TrainingName { get; set; } = default!;
        [Required]
        public string Institute { get; set; }=default!;
        [Required]
        public string Duration { get; set; } = default!;
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class Resume
    {
        public int ResumeId { get; set; }
        public string UploadFill { get; set;}=default!;
        [Required]
        public string Description { get; set; } = default!;
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; } = default!;
        [Required]
        public string Description { get; set; }=default!;
        [Required]
        public string ProjectLink { get; set; } = default!;
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class Reference
    {
        public int ReferenceId { get; set; }
        [Required]
        public string ReferenceName { get; set; } = default!;
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        public string Phone { get; set; } = default!;
        [Required]
        public string Relation { get; set; }= default!;
        [Required]
        public string Description { get; set; } = default!;
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class JobDetail
    {
        public int JobDetailId { get; set; }
        [Required]
        public string ApplicationFor { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal ExpectedSalary { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; } = default!;
    }
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set;}= default!;
        public DbSet<Education> Educations { get; set; } = default!;
        public DbSet<Experience> Experiences { get; set; } = default!;
        public DbSet<Skill> Skills { get; set; } = default!;
        public DbSet<Training> Training { get; set; } = default!;
        public DbSet<PersonalInfo> PersonalInfos { get; set; } = default!;
        public DbSet<Project> Projects { get; set; } = default!;
        public DbSet<Resume> Resumes { get; set; } = default!;
        public DbSet<Reference> References { get; set; } = default!;
        public DbSet<JobDetail> JobDetails { get; set; } = default!;
    }
}
