using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configration
{
    public class TaskConfig : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasOne(m => m.employee)
                .WithMany(t => t.EmployeeTasks)
                .HasForeignKey(m => m.EmployeeId)
                .IsRequired(true)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.manger)
                .WithMany(t => t.ManagerTasks)
                .HasForeignKey(m => m.MangerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}