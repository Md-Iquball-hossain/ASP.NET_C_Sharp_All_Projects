using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductDeliveryManagement.Models
{
   public enum OrderStatus { Pending=1, AssignedToDeliver, OnWay,Delivered}
    public class Product 
    {
        public int ProductId { get; set; }
        [Required, StringLength(50), Display(Name ="Product name")]
        public string ProductName { get; set; }
        [Required, StringLength(150)]
        public string Description { get; set; }
        [Required, Column(TypeName = "money"), Display(Name ="Price/Unit"), DisplayFormat(DataFormatString ="{0:0.00}", ApplyFormatInEditMode =true)]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Available?")]
        public bool IsAvailable { get; set; } = false;
        //
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
    public class DeliveryPerson 
    {
        public int DeliveryPersonId { get; set;}
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(20)]
        public string Phone { get; set; }
        [Required, StringLength(50)]
        public string Address { get; set; }
        //
        public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; } = new List<OrderDelivery>();
    }
    public class Order 
    {
        public int OrderId { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Order date")]
        public DateTime OrderDate { get; set; } = DateTime.Today;
        [Required, StringLength(50), Display(Name ="Customer name")]
        public string CustomerName { get; set; }
        [Required, StringLength(150), Display(Name ="Customer address")]
        public string CustomerAddress { get; set; }
        [Required, StringLength(20), Display(Name ="Customer phone")]
        public string CustomerPhone { get; set; }
        [Required, ForeignKey("Product"), Display(Name ="Product id")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;
        //
        public virtual Product Product { get; set; }
        public OrderDelivery OrderDelivery { get; set; }
    }
    public class OrderDelivery 
    {
        [ForeignKey("Order")]
        public int OrderDeliveryId { get; set; }
        [Required,ForeignKey("DeliveryPerson")]
        public int DeliveryPersonId { get; set; }
        
        public DateTime? DeliveryDateTime { get; set; }
        public bool IsDelivered { get; set; } = false;
        public virtual DeliveryPerson DeliveryPerson { get; set; }
        public virtual Order Order { get; set; }
    }
    public class DeliveryManagementDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<DeliveryPerson> DeliveryPeople { get; set; }
        public DbSet<Order> Orders { get; set; }    
        public DbSet<OrderDelivery> OrdersDeliveries { get; set;}  
    }
}