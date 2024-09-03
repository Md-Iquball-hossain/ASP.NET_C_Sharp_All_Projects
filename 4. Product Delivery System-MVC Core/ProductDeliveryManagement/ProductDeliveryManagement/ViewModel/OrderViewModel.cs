﻿using ProductDeliveryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDeliveryManagement.ViewModel
{
   
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; }
        public virtual Product Product { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}