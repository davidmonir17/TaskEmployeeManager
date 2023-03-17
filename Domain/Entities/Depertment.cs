using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Depertment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required field")]
        [MaxLength(60, ErrorMessage = "name Field not Exceded 60 char")]
        public string Name { get; set; }

        public int? MangerId { get; set; }
        public Employee manger { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}