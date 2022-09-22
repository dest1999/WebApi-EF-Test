using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi_EF_Test.Models
{
    public class EmployeeDTO
    {
        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [StringLength(50)]
        public string? JobRole { get; set; }

        public static implicit operator Employee(EmployeeDTO employeeDTO) 
        {
            return new Employee
            {
                FIO = employeeDTO.FIO,
                JobRole = employeeDTO.JobRole,
                Id = 0
            };
        }
    }
}
