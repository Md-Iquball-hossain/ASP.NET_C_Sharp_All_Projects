using ProductDeliveryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductDeliveryManagement.Controllers
{
    [Authorize]
    public class DeliveryPersonsController : Controller
    {
        DeliveryManagementDbContext db = new DeliveryManagementDbContext();
        // GET: DeliveryPersons
        public ActionResult Index(int page = 1)
        {
            int totalPages = (int)Math.Ceiling((double)db.DeliveryPeople.Count() / 5);
            ViewBag.TotalPages = totalPages;
            ViewBag.Current = page;
            var data = db.DeliveryPeople.OrderBy(x => x.DeliveryPersonId).Skip((page - 1) * 5).Take(5).ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeliveryPerson person)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryPeople.Add(person);
                db.SaveChanges();
                return Json(new { success = true, message = "Data saved successfully" });
            }
            return Json(new { success = false, message = "Failed to save data" });
        }
        public ActionResult Edit(int id)
        {
            var data = db.DeliveryPeople.FirstOrDefault(d => d.DeliveryPersonId == id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(DeliveryPerson person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, data = person });
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var data = new DeliveryPerson { DeliveryPersonId = id };
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}