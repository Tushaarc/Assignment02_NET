using EmpMngmntSys.DTOs.Employee;
using EmpMngmntSys.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpMngmntSys.DTOs.Department
{
    public class GetDepartmentEmployeesDto
    {
        [Key]
        public int DId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100), MinLength(21)]
        public int Age { get; set; } = int.MinValue;

        [Required]
        public decimal Salary { get; set; }

        public List<EmployeeDto> Employees { get; set; } 

    }
}
