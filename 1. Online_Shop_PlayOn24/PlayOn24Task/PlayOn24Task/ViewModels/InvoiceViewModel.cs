using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PlayOn24Task.ViewModels
{
    public class InvoiceViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
       
        public string CustomerName { get; set; }
    
        public string Address { get; set; }
        public int ProductId { get; set; }
     
        public string ProductName { get; set; }
       
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}