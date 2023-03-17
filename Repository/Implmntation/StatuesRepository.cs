using Domain.Context;
using Domain.Entities;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implmntation
{
    public class StatuesRepository : RepositoryBase<Statues>, IStatuesRepository
    {
        public StatuesRepository(DataBaseContext dataBase) : base(dataBase)
        {
        }

        public void AddStatues(Statues statues)
        {
            Add(statues);
        }

        public IEnumerable<Statues> GetAllStatues()
        {
            return GetAll().OrderBy(x => x.Id).ToList();
        }

        public Statues GetStatues(int id)
        {
            return Find(x => x.Id == id).FirstOrDefault();
        }
    }
}