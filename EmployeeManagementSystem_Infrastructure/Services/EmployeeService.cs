using EmployeeManagementSystem_Core.Interface.IServices;
using EmployeeManagementSystem_Core.Models.Dto;
using EmployeeManagementSystem_Core.Models.Entites;
using EmployeeManagementSystem_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Infrastructure.Services;

public class EmployeeService : IEmployeeServices
{
    private readonly ApplicationDbContext _db;
    public EmployeeService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Employee> AddEmployeeAsync(EmployeeDto employeeDto)
    {
        var existingEmployeeByEmail = await _db.Employees
            .FirstOrDefaultAsync(e => e.Email == employeeDto.Email);
        if (existingEmployeeByEmail != null)
        {
            throw new InvalidOperationException("Email is already exist.");
        }

        var existingEmployeeByPhone = await _db.Employees
            .FirstOrDefaultAsync(e => e.Phone == employeeDto.Phone);
        if (existingEmployeeByPhone != null)
        {
            throw new InvalidOperationException("Phone number is already exist.");
        }

        var employee = new Employee
        {
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Email = employeeDto.Email,
            Phone = employeeDto.Phone,
            Salary = employeeDto.Salary,
            Department = employeeDto.Department,
        };

        await _db.Employees.AddAsync(employee);
        await _db.SaveChangesAsync();
        return employee;
    }


    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
        var emp = await _db.Employees.FindAsync(id);
        if (emp != null)
        {
            _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Employee>> GetAllEmployeeAsync()
    {
        return await _db.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        return await _db.Employees.FindAsync(id);
    }

    public async Task<Employee> UpdateEmployeeAsync(Guid id, EmployeeDto employeeDto)
    {
        var existingEmailEmployee = await _db.Employees
            .FirstOrDefaultAsync(e => e.Email == employeeDto.Email && e.Id != id);
        if (existingEmailEmployee != null)
        {
            throw new Exception("Email is already exist.");
        }

        var existingPhoneEmployee = await _db.Employees
            .FirstOrDefaultAsync(e => e.Phone == employeeDto.Phone && e.Id != id);
        if (existingPhoneEmployee != null)
        {
            throw new Exception("Phone number is already exist.");
        }

        var emp = await _db.Employees.FindAsync(id);
        if (emp != null)
        {
            emp.FirstName = employeeDto.FirstName;
            emp.LastName = employeeDto.LastName;
            emp.Email = employeeDto.Email;
            emp.Phone = employeeDto.Phone;
            emp.Salary = employeeDto.Salary;
            emp.Department = employeeDto.Department;

            _db.Employees.Update(emp);
            await _db.SaveChangesAsync();
            return emp;
        }

        return null;
    }

}
