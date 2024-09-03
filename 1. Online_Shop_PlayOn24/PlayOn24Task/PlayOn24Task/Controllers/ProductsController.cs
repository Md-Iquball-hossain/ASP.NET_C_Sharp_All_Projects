using PlayOn24Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayOn24Task.Controllers
{
    public class ProductsController : Controller
    {
        private readonly StoreDbContext db = new StoreDbContext();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(product != null)
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(p=>p.ProductId == id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}