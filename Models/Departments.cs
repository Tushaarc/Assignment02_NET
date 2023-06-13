using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpMngmntSys.Models
{
    public class Departments
    {
        [Key]
        public int DId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; } = string.Empty;

        //Department model contains Id, Department Name(Max 50 char limit).
        //(Need to create a foreign key relation in Employee model for department)

    }
}

