using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Models;
using ShoppingList.ViewModels;

namespace ShoppingList.Controllers {
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly MyDbContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, MyDbContext context) {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {
                //Available User check password
                var pwCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (pwCheck)
                {
                    //Password is okay
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Item");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Password is incorrect, try again!";
                return View(loginVM);
            }
            //User not found
            TempData["Error"] = "This email is incorrect!";
            return View(loginVM);
        }
    }
}
