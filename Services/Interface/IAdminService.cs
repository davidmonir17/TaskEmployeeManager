using Domain.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAdminService
    {
        public DepertmentDto addDepertment(AddDepDTo depDTo);

        public mgrEmpDto addMnager(addMngrDto manager);
    }
}