using Diploma.Application.Interfaces;
using Diploma.WebApi.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManage;
        private readonly IDiplomaDbContext _context;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManage, IDiplomaDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManage = roleManage;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            _signInManager.SignOutAsync();
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/apps/index");
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
                            return Redirect("/Apps");
                        }
                    }
                }
                ModelState.AddModelError("", "Неверный логин или пароль");
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine("Exception: " + e.Message);
            }


            return View("login");

        }
        [AllowAnonymous]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectPermanent("Login");
        }


        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> RegisterUser(RegisterRequest registerData)
        //{
        //    var entity = await _userManager.FindByNameAsync(registerData.Username);
        //    if (entity != null) return BadRequest("Пользователь с данным именем уже зарегистрирован");
        //    else
        //    {
        //        await _roleManage.CreateAsync(new IdentityRole(roleName: "User"));
        //        var user = new IdentityUser
        //        {
        //            Email = registerData.Email,
        //            UserName = registerData.Username,
        //            SecurityStamp = "dummyStamp",
        //        };
        //        var result = await _userManager.CreateAsync(user, registerData.Password);
        //        if (result.Succeeded)
        //        {
        //            _userManager.AddToRoleAsync(user, "User").Wait();
        //            return Redirect("Login");
        //        }
        //        else
        //        {
        //            return BadRequest("Could not create user.");
        //        }
        //    }

        //}

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
