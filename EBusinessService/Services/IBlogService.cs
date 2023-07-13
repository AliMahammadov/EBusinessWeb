using EBusinessEntity.Entities;

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
