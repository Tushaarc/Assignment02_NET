using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpMngmntSys.Models
{
    public class Employees
    {
        [Key]
        public int EId { get; set; }
        [Required]
        [MaxLength(30)]
        public string EmployeeName { get; set; } = string.Empty;

        [Required]
        [Range(21,100)]
        public int Age { get; set; } = int.MinValue;

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int DId { get; set; }

        //[ForeignKey("DId")]
        //public virtual Departments? departments { get; set; }

    }
}
