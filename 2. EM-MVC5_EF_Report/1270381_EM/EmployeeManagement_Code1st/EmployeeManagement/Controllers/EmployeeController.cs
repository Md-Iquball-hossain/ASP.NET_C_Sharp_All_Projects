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
    public class EmployeeController : Controller
    {
        EmployeeDbContext db = new EmployeeDbContext();
        public ActionResult Index()
        {
            return View(db.Employees.Include(x => x.Skills).ToList());
        }
        public ActionResult Create()
        {
            ViewBag.PostList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Select", Value="", Selected=true},
                new SelectListItem { Text = "Designer", Value="Designer"},
                new SelectListItem { Text = "Web Developer", Value = "Web Developer" },
                new SelectListItem { Text = "Android Developer", Value = "Web Developer" },
                new SelectListItem { Text = "WordPress Developer", Value = "Web Developer" },
                new SelectListItem { Text = "Networking Executive", Value = "Networking Executive" }
            };
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeInputModel data)
        {
            if (ModelState.IsValid)
            {
                Employee c = new Employee
                {
                    EmployeeName = data.EmployeeName,
                    BirthDate = data.BirthDate,
                    AppliedFor = data.AppliedFor,
                    ExpectedSalary = data.ExpectedSalary,
                    WorkFromHome = data.WorkFromHome,
                    Picture = data.Picture
                };
                foreach (var q in data.Skills)
                {
                    c.Skills.Add(q);
                }
                db.Employees.Add(c);
                db.SaveChanges();
                return Json(new { id = c.EmployeeId });
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToForm(EmployeeInputModel c = null, int? index = null)
        {
            if (c == null) c = new EmployeeInputModel();
            if (index.HasValue)
            {
                if (index < c.Skills.Count)
                {
                    c.Skills.RemoveAt(index.Value);
                }
            }
            else
            {
                c.Skills.Add(new Skill());
            }

            return PartialView("_SkillForm", c);
        }
        public ActionResult UploadImage(int id, ImageUpload pic)
        {
            if (ModelState.IsValid)
            {
                if (pic.Picture != null)
                {
                    Employee c = db.Employees.First(x => x.EmployeeId == id);
                    string ext = Path.GetExtension(pic.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    pic.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                    db.SaveChanges();
                    return Json(fileName);
                }
            }
            return Json(null);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.PostList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Select", Value="", Selected=true},
                new SelectListItem { Text = "Designer", Value="Designer"},
                new SelectListItem { Text = "Web Developer", Value = "Web Developer" },
                new SelectListItem { Text = "Android Developer", Value = "Web Developer" },
                new SelectListItem { Text = "WordPress Developer", Value = "Web Developer" },
                new SelectListItem { Text = "Networking Executive", Value = "Networking Executive" }
            };
            var Employee = db.Employees.Include(c => c.Skills).First(c => c.EmployeeId == id);

            return View(
                new EmployeeEditModel
                {
                    EmployeeId = Employee.EmployeeId,
                    EmployeeName = Employee.EmployeeName,
                    BirthDate = Employee.BirthDate,
                    AppliedFor = Employee.AppliedFor,
                    ExpectedSalary = Employee.ExpectedSalary,
                    WorkFromHome = Employee.WorkFromHome,
                    Picture = Employee.Picture,
                    Skills = Employee.Skills.ToList()
                }
                );
        }
        [HttpPost]
        public ActionResult Edit(EmployeeEditModel model)
        {
            var existing = db.Employees.First(c => c.EmployeeId == model.EmployeeId);
            if (ModelState.IsValid)
            {
                existing.EmployeeName = model.EmployeeName;
                existing.BirthDate = model.BirthDate;
                existing.AppliedFor = model.AppliedFor;
                existing.WorkFromHome = model.WorkFromHome;
                existing.ExpectedSalary = model.ExpectedSalary;
                db.Skills.RemoveRange(existing.Skills.ToList());
                foreach (var q in model.Skills)
                {
                    q.EmployeeId = existing.EmployeeId;
                    db.Skills.Add(q);
                }
                db.SaveChanges();
                return Json(existing.EmployeeId);
            }
            return Json(null);
        }
        public PartialViewResult AddQuationToEditForm(EmployeeEditModel c, int? index = null)
        {

            if (index.HasValue)
            {
                if (index < c.Skills.Count)
                {
                    c.Skills.RemoveAt(index.Value);
                }
            }


            return PartialView("_SkillEditForm", c);
        }
        public PartialViewResult AddMore(EmployeeEditModel c, int? index = null)
        {
            if (c == null) c = new EmployeeEditModel();
            if (index.HasValue)
            {
                if (index < c.Skills.Count)
                {
                    c.Skills.RemoveAt(index.Value);
                }
            }
            else
            {
                c.Skills.Add(new Skill());
            }

            return PartialView("_SkillEditForm", c);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Employees.FirstOrDefault(c => c.EmployeeId == id);
            if (existing != null)
            {
                db.Employees.Remove(existing);
                db.SaveChanges();
                return Json(existing.EmployeeId);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}