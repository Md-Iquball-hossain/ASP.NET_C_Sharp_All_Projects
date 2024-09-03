using PlayOn24Task.Models;
using PlayOn24Task.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PlayOn24Task.Reports;
using System.IO;

namespace PlayOn24Task.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StoreDbContext db = new StoreDbContext();
        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }
        public ActionResult Create() {
            ViewBag.CustomerNames  =db.Customers.Select(x=> x.CustomerName).ToList();
            ViewBag.Products = db.Products.ToList();
            return View();
        }
        public ActionResult GetCustomerAddress(string customerName)
        {
            var customer = db.Customers.FirstOrDefault(x=> x.CustomerName == customerName);
         if (customer != null)
            {
                return Json(customer.Address, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create(OrderInputModel model)
        {
            if(ModelState.IsValid)
            {
                SqlParameter[] paramObjects = new SqlParameter[]
                {
                    new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
                    new SqlParameter("@name", SqlDbType.NVarChar, 50){ Value=model.CustomerName },
                    new SqlParameter("@address", SqlDbType.NVarChar, 150){ Value=model.Address }
                 };
                db.Database.ExecuteSqlCommand("exec @returnVal=getcustomerid @name, @address" , paramObjects);
                int cid = (int)paramObjects[0].Value;
                Order o = new Order { OrderDate = DateTime.Today,
                CustomerId = cid,
                };
                foreach(var oi in model.Items)
                {
                    o.OrderItems.Add(new OrderItem { ProductId = oi.ProductId, Quantity = oi.Quantity });
                }
                db.Orders.Add(o);
                db.SaveChanges();
                return Json(new { success = true, orderId = o.OrderId });
            }
            return Json(new { success = false });
        }
        public ActionResult Invoice(int id)
        {
            var orders = db.Orders.Include(o => o.Customer)
                .Include(o => o.OrderItems.Select(oi => oi.Product))
                .Where(o => o.OrderId == id);
            if(orders.Count() == 0)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                List<InvoiceViewModel> list = new List<InvoiceViewModel>();
               foreach(var order in orders)
                {
                    var inv = new InvoiceViewModel
                    {
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        CustomerName = order.Customer.CustomerName,
                        Address = order.Customer.Address,

                    };
                    foreach (var oi in order.OrderItems)
                    {
                        inv.ProductId = oi.ProductId;
                        inv.Quantity = oi.Quantity;
                        inv.ProductName = oi.Product.ProductName;
                        inv.OrderId = oi.OrderId;
                        inv.Price = oi.Product.Price;

                    }
                    list.Add(inv);
                }
                return View(list);
            }

        }
        public ActionResult SaveInvoice(int id)
        {
            var orders = db.Orders.Include(o => o.Customer)
               .Include(o => o.OrderItems.Select(oi => oi.Product))
               .Where(o => o.OrderId == id);
            if (orders.Count() == 0)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                List<InvoiceViewModel> list = new List<InvoiceViewModel>();
                foreach (var order in orders)
                {
                    var inv = new InvoiceViewModel
                    {
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        CustomerName = order.Customer.CustomerName,
                        Address = order.Customer.Address,

                    };
                    foreach (var oi in order.OrderItems)
                    {
                        inv.ProductId = oi.ProductId;
                        inv.Quantity = oi.Quantity;
                        inv.ProductName = oi.Product.ProductName;
                        inv.OrderId = oi.OrderId;
                        inv.Price = oi.Product.Price;

                    }
                    list.Add(inv);
                    
                }
                InvoicePrint rpt = new InvoicePrint();
                rpt.SetDataSource(list);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();


                Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "CustomerList.pdf");
            }
        }
    }
}