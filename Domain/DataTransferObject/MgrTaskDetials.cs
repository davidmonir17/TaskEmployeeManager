using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObject
{
    public class MgrTaskDetials
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string description { get; set; }

        public DateTime SubmitionDate { get; set; }

        public int statuesId { get; set; }

        public string statues { get; set; }
        public int MangerId { get; set; }
        public string ManagerName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}