using CrystalDecisions.CrystalReports.Engine;
using ProductDeliveryManagement.Models;
using ProductDeliveryManagement.ViewModel.Reports;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductDeliveryManagement.Controllers
{
    public class CrystalReportController : Controller
    {
        DeliveryManagementDbContext db = new DeliveryManagementDbContext();
        // GET: CrystalReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductReport()
        {
            var data = db.Orders.Include(o => o.Product).Select(x => new ProductReportViewModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                CustomerName = x.CustomerName,
                CustomerPhone = x.CustomerPhone,
                CustomerAddress = x.CustomerAddress,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ProductName = x.Product.ProductName,
                UnitPrice = x.Product.UnitPrice
            }).ToList();
            return View(data);
        }
        public ActionResult ProductPDF()
        {
            var data = db.Orders.Include(o => o.Product).Select(x => new ProductReportViewModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                CustomerName = x.CustomerName,
                CustomerPhone = x.CustomerPhone,
                CustomerAddress = x.CustomerAddress,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ProductName = x.Product.ProductName,
                UnitPrice = x.Product.UnitPrice
            }).ToList();

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            //rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Products.pdf");

        }
        public ActionResult ProductExcel()
        {
            var data = db.Orders.Include(o => o.Product).Select(x => new ProductReportViewModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                CustomerName = x.CustomerName,
                CustomerPhone = x.CustomerPhone,
                CustomerAddress = x.CustomerAddress,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ProductName = x.Product.ProductName,
                UnitPrice = x.Product.UnitPrice
            }).ToList();

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            //rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Products.xls");

        }
        public ActionResult DeliveryReport()
        {
            var data = db.OrdersDeliveries.Include(o => o.Order).Select(x => new DeliveryReportViewModel
            {
                OrderDeliveryId = x.OrderDeliveryId,
                DeliveryPersonId = x.DeliveryPersonId,
                DeliveryDateTime = x.DeliveryDateTime,
                IsDelivered =   x.IsDelivered,
                Name = x.DeliveryPerson.Name,
                OrderDate = x.Order.OrderDate,
                CustomerName = x.Order.CustomerName
            }).ToList();
            return View(data);
        }
        public ActionResult DeliveryPDF()
        {
            var data = db.OrdersDeliveries.Include(o => o.Order).Select(x => new DeliveryReportViewModel
            {
                OrderDeliveryId = x.OrderDeliveryId,
                DeliveryPersonId = x.DeliveryPersonId,
                DeliveryDateTime = x.DeliveryDateTime,
                IsDelivered = x.IsDelivered,
                Name = x.DeliveryPerson.Name,
                OrderDate = x.Order.OrderDate,
                CustomerName = x.Order.CustomerName
            }).ToList();

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            //rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Deliveries.pdf");

        }
        public ActionResult DeliveryExcel()
        {
            var data = db.OrdersDeliveries.Include(o => o.Order).Select(x => new DeliveryReportViewModel
            {
                OrderDeliveryId = x.OrderDeliveryId,
                DeliveryPersonId = x.DeliveryPersonId,
                DeliveryDateTime = x.DeliveryDateTime,
                IsDelivered = x.IsDelivered,
                Name = x.DeliveryPerson.Name,
                OrderDate = x.Order.OrderDate,
                CustomerName = x.Order.CustomerName
            }).ToList();

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            //rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Deliveries.xls");

        }
    }
}