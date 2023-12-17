using E_Commerce_App.Models;
using E_Commerce_App.Static;
using E_Commerce_App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager , AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<IActionResult> Users()
        {
            var users = await context.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid) return View(loginVM);

            var user = await userManager.FindByEmailAsync(loginVM.EmailAddress);

            if(user != null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user , loginVM.Password);
                if (passwordCheck)
                {
                    var result = await signInManager.PasswordSignInAsync(user , loginVM.Password, false , false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
				TempData["Error"] = "Wrong Credentials , Please try again!";
				return View(loginVM);
			}

            TempData["Error"] = "Wrong Credentials , Please try again!";
            return View(loginVM);
        }
		[HttpGet]
		public IActionResult Register()
		{
			return View(new RegisterVM());
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
            if (!ModelState.IsValid) return View(registerVM);

            var user = await userManager.FindByEmailAsync(registerVM.EmailAddress);

            if(user != null)
            {
                TempData["Error"] = "This email address already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
                EmailConfirmed = true
            };

            var response = await userManager.CreateAsync(newUser,registerVM.Password);

            if (response.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return View("RegisterCompleted");

		}

        [HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
            return RedirectToAction("Index" , "Movies");
		}
	}
}
