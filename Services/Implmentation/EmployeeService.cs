using AutoMapper;
using Domain.DataTransferObject;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implmentation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<EmpTasksDTO> GetTasks(int empid)
        {
            if (empid != 0)
            {
                var emp = _repository.employeeRepository.GetEmployee(empid);
                if (emp != null)
                {
                    var tasks = _repository.taskRepository.GetAllTaskforEmp(empid, 0);
                    var TsksDTO = _mapper.Map<List<EmpTasksDTO>>(tasks);
                    return TsksDTO;
                }
            }
            return null;
        }

        public EmpTasksDTO UpdateTask(int empid, UpdateEmpTaskDTO uptedtask)
        {
            if (empid != 0)
            {
                var emp = _repository.employeeRepository.GetEmployee(empid);
                if (emp != null)
                {
                    var task = _repository.taskRepository.GetTask(uptedtask.Id);
                    _mapper.Map(uptedtask, task);
                    _repository.save();
                    var taskget = _repository.taskRepository.GetTask(uptedtask.Id);
                    var TsksDTO = _mapper.Map<EmpTasksDTO>(taskget);
                    return TsksDTO;
                }
            }
            return null;
        }
    }
}