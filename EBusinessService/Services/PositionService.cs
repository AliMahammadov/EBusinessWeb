using EBusinessData.UnitOfWorks;
using EBusinessEntity.Entities;

namespace EBusinessService.Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork unitOfWork;

        public PositionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddPosition(Position position)
        {
            Position positions = new Position
            {
                Name = position.Name,
            };
            await unitOfWork.GetRepository<Position>().AddAsync(positions);
            await unitOfWork.SaveChangeAsync();

        }

        public async Task DeletePosition(int? id)
        {
            var position = await unitOfWork.GetRepository<Position>().GetByIdAsync(id);
            await unitOfWork.GetRepository<Position>().DeleteAsync(position);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Position>> GetAllPositionAsync()
        {
           await unitOfWork.GetRepository<Position>().GetAllAsync();
            return await unitOfWork.GetRepository<Position>().GetAllAsync();
        }

        public async Task<Position> UpdatePositionAsync(int id)
        {
            var positionOne = await unitOfWork.GetRepository<Position>().GetByIdAsync(id);
          Position position = new Position 
          {
              Name = positionOne.Name
          };
           return position;
        }

        public async Task UpdatePositionPostAsync(int? id, Position position)
        {
            var positionOne = await unitOfWork.GetRepository<Position>().GetByIdAsync(id);
            if (positionOne!=null)
            {
                positionOne.Name = position.Name;
                positionOne.UpdateAt = DateTime.Now;

                await unitOfWork.GetRepository<Position>().UpdateAsync(positionOne);
                await unitOfWork.SaveChangeAsync();
            }
           
        }
    }
}
