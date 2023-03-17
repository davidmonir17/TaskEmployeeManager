using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required field")]
        [MaxLength(60, ErrorMessage = "name Field not Exceded 60 char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "description is required field")]
        [MaxLength(120, ErrorMessage = "discreption Field not Exceded 60 char")]
        public string description { get; set; }

        [Required]
        public DateTime SubmitionDate { get; set; }

        [ForeignKey(nameof(statues))]
        [Required]
        public int statuesId { get; set; }

        public Statues statues { get; set; }
        public int MangerId { get; set; }
        public int EmployeeId { get; set; }

        public Employee employee { get; set; }
        public Employee manger { get; set; }
    }
}