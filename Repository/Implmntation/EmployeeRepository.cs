﻿using Domain.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implmntation
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataBaseContext dataBase) : base(dataBase)
        {
        }

        public void AddEmployee(Employee employee)
        {
            Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Remove(employee);
        }

        public IEnumerable<Employee> GetAllEmployees(int Depid)
        {
            return Find(x => x.depId == Depid).Include(x => x.depertment).ToList();
        }

        public IEnumerable<Employee> GetAllEmployeesExceptMgr(int Depid, int mgrId)
        {
            return Find(x => x.depId == Depid && x.Id != mgrId).Include(x => x.depertment).ToList();
        }

        public Employee GetEmployee(int id)
        {
            return Find(x => x.Id == id).Include(x => x.depertment).FirstOrDefault();
        }

        public Employee GetEmployeeForAuth(string email)
        {
            return Find(x => x.Email == email).FirstOrDefault();
        }
    }
}