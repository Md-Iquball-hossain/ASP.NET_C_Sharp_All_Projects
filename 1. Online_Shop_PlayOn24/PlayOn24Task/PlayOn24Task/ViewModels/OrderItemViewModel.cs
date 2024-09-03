using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayOn24Task.ViewModels
{
    public class OrderItemViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}