using AutoMapper;
using Domain.DataTransferObject;
using Domain.Entities;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}