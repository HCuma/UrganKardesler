using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Threading;
using System.Threading.Tasks;
using UrganKardesler.Models;
using UrganKardesler.Services;

namespace UrganKardesler.Controllers
{
    public class CorporateController : Controller
    {
        private readonly ICorporateService _corporateService;

        public CorporateController(ICorporateService corporateService)
        {
            _corporateService = corporateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<Corporate> GetTitleAndArticle(string title)
        {
            var result = await _corporateService.GetDataByTitleAsync(title);
            return result;
        }
    }
}