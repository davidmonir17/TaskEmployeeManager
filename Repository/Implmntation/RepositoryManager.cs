using Domain.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implmntation
{
    public class RepositoryManager : IRepositoryManager
    {
        private DataBaseContext _context;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private IStatuesRepository _statuesRepository;
        private ITaskRepository _taskRepository;

        public RepositoryManager(DataBaseContext context)
        {
            _context = context;
        }

        public IDepartmentRepository departmentRepository
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_context);
                return _departmentRepository;
            }
        }

        public IEmployeeRepository employeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_context);
                return _employeeRepository;
            }
        }

        public IStatuesRepository statuesRepository
        {
            get
            {
                if (_statuesRepository == null)
                    _statuesRepository = new StatuesRepository(_context);
                return _statuesRepository;
            }
        }

        public ITaskRepository taskRepository
        {
            get
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(_context);
                return _taskRepository;
            }
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}