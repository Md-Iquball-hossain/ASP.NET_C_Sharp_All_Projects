using CrystalDecisions.CrystalReports.Engine;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ReportsController : Controller
    {
            EmployeeDbContext db = new EmployeeDbContext();
            // GET: Reports
            public ActionResult EmployeeReport()
            {

                return View(db.Employees.ToList()); ;
            }
            public ActionResult SkillReport()
            {
                var data = db.Skills.Include(x => x.Employee).Select(x => new SkillReportModel
                {
                    EmployeeName = x.Employee.EmployeeName,
                    EmployeeId = x.EmployeeId,
                    Course = x.Course,
                    PassingYear = x.PassingYear,
                    Department= x.Department,
                    Result = x.Result,
                    Institute = x.Institute,
                }).ToList();
                return View(data);
            }
        public ActionResult EmployeePDF()
        {
            var data = db.Employees.AsEnumerable().Select(x => new EmployeeReportModel
            {
                EmployeeId = x.EmployeeId,
                EmployeeName = x.EmployeeName,
                AppliedFor = x.AppliedFor,
                BirthDate = x.BirthDate,
                ExpectedSalary = x.ExpectedSalary,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Pictures"), x.Picture))
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Employees.pdf");

        }
        public ActionResult SkillPDF()
        {
            var data = db.Skills.Include(x => x.Employee).Select(x => new SkillReportModel
            {
                EmployeeName = x.Employee.EmployeeName,
                EmployeeId = x.EmployeeId,
                Course = x.Course,
                PassingYear = x.PassingYear,
                Department= x.Department,
                Result = x.Result,
                Institute = x.Institute
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Skills.pdf");
        }
    }
}