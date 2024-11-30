using EmployeeManagementSystem_Core.Models.Dto;
using EmployeeManagementSystem_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Core.Interface.IServices;

public interface IEmployeeServices
{
    Task<List<Employee>> GetAllEmployeeAsync();
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<Employee> AddEmployeeAsync(EmployeeDto employeeDto);
    Task<Employee> UpdateEmployeeAsync(Guid id, EmployeeDto employeeDto);
    Task<bool> DeleteEmployeeAsync(Guid id);
}
