using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrganKardesler.DTOs;

namespace UrganKardesler.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginDTO.userName, loginDTO.password, loginDTO.isPersistent, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
                    {
                        return RedirectToAction("Index", "Blog", new { area = "Admin" });
                    }
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError("", "şifre veya kullanıcı adı hatalı");
            }

            return View(loginDTO);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}