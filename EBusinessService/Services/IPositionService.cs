using EBusinessEntity.Entities;

namespace EBusinessService.Services
{
    public interface IPositionService
    {
        Task<ICollection<Position>> GetAllPositionAsync();
        Task AddPosition(Position position);
        Task DeletePosition(int? id);
        Task<Position> UpdatePositionAsync(int id);
        Task UpdatePositionPostAsync(int? id, Position position);
    }
}
