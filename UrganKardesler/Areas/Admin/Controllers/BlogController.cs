using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using UrganKardesler.Areas.Admin.Services;
using UrganKardesler.DTOs;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdminBlogService _blogService;
        private readonly string userId;

        public BlogController(IMapper mapper, IAdminBlogService blogService, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _blogService = blogService;

            // TODO : düzenle burayı
            //userId = User.FindFirstValue("userId");
            userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            // TODO : Check this out
        }

        public async Task<IActionResult> Index(string message, bool isSuccess)
        {
            var Blogs = await _blogService.GetAllAsync();

            ViewBag.isSuccess = isSuccess ? 1 : 0;
            ViewBag.message = message;

            return View(Blogs);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var res = await _blogService.DeleteById(id);
            var data = res ? new { isSuccess = true, message = "Başarıyla silindi.", area = "Admin" } : new { isSuccess = false, message = "blog silinirken bir hata meydana geldi!", area = "Admin" };
            return RedirectToAction("Index", data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogDTO blog)
        {
            if (ModelState.IsValid)
            {
                var result = await _blogService.CreateAsync(blog, userId);
                var data = result ? new { isSuccess = true, message = "Blog Başarıyla Oluşturuldu.", area = "Admin" } : new { isSuccess = false, message = "Blog Oluşturulurken bir hata meydana geldi!", area = "Admin" };

                return RedirectToAction("Index", data);
            }
            return View(blog);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog is null)
            {
                return RedirectToAction("ErrorPage", "Home", new ErrorDTO() { errorCode = 404, errorMessage = "Aradığınız Sayfa Bulunamadı!" });
            }
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogDTO blog)
        {
            if (ModelState.IsValid)
            {
                var result = await _blogService.UpdateAsync(blog);

                var data = result is not null ? new { isSuccess = true, message = "Blog Başarıyla Değiştirildi.", area = "Admin" } : new { isSuccess = false, message = "Blog düzenlenirken bir hata meydana geldi!", area = "Admin" };

                return RedirectToAction("Index", data);
            }
            return View(blog);
        }

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog is null)
            {
                return RedirectToAction("ErrorPage", "Home", new ErrorDTO() { errorCode = 404, errorMessage = "Aradığınız Sayfa Bulunamadı!" });
            }
            return View(_mapper.Map<BlogVM>(blog));
        }
    }
}