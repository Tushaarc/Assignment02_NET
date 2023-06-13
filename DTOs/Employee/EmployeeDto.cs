using EmpMngmntSys.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpMngmntSys.DTOs.Employee
{
    public class EmployeeDto
    {
        [Key]
        public int DId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; } = string.Empty;

        [Key]
        public int EId { get; set; }
        [Required]
        [MaxLength(30)]
        public string EmployeeName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100), MinLength(21)]
        public int Age { get; set; } = int.MinValue;

        [Required]
        public decimal Salary { get; set; }

    }
}
