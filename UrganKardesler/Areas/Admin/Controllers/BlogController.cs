using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UrganKardesler.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.FindFirstValue("userId");
            return View();
        }
    }
}