using System.ComponentModel.DataAnnotations;

namespace DeveloperStore.App.ViewModels;

public class CategoryViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "The name field is mandatory.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "The Description field is mandatory.")]
    public string Description { get; set; }

    public ICollection<ProductViewModel> Products { get; set; } = [];
}
