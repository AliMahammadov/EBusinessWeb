using EBusinessEntity.Entities;
using EBusinessViewModel.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessService.Services
{
    public interface IPostService
    {
        Task AddPostAsync(AddPostVM postVM);
        Task<ICollection<Post>> GetAllPostAsync();
        Task RemovePostAsync(int id);
        Task<EditPostVM> EditPostAsync(int id);
        Task EditPostPostAsync(int id, EditPostVM postVM);
    }
}
