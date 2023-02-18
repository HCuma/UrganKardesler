using System.Collections.Generic;
using System.Threading.Tasks;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Areas.Admin.Services
{
    public interface IAdminBlogService
    {
        public Task<BlogVM> GetByIdAsync(int id);

        public Task<List<BlogVM>> GetAllAsync();
    }
}