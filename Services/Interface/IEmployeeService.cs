using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DataTransferObject;
using Domain.Entities;

namespace Services.Interface
{
    public interface IEmployeeService
    {
        public IEnumerable<EmpTasksDTO> GetTasks(int empid);

        public UpdateEmpTaskDTO UpdateTask(int empid, UpdateEmpTaskDTO uptedtask);
    }
}