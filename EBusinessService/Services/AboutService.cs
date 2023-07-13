using EBusinessData.UnitOfWorks;
using EBusinessEntity.Entities;
using EBusinessViewModel.Entities.AboutVM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EBusinessService.Services
{
    public class AboutService : IAboutService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IHostingEnvironment environment;

        public AboutService(UnitOfWork unitOfWork, IHostingEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
        }

        public async Task AddAboutAsync(CreateAboutVM aboutVM)
        {
            IFormFile file = aboutVM.Image;
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "about", fileName), FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            About about = new About
            {
                ImgUrl = fileName,
                Title = aboutVM.Title,
                Information = aboutVM.Information,
                CreateAt = DateTime.Now,
            };
            await unitOfWork.GetRepository<About>().AddAsync(about);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<About>> GetAllAboutAsync()
        {
            return await unitOfWork.GetRepository<About>().GetAllAsync();
        }

        public async Task RemovePostAsync(int id)
        {
            var aboutId = await unitOfWork.GetRepository<About>().GetByIdAsync(id);
            await unitOfWork.GetRepository<About>().DeleteAsync(aboutId);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<UpdateAboutVM> UpdateAboutAsync(int id)
        {
            var aboutId = await unitOfWork.GetRepository<About>().GetByIdAsync(id);
            UpdateAboutVM vM = new UpdateAboutVM
            {
                Title = aboutId.Title,
                Information = aboutId.Information,
            };
            return vM;

        }

        public async Task UpdateAboutAsync(int id, UpdateAboutVM aboutVM)
        {
            var aboutId = await unitOfWork.GetRepository<About>().GetByIdAsync(id);
            if (aboutId != null)
            {
                IFormFile file = aboutVM.Image;
                string fileName = Guid.NewGuid().ToString() + file.FileName;
                using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "about", fileName), FileMode.Create);
                await stream.CopyToAsync(stream);
                await stream.FlushAsync();
                aboutId.Information = aboutVM.Information;
                aboutId.ImgUrl = fileName;
                aboutId.Title = aboutVM.Title;
                aboutId.UpdateAt = DateTime.Now;
                await unitOfWork.GetRepository<About>().UpdateAsync(aboutId);
                await unitOfWork.SaveChangeAsync();

            }
        }
    }
}
