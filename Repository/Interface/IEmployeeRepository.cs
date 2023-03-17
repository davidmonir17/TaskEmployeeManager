using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(int DepId, Employee employee);

        public void DeleteEmployee(Employee employee);

        public IEnumerable<Employee> GetAllEmployees(int Depid);

        public Employee GetEmployee(int DepId, int id);
    }
}