using Microsoft.AspNetCore.Identity;
using SampleBilling.Data;
using SampleBilling.Models;
using Microsoft.AspNetCore.Mvc;

namespace SampleBilling.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> signInManager;
        private UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> _signInManager, UserManager<IdentityUser> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }
        public IActionResult Register()
        {          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountViewModel users)
        {
            IdentityUser user = new() { 
            UserName=users.UserName,
            };
           var result= await userManager.CreateAsync(user, users.Password!);
            if (result.Succeeded)
            {
               await signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Billing");

            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(users);
            
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(AccountViewModel model)
        {
           var result= await signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Billing", new {area="Admin"});
            }
            ModelState.AddModelError("", "Invalid LogIn attempt");
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
