using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepositoryManager
    {
        IDepartmentRepository departmentRepository { get; }
        IEmployeeRepository employeeRepository { get; }

        void save();
    }
}