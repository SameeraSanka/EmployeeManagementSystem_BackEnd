using EmployeeManagementSystem_Core.Interface.IServices;
using EmployeeManagementSystem_Core.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem_API.Controllers;

[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeServices _employeeService;
    public EmployeeController(IEmployeeServices employeeServices)
    {
        _employeeService = employeeServices;
    }

    [HttpGet(Name = "GetAllEmployees")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var emp = await _employeeService.GetAllEmployeeAsync();
        if (emp != null)
        {
            return Ok(emp);
        }
        return NotFound();
    }

    [HttpGet("{id:guid}", Name ="GetEmployee")]
    public async Task<IActionResult> GetEmployee(Guid id)
    {
        var emp = await _employeeService.GetEmployeeByIdAsync(id);
        if (emp != null)
        {
            return Ok(emp);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
    {
        try
        {
            var emp = await _employeeService.AddEmployeeAsync(employeeDto);
            return Ok(emp);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message); 
        }

    }

    [HttpPut("{id:Guid}", Name = "UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeDto employeeDto)
    {
        try
        {
            var emp = await _employeeService.UpdateEmployeeAsync(id, employeeDto);
            if (emp != null)
            {
                return Ok(emp); 
            }
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:Guid}", Name = "DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var result = await _employeeService.DeleteEmployeeAsync(id);
        if (result)
        {
            return Ok();
        }
        return NotFound();
    }
}
