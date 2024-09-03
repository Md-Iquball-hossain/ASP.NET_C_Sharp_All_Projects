using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required, StringLength(50)]
        public string EmployeeName { get; set; }
        [Required, DataType(DataType.Date)]
        public System.DateTime BirthDate { get; set; }
        [Required, StringLength(30)]
        public string AppliedFor { get; set; }
        [Required, Column(TypeName = "money"), DataType(DataType.Currency)]
        public decimal ExpectedSalary { get; set; }
        public bool WorkFromHome { get; set; }
        [Required, StringLength(30)]
        public string Picture { get; set; }
        public virtual List<Skill> Skills { get; set; } = new List<Skill>();
    }
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required, StringLength(50)]
        public string Course { get; set; }
        [Required]
        public int PassingYear { get; set; }
        [Required, StringLength(50)]
        public string Institute { get; set; }
        [Required, StringLength(20)]
        public string Department { get; set; }
        [Required, StringLength(20)]
        public string Result { get; set; }
        [Required, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            Employee c = new Employee
            {
                EmployeeName = "Md. Iquball Hossain",
                AppliedFor = "Web Developer",
                BirthDate = new DateTime(1995, 3, 26),
                ExpectedSalary = 20000.00M,
                Picture = "1.jpg",
                WorkFromHome = true
            };
            c.Skills.Add(new Skill { Course = "Graphics", PassingYear = 2019, Institute = "Dhaka University", Department = "Science", Result = "3.0/5" });
            context.Employees.Add(c);
        }
    }
}