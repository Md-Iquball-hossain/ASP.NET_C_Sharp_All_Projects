using ProductDeliveryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProductDeliveryManagement.ViewModel.Reports
{
    public class ProductReportViewModel
    {
        public int OrderId { get; set; }
       
        public DateTime OrderDate { get; set; } = DateTime.Today;
        
        public string CustomerName { get; set; }
        
        public string CustomerAddress { get; set; }
       
        public string CustomerPhone { get; set; }
        
        public int ProductId { get; set; }
        
        public int Quantity { get; set; } = 1;
        //
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
    }
}