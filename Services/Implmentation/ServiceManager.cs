using AutoMapper;
using Domain.Entities;
using Domain.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
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
        private readonly Lazy<IAdminService> _adminService;
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<IEmailService> _mailService;

        public ServiceManager(IRepositoryManager repository, IMapper mapper, UserManager<ApplicationUser> userManager, IOptions<JWT> jwt)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, mapper));
            _ManagerService = new Lazy<IManagerService>(() => new ManagerService(repository, mapper));
            _adminService = new Lazy<IAdminService>(() => new AdminService(repository, mapper));
            _authService = new Lazy<IAuthService>(() => new AuthService(userManager, jwt));
            _mailService = new Lazy<IEmailService>(() => new EmailService("ejadatask@outlook.com", "a123456789A@"));
        }

        public IEmployeeService employeeService => _employeeService.Value;

        public IManagerService ManagerService => _ManagerService.Value;

        public IAdminService adminService => _adminService.Value;

        public IAuthService authService => _authService.Value;

        public IEmailService emailService => _mailService.Value;
    }
}