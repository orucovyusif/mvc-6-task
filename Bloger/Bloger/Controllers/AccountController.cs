using Bloger.ViewModels;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloger.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(MemberRegisterVm vm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = null;

            user = await _userManager.FindByNameAsync(vm.UserName);

            if (user !=null)
            {
                ModelState.AddModelError("Username", "Username already exist");
                return View();
            }
            user = await _userManager.FindByEmailAsync(vm.Email);

            if (user != null)
            {
                ModelState.AddModelError("Email", "Email already exist");
                return View();
            }

            user = new AppUser
            {
                FullName = vm.FullName,
                UserName = vm.UserName,
                Email = vm.Email,

            };

            var result = await _userManager.CreateAsync(user,vm.Password);
            if (!result.Succeeded) 
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();  
                }
            }

            await _userManager.AddToRoleAsync(user, "Member");

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is not valid");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is not valid");
                return View();
            }


            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
    }
}
