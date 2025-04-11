using Assignment089.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Persistence.Configurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable(nameof(Employee));
		builder.HasKey(x => x.Id);

		builder
			.Property(x => x.Name).IsRequired().HasMaxLength(50);
 
		builder
			.HasOne<Department>(e => e.Department).WithMany(d=>d.Employees)
			.HasForeignKey(e => e.DepartmentId)
			.OnDelete(DeleteBehavior.Cascade);


	}
}
