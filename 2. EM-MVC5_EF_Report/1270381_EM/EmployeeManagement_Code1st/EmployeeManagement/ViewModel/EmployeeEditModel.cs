using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeEditModel
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

        public string Picture { get; set; }
        public virtual List<Skill> Skills { get; set; } = new List<Skill>();
    }
}