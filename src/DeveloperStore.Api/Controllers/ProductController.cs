﻿using AutoMapper;
using DeveloperStore.Business.Functions;
using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;
using DeveloperStore.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DeveloperStore.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ProductController(IProductService productService,
                                IImageService imageService,
                                IMapper mapper,
                                INotifier notifier) : MainController(notifier)
{
    private readonly IProductService _productService = productService;
    private readonly IImageService _imageService = imageService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [AllowAnonymous]
    public async Task<IEnumerable<ProductLoggedOutViewModel>> GetAll()
    {
        var productList = _mapper.Map<IEnumerable<ProductLoggedOutViewModel>>(await _productService.GetAllAsync());

        foreach (var product in productList)
        {
            product.ImageUpload = _imageService.ConvertImageToBase64(product.Image);
        }

        return productList;
    }

    [HttpGet("{id:guid}/category")]
    [AllowAnonymous]
    public async Task<IEnumerable<ProductLoggedOutViewModel>> GetAllByCategory(Guid id)
    {
        var productsByCategoryList = _mapper.Map<IEnumerable<ProductLoggedOutViewModel>>(await _productService.GetAllByCategory(id));

        foreach (var product in productsByCategoryList)
        {
            product.ImageUpload = _imageService.ConvertImageToBase64(product.Image);
        }

        return productsByCategoryList;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> GetByID(Guid id)
    {
        var sellerId = GeneralFunctions.GetUserIdFromToken(Request.Headers.Authorization.ToString());

        var product = await GetProductByID(id, sellerId);

        if (product == null)
        {
            ReportError("Only the user who created it can delete the record.");
            return CustomResponse();
        }

        product.ImageUpload = _imageService.ConvertImageToBase64(product.Image);

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Add([FromBody] ProductViewModel produtoViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var completeName = $"{Guid.NewGuid()}_{produtoViewModel.Image}".Trim();

        var fileName = await UploadFile(produtoViewModel.ImageUpload, completeName);

        if (string.IsNullOrEmpty(fileName))
        {
            return CustomResponse(ModelState);
        }

        produtoViewModel.Image = fileName;

        await _productService.AddAsync(_mapper.Map<Product>(produtoViewModel));

        return CustomResponse(produtoViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, ProductViewModel produtoViewModel)
    {
        if (id != produtoViewModel.Id)
        {
            ReportError("The IDs provided are not the same!");
            return CustomResponse();
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var sellerId = GeneralFunctions.GetUserIdFromToken(Request.Headers.Authorization.ToString());

        var productUpdate = await GetProductByID(id, sellerId);
        if (productUpdate == null)
        {
            ReportError("Only the user who created it can make changes.");
            return CustomResponse();
        }

        var fileName = await UpdateFile(produtoViewModel.ImageUpload, produtoViewModel.Name, productUpdate.Image);

        productUpdate.Stock = produtoViewModel.Stock;
        productUpdate.Price = produtoViewModel.Price;
        productUpdate.Name = produtoViewModel.Name;
        productUpdate.Description = produtoViewModel.Description;
        productUpdate.Image = fileName;

        await _productService.UpdateAsync(_mapper.Map<Product>(productUpdate));

        return CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
    {
        var sellerId = GeneralFunctions.GetUserIdFromToken(Request.Headers.Authorization.ToString());

        var product = await GetProductByID(id, sellerId);

        if (product == null)
        {
            ReportError("Only the user who created it can delete the record.");
            return CustomResponse();
        }

        var entity = await _productService.GetByIdAsync(id);

        if (await _productService.DeleteAsync(id))
        {
            UpdateFile(entity.Image);
        }

        return CustomResponse(HttpStatusCode.NoContent);
    }

    private async Task<ProductViewModel> GetProductByID(Guid id, Guid sellerId)
    {
        return _mapper.Map<ProductViewModel>(await _productService.GetByIdAsync(id, sellerId));
    }

    private async Task<string> UploadFile(string arquivo, string imgNome)
    {
        if (string.IsNullOrEmpty(arquivo))
        {
            ReportError("Please provide an image for this product!");
            return string.Empty;
        }

        var imageName = await _imageService.SaveImageAsync(arquivo, imgNome);

        return imageName;
    }

    private async Task<string> UpdateFile(string arquivo, string imgNome, string oldFileName)
    {
        if (string.IsNullOrEmpty(arquivo))
        {
            ReportError("Please provide an image for this product!");
            return string.Empty;
        }

        var imageName = await _imageService.UpdateImageAsync(arquivo, imgNome, oldFileName);

        return imageName;
    }

    private void UpdateFile(string delete)
    {
        if (string.IsNullOrEmpty(delete))
        {
            ReportError("Please provide an image for this product!");
            return;
        }

        _imageService.DeleteFile(delete);
    }
}