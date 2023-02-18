using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
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

        public BlogService(UrganKardeslerDbCTX dbCTX, IMapper mapper)
        {
            _dbCTX = dbCTX;
            _mapper = mapper;
        }

        public async Task<List<BlogVM>> GetAllAsync()
        {
            var c = new AdminBlogService(_dbCTX, _mapper);

            var Blogs = await _dbCTX.Blogs.Where(x => true).Include(x => x.IdentityUser).ToListAsync();

            var BlogsVM = _mapper.Map<List<BlogVM>>(Blogs);

            var xx = await c.CreateAsync(BlogsVM.First(), "1");

            return BlogsVM;
        }

        public async Task<BlogVM> GetByIdAsync(int id)
        {
            var blog = await _dbCTX.Blogs.FindAsync(id);

            blog.IdentityUser = await _dbCTX.Users.FindAsync(blog.AuthorId);

            var blogVM = _mapper.Map<BlogVM>(blog);
            return blogVM;
        }
    }
}