using EBusinessData.DAL;
using EBusinessData.UnitOfWorks;
using EBusinessEntity.Entities;
using EBusinessViewModel.Entities.Employee;
using EBusinessViewModel.Entities.Post;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessService.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment environment;
        private readonly AppDbContext dbContext;

        public PostService(IUnitOfWork unitOfWork, IHostingEnvironment environment, AppDbContext dbContext)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
            this.dbContext = dbContext;
        }
        public async Task AddPostAsync(AddPostVM postVM)
        {

            IFormFile file = postVM.Image;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "post", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            Post postVMs = new Post
            {
                Title = postVM.Title,
                Description = postVM.Description,
                ImageUrl = fileName,
                BlogId = postVM.BlogId,

            };
            await unitOfWork.GetRepository<Post>().AddAsync(postVMs);
            await unitOfWork.SaveChangeAsync();
        }

        public Task<EditPostVM> EditPostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EditPostPostAsync(int id, EditPostVM postVM)
        {
            var postId = await unitOfWork.GetRepository<Post>().GetByIdAsync(id);
            if (postId != null)
            {
                IFormFile file = postVM.Image;
                string fileName = Guid.NewGuid().ToString() + file.FileName;
                using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "post", fileName), FileMode.Create);
                await file.CopyToAsync(stream);
                await stream.FlushAsync();
                postId.Title = postVM.Title;
                postId.ImageUrl = fileName;
                postId.BlogId = postVM.BlogId;
                postId.UpdateAt = DateTime.Now;
                postId.Description = postVM.Description;
                await unitOfWork.GetRepository<Post>().UpdateAsync(postId);
                await unitOfWork.SaveChangeAsync();
            }
        }

            public async Task<ICollection<Post>> GetAllPostAsync()
            {
                return await dbContext.Posts.Include(e => e.Blog).ToListAsync();

            }

            public async Task RemovePostAsync(int id)
            {
                var postId = await unitOfWork.GetRepository<Post>().GetByIdAsync(id);
                await unitOfWork.GetRepository<Post>().DeleteAsync(postId);
                await unitOfWork.SaveChangeAsync();
            }
        
    }
}
