using AutoMapper;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implmentation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IManagerService> _ManagerService;

        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, mapper));
            _ManagerService = new Lazy<IManagerService>(() => new ManagerService(repository, mapper));
        }

        public IEmployeeService employeeService => _employeeService.Value;

        public IManagerService ManagerService => _ManagerService.Value;
    }
}