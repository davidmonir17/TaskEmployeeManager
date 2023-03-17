using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDepartmentRepository
    {
        void AddDepertment(Depertment depertment);

        void DeleteDepertment(Depertment depertment);

        Depertment GetDepertment(int id);

        IEnumerable<Depertment> GetAllDepertment();
    }
}