using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Threading.Tasks;
using UrganKardesler.DTOs;
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

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);

            if (blog is null)
            {
                return RedirectToAction("ErrorPage", "Home", new ErrorDTO() { errorMessage = "Aradığınız sayfa bulunamadı", errorCode = 404 });
            }

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var blogs = await _blogService.GetByTitleAsync(searchString);

            return View(blogs);
        }
    }
}