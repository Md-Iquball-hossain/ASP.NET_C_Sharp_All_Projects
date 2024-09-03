using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementApp.ViewModels.Input
{
    public class ProductInventoryInputModel
    {
        public string? Key { get; set; }
        public int ProductInventoryId { get; set; }

        [Required, Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required, ForeignKey("Product")]
        public int? ProductId { get; set; }
    }
}
