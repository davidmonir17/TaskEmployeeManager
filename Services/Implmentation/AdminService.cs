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
    public class AdminService : IAdminService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AdminService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DepertmentDto addDepertment(AddDepDTo depDTo)
        {
            var depertment = _mapper.Map<Depertment>(depDTo);
            if (depertment.MangerId == 0)
            {
                depertment.MangerId = null;
            }
            _repository.departmentRepository.AddDepertment(depertment);
            _repository.save();
            var dep = _repository.departmentRepository.GetDepertment(depertment.Id);
            var depdto = _mapper.Map<DepertmentDto>(dep);
            return depdto;
        }

        public mgrEmpDto addMnager(addMngrDto manager)
        {
            var depertment = _repository.departmentRepository.GetDepertment(manager.depId);
            if (depertment != null && depertment.MangerId == null)
            {
                var mang = _mapper.Map<Employee>(manager);
                _repository.employeeRepository.AddEmployee(mang);
                _repository.save();
                depertment.MangerId = mang.Id;
                _repository.departmentRepository.UpdateDepertment(depertment);
                _repository.save();

                var Mnager = _repository.employeeRepository.GetEmployee(mang.Id);
                var MNagerDTo = _mapper.Map<mgrEmpDto>(Mnager);
                return MNagerDTo;
            }
            return null;
        }
    }
}