using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Threading.Tasks;
using UrganKardesler.Services;

namespace UrganKardesler.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();

            // TODO: Sınırlı sayıda blog göster sayfa başına.

            return View(blogs);
        }

        public async Task<IActionResult> Single(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);

            if (blog is null)
            {
                return RedirectToAction("ErrorPage", "Home");
            }

            return View(blog);
        }
    }
}