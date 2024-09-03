using SPL_HOME_TASK.Models;
using SPL_HOME_TASK.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace SPL_HOME_TASK.Controllers
{
    public class InfoController : Controller
    {
        private readonly SPL_HOME_TASKEntities db = new SPL_HOME_TASKEntities();
        // GET: Info
        public ActionResult Index(int page =1)
        {
            int totalPages = (int)Math.Ceiling((double)db.DocumentInformations.Count() / 5);
            ViewBag.TotalPages = totalPages;
            ViewBag.Current = page;
            var data = db.DocumentInformations.Include(x=>x.DocumentCategoryInfo).OrderBy(x => x.DocumentyIdentity)
                .Skip((page - 1) * 5)
                .Take(5).ToList();
            ViewBag.Countdata = db.DocumentInformations.Count();
            return View(data);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = db.DocumentCategoryInfoes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Upload()
        {
            HttpFileCollectionBase files = Request.Files;
            var saved = new List<ImagePathResponse>();
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(file.FileName);
                var savePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(savePath);
                saved.Add(new ImagePathResponse { FileName = file.FileName, SavedFileName = fileName });
            }
            return Json(saved);
        }
        [HttpPost]
        public ActionResult Insert(DocumentInformation data)
        {
            if (ModelState.IsValid)
            {
                db.DocumentInformations.Add(data);
                db.SaveChanges();
                return Json(new { success = true, msg = "Data Saved" });
            }
            return Json(new { success = false, msg = "Failed to save data" });
        }
        public ActionResult Edit(int id)
        {
            var data = db.DocumentInformations.FirstOrDefault(x => x.DocumentyIdentity == id);
            return View(data);
        }
    }
}