using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace Repository.Interface
{
    public interface ITaskRepository
    {
        void AddTask(Task task);

        void DeleteTask(Task task);

        Task GetTask(int id);

        IEnumerable<Task> GetAllTaskforMgr(int mgrId, int statues);

        IEnumerable<Task> GetAllTaskforEmp(int empid, int statues);
    }
}