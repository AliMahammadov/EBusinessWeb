using EBusinessData.DAL;
using EBusinessData.UnitOfWorks;
using EBusinessEntity.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessService.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddBlogAsync(Blog blog)
        {
            await unitOfWork.GetRepository<Blog>().AddAsync(blog);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<Blog> EditBlogAsync(int id)
        {
           var blogId = await unitOfWork.GetRepository<Blog>().GetByIdAsync(id);
            if(blogId != null)
            {
                return blogId;
            }
            return blogId;
        }

        public async Task EditPostBlogAsync(int id, Blog blog)
        {
            var blogId = await unitOfWork.GetRepository<Blog>().GetByIdAsync(id);
            if(blogId != null)
            {
                blogId.Name = blog.Name;
                blogId.UpdateAt= DateTime.Now;
                await unitOfWork.GetRepository<Blog>().UpdateAsync(blogId);
                await unitOfWork.SaveChangeAsync(); 
            }
        }

        public async Task<ICollection<Blog>> GetAllBlogAsync()
        {
       return await unitOfWork.GetRepository<Blog>().GetAllAsync();
        }

        public async Task RemoveBlogAsync(int id)
        {
            var blogId = await unitOfWork.GetRepository<Blog>().GetByIdAsync(id);
            await unitOfWork.GetRepository<Blog>().DeleteAsync(blogId);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
