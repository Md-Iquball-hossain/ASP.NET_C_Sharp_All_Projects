using ProductDeliveryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductDeliveryManagement.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        DeliveryManagementDbContext db = new DeliveryManagementDbContext();
        // GET: Products
        public ActionResult Index(int page = 1)
        {
            int totalPages = (int)Math.Ceiling((double)db.Products.Count() / 5);
            ViewBag.TotalPages = totalPages;
            ViewBag.Current = page;
            var data = db.Products.OrderBy(x => x.ProductId).Skip((page - 1) * 5).Take(5).ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return PartialView("_CreateProduct");
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Products.FirstOrDefault(p => p.ProductId == id);
            return PartialView("_EditProduct", data);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var data = new Product { ProductId = id };
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}