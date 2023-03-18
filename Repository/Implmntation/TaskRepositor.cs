using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implmntation
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        //private DataBaseContext dbcontext;
        public TaskRepository(DataBaseContext dataBase) : base(dataBase)
        {
            //dbcontext = dataBase;
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
                return Find(x => x.EmployeeId == empid && x.statuesId != 3).Include(x => x.manger).Include(x => x.statues).OrderBy(x => x.SubmitionDate).ToList();
            }
            return Find(x => x.EmployeeId == empid && x.statuesId == statues).Include(x => x.manger).Include(x => x.statues).OrderBy(x => x.SubmitionDate).ToList();
        }

        public IEnumerable<Task> GetAllTaskforMgr(int mgrId, int statues)
        {
            if (statues == 0)
            {
                return Find(x => x.MangerId == mgrId).Include(x => x.manger).Include(x => x.statues).Include(x => x.employee).OrderBy(x => x.SubmitionDate).ToList();
            }
            return Find(x => x.MangerId == mgrId && x.statuesId == statues).Include(x => x.manger).Include(x => x.statues).Include(x => x.employee).OrderBy(x => x.SubmitionDate).ToList();
        }

        public IEnumerable<Task> GetAllTaskforMgrtoEmp(int mgrId, int Empid, int statues)
        {
            if (statues == 0)
            {
                return Find(x => x.MangerId == mgrId && x.EmployeeId == Empid).Include(x => x.manger).Include(x => x.statues).Include(x => x.employee).OrderBy(x => x.SubmitionDate).ToList();
            }
            return Find(x => x.MangerId == mgrId && x.EmployeeId == Empid && x.statuesId == statues).Include(x => x.manger).Include(x => x.statues).Include(x => x.employee).OrderBy(x => x.SubmitionDate).ToList();
        }

        public Task GetTask(int id)
        {
            //return dbcontext.Tasks.Where(x => x.Id == id).FirstOrDefault();
            return Find(x => x.Id == id).Include(x => x.manger).Include(x => x.statues).Include(x => x.employee).FirstOrDefault();
        }
    }
}