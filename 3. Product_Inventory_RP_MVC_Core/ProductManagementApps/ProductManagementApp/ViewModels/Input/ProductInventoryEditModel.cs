using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementApp.ViewModels.Input
{
    public class ProductInventoryEditModel
    {
       public int ProductInventoryId { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required, ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}
