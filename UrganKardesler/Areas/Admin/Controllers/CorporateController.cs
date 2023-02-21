using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UrganKardesler.DTOs;
using UrganKardesler.Models;

namespace UrganKardesler.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CorporateController : Controller
    {
        private readonly UrganKardeslerDbCTX _dbCTX;
        private readonly IMapper _mapper;

        public CorporateController(UrganKardeslerDbCTX dbCTX, IMapper mapper)
        {
            _dbCTX = dbCTX;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _dbCTX.Corporates.Where(x => true).ToListAsync();

            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> Update(CorporateDTO corporate)
        {
            var data = new { isSuccess = false, message = "Güncelleme esnasında client bazlı bir hata oluştu." };
            if (ModelState.IsValid)
            {
                var originalCor = await _dbCTX.Corporates.FindAsync(corporate.Id);

                if (originalCor is not null)
                {
                    originalCor.Article = corporate.Article;
                    _dbCTX.Corporates.Update(originalCor);
                    var res = await _dbCTX.SaveChangesAsync();

                    if (res > 0)
                    {
                        data = new
                        {
                            isSuccess = true,
                            message = originalCor.DisplayTitle + "Başarıyla Güncellendi."
                        };
                    }
                    else
                    {
                        data = new
                        {
                            isSuccess = false,
                            message = originalCor.DisplayTitle + "Güncelleme esnasında sunucuda bir hata oluştu."
                        };
                    }
                }
            }

            return new JsonResult(data);
        }
    }
}