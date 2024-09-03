using ProductDeliveryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductDeliveryManagement.ViewModel.Reports
{
    public class DeliveryReportViewModel
    {
        
        public int OrderDeliveryId { get; set; }
        
        public int DeliveryPersonId { get; set; }

        public DateTime? DeliveryDateTime { get; set; }
        public bool IsDelivered { get; set; } = false;
        public string Name { get; set; }
        public int OrderId { get; set; }
        public virtual DeliveryPerson DeliveryPerson { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Today;
        public string CustomerName { get; set; }
        public virtual Order Order { get; set; }
    }
}