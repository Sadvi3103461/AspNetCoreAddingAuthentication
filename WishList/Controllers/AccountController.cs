using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using WishList.Models.AccountViewModels;

namespace WishList.Controllers
{
    
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]

        public IActionResult Register( RegisterViewModel registerViewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewmodel);
            }

            var result = _userManager.CreateAsync(new ApplicationUser() { Email = registerViewmodel.Email, UserName = registerViewmodel.Email }, registerViewmodel.Password).Result;

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }

                return View(registerViewmodel);

            }

            return RedirectToAction  ("Index" ,"Home");
        }









        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() 
        { return View(); }





        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return RedirectToAction("Item.Index", "Home");
        }





    }
}
