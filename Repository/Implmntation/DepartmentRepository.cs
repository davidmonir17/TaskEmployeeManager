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
    public class DepartmentRepository : RepositoryBase<Depertment>, IDepartmentRepository
    {
        private readonly DataBaseContext _dbContext;

        public DepartmentRepository(DataBaseContext dataBase) : base(dataBase)
        {
            _dbContext = dataBase;
        }

        public void AddDepertment(Depertment depertment)
        {
            Add(depertment);
        }

        public void DeleteDepertment(Depertment depertment)
        {
            Remove(depertment);
        }

        public IEnumerable<Depertment> GetAllDepertment()
        {
            return GetAll().OrderBy(x => x.Id).ToList();
        }

        public Depertment GetDepertment(int id)
        {
            return Find(x => x.Id == id).Include(x => x.manger).OrderBy(x => x.Id).FirstOrDefault();
        }

        public void UpdateDepertment(Depertment department)
        {
            _dbContext.Entry(department).State = EntityState.Modified;
        }
    }
}