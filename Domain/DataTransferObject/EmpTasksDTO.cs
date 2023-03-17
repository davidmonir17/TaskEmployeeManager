using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObject
{
    public class EmpTasksDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required field")]
        [MaxLength(60, ErrorMessage = "name Field not Exceded 60 char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "description is required field")]
        [MaxLength(120, ErrorMessage = "discreption Field not Exceded 60 char")]
        public string description { get; set; }

        [Required]
        public DateTime SubmitionDate { get; set; }

        public string statuesName { get; set; }

        public string MangerName { get; set; }
    }
}