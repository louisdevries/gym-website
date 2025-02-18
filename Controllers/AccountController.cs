using Microsoft.AspNetCore.Mvc;
using GymWebsite.Models;  // Your model namespace
using GymWebsite.ViewModels;  // Namespace for view models (if needed)
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Login Action - Shows Login Page
    [HttpGet]
    public IActionResult Login()
    {
        return View(); // Returns the Login view
    }

    // Login Action - Handles Form Submission
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");  // Redirect to home after successful login
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            else
            {
                ModelState.AddModelError("", "User not found.");
            }
        }
        return View(model);  // Return to the login view with error messages
    }

    // Register Action - Shows Register Page
    [HttpGet]
    public IActionResult Register()
    {
        return View();  // Returns the Register view
    }

    // Register Action - Handles Form Submission
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Username = model.Username,
                Email = model.Email
            };

            // Use CreateAsync to automatically hash the password
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");  // Redirect to home after successful registration
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View(model);  // Return to the register view with error messages
    }

}
