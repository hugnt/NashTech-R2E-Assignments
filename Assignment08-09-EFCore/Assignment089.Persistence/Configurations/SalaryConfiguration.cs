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

public sealed class SalaryConfiguration : IEntityTypeConfiguration<Salary>
{
	public void Configure(EntityTypeBuilder<Salary> builder)
	{
		builder.ToTable(nameof(Salary));
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");

		builder
			.HasOne<Employee>(s => s.Employee).WithOne(e => e.Salary)
			.HasForeignKey<Salary>(e => e.EmployeeId);
	}
}
