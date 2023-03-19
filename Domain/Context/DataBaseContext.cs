using Domain.Configration;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Context
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Depertment> Depertments { get; set; }
        public DbSet<Statues> Statues { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}