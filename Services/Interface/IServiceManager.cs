using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IServiceManager
    {
        public IEmployeeService employeeService { get; }
        public IManagerService ManagerService { get; }
        public IAdminService adminService { get; }
    }
}