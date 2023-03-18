using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObject
{
    public class DepertmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? MangerId { get; set; }
        public string? ManagerName { get; set; }
    }
}