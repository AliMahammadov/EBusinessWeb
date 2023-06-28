using EBusinessEntity.Entities;
using EBusinessViewModel.Entities.Employee;

namespace EBusinessService.Services.Abstraction;

public interface IEmployeeService
{
    Task AddEmplooyeAsync(CreateEmployeeVM createEmployeeVM);
    Task UpdateEmployeeAsync(int id, UpdateEmployeeVM updateEmployeeVM);
    Task<UpdateEmployeeVM> UpdateEmployeeAsync(int id);
    Task RemoveEmployeeAsync(int id);
    Task<ICollection<Employee>> GetAllEmployeeAsync();
}
