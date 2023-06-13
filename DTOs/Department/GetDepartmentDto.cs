using System.ComponentModel.DataAnnotations;

namespace EmpMngmntSys.DTOs.Department
{
    public class GetDepartmentDto
    {
        [Key]
        public int DId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
