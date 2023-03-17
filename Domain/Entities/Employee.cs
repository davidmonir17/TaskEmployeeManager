using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required field")]
        [MaxLength(60, ErrorMessage = "name Field not Exceded 60 char")]
        public string Name { get; set; }

        [MaxLength(11, ErrorMessage = "Phone Field not Exceded 11 Number")]
        public int Phone { get; set; }

        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Email is required field")]
        [MaxLength(60, ErrorMessage = "Email Field not Exceded 60 char")]
        public string Email { get; set; }

        [ForeignKey(nameof(depertment))]
        [Required]
        public int depId { get; set; }

        public Depertment depertment { get; set; }

        public IEnumerable<Task> EmployeeTasks { get; set; }
        public IEnumerable<Task> ManagerTasks { get; set; }
    }
}