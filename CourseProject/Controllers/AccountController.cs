using CourseProject.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public UserManager<IdentityUser> UserManager { get; }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
                    UserName = registerViewModel.Username,
                    Email = registerViewModel.Email,
                };

                var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);

                if (identityResult.Succeeded)
                {
                    // assign this user the "User" role
                    var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");

                    if (roleIdentityResult.Succeeded)
                    {
                        // Show success notification
                        return RedirectToAction("Login", "Account");
                    }
                }
            }
            // Show error notification
            return View();
        }
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl,
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);

            if (signInResult != null && signInResult.Succeeded)
            {
                if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl)) 
                {
                    return RedirectToPage("loginViewModel.ReturnUrl");
                }

                return RedirectToAction("Index", "DefaultPage");
            }

            //Show errors
            return View();
        }

        public async Task<IActionResult> Logout() 
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "DefaultPage");
        }
        public  IActionResult AccessDenied() 
        {
            return View();
        }
    }
}
