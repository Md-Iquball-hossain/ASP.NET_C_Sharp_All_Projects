using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.ViewModel
{
    public class SkillReportModel
    {
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
    public string EmployeeName { get; set; }
    }
}