using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementApp.Models
{
    public enum SellUnit { kg = 1, g, mg, l, ml, nos }
    public class Product
    {
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = default!;

        [Required, StringLength(100)]
        public string Picture { get; set; } = default!;

        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [EnumDataType(typeof(SellUnit))]
        public SellUnit SellUnit { get; set; }

        public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
    }
    public class ProductInventory
    {
        public int ProductInventoryId { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required, ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; } = default!;
        public virtual Company? Company { get; set; } = default!;
    }
    public class Company
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories => new List<ProductInventory>();
    }
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Company> Companies { get; set; } = default!;
        public DbSet<ProductInventory> ProductInventories { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 1; i <= 7; i++)
            {
                Product p1 = new Product { ProductId = i, Name = $"P{i:00}", UnitPrice = i * 950.00M, SellUnit = SellUnit.kg, Picture = $"{i}.jpg" };
                modelBuilder.Entity<Product>().HasData(p1);
            }
            for (int i = 1; i <= 7; i++)
            {

                Company c = new Company { CompanyId = i, CompanyName = $"Company {i}", Address = $"Addres {i}" };

                modelBuilder.Entity<Company>().HasData(c);


            }
            for (int i = 1; i <= 7; i++)
            {

                ProductInventory pi = new ProductInventory { ProductInventoryId = i, Date = DateTime.Now.AddDays(-23 * i), Quantity = 50 * i, ProductId = i, CompanyId = i };

                modelBuilder.Entity<ProductInventory>().HasData(pi);


            }


        }
    }
}
