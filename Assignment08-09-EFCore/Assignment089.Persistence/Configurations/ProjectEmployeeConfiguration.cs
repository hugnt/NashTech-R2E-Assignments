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

public sealed class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
{
	public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
	{
		builder.ToTable(nameof(ProjectEmployee));
		builder.HasKey(x => new { x.ProjectId,x.EmployeeId});

		builder
			.HasOne<Project>(pe => pe.Project).WithMany(p => p.ProjectEmployees)
			.HasForeignKey(pe => pe.ProjectId);

		builder
			.HasOne<Employee>(pe => pe.Employee).WithMany(e => e.ProjectEmployees)
			.HasForeignKey(pe => pe.EmployeeId);
	}
}
