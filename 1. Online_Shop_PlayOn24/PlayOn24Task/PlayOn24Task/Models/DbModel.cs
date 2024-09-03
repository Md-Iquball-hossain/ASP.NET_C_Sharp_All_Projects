using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlayOn24Task.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }= new List<Order>();

    }
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(50)]
        public string ProductName { get; set; }
        [Required, Column(TypeName ="money")]
        public decimal Price { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
       
    }
    public class Order
    {
        
        public int OrderId { get; set;}
        [Required, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required, Column(TypeName ="date")]
        public DateTime OrderDate { get; set;}
        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set;}
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }=new List<OrderItem>();
    }
    public class OrderItem
    {
        [Key, Column(Order =0), ForeignKey("Order")]
        public int OrderId { get; set;}
        [Key, Column(Order = 1), ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set;}
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }    
    }
    public class StoreDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
   
}