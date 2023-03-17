using Domain.Configration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskConfig());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Depertment> Depertments { get; set; }
        public DbSet<Statues> Statues { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}