using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperStore.App.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // FK for Category
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // FK for Seller
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; } = null!;
    }
}
