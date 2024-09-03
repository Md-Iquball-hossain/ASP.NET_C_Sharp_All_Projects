using ProductDeliveryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductDeliveryManagement.ViewModel
{
    public class ReportViewModel
    {
      
        public int OrderDeliveryId { get; set; }
        public int DeliveryPersonId { get; set; }
        public DateTime? DeliveryDateTime { get; set; }
        public bool IsDelivered { get; set; } = false;
        public virtual DeliveryPerson DeliveryPerson { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}