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
    }
}