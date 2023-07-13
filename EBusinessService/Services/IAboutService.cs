using EBusinessEntity.Entities;
using EBusinessViewModel.Entities.AboutVM;

namespace EBusinessService.Services
{
    public interface IAboutService
    {
        Task AddAboutAsync (CreateAboutVM aboutVM);
        Task<ICollection<About>> GetAllAboutAsync();
        Task RemovePostAsync(int id);
        Task<UpdateAboutVM> UpdateAboutAsync(int id);
        Task UpdateAboutAsync(int id, UpdateAboutVM aboutVM);
    }
}
