using EmployeeManagementSystem_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Core.Models.Entites;

public class Employee
{

    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = ErrorMessages.FistNameRequired)]
    [StringLength(30, ErrorMessage = ErrorMessages.NameMaxLength)]
    public string FirstName { get; set; }

    [StringLength(30, ErrorMessage = ErrorMessages.NameMaxLength)]
    public string LastName { get; set; }

    [NotMapped]
    public string Name => $"{FirstName} {LastName}";

    [Required(ErrorMessage = ErrorMessages.EmailRequired)]
    [EmailAddress(ErrorMessage = ErrorMessages.InvalidEmail)]
    public string Email { get; set; }

    [Required(ErrorMessage = ErrorMessages.PhoneRequired)]
    [RegularExpression(@"^\d{10}$", ErrorMessage = ErrorMessages.InvalidPhone)]
    public string Phone { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = ErrorMessages.SalaryRange)]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = ErrorMessages.DepartmentRequired)]
    [StringLength(50, ErrorMessage = ErrorMessages.DepartmentMaxLength)]
    public string Department { get; set; }
}
