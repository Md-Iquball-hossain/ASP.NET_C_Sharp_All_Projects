using ProductDeliveryManagement.Models;
using ProductDeliveryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductDeliveryManagement.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        DeliveryManagementDbContext db = new DeliveryManagementDbContext();
        // GET: Orders
        public ActionResult Index(int page = 1)
        {
            int totalPages = (int)Math.Ceiling((double)db.Products.Count() / 5);
            ViewBag.TotalPages = totalPages;
            ViewBag.Current = page;

            var data = db.Orders
               .AsEnumerable()
                .OrderBy(x => x.OrderId)
               .Select(o => new OrderViewModel
               {
                   OrderId = o.OrderId,
                   OrderDate = o.OrderDate,
                   ProductId = o.ProductId,
                   Product = o.Product,
                   Quantity = o.Quantity,
                   CustomerName = o.CustomerName,
                   CustomerAddress = o.CustomerAddress,
                   CustomerPhone = o.CustomerPhone,
                   OrderStatus = getStatus(o)

               }).OrderBy(x => x.OrderId).Skip((page - 1) * 5).Take(5).ToList();
            ViewBag.DeliverPeople = db.DeliveryPeople.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            ViewBag.Products = db.Products.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Order model)
        {
            if (ModelState.IsValid)
            {
               db.Orders.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Products = db.Products.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Assign(int OrderId, int DeilveryPersonId)
        {
            var order = db.Orders.Include(x => x.OrderDelivery).FirstOrDefault(x => x.OrderId == OrderId);
            if (order == null) return new HttpNotFoundResult();
            order.OrderDelivery = new OrderDelivery { DeliveryPersonId = DeilveryPersonId };
            db.SaveChanges();
            return Json(new { success = true });
        }
        private OrderStatus getStatus(Order order)
        {
            var od = db.OrdersDeliveries.FirstOrDefault(x => x.OrderDeliveryId == order.OrderId);
            if (od == null) return OrderStatus.Pending;
            if (od.DeliveryPersonId != 0 && !od.IsDelivered) return OrderStatus.AssignedToDeliver;
            else return OrderStatus.AssignedToDeliver;

        }
    }
}