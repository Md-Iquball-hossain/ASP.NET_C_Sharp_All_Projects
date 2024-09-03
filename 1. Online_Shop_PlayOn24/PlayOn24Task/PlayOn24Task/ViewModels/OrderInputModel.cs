using PlayOn24Task.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayOn24Task.ViewModels
{
    public class OrderInputModel
    {
        public int CustomerId { get; set; }
        [Required, StringLength(50), Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        public List<OrderItemViewModel> Items { get; set; }=new List<OrderItemViewModel>();
    }
}