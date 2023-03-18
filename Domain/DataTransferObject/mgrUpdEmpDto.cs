using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObject
{
    public class mgrUpdEmpDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required field")]
        public string Name { get; set; }

        public int Phone { get; set; }
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Email is required field")]
        public string Email { get; set; }

        [Required(ErrorMessage = "depId is required field")]
        public int depId { get; set; }
    }
}