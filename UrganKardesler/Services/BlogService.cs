using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using UrganKardesler.Areas.Admin.Services;
using UrganKardesler.Models;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Services
{
    public class BlogService : IBlogService
    {
        private readonly UrganKardeslerDbCTX _dbCTX;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        public BlogService(IWebHostEnvironment hostEnvironment, UrganKardeslerDbCTX dbCTX, IMapper mapper)
        {
            _dbCTX = dbCTX;
            _mapper = mapper;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<List<BlogVM>> GetAllAsync()
        {
            var Blogs = await _dbCTX.Blogs.Where(x => x.isActive).Include(x => x.IdentityUser).OrderByDescending(x => x.CreatedDate).ToListAsync();

            if (Blogs.Count == 0)
            {
                return null;
            }
            var BlogsVM = _mapper.Map<List<BlogVM>>(Blogs);

            return BlogsVM;
        }

        public async Task<BlogVM> GetByIdAsync(int id)
        {
            var blog = await _dbCTX.Blogs.Where(x => x.isActive && x.Id == id).FirstOrDefaultAsync();

            if (blog == null)
            {
                return null;
            }

            blog.IdentityUser = await _dbCTX.Users.FindAsync(blog.AuthorId);

            var blogVM = _mapper.Map<BlogVM>(blog);
            return blogVM;
        }

        public async Task<List<BlogVM>> GetByTitleAsync(string title)
        {
            var blogs = await _dbCTX.Blogs.Where(i => i.Title.Contains(title)).ToListAsync();

            if (blogs.Count == 0)
            {
                return null;
            }
            var mappedBlogs = _mapper.Map<List<BlogVM>>(blogs);

            return mappedBlogs;
        }
    }
}