using System.ComponentModel.DataAnnotations;

namespace EmpMngmntSys.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        [Key]
        public int DId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
