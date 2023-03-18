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
        public void AddEmployee(Employee employee);

        public void DeleteEmployee(Employee employee);

        public IEnumerable<Employee> GetAllEmployees(int Depid);

        public IEnumerable<Employee> GetAllEmployeesExceptMgr(int Depid, int mgrId);

        public Employee GetEmployee(int id);
    }
}