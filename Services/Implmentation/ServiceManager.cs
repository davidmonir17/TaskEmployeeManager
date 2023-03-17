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

        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, mapper));
        }

        public IEmployeeService employeeService => _employeeService.Value;
    }
}