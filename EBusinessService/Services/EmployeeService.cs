using EBusinessData.DAL;
using EBusinessData.UnitOfWorks;
using EBusinessEntity.Entities;
using EBusinessViewModel.Entities.Employee;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EBusinessService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment environment;
        private readonly AppDbContext dbContext;
        public EmployeeService(IUnitOfWork unitOfWork, IHostingEnvironment environment, AppDbContext dbContext)
        {
            this.unitOfWork = unitOfWork;
            this.environment = environment;
            this.dbContext = dbContext;
        }

        public async Task AddEmplooyeAsync(CreateEmployeeVM createEmployeeVM)
        {
            IFormFile file = createEmployeeVM.Image;
            string fileName = Guid.NewGuid().ToString() +file.FileName;
            using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets","img","emplyee",fileName),FileMode.Create);
            await file.CopyToAsync(stream);
            await stream.FlushAsync();
            Employee employee = new Employee
            {
                Name = createEmployeeVM.Name,
                Surname = createEmployeeVM.Surname,
                ImgUrl=fileName,
                Instagram=createEmployeeVM.Instagram,
                Facebook=createEmployeeVM.Facebook,
                Twitter=createEmployeeVM.Twitter,
                PositionId=createEmployeeVM.PositionId,
            };
            await unitOfWork.GetRepository<Employee>().AddAsync(employee);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task<ICollection<Employee>> GetAllEmployee()
        {
            return await dbContext.Employees.Include(e =>e.Positions).ToListAsync(); 
        }

        public async Task RemoveEmployeeAsync(int id)
        {
            var emplooyeId = await unitOfWork.GetRepository<Employee>().GetByIdAsync(id);
            await unitOfWork.GetRepository<Employee>().DeleteAsync(emplooyeId);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeeVM updateEmployeeVM)
        {
            var employeeId = await unitOfWork.GetRepository<Employee>().GetByIdAsync(id);
            if (employeeId != null)
            {
                IFormFile file = updateEmployeeVM.Image;
                string fileName = Guid.NewGuid().ToString() + file.FileName;
                using var stream = new FileStream(Path.Combine(environment.WebRootPath, "assets", "img", "employee", fileName), FileMode.Create);
                await file.CopyToAsync(stream);
                await stream .FlushAsync();
                employeeId.Name=updateEmployeeVM.Name;
                employeeId.Surname=updateEmployeeVM.Surname;
                employeeId.ImgUrl = fileName;
                employeeId.UpdateAt= DateTime.Now;
                employeeId.Twitter=updateEmployeeVM?.Twitter;
                employeeId.Facebook=updateEmployeeVM?.Facebook;
                employeeId.Instagram=updateEmployeeVM?.Instagram;
                employeeId.PositionId=updateEmployeeVM?.PositionId;
                await unitOfWork.GetRepository<Employee>().UpdateAsync(employeeId);
                await unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<UpdateEmployeeVM> UpdateEmployeeAsync(int id)
        {
            var emplooyeId = await unitOfWork.GetRepository<Employee>().GetByIdAsync(id);
            UpdateEmployeeVM vM = new UpdateEmployeeVM
            {
                Name = emplooyeId.Name,
                Surname = emplooyeId.Surname,
                PositionId = emplooyeId.PositionId,
                Instagram = emplooyeId.Instagram,
                Facebook = emplooyeId.Facebook,
                Twitter = emplooyeId.Twitter,
            };

            return vM;
        }
    }
}
