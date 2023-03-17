using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Context;
using Domain.Entities;
using Repository.Interface;

namespace Repository.Implmntation
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(DataBaseContext dataBase) : base(dataBase)
        {
        }

        public void AddTask(Task task)
        {
            Add(task);
        }

        public void DeleteTask(Task task)
        {
            Remove(task);
        }

        public IEnumerable<Task> GetAllTaskforEmp(int empid, int statues)
        {
            if (statues == 0)
            {
                return Find(x => x.EmployeeId == empid && x.statuesId != 3).OrderBy(x => x.SubmitionDate).ToList();
            }
            return Find(x => x.EmployeeId == empid && x.statuesId == statues).OrderBy(x => x.SubmitionDate).ToList();
        }

        public IEnumerable<Task> GetAllTaskforMgr(int mgrId, int statues)
        {
            if (statues == 0)
            {
                return Find(x => x.MangerId == mgrId).OrderBy(x => x.SubmitionDate).ToList();
            }
            return Find(x => x.MangerId == mgrId && x.statuesId == statues).OrderBy(x => x.SubmitionDate).ToList();
        }

        public Task GetDepertment(int id)
        {
            return Find(x => x.Id == id).FirstOrDefault();
        }
    }
}