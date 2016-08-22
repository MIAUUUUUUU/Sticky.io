using MiauCore.IO.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    [Authorize]
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(BaseUser user)
        {
            //TODO
            var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);

            if (result.Succeeded)
            {
                return View("Index", "Home");
            }

            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(BaseUser baseUser)
        {
            var user = new ApplicationUser()
            {
                UserName = baseUser.Login,
                PasswordHash = baseUser.Password
            };

            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("", "");
            }

            return View("Index", new User
            {
                Login = baseUser.Login
            });
        }
    }
}
