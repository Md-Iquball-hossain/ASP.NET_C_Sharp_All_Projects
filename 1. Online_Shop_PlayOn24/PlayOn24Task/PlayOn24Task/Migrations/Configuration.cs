namespace PlayOn24Task.Migrations
{
    using PlayOn24Task.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlayOn24Task.Models.StoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PlayOn24Task.Models.StoreDbContext context)
        {
            Customer c1 = new Customer { CustomerName = "Iquball Hossain", Address = "Mirpur 10, Dhaka" };
            Customer c2 = new Customer { CustomerName = "Abdur Rahim", Address = "Mirpur 1, Dhaka" };
            Product p1 = new Product { ProductName = "Samsung A35", Price = 35000.00M };
            Product p2 = new Product { ProductName = "HP Pavillion 1500", Price = 55000.00M };
            context.Products.AddRange(new Product[] { p1, p2 });
            context.Customers.AddRange(new Customer[] { c1, c2 });
            context.SaveChanges();

        }
    }
}
