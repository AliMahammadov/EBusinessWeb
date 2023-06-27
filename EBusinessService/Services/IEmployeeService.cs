using EBusinessEntity.Entities;
using EBusinessViewModel.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessService.Services
{
    public interface IEmployeeService
    {
        Task AddEmplooyeAsync(CreateEmployeeVM createEmployeeVM);
        Task UpdateEmployeeAsync(int id, UpdateEmployeeVM updateEmployeeVM);
        Task<UpdateEmployeeVM> UpdateEmployeeAsync(int id);
        Task RemoveEmployeeAsync(int id);
        Task<ICollection<Employee>> GetAllEmployee();
    }
}
