using AutoMapper;
using DeveloperStore.App.ViewModels;
using DeveloperStore.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeveloperStore.App.Controllers;

public class HomeController(IProductService productService, IMapper mapper) : Controller
{
    private readonly IProductService _productService = productService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAllWithCategoryAsync()));
    }
     
    public IActionResult Privacy()
    {
        return View();
    }
 
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
