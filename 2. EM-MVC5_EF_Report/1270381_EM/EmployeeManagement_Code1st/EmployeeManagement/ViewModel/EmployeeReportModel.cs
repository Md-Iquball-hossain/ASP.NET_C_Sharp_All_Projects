using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeReportModel
    { 
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public System.DateTime BirthDate { get; set; }

    public string AppliedFor { get; set; }

    public decimal ExpectedSalary { get; set; }
    public bool WorkFromHome { get; set; }

    public string Picture { get; set; }
    public byte[] Image { get; set; }
    }
}