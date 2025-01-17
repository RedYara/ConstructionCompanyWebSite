using Application.Interfaces;
using Web.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManage, IWebDbContext context) : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManage = roleManage;
        private readonly IWebDbContext _context = context;

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/building/index");
            }

            var existingUser = await userManager.FindByNameAsync(Environment.GetEnvironmentVariable("ADMIN_USERNAME"));
            if (existingUser == null)
            {
                var user = new IdentityUser()
                {
                    UserName = Environment.GetEnvironmentVariable("ADMIN_USERNAME"),
                    Email = $"{Environment.GetEnvironmentVariable("ADMIN_USERNAME")}@admin.com",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(user, Environment.GetEnvironmentVariable("ADMIN_PASSWORD"));
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser(LoginRequest loginData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser user = await _userManager.FindByNameAsync(loginData.Username);
                    if (user != null)
                    {
                        await _signInManager.SignOutAsync();
                        if ((await _signInManager.PasswordSignInAsync(user, loginData.Password, false, false)).Succeeded)
                        {
                            return Redirect("/Building/Index");
                        }
                    }
                }
                ModelState.AddModelError("", "Неверный логин или пароль");
            }
            catch (Exception e)
            {

                System.Console.WriteLine("Exception: " + e.Message);
            }


            return RedirectToAction("Login");

        }
        [AllowAnonymous]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectPermanent("/building/index");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public bool CheckUsername(string username)
        {
            if (_context.Users.Select(x => x.UserName).Contains(username))
                return false;
            return true;
        }
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public bool CheckEmail(string email)
        {
            if (_context.Users.Select(x => x.Email).Contains(email))
                return false;
            return true;
        }
    }
}
