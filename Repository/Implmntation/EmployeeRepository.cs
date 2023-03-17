﻿using Domain.Context;
using Domain.Entities;
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

        public void AddEmployee(int DepId, Employee employee)
        {
            employee.depId = DepId;
            Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Remove(employee);
        }

        public IEnumerable<Employee> GetAllEmployees(int Depid)
        {
            return Find(x => x.depId == Depid).ToList();
        }

        public Employee GetEmployee(int DepId, int id)
        {
            return Find(x => x.depId == DepId && x.Id == id).FirstOrDefault();
        }

        public Employee GetEmployeeByid(int id)
        {
            return Find(x => x.Id == id).FirstOrDefault();
        }
    }
}