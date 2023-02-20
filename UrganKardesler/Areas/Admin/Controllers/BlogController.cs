using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using UrganKardesler.Areas.Admin.Services;
using UrganKardesler.DTOs;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdminBlogService _blogService;
        private readonly string userId;

        public BlogController(IMapper mapper, IAdminBlogService blogService)
        {
            _mapper = mapper;
            _blogService = blogService;

            // TODO : düzenle burayı
            //userId = User.FindFirstValue("userId");
            userId = "asdasd";
        }

        public async Task<IActionResult> Index()
        {
            var Blogs = await _blogService.GetAllAsync();

            return View(Blogs);
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            var res = await _blogService.DeleteById(id);
            var data = res ? new { success = true, message = "Başarıyla silindi." } : new { success = false, message = "blog silinirken bir hata oluştu." };
            return new JsonResult(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogDTO blog)
        {
            var result = await _blogService.CreateAsync(blog, userId);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("ErrorPage", "Home", new ErrorDTO() { errorMessage = "Blog oluşturulurken bir hata oluştu!", errorCode = 505 });
        }

        public async Task<IActionResult> Update(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog is null)
            {
                return RedirectToAction("ErrorPage", "Home", new ErrorDTO() { errorCode = 404, errorMessage = "Aradğınız Sayfa Bulunamadı!" });
            }
            return View(blog);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BlogDTO blog)
        {
            var result = await _blogService.UpdateAsync(blog);

            if (result is null)
            {
                return RedirectToAction("ErrorPage", "Home", new ErrorDTO() { errorMessage = "Blog düzenlenirken bir hata oluştu!", errorCode = 505 });
            }

            return RedirectToAction("Single", "Blog", new { id = blog.Id });
        }

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog is null)
            {
                return RedirectToAction("ErrorPage", "Home", new ErrorDTO() { errorCode = 404, errorMessage = "Aradğınız Sayfa Bulunamadı!" });
            }
            return View(blog);
        }
    }
}