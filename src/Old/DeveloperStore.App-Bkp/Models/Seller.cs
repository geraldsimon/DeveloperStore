using Microsoft.AspNetCore.Identity;

namespace DeveloperStore.App.Models
{
    public class Seller : IdentityUser
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Product> Products { get; set; } = [];
    }
}
