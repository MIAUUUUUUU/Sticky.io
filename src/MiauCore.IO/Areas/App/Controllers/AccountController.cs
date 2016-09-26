using MiauCore.IO.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.App.Controllers
{
    [Route("app/[controller]")]
    public class AccountController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Admin.Models.User user)
        {
            if(user != null && !string.IsNullOrEmpty(user.Login) && !string.IsNullOrEmpty(user.Password))
            {
                var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);

                if (result.Succeeded)
                {
                    return Ok();
                }

                return Unauthorized();
            }

            return Unauthorized();
        }
    }
}
