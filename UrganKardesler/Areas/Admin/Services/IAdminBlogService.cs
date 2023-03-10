using System.Collections.Generic;
using System.Threading.Tasks;
using UrganKardesler.DTOs;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Areas.Admin.Services
{
    public interface IAdminBlogService
    {
        public Task<BlogDTO> GetByIdAsync(int id);

        public Task<List<BlogVM>> GetAllAsync();

        public Task<bool> CreateAsync(BlogDTO blog, string userId);

        public Task<BlogDTO> UpdateAsync(BlogDTO blog);

        public Task<bool> DeleteById(int id);
    }
}