using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Common
{
    public static class ErrorMessages
    {
        public const string FistNameRequired = "First Name is required.";
        public const string NameMaxLength = "Name cannot exceed 30 characters.";
        public const string EmailRequired = "Email is required.";
        public const string InvalidEmail = "Invalid email format.";
        public const string PhoneRequired = "Phone number is required.";
        public const string InvalidPhone = "Invalid phone number format.";
        public const string SalaryRange = "Salary must be a positive value.";
        public const string DepartmentRequired = "Department is required.";
        public const string DepartmentMaxLength = "Department cannot exceed 50 characters.";
    }
}
