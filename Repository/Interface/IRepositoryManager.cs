using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepositoryManager
    {
        IStatuesRepository statuesRepository { get; }
        IDepartmentRepository departmentRepository { get; }
        IEmployeeRepository employeeRepository { get; }
        ITaskRepository taskRepository { get; }

        void save();
    }
}