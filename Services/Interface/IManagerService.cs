using Domain.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IManagerService
    {
        public mgrEmpDetailsDto addNewEmployee(int mgrId, mgrAddEmp employee);

        public IEnumerable<mgrEmpDto> GeteallEmps(int mgrId);

        public bool checkMangerDep(int mgr);

        public bool DeleteEmployee(int mgrId, int EmpId);

        public mgrEmpDto updateEmployee(int mgrId, mgrUpdEmpDto EmpDto);

        public MgrTaskDetials AddtaskToEmp(int mgrId, int empId, MgrAddTaskDto taskDto);

        public IEnumerable<MgrTaskDetials> GetAlltasks(int mgrId, int statues);

        public IEnumerable<MgrTaskDetials> GetAlltasksForEmp(int mgrId, int EmpId, int statues);

        public bool DeleteTaskForMgr(int MgrId, int TaskId);

        public MgrTaskDetials updateTask(int MgrId, MgrUpdTaskDto taskDto);

        public MgrTaskDetials ReAssignTask(int MgrId, int TaskId, int NewEmpId);

        public mgrEmpDto GetEmployee(int mgrId, int empid);
    }
}