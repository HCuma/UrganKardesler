using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UrganKardesler.Areas.Admin.Services;
using UrganKardesler.Models;

namespace UrganKardesler.Services
{
    public class CorporateService : ICorporateService
    {
        private readonly UrganKardeslerDbCTX _dbCTX;

        public CorporateService(UrganKardeslerDbCTX dbCTX)
        {
            _dbCTX = dbCTX;
        }

        public async Task<Corporate> GetDataByTitleAsync(string title)
        {
            var result = await _dbCTX.Corporates.Where(x => x.Title == title).FirstOrDefaultAsync();

            return result;
        }
    }
}