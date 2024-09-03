using ProductDeliveryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductDeliveryManagement.Controllers
{
    [Authorize]
    public class OrderDeliveriesController : Controller
    {
        DeliveryManagementDbContext db = new DeliveryManagementDbContext();
        // GET: OrderDeliveries
        public ActionResult Index(int page = 1)
        {
            int totalPages = (int)Math.Ceiling((double)db.OrdersDeliveries.Count() / 5);
            ViewBag.TotalPages = totalPages;
            ViewBag.Current = page;
            var data = db.OrdersDeliveries.OrderBy(x => x.OrderDeliveryId).Skip((page - 1) * 5).Take(5).ToList();
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            return View(db.OrdersDeliveries.FirstOrDefault(x => x.OrderDeliveryId == id));
        }
        [HttpPost]
        public ActionResult Edit(OrderDelivery delivery)
        {
            if (ModelState.IsValid)
            {
                delivery.IsDelivered = true;
                db.Entry(delivery).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(delivery);
        }
    }
}