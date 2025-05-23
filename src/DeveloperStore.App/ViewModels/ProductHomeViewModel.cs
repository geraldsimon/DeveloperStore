﻿
namespace DeveloperStore.App.ViewModels;

public class ProductHomeViewModel
{
    public Guid Id { get; set; } 

    public string Name { get; set; } = null!;

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Image { get; set; }

    public string Category { get; set; } = null!;
}
