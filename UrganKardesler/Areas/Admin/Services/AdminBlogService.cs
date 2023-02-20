using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UrganKardesler.DTOs;
using UrganKardesler.Models;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Areas.Admin.Services
{
    public class AdminBlogService : IAdminBlogService
    {
        private readonly UrganKardeslerDbCTX _dbCTX;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string directoryPath;

        public AdminBlogService(UrganKardeslerDbCTX dbCTX, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _dbCTX = dbCTX;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            directoryPath = Path.Combine(_hostEnvironment.WebRootPath, "images", "blog");
        }

        public async Task<List<BlogVM>> GetAllAsync()
        {
            var Blogs = await _dbCTX.Blogs.Where(x => x.isActive).Include(x => x.IdentityUser).ToListAsync();

            var BlogsVM = _mapper.Map<List<BlogVM>>(Blogs);

            return BlogsVM;
        }

        public async Task<BlogVM> GetByIdAsync(int id)
        {
            var blog = await _dbCTX.Blogs.Where(x => x.isActive && x.Id == id).FirstOrDefaultAsync();

            if (blog is null)
            {
                return null;
            }

            blog.IdentityUser = await _dbCTX.Users.FindAsync(blog.AuthorId);

            var blogVM = _mapper.Map<BlogVM>(blog);
            return blogVM;
        }

        public async Task<bool> CreateAsync(BlogDTO blog, string userId)
        {
            var newBlog = _mapper.Map<Blog>(blog);

            newBlog.CreatedDate = DateTime.UtcNow;
            newBlog.AuthorId = userId;
            newBlog.isActive = true;

            var imagePathName = "no-thumbnail.png";
            if (blog.ThumbnailBase64Code is not null)
            {
                imagePathName = FileService.SaveBase64Image(blog.ThumbnailBase64Code, directoryPath);
            }
            newBlog.ThumbnailName = imagePathName;

            await _dbCTX.AddAsync(newBlog);

            var result = await _dbCTX.SaveChangesAsync();
            return result > 0;
        }

        public async Task<BlogVM> UpdateAsync(BlogDTO blog)
        {
            var originalBlog = await _dbCTX.Blogs.Where(x => x.isActive && x.Id == blog.Id).FirstOrDefaultAsync();

            if (originalBlog == null)
            {
                return null;
            }
            if (blog.ThumbnailBase64Code is not null)
            {
                blog.ThumbnailName = FileService.SaveBase64Image(blog.ThumbnailBase64Code, directoryPath);
            }

            var newBlog = _mapper.Map<Blog>(blog);

            newBlog.CreatedDate = originalBlog.CreatedDate;
            newBlog.AuthorId = originalBlog.AuthorId;
            newBlog.isActive = true;

            _dbCTX.Blogs.Update(newBlog);

            var res = await _dbCTX.SaveChangesAsync();

            if (res > 0)
            {
                return _mapper.Map<BlogVM>(newBlog);
            }
            return null;
        }

        public async Task<bool> DeleteById(int id)
        {
            var blog = await _dbCTX.Blogs.Where(x => x.isActive && x.Id == id).FirstOrDefaultAsync();

            if (blog is null)
            {
                return false;
            }
            blog.isActive = false;

            _dbCTX.Blogs.Update(blog);

            var res = await _dbCTX.SaveChangesAsync();

            return res > 0;
        }
    }
}