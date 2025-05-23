﻿using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DeveloperStore.App.ViewModels;

namespace DeveloperStore.App.Controllers;

public class AccountController(ISellerService sellerService,
                         SignInManager<ApplicationUser> signInManager,
                         UserManager<ApplicationUser> userManager) : Controller
{
    private readonly ISellerService _sellerService = sellerService;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or password is incorrect.");
                return View(model);
            }
        }
        return View(model);
    }


    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var logedUser = await _userManager.GetUserAsync(User);
                var userId = logedUser?.Id;
                Seller saller = new()
                {
                    Id = (Guid)userId,
                    Name = model.Name,
                };

                await _sellerService.AddAsync(saller);
                await _signInManager.SignOutAsync();
            }
            

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        return View(model);
   }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
