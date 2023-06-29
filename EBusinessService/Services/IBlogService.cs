using EBusinessEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessService.Services
{
    public interface IBlogService
    {
        Task AddBlogAsync(Blog blog); //blog elave et
        Task<ICollection<Blog>> GetAllBlogAsync(); //get butun blogu getir
        Task RemoveBlogAsync(int id);
        Task<Blog> EditBlogAsync(int id);
        Task EditPostBlogAsync(int id, Blog blog);

    }
}
