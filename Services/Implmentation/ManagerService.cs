using AutoMapper;
using Domain.DataTransferObject;
using Domain.Entities;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implmentation
{
    public class ManagerService : IManagerService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ManagerService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public mgrEmpDetailsDto addNewEmployee(int mgrId, mgrAddEmp employee)
        {
            var manager = _repository.employeeRepository.GetEmployee(mgrId);
            if (manager != null)
            {
                var emp = _mapper.Map<Employee>(employee);
                emp.depId = manager.depId;
                _repository.employeeRepository.AddEmployee(emp);
                _repository.save();
                var empDetail = _mapper.Map<mgrEmpDetailsDto>(emp);
                return empDetail;
            }
            return null;
        }

        public MgrTaskDetials AddtaskToEmp(int mgrId, int empId, MgrAddTaskDto taskDto)
        {
            var manager = _repository.employeeRepository.GetEmployee(mgrId);
            var employee = _repository.employeeRepository.GetEmployee(empId);
            if (manager != null && employee != null && manager.depId == employee.depId)
            {
                var asigntask = _mapper.Map<Task>(taskDto);
                asigntask.MangerId = manager.Id;
                asigntask.EmployeeId = employee.Id;
                _repository.taskRepository.AddTask(asigntask);
                _repository.save();
                var taskAssigned = _repository.taskRepository.GetTask(asigntask.Id);
                var task = _mapper.Map<MgrTaskDetials>(taskAssigned);
                return task;
            }
            return null;
        }

        public bool checkMangerDep(int mgr)
        {
            var manager = _repository.employeeRepository.GetEmployee(mgr);
            if (manager != null)
            {
                var dep = _repository.departmentRepository.GetDepertment(manager.depId);
                if (dep.MangerId == mgr)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteEmployee(int mgrId, int EmpId)
        {
            var manager = _repository.employeeRepository.GetEmployee(mgrId);
            var employee = _repository.employeeRepository.GetEmployee(EmpId);
            if (manager != null && employee != null && manager.depId == employee.depId)
            {
                _repository.employeeRepository.DeleteEmployee(employee);
                _repository.save();
                return true;
            }
            return false;
        }

        public IEnumerable<mgrEmpDto> GeteallEmps(int mgrId)
        {
            var manager = _repository.employeeRepository.GetEmployee(mgrId);
            if (manager != null)
            {
                var emps = _repository.employeeRepository.GetAllEmployeesExceptMgr(manager.depId, mgrId);
                var ListEmps = _mapper.Map<List<mgrEmpDto>>(emps);
                return ListEmps;
            }
            return null;
        }

        public mgrEmpDto updateEmployee(int mgrId, mgrUpdEmpDto EmpDto)
        {
            var manager = _repository.employeeRepository.GetEmployee(mgrId);
            var employee = _repository.employeeRepository.GetEmployee(EmpDto.Id);
            if (manager != null)
            {
                _mapper.Map(EmpDto, employee);
                _repository.save();
                var emp = _repository.employeeRepository.GetEmployee(EmpDto.Id);
                var mgeEmp = _mapper.Map<mgrEmpDto>(emp);
                return mgeEmp;
            }
            return null;
        }
    }
}