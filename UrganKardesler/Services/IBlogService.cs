using System.Collections.Generic;
using System.Threading.Tasks;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Services
{
    public interface IBlogService
    {
        public Task<List<BlogVM>> GetAllAsync();

        public Task<BlogVM> GetByIdAsync(int id);

        public Task<List<BlogVM>> GetByTitleAsync(string title);
    }
}