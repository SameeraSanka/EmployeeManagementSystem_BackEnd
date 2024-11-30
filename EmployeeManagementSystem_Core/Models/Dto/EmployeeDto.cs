using EmployeeManagementSystem_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Core.Models.Dto;

public class EmployeeDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = ErrorMessages.FistNameRequired)]
    [StringLength(30, ErrorMessage = ErrorMessages.NameMaxLength)]
    public string FirstName { get; set; }

    [StringLength(30, ErrorMessage = ErrorMessages.NameMaxLength)]
    public string LastName { get; set; }

    [Required(ErrorMessage = ErrorMessages.EmailRequired)]
    [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmail)]
    public string Email { get; set; }

    [Required(ErrorMessage = ErrorMessages.PhoneRequired)]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = ErrorMessages.InvalidPhone)]
    public string Phone { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = ErrorMessages.SalaryRange)]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = ErrorMessages.DepartmentRequired)]
    [StringLength(50, ErrorMessage = ErrorMessages.DepartmentMaxLength)]
    public string Department { get; set; }
}
