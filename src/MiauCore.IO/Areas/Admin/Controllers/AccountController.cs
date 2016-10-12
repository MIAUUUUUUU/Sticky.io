using MiauCore.IO.Areas.Admin.Models;
using MiauCore.IO.Areas.Admin.ViewModels;
using MiauCore.IO.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.User.Login, model.User.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult List()
        {
            var users = _userManager.Users.ToList();
            var name = User.Identity.Name;
            var user = users.FirstOrDefault(u => u.UserName == name);

            users.Remove(user);

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var userIdentity = await _userManager.GetUserAsync(User);

            var user = new User
            {
                IdentityId = userIdentity.Id,
                Email = userIdentity.Email,
                Login = userIdentity.UserName
            };
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
            var userIdentity = await _userManager.GetUserAsync(User);

            userIdentity.Email = user.Email;
            userIdentity.UserName = user.Login;

            await _userManager.UpdateAsync(userIdentity);

            return Redirect("/Admin/Account/List");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return Redirect("/Admin/Account/List");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginViewModel vm)
        {
            var user = new ApplicationUser { UserName = vm.User.Login, Email = vm.User.Email };
            var result = await _userManager.CreateAsync(user, vm.User.Password);
            if (result.Succeeded)
            {
                if (User.Identity.IsAuthenticated)
                {
                    return Redirect("/Admin/Account/List");
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("/Admin/Home/Index");
                }
            }

            vm.IdentityErrors = result.Errors;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
