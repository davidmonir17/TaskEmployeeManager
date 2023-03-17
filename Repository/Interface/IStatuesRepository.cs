using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IStatuesRepository
    {
        void AddStatues(Statues statues);

        Statues GetStatues(int id);

        IEnumerable<Statues> GetAllStatues();
    }
}