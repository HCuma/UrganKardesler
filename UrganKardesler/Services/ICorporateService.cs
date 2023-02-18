using System.Threading.Tasks;
using UrganKardesler.Models;

namespace UrganKardesler.Services
{
    public interface ICorporateService
    {
        public Task<Corporate> GetDataByTitleAsync(string title);
    }
}