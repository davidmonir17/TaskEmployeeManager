using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Depertment>
    {
        public void Configure(EntityTypeBuilder<Depertment> builder)
        {
            builder.HasMany(d => d.Employees)
                .WithOne(e => e.depertment)
                .HasForeignKey(e => e.depId)
                .IsRequired();

            builder.HasOne(d => d.manger)
                .WithMany()
                .HasForeignKey(d => d.MangerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}