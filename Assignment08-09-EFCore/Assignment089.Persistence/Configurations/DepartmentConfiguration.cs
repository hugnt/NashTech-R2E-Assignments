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

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
	public void Configure(EntityTypeBuilder<Department> builder)
	{
		builder.ToTable(nameof(Department));
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name).IsRequired().HasMaxLength(50);


		builder.HasData(
			new Department
			{
				Id = Guid.Parse("3f8b2a1e-5c4d-4e9f-a2b3-7c8d9e0f1a2b"), 
				Name = "Software Development",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Department
			{
				Id = Guid.Parse("9a4c6e2d-8f3b-4d1a-b5c7-2e9f0a1b3c4d"),
				Name = "Finance",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Department
			{
				Id = Guid.Parse("1b2c3d4e-5f6a-4e8b-9c0d-7a8b9e0f1c2d"),
				Name = "Accountant",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Department
			{
				Id = Guid.Parse("6d7e8f9a-0b1c-4d2e-a3b4-5c6d7e8f9a0b"),
				Name = "HR",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			}
		);
	}
}
