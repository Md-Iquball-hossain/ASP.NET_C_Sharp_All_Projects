using PlayOn24Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayOn24Task.Controllers
{
    public class CustomersController : Controller
    {
        private readonly StoreDbContext db = new StoreDbContext();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (customer != null)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var c = db.Customers.FirstOrDefault(p => p.CustomerId == id);
            db.Customers.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}